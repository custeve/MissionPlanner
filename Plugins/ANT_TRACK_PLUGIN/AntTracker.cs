using MissionPlanner.Comms;
using MissionPlanner.Utilities;
using Pololu.UsbWrapper;
using Pololu.Usc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Community.CsharpSqlite.Sqlite3.WhereLevel._u;


namespace MissionPlanner.Controls
{
    public partial class AntTracker : UserControl
    {

        const int SERVO_MIN = 3500;
        const int SERVO_RANGE = 5000; 

        static AntTracker Instance;
        static TcpListener listener;
        static SerialPort comPort = null; // new SerialPort();
        private double gcs_ac_az;
        private double gcs_ac_el;
        private int last_az;
        private int last_el;
        private int last_com_cnt = 0; 
        Usc device = null;

        static internal PointLatLngAlt lastgotolocation = new PointLatLngAlt(0, 0, 0, "Goto last");
        static internal PointLatLngAlt gotolocation = new PointLatLngAlt(0, 0, 0, "0.0");

        public AntTracker()
        {
            InitializeComponent();

            Instance = this;

            try
            {
                CMB_serialport.Items.AddRange(SerialPort.GetPortNames());
 


                CMB_baudrate.Text = "9600";

                

            }
            catch
            {
                Console.WriteLine("Couldn't Init Ant Tracker Form.");
            }
            
            timer1.Start();


        }

        private void BUT_connect_Click(object sender, EventArgs e)
        {
           

            if (comPort != null && comPort.IsOpen)
            {
               
                comPort.Close();
                BUT_connect.Text = Strings.Connect;
            }
            else
            {
                try
                {

                    comPort = new SerialPort();
                    comPort.PortName = CMB_serialport.Text;

                }
                catch
                {
                    CustomMessageBox.Show(Strings.InvalidPortName);
                    return;
                }
                try
                {
                    comPort.BaudRate = int.Parse(CMB_baudrate.Text);
                }
                catch
                {
                    CustomMessageBox.Show(Strings.InvalidBaudRate, Strings.ERROR);
                    return;
                }
                try
                {
                    if (listener == null)
                        comPort.Open();
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Show(Strings.ErrorConnecting + "\n" + ex.ToString(), Strings.ERROR);
                    return;
                }
                TXT_rot_position.Text = "Connected!"; 
                BUT_connect.Text = Strings.Stop;
            }
        }

        Usc connectToDevice()
        {
            // Get a list of all connected devices of this type.
            List<DeviceListItem> connectedDevices = Usc.getConnectedDevices();

            foreach (DeviceListItem dli in connectedDevices)
            {
                // If you have multiple devices connected and want to select a particular
                // device by serial number, you could simply add a line like this:
                //   if (dli.serialNumber != "00012345"){ continue; }

                Usc device = new Usc(dli); // Connect to the device.
                return device;             // Return the device.
            }
            throw new Exception("Could not find device.  Make sure it is plugged in to USB " +
                "and check your Device Manager (Windows) or run lsusb (Linux).");
        }

        private void but_usc_connect_Click(object sender, EventArgs e)
        {
            if (device == null)
            {
                device = connectToDevice(); 
            }

            if (device.getSerialNumber() != null)
            {
                txt_status.Text = "Connected to: " + device.getSerialNumber();
                but_usc_connect.Text = "Disconnect";
            }


        }

        private void DisplayPosition()
        {
            try
            {
                ServoStatus[] servos;
                device.getVariables(out servos);

                txt_ch0.Text = servos[0].position.ToString();
                txt_ch1.Text = servos[1].position.ToString();
            } catch
            {
                Console.WriteLine("MAESTRO: Error Getting Servo Positions.");
            }


        }

        private void DisplayACGCS()
        {
            TXT_AC_position.Text = MainV2.comPort.MAV.cs.Location.ToString();
            TXT_GCS_position.Text = MainV2.comPort.MAV.cs.Base.ToString();
            TXT_AZ_MAV.Text = Math.Round(gcs_ac_az, 2).ToString();
            TXT_EL_MAV.Text = Math.Round(gcs_ac_el, 2).ToString();
            
        }

        private void set_COM_Rot(int az, int el)
        {
            if (az == last_az && el == last_el && last_com_cnt < 5)
            {
                last_com_cnt++; 
                return;
            }

            last_com_cnt = 0;

            last_az = az;
            last_el = el;

            if (comPort != null && comPort.IsOpen)
            {
                comPort.Write("[MOVE,1," + last_az.ToString() + "," + last_el.ToString() + "]\n\r");
            }
        }

