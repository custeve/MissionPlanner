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


namespace MissionPlanner.Controls
{
    public partial class IRISS_moving_gcs : UserControl
    {

        static IRISS_moving_gcs Instance;
        static TcpListener listener;
        static ICommsSerial comPort = null; // new SerialPort();
        static internal PointLatLngAlt lastgotolocation = new PointLatLngAlt(0, 0, 0, "Goto last");
        static internal PointLatLngAlt gotolocation = new PointLatLngAlt(0, 0, 0, "0.0");
        static internal string gps_sats;
        static internal int intalt = 100;

        static bool has_gps_course = false;

        static internal double updaterate = 0.5;

        static bool updaterallypnt = false;
        //StreamWriter sw = new StreamWriter(Settings.GetUserDataDirectory() + "MovingBase.txt");

        public IRISS_moving_gcs()
        {

            InitializeComponent();

            Instance = this;



            try
            {
                CMB_serialport.Items.AddRange(SerialPort.GetPortNames());
                CMB_serialport.Items.Add("TCP Host - 14551");
                CMB_serialport.Items.Add("TCP Client");
                CMB_serialport.Items.Add("UDP Host - 14551");
                CMB_serialport.Items.Add("UDP Client");


                CMB_baudrate.Text = "4800";
                CMB_updaterate.Text = "0.5hz";

                CMB_updaterate.SelectedItem = "0.5Hz";

                CHK_updateRallyPnt.Checked = updaterallypnt;
            } catch
            {
                Console.WriteLine("Couldn't Init Moving Base Form.");
            }

        }

