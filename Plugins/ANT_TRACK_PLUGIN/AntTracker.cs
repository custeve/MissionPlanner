using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using System.Net.Sockets;
using MissionPlanner.Comms;
using MissionPlanner.Utilities;
using Pololu.Usc;
using Pololu.UsbWrapper;


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
           

            if (comPort.IsOpen)
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
            TXT_GCS_position.Text = MainV2.comPort.MAV.cs.MovingBase.ToString();
            TXT_AZ_MAV.Text = Math.Round(gcs_ac_az, 2).ToString();
            TXT_EL_MAV.Text = Math.Round(gcs_ac_el, 2).ToString();
            
        }

        private void setAZ(double az_in)
        {
            az_in = Math.Max(0.0,Math.Min(360.0, az_in));
            device.setTarget(0,  (ushort) (((az_in / 360.0) * SERVO_RANGE) + SERVO_MIN ));
        }

        private void setEL(double el_in)
        {
            el_in = Math.Max(0.0, Math.Min(360.0, el_in));
            device.setTarget(1, (ushort)(((el_in / 90.0) * SERVO_RANGE) + SERVO_MIN));
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

            gcs_ac_az = MainV2.comPort.MAV.cs.MovingBase.GetBearing(MainV2.comPort.MAV.cs.Location);

            double ac_dist = MainV2.comPort.MAV.cs.MovingBase.GetDistance(MainV2.comPort.MAV.cs.Location);
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

        private void USE_MC_Click(object sender, EventArgs e)
        {
            // Use this function to override the GCS location to the map cetner. 
            lastgotolocation = gotolocation;
            gotolocation = MissionPlanner.GCSViews.FlightData.mymap.Position;
            gotolocation.Tag2 = "0.0";


            Console.WriteLine("Use Map Center Clicked: " + gotolocation.ToString());

            MainV2.comPort.MAV.cs.MovingBase = gotolocation;
            MainV2.comPort.MAV.cs.MovingBase.Tag = gotolocation.Tag;
            Console.WriteLine("Moving Base updated to: " + MainV2.comPort.MAV.cs.MovingBase.ToString());
        }
    }
}