        private void setAZ(double az_in)
        {
            az_in = Math.Max(0.0, Math.Min(360.0, az_in));
            try
            {
                if (device != null && device.getSerialNumber() != null)
                {
                    
                    device.setTarget(0, (ushort)(((az_in / 360.0) * SERVO_RANGE) + SERVO_MIN));
                }
            }
            catch { }

            set_COM_Rot((int) az_in, last_el);

            

            //try
            //{
            //    if (comPort != null && comPort.IsOpen)
            //    {
            //        comPort.Write("[MOVE,2," + az_in.ToString() + "]\n\r");
            //    }
            //}
            //catch { }

        }

        private void setEL(double el_in)
        {
            el_in = Math.Max(0.0, Math.Min(90.0, el_in));
            try
            {
                if (device != null && device.getSerialNumber() != null)
                {
                    
                    device.setTarget(1, (ushort)(((el_in / 90.0) * SERVO_RANGE) + SERVO_MIN));
                }
            } 
            catch { }

            set_COM_Rot(last_az, (int) el_in);

            //try
            //{
            //    if (comPort != null && comPort.IsOpen)
            //    {
            //        comPort.Write("[MOVE,3," + el_in.ToString() + "]\n\r");
            //    }
            //}
            //catch { }
        }

        private void readRotator()
        {
            try // Process Comport Data
            {
                if (comPort != null && comPort.IsOpen)
                {

                    while (comPort.BytesToRead > 0)
                    {
                        string line = comPort.ReadLine();
                        //Console.WriteLine(line); // for debug
                        lbl_rot_recv.Text = line;

                        try
                        {
                            string[] items = line.Trim().Split(',');
                            TXT_rot_position.Text = "AZ: " + items[2] + " ( " + items[4] + ")     EL: " + items[3] + " (" + items[5] + ")";
                        }
                        catch
                        {
                            TXT_rot_position.Text = "Unknown!";
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }



        private void timer1_Tick(object sender, EventArgs e)
        {

            try
            {
                if (device != null && device.getSerialNumber() != null)
                {
                    DisplayPosition();
                    txt_status.Text = "Position Updated from:  " + device.getSerialNumber();
                }
                else
                {
                    txt_status.Text = "Not Connected";
                }
            } catch
            {
                txt_status.Text = "Error";
                //Console.WriteLine("MAESTRO: real-time exception");
            }

            try
            {
                if (comPort != null && comPort.IsOpen)
                {
                    readRotator();
                }
            }
            catch (Exception ex)
            {

            }
            

            gcs_ac_az = MainV2.comPort.MAV.cs.Base.GetBearing(MainV2.comPort.MAV.cs.Location);

            double ac_dist = MainV2.comPort.MAV.cs.Base.GetDistance(MainV2.comPort.MAV.cs.Location);
            if (ac_dist > 50.0)
            {
                gcs_ac_el = Math.Atan2(MainV2.comPort.MAV.cs.alt, ac_dist)*180.0/Math.PI;
            } else
            { 
                gcs_ac_el = 0.0; 
            }
            DisplayACGCS();
            if (cb_auto.Checked)
            {
                setAZ(gcs_ac_az);
                setEL(gcs_ac_el);
            }


            but_az_0.Enabled = !(cb_auto.Checked);
            but_el_0.Enabled = !(cb_auto.Checked);
            but_az_max.Enabled = !(cb_auto.Checked);
            but_el_90.Enabled = !(cb_auto.Checked);

        }

        private void but_az_0_Click(object sender, EventArgs e)
        {
            setAZ(0);
        }

        private void but_el_0_Click(object sender, EventArgs e)
        {
            setEL(0);
        }

        private void but_az_max_Click(object sender, EventArgs e)
        {
            setAZ(360.0);
        }

        private void but_el_90_Click(object sender, EventArgs e)
        {
            setEL(90.0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            setAZ(180.0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            setEL(45.0);
        }

        private void BUT_stop_rot_Click(object sender, EventArgs e)
        {

            try
            {
                if (comPort != null && comPort.IsOpen)
                {
                    comPort.Write("[STOP]\n\r");
                }
            }
            catch { }
        }

        private void BUT_park_rot_Click(object sender, EventArgs e)
        {
            try
            {
                if (comPort != null && comPort.IsOpen)
                {
                    comPort.Write("[PARK]\n\r");
                }
            }
            catch { }
        }

        private void USE_MC_Click(object sender, EventArgs e)
        {
            // Use this function to override the GCS location to the map cetner. 
            lastgotolocation = gotolocation;
            gotolocation = MissionPlanner.GCSViews.FlightData.mymap.Position;
            gotolocation.Tag2 = "0.0";


            Console.WriteLine("Use Map Center Clicked: " + gotolocation.ToString());

            MainV2.comPort.MAV.cs.Base = gotolocation;
            MainV2.comPort.MAV.cs.Base.Tag = gotolocation.Tag;
            Console.WriteLine("Moving Base updated to: " + MainV2.comPort.MAV.cs.Base.ToString());
        }


    }
}