        private void BUT_connect_Click(object sender, EventArgs e)
        {
            comPort = new SerialPort();

            if (comPort.IsOpen)
            {
                comPort.Close();
                BUT_connect.Text = Strings.Connect;
            }
            else
            {
                try
                {
                    switch (CMB_serialport.Text)
                    {
                        case "TCP Host - 14551":
                        case "TCP Host":
                            comPort = new TcpSerial();
                            CMB_baudrate.SelectedIndex = 0;
                            listener = new TcpListener(System.Net.IPAddress.Any, 14551);
                            listener.Start(0);
                            listener.BeginAcceptTcpClient(new AsyncCallback(DoAcceptTcpClientCallback), listener);
                            BUT_connect.Text = Strings.Stop;
                            break;
                        case "TCP Client":
                            comPort = new TcpSerial() { retrys = 999999, autoReconnect = true };
                            CMB_baudrate.SelectedIndex = 0;
                            break;
                        case "UDP Host - 14551":
                            comPort = new UdpSerial();
                            CMB_baudrate.SelectedIndex = 0;
                            break;
                        case "UDP Client":
                            comPort = new UdpSerialConnect();
                            CMB_baudrate.SelectedIndex = 0;
                            break;
                        default:
                            comPort = new SerialPort();
                            comPort.PortName = CMB_serialport.Text;
                            break;
                    }
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

                timer1.Start();

                BUT_connect.Text = Strings.Stop;
            }
        }

        void DoAcceptTcpClientCallback(IAsyncResult ar)
        {
            // Get the listener that handles the client request.
            TcpListener listener = (TcpListener)ar.AsyncState;

            try
            {
                // End the operation and display the received data on  
                // the console.
                TcpClient client = listener.EndAcceptTcpClient(ar);

                ((TcpSerial)comPort).client = client;

                listener.BeginAcceptTcpClient(new AsyncCallback(DoAcceptTcpClientCallback), listener);
            }
            catch { }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime nextsend = DateTime.Now;

            DateTime nextrallypntupdate = DateTime.Now;
            try
            {
                while (comPort.BytesToRead > 0)
                {
                    string line = comPort.ReadLine();
                    TXT_gps_out.Text = line;
                    //sw.WriteLine(line);

                    //string line = string.Format("$GP{0},{1:HHmmss},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},", "GGA", DateTime.Now.ToUniversalTime(), Math.Abs(lat * 100), MainV2.comPort.MAV.cs.lat < 0 ? "S" : "N", Math.Abs(lng * 100), MainV2.comPort.MAV.cs.lng < 0 ? "W" : "E", MainV2.comPort.MAV.cs.gpsstatus, MainV2.comPort.MAV.cs.satcount, MainV2.comPort.MAV.cs.gpshdop, MainV2.comPort.MAV.cs.alt, "M", 0, "M", "");
                    if (line.StartsWith("$GPGGA") || line.StartsWith("$GNGGA")) // 
                    {
                        string[] items = line.Trim().Split(',', '*');

                        if (items[items.Length - 1] != GetChecksum(line.Trim()))
                        {
                            Console.WriteLine("Bad Nmea line " + items[15] + " vs " + GetChecksum(line.Trim()));
                            return;
                        }

                        if (items[6] == "0")
                        {
                            Console.WriteLine("No Fix");
                            return;
                        }

                        gotolocation.Lat = double.Parse(items[2], CultureInfo.InvariantCulture) / 100.0;

                        gotolocation.Lat = (int)gotolocation.Lat + ((gotolocation.Lat - (int)gotolocation.Lat) / 0.60);

                        if (items[3] == "S")
                            gotolocation.Lat *= -1;

                        gotolocation.Lng = double.Parse(items[4], CultureInfo.InvariantCulture) / 100.0;

                        gotolocation.Lng = (int)gotolocation.Lng + ((gotolocation.Lng - (int)gotolocation.Lng) / 0.60);

                        if (items[5] == "W")
                            gotolocation.Lng *= -1;

                        gotolocation.Alt = double.Parse(items[9], CultureInfo.InvariantCulture);

                        gps_sats = "Sats " + items[7] + " hdop " + items[8];
                    }
                    if (cb_use_course.Checked)
                    {
                        if (line.StartsWith("$GPRMC") || line.StartsWith("$GNRMC"))
                        {
                            string[] items = line.Trim().Split(',', '*');
                            if (items[2] == "A")
                            {
                                if (!has_gps_course && float.Parse(items[7]) > 10.0)
                                {
                                    has_gps_course = true;
                                    num_no_gps_hdg.Enabled = false;
                                }

                                if (has_gps_course && float.Parse(items[7]) > 5.0)
                                    gotolocation.Tag = Math.Round(float.Parse(items[8]), 1).ToString(); ; // Course

                                gotolocation.Tag2 = Math.Round((float.Parse(items[7]) * 0.514444), 1).ToString();  // Speed
                            }
                        }
                    }

                    if (!cb_use_course.Checked || !has_gps_course)
                    {
                        num_no_gps_hdg.Enabled = true;
                        gotolocation.Tag = num_no_gps_hdg.Value.ToString(); // Course
                        gotolocation.Tag2 = "0.0";  // Speed
                        has_gps_course = false;
                    }


                    if (DateTime.Now > nextsend && gotolocation.Lat != 0 && gotolocation.Lng != 0) // 200 * 10 = 2 sec /// lastgotolocation != gotolocation && 
                    {
                        nextsend = DateTime.Now.AddMilliseconds(1000 / updaterate);
                        Console.WriteLine("new home wp " + DateTime.Now.ToString("h:MM:ss") + " " + gotolocation.Lat +
                                          " " + gotolocation.Lng + " " + gotolocation.Alt);
                        lastgotolocation = new PointLatLngAlt(gotolocation);



                        try
                        {
                            updateLocationLabel();
                        }
                        catch
                        {
                        }

                        MainV2.comPort.MAV.cs.Base = gotolocation;

                        MainV2.comPort.MAV.cs.HomeLocation = gotolocation;

                        // plane only
                        if (updaterallypnt && DateTime.Now > nextrallypntupdate)
                        {
                            nextrallypntupdate = DateTime.Now.AddSeconds(5);
                            try
                            {
                                MainV2.comPort.setParam((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent, "RALLY_TOTAL", 1);

                                MainV2.comPort.setRallyPoint(0,
                                    new PointLatLngAlt(gotolocation)
                                    {
                                        Alt =
                                            gotolocation.Alt + double.Parse(Settings.Instance["TXT_DefaultAlt"].ToString())
                                    },
                                    0, 0, 0, (byte)(float)MainV2.comPort.MAV.param["RALLY_TOTAL"]);

                                MainV2.comPort.setParam((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent, "RALLY_TOTAL", 1);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.ToString());
                            }
                        }
                    }
                }
            }
            catch
            {
                
            }
        }



        private void updateLocationLabel()
        {
            if (!Instance.IsDisposed)
            {
                Instance.BeginInvoke(
                    (MethodInvoker)
                        delegate
                        {
                            Instance.LBL_location.Text = Math.Round(gotolocation.Lat, 6) + " " + Math.Round(gotolocation.Lng, 6) + " " +
                                                         Math.Round(gotolocation.Alt, 2) + Environment.NewLine + gotolocation.Tag + " deg " +
                                                         gotolocation.Tag2 + " m/s " + double.Parse(gotolocation.Tag2)* 2.23694d + " mph" + 
                                                         Environment.NewLine + gps_sats + " sv"; 
                        }
                    );
            }
        }

        private void SerialOutput_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        // Calculates the checksum for a sentence
        string GetChecksum(string sentence)
        {
            // Loop through all chars to get a checksum
            int Checksum = 0;
            foreach (char Character in sentence.ToCharArray())
            {
                switch (Character)
                {
                    case '$':
                        // Ignore the dollar sign
                        break;
                    case '*':
                        // Stop processing before the asterisk
                        return Checksum.ToString("X2");
                    default:
                        // Is this the first value for the checksum?
                        if (Checksum == 0)
                        {
                            // Yes. Set the checksum to the value
                            Checksum = Convert.ToByte(Character);
                        }
                        else
                        {
                            // No. XOR the checksum with this character's value
                            Checksum = Checksum ^ Convert.ToByte(Character);
                        }
                        break;
                }
            }
            // Return the checksum formatted as a two-character hexadecimal
            return Checksum.ToString("X2");
        }

        private void CMB_updaterate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                updaterate = float.Parse(CMB_updaterate.Text.Replace("hz", ""));
            }
            catch
            {
                CustomMessageBox.Show(Strings.InvalidUpdateRate, Strings.ERROR);
            }
        }

