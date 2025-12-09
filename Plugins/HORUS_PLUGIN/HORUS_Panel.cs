using AviFile;
using IronPython.Runtime.Operations;
using MissionPlanner.Controls;
using MissionPlanner.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MissionPlanner
{
    public partial class HORUS_Panel : UserControl
    {
        private Plugin.PluginHost _host = null;
        int packetRate;
        int byteRate;
        int packetCount;
        int byteCount;
        int packetCounter;

        int hb_counter = 1;
        int mav_ftp_counter = 0;
        int msg_counter = 0;

        String[] sensorStrings = new string[16]; 

        private int messagecount;

        private MAVLinkInterface mav;

        public HORUS_Panel()
        {
            InitializeComponent();
            timer1.Start();

            
            ledHB.On = false;
        }

        public void setHost(Plugin.PluginHost host)
        {
            _host = host;

            this.mav = _host.comPort;
            this.mav.OnPacketReceived += MavOnOnPacketReceived;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            printAHRS();
            printGliderStats();
            printCommStats();
            printMission();

     

            var messagetime = MainV2.comPort.MAV.cs.messages.LastOrDefault().time;
            if (messagecount != messagetime.toUnixTime())
            {
                try
                {
                    StringBuilder message = new StringBuilder();
                    MainV2.comPort.MAV.cs.messages.ForEach(x =>
                    {
                        message.Insert(0, x.Item1.ToString("hh:mm:ss") + " : " + x.Item2 + "\n");
                    });
                    TXT_msgBox.Text = message.ToString();

                    messagecount = messagetime.toUnixTime();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error in messages IRISS PreFlight");
                }
            }

            if (msg_counter > 0)
            {
                TXT_msgBox.BackColor = Color.DarkOliveGreen;
                //TXT_msgBox.ForeColor = Color.Black;
                msg_counter--;
            } else
            {
                TXT_msgBox.BackColor = Color.FromArgb(64, 64, 64);
                //TXT_msgBox.ForeColor = Color.White;
            }

            
            StringBuilder _txt = new StringBuilder();

            sensorStrings.ForEach<String>(x =>
            {
                if (x!=null && x.Length > 0)
                    _txt.Append(x.replace("\0","").ToString() + "\n");
            });
            _txt.Append("---\n");
            //Console.WriteLine("[" + _txt.ToString() + "]");
            rt_sensorData.Text = _txt.ToString();
            //Console.WriteLine(rt_sensorData.Text);
        }


        private void printCommStats()
        {
            try
            {
                if (packetCounter++ >= (5000/timer1.Interval))
                {
                    packetRate = packetCount/5;
                    byteRate = byteCount/5; 
                    packetCount = 0;
                    byteCount = 0;
                    packetCounter = 0;
                }

                if (hb_counter == 0) { ledHB.On = true; }
                if (hb_counter > 0) { ledHB.On = false; }
                hb_counter++; 

                lblCommStats.Text = "Byte Rate: ".PadRight(14) +
                               byteRate.ToString().PadLeft(8) + " bps\n";
                lblCommStats.Text += "Packet Rate: ".PadRight(14) +
                               packetRate.ToString().PadLeft(8) + " pps\n";
                lblCommStats.Text += "Last HB: ".PadRight(14) +
                               ((float) hb_counter / (1000/timer1.Interval)).ToString("0.0").PadLeft(8) + " sec\n";


                if (mav_ftp_counter > 0)
                {
                    lblCommStats.Text += "MAV FTP Detected";
                    mav_ftp_counter--; 
                }
            }
            catch
            {
                lblCommStats.Text = "Waiting for Data.";
            }
        }



        private void MavOnOnPacketReceived(object o, MAVLink.MAVLinkMessage linkMessage)
        {
            byteCount += linkMessage.Length;
            packetCount++;
            if (linkMessage.msgid == (uint)MAVLink.MAVLINK_MSG_ID.HEARTBEAT)
                hb_counter = 0;

            if (linkMessage.msgid == (uint)MAVLink.MAVLINK_MSG_ID.FILE_TRANSFER_PROTOCOL)
                mav_ftp_counter = 10;

            if (linkMessage.msgid == (uint)MAVLink.MAVLINK_MSG_ID.STATUSTEXT)
                msg_counter = 10;

            if (linkMessage.msgid == (uint)MAVLink.MAVLINK_MSG_ID.BUTTON_CHANGE)
            {
                //Console.WriteLine("BUTTON MESSAGE: " + linkMessage);
                MAVLink.mavlink_button_change_t packet =
                    linkMessage.ToStructure<MAVLink.mavlink_button_change_t>();

                pic_is_armed.On = (packet.state==1);
            }
            if (linkMessage.msgid == (uint)MAVLink.MAVLINK_MSG_ID.DATA32)
            {
                MAVLink.mavlink_data32_t rd = linkMessage.ToStructure<MAVLink.mavlink_data32_t>();
                

                byte[] fl_data = new byte[28];
                byte fl_size, fl_type, fl_type2, fl_id; 
                fl_type = rd.data[0];
                fl_type2 = rd.data[1];
                fl_id = rd.data[2];
                fl_size = rd.data[3];

                Array.Copy(rd.data, 4, fl_data, 0, 28);
                String _txt = Encoding.UTF8.GetString(fl_data).Trim() ;
                //Console.WriteLine("Data32 ID: " + fl_id + " Data: " + _txt);
                string[] _fields = _txt.Split(',');
                if (fl_id < 16)
                {
                    sensorStrings[fl_id] = $"{DateTime.Now.ToString("HH:mm:ss"),-10}";
                    foreach (string _x in _fields)
                    {
                        sensorStrings[fl_id] += $"{_x,-8}";
                    }
                }

                
            }
        }


        private void printAHRS()
        {
            try
            {
                // Print ACC
                lblAHRS1.Text = "AHRS YPR:".PadRight(10) +
                                _host.cs.yaw.ToString("0").PadRight(5) + 
                                _host.cs.pitch.ToString("0").PadRight(5) +
                                _host.cs.roll.ToString("0").PadRight(5) ;

                if (Math.Abs(_host.cs.pitch) < 3 && Math.Abs(_host.cs.roll) < 3)
                {
                    lblAHRS1.Text += "~Level\n";
                }
                else if (_host.cs.pitch > (Math.Abs(_host.cs.roll)))
                {
                    lblAHRS1.Text += "Pitch Up\n";
                }
                else if (-_host.cs.pitch > (Math.Abs(_host.cs.roll)))
                {
                    lblAHRS1.Text += "Pitch Down\n";
                }
                else if (_host.cs.roll > (Math.Abs(_host.cs.pitch)))
                {
                    lblAHRS1.Text += "RW Down\n";
                }
                else if (-_host.cs.roll > (Math.Abs(_host.cs.pitch)))
                {
                    lblAHRS1.Text += "LW Down\n";
                }

                // Print Mag
                lblAHRS1.Text += "MAG XYZ:".PadRight(10) +
                                _host.cs.mx.ToString("0").PadRight(5) +
                                _host.cs.my.ToString("0").PadRight(5) +
                                _host.cs.mz.ToString("0").PadRight(5);
                if (_host.cs.mz > (Math.Abs(_host.cs.mx) + Math.Abs(_host.cs.my)))
                {
                    lblAHRS1.Text += "Top Up\n";
                }
                else if (-_host.cs.mz > (Math.Abs(_host.cs.mx) + Math.Abs(_host.cs.my)))
                {
                    lblAHRS1.Text += "Inverted\n";
                }
                else if (_host.cs.mx > (Math.Abs(_host.cs.mz) + Math.Abs(_host.cs.my)))
                {
                    lblAHRS1.Text += "Nose Down\n";
                }
                else if (-_host.cs.mx > (Math.Abs(_host.cs.mz) + Math.Abs(_host.cs.my)))
                {
                    lblAHRS1.Text += "Nose Up\n";
                }
                else if (_host.cs.my > (Math.Abs(_host.cs.mz) + Math.Abs(_host.cs.mx)))
                {
                    lblAHRS1.Text += "RW Down\n";
                }
                else if (-_host.cs.my > (Math.Abs(_host.cs.mz) + Math.Abs(_host.cs.mx)))
                {
                    lblAHRS1.Text += "LW Down\n";
                }
                else
                {
                    lblAHRS1.Text += "UNK\n";
                }

                // Print ACC
                lblAHRS1.Text += "ACC XYZ:".PadRight(10) +
                                _host.cs.ax.ToString("0").PadRight(5) +
                                _host.cs.ay.ToString("0").PadRight(5) +
                                _host.cs.az.ToString("0").PadRight(5);
                if (-_host.cs.az > (Math.Abs(_host.cs.ax) + Math.Abs(_host.cs.ay)))
                {
                    lblAHRS1.Text += "Top Up\n";
                }
                else if (_host.cs.az > (Math.Abs(_host.cs.ax) + Math.Abs(_host.cs.ay)))
                {
                    lblAHRS1.Text += "Inverted\n";
                }
                else if (-_host.cs.ax > (Math.Abs(_host.cs.az) + Math.Abs(_host.cs.ay)))
                {
                    lblAHRS1.Text += "Nose Down\n";
                }
                else if (_host.cs.ax > (Math.Abs(_host.cs.az) + Math.Abs(_host.cs.ay)))
                {
                    lblAHRS1.Text += "Nose Up\n";
                }
                else if (_host.cs.ay > (Math.Abs(_host.cs.az) + Math.Abs(_host.cs.ax)))
                {
                    lblAHRS1.Text += "LW Down\n";
                }
                else if (-_host.cs.ay > (Math.Abs(_host.cs.az) + Math.Abs(_host.cs.ax)))
                {
                    lblAHRS1.Text += "RW Down\n";
                }
                else
                {
                    lblAHRS1.Text += "UNK\n";
                }



                lblAHRS1.Text += "EKF STAT:".PadRight(10) + _host.cs.ekfstatus + "\n";
                lblAHRS1.Text += "EKF FLAG:".PadRight(10) + Convert.ToString(_host.cs.ekfflags,2).PadLeft(16, '0') + "\n";


            }
            catch
            {
                lblAHRS1.Text = "Waiting for Data.";
            }
        }

        private void printMission()
        {
            try { 
                if (_host.cs.mode.ToLower() != "AUTO".ToLower())
                {
                    lblMission.Text = "Waiting for AUTO";
                    return;
                }
               
                lblMission.Text = "Curr WP:".PadRight(10) + _host.cs.wpno.ToString("0") +  "\n";
                lblMission.Text += "WP Dist:".PadRight(10) + _host.cs.wp_dist.ToString("0") + "\n";
                lblMission.Text += "Target Alt:".PadRight(10) +_host.cs.targetalt.ToString("0") + "\n";
                lblMission.Text += "Target Speed:".PadRight(10) + _host.cs.targetairspeed.ToString("0.0") + "\n";

                //butPullup.Enabled = _host.cs.wpno == 3;  // At this point, assume wp 3 is the alt hold
            } catch
            {

            } 
        } 

        private void printGliderStats()
        {
            try
            {
                double ft2miles = 1.893939393939394e-4;

                lblGliderCalcs.Text = "DTH:".PadRight(10) + _host.cs.DistToHome.ToString("0.0") + " " + CurrentState.DistanceUnit;
                if (CurrentState.DistanceUnit.ToLower() == "ft")
                    lblGliderCalcs.Text += " / " + (_host.cs.DistToHome * ft2miles).ToString("0.0") + " mi\n";
                else
                    lblGliderCalcs.Text += "\n"; 

                lblGliderCalcs.Text += "GS:".PadRight(10) + _host.cs.groundspeed.ToString("0.0") + " " + CurrentState.SpeedUnit +  "\n";
                lblGliderCalcs.Text += "VS:".PadRight(10) + _host.cs.verticalspeed_fpm.ToString("0.0") + " fpm " + (_host.cs.verticalspeed_fpm* 0.00508).ToString("0.0") + " m/s" + "\n";
                if (_host.cs.vz > 0)
                {
                    if (CurrentState.DistanceUnit.ToLower() != "ft")
                    {
                        lblGliderCalcs.Text += "Units must be set\n to imperial to calc";
                    }
                    else
                    {
                        // assumes mph, fpm for now
                        lblGliderCalcs.Text += "GStoHOME:".PadRight(10) + (((_host.cs.DistToHome * ft2miles) / _host.cs.groundspeed) * 60.0).ToString("0.0") + " min\n";
                        lblGliderCalcs.Text += "VZtoHOME:".PadRight(10) + ((_host.cs.alt / -_host.cs.verticalspeed_fpm)).ToString("0.0") + " min\n";
                    }
                }
                

            }
            catch
            {
                lblAHRS1.Text = "Waiting for Data.";
            }
        }

        //private void butPullup_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (_host.cs.mode.ToLower() != "AUTO".ToLower())
        //        {
        //            CustomMessageBox.Show("Not in Auto", Strings.ERROR);
        //            return;
        //        }
        //        if (
        //        CustomMessageBox.Show("Are you sure you want to Advance to Pullup??", "Action",
        //            MessageBoxButtons.YesNo) == (int)DialogResult.Yes)
        //        {
        //            // Old V1 Method: 
        //            //_host.comPort.setWPCurrent(_host.comPort.MAV.sysid, _host.comPort.MAV.compid, Convert.ToUInt16(_host.cs.wpno + 1));

        //            try
        //            {
        //                // Currently this is hard coded to 221 as per https://github.com/ArduPilot/ardupilot/pull/30962/commits/46626d64a15e6b4293add42e78cb3bb48c14d3e3
        //                int PULLUP_AUX_COMMAND = 221;
        //                if (MainV2.comPort.doCommand((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent, MAVLink.MAV_CMD.DO_AUX_FUNCTION, PULLUP_AUX_COMMAND, 1, 0, 0,
        //                    0, 0, 0))
        //                {
                            
        //                }
        //                else
        //                {
        //                    CustomMessageBox.Show(Strings.CommandFailed, Strings.ERROR);
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                CustomMessageBox.Show(Strings.CommandFailed + ex.ToString(), Strings.ERROR);
        //            }

        //        }
        //    }
        //    catch {
        //        CustomMessageBox.Show(Strings.CommandFailed, Strings.ERROR);
        //    }
             
        //}

        private void horusControlMode1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Sending FMC Message: " + txt_note.Text);
            MAVLink.mavlink_data32_t cmd_out = new MAVLink.mavlink_data32_t();
            cmd_out.type = 66;
            cmd_out.len = (byte)txt_note.TextLength;
            cmd_out.data = Encoding.ASCII.GetBytes(txt_note.Text.PadRight(32, ' '));
            Console.WriteLine("Sending MAVLink command.");
            MainV2.comPort.sendPacket(cmd_out, MainV2.comPort.MAV.sysid, 99);

            txt_note.Clear();
        }
    }
}