        private void CHK_updateRallyPnt_CheckedChanged(object sender, EventArgs e)
        {
            updaterallypnt = CHK_updateRallyPnt.Checked;
        }

        private void LBL_location_Click(object sender, EventArgs e)
        {

        }

        private void USE_MC_Click(object sender, EventArgs e)
        {
            // Use this function to override the GCS location to the map cetner. 
            lastgotolocation = gotolocation; 
            gotolocation = MissionPlanner.GCSViews.FlightData.mymap.Position;
            gotolocation.Tag = Math.Round(num_no_gps_hdg.Value,1).ToString();
            gotolocation.Tag2 = "0.0";
            updateLocationLabel();
            

            Console.WriteLine("Use Map Center Clicked: " + gotolocation.ToString());

            MainV2.comPort.MAV.cs.Base = gotolocation;
            MainV2.comPort.MAV.cs.Base.Tag = gotolocation.Tag;
            Console.WriteLine("Moving Base updated to: " + MainV2.comPort.MAV.cs.Base.ToString());


            if (comPort != null && comPort.IsOpen) comPort.Close();
            BUT_connect.Enabled = false;
            cb_use_course.Checked = false;

        }

        private void CMB_serialport_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            CMB_serialport.Items.AddRange(SerialPort.GetPortNames());
        }


    }
}
