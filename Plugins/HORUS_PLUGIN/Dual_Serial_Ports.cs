using Microsoft.Scripting.Utils;
using MissionPlanner.Comms;
using MissionPlanner.Controls;
using MissionPlanner.GCSViews.ConfigurationView;
using MissionPlanner.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;

using System.Windows.Forms;
using Xamarin.Essentials;
using static MAVLink;
using ZedGraph;
using System.Drawing;
using System.Collections.Concurrent;
using System.Collections;

namespace MissionPlanner
{
    public partial class Dual_Serial_Ports : Form
    {

        private MAVLinkInterface comPort1 = new MAVLinkInterface();
        private MAVLinkInterface comPort2 = new MAVLinkInterface();

        System.Threading.Thread _thread;
       private bool threadrun = false;
       private TcpListener listener;

        static Dual_Serial_Ports Instance;

        private ICommsSerial outputTCP; 
        DateTime com1_last_HB = DateTime.Now;
        DateTime com1_last_TX = DateTime.Now;
        DateTime com1_last_FTP = DateTime.Now;
        DateTime com1_last_ACK = DateTime.Now;
        
        DateTime com2_last_HB = DateTime.Now;
        DateTime com2_last_TX = DateTime.Now;
        DateTime com2_last_FTP = DateTime.Now;
        DateTime com2_last_ACK = DateTime.Now;

        int packetRXCount1, packetRXCount2;  
        int packetSentCount1, packetSentCount2;

        public RollingPointPairList com1_qos = new RollingPointPairList(600);
        public RollingPointPairList com2_qos = new RollingPointPairList(600);

        ConcurrentQueue<MAVLinkMessage> cmdQueue = new ConcurrentQueue<MAVLinkMessage>();

        public Dual_Serial_Ports()
        {
            InitializeComponent();
            Instance = this;

            timer1.Start();

            // INIT COM1 Drop downs

            CMB_serialport1.Items.AddRange(SerialPort.GetPortNames());
            CMB_serialport1.Items.Add("TCP Host - 14550");
            CMB_serialport1.Items.Add("TCP Client");
            CMB_serialport1.Items.Add("UDP Host - 14550");
            CMB_serialport1.Items.Add("UDP Client");


            // load last saved connection settings
            string temp = Settings.Instance["dsp_com1_port"];
            if (!string.IsNullOrEmpty(temp))
            {
                //statusLine("COM1 Port Setting to: " + temp);
                CMB_serialport1.SelectedIndex = CMB_serialport1.FindString(temp);
                if (CMB_serialport1.SelectedIndex == -1)
                {
                    CMB_serialport1.Text = temp; // allows ports that dont exist - yet
                }

            }

            string temp2 = Settings.Instance["dsp_com1_baud"];
            if (!string.IsNullOrEmpty(temp2))
            {
                //statusLine("COM1 Baud Setting to: " + temp2);
                var idx = CMB_baudrate1.FindString(temp2);
                if (idx == -1)
                {
                    CMB_baudrate1.Text = temp2;
                }
                else
                {
                    CMB_baudrate1.SelectedIndex = idx;
                }
            }

            // INIT COM2 Drop downs

            CMB_serialport2.Items.AddRange(SerialPort.GetPortNames());
            CMB_serialport2.Items.Add("TCP Host - 14550");
            CMB_serialport2.Items.Add("TCP Client");
            CMB_serialport2.Items.Add("UDP Host - 14550");
            CMB_serialport2.Items.Add("UDP Client");


            // load last saved connection settings
            temp = Settings.Instance["dsp_com2_port"];
            if (!string.IsNullOrEmpty(temp))
            {
                //statusLine("COM1 Port Setting to: " + temp);
                CMB_serialport2.SelectedIndex = CMB_serialport2.FindString(temp);
                if (CMB_serialport2.SelectedIndex == -1)
                {
                    CMB_serialport2.Text = temp; // allows ports that dont exist - yet
                }

            }

            temp2 = Settings.Instance["dsp_com2_baud"];
            if (!string.IsNullOrEmpty(temp2))
            {
                //statusLine("COM1 Baud Setting to: " + temp2);
                var idx = CMB_baudrate2.FindString(temp2);
                if (idx == -1)
                {
                    CMB_baudrate2.Text = temp2;
                }
                else
                {
                    CMB_baudrate2.SelectedIndex = idx;
                }
            }

            // INIT ZED GRAPH

            zed_com1.GraphPane.Title.Text = "QOS (COM1 (yellow) COM2 (green)";
            zed_com1.GraphPane.AddCurve("QOS", com1_qos, Color.Yellow,SymbolType.None);
            zed_com1.GraphPane.AddCurve("QOS", com2_qos, Color.Green, SymbolType.None);
            zed_com1.GraphPane.Legend.IsVisible = false;
            zed_com1.GraphPane.XAxis.Type = AxisType.Date;
            zed_com1.GraphPane.YAxis.Scale.Min = 0;
            zed_com1.GraphPane.YAxis.Scale.Max = 120;
            zed_com1.GraphPane.YAxis.Title.IsVisible = false;
            zed_com1.GraphPane.XAxis.Title.IsVisible = false;

        }

        private void updateCOMPlot(double qos_val1, double qos_val2)
        {
            if (qos_val1 != null) com1_qos.Add((double)new XDate(DateTime.Now), (double)qos_val1);
            else com1_qos.Add((double)new XDate(DateTime.Now), (double) 0);

            if (qos_val2 != null) com2_qos.Add((double)new XDate(DateTime.Now), (double)qos_val2);
            else com2_qos.Add((double)new XDate(DateTime.Now), (double)0);

            zed_com1.AxisChange();
            zed_com1.Invalidate();
        }

        private void start_thread()
        {
            if (threadrun)
            {
                statusLine("Thread already running?");
                return;
            }
            threadrun = true;
            _thread = new System.Threading.Thread(new System.Threading.ThreadStart(mainloop))
            {
                IsBackground = true,
                Name = "Dual Comm Port Thread"
            };
            _thread.Start();
            statusLine("{DUAL} Main background thread started");

        }

        private void packetReceivedHandler1(object sender, MAVLink.MAVLinkMessage mavLinkMessage)
        {
            packetRXCount1++;
            if (mavLinkMessage.msgid == (uint)MAVLink.MAVLINK_MSG_ID.HEARTBEAT) com1_last_HB = DateTime.Now.AddMilliseconds(200);
            if (mavLinkMessage.msgid == (uint)MAVLink.MAVLINK_MSG_ID.FILE_TRANSFER_PROTOCOL) com1_last_FTP = DateTime.Now.AddMilliseconds(200);
            if (mavLinkMessage.msgid == (uint)MAVLink.MAVLINK_MSG_ID.COMMAND_ACK
                ) //&& !cmdsIgnore.Contains(((MAVLink.mavlink_command_ack_t)mavLinkMessage.data).command))
            {
                com1_last_ACK = DateTime.Now.AddMilliseconds(200);
                statusLine("COM1 ACK RECEIVED: " + ((MAVLink.mavlink_command_ack_t)mavLinkMessage.data).command);
            }
            packetForwarder(mavLinkMessage); 
        }


        private void packetReceivedHandler2(object sender, MAVLink.MAVLinkMessage mavLinkMessage)
        {
            packetRXCount2++;
            if (mavLinkMessage.msgid == (uint)MAVLink.MAVLINK_MSG_ID.HEARTBEAT) com2_last_HB = DateTime.Now.AddMilliseconds(200);
            if (mavLinkMessage.msgid == (uint)MAVLink.MAVLINK_MSG_ID.FILE_TRANSFER_PROTOCOL) com2_last_FTP = DateTime.Now.AddMilliseconds(200);
            if (mavLinkMessage.msgid == (uint)MAVLink.MAVLINK_MSG_ID.COMMAND_ACK &&
                !cmdsIgnore.Contains(((MAVLink.mavlink_command_ack_t)mavLinkMessage.data).command))
            {
                com2_last_ACK = DateTime.Now.AddMilliseconds(200);
                statusLine("COM2 ACK RECEIVED: " + ((MAVLink.mavlink_command_ack_t)mavLinkMessage.data).command);
            }
            packetForwarder(mavLinkMessage);
        }

        private void statusLine(string str)
        {
            this.Invoke((MethodInvoker)delegate
            {
                rt_log.Text += DateTime.Now.ToString() + " " + str + "\n" + rt_log.Text;
            });
        }

        static List<ushort> cmdsIgnore = new List<ushort> {
            (ushort) MAVLink.MAVLINK_MSG_ID.AUTOPILOT_VERSION_REQUEST,
            (ushort) MAVLink.MAVLINK_MSG_ID.REQUEST_DATA_STREAM,
            512,
            520

        };

        private void packetForwarder(MAVLink.MAVLinkMessage mavLinkMessage)
        {      



            // TODO - may need a sequence number generator here to feed in sequence vales to TCP port.

            if (outputTCP != null && outputTCP.IsOpen)
                outputTCP.Write(mavLinkMessage.buffer,0,mavLinkMessage.buffer.Length);
        }


        private void BUT_connect_Click(object sender, EventArgs e)
        {
            if (BUT_connect1.Text == "Disconnect")
            {
                try
                {
                    if (Instance.comPort1 != null && Instance.comPort1.BaseStream.IsOpen)
                    {
                        statusLine("Closing COM 1"); 
                        Instance.comPort1.Close();
                        BUT_connect1.Text = "Connect";
                    }
                }
                catch { }

                return;
            }

            statusLine("Connecting to COM 1...");

            if (Instance.comPort1.BaseStream != null && Instance.comPort1.BaseStream.IsOpen)
            {
                Instance.statusLine("COM1 is already Open");
                Console.WriteLine("{DUAL} COM1 is already Open.");
                return;
            }

            Instance.lbl_com1_status.Text = "Connecting to " + CMB_serialport1.Text + "...";
            switch (CMB_serialport1.Text)
            {
                case "TCP":
                    Instance.comPort1.BaseStream = new TcpSerial();
                    break;
                case "UDP":
                    Instance.comPort1.BaseStream = new UdpSerial();
                    break;
                case "WS":
                    Instance.comPort1.BaseStream = new WebSocket();
                    break;
                case "UDPCl":
                    Instance.comPort1.BaseStream = new UdpSerialConnect();
                    break;
                default:
                    Instance.comPort1.BaseStream = new SerialPort();
                    break;
            }

            try
            {
                Instance.comPort1.BaseStream.PortName = CMB_serialport1.Text;
                if (CMB_baudrate1.Text != "" && CMB_baudrate1.Text != "0" && CMB_baudrate1.Text.IsNumber())
                    Instance.comPort1.BaseStream.BaudRate = int.Parse(CMB_baudrate1.Text);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
            }

            Instance.comPort1.OnPacketReceived += Instance.packetReceivedHandler1;
            


            // do the connect
            Instance.comPort1.Open(false, false, false);


            if (!Instance.comPort1.BaseStream.IsOpen)
            {
                statusLine("{DUAL} comport is closed. existing connect");
                try
                {
                    //_connectionControl.IsConnected(false);
                    //UpdateConnectIcon();
                    Instance.comPort1.Close();
                }
                catch
                {
                }

                return;
            }

            

            Instance.comPort1.giveComport = false;
            Instance.lbl_com1_status.Text = "Com Port Opened..."; 
            Instance.comPort1.getHeartBeat();
            Instance.lbl_com1_status.Text = "Got Heartbeat.... ";
            statusLine("{DUAL} Comm Port 1 Got Heartbeat");

            Settings.Instance["dsp_com1_port"] = CMB_serialport1.Text;
            Settings.Instance["dsp_com1_baud"] = CMB_baudrate1.Text;


            Instance.start_thread();

            Instance.setupTCPConnection();


        }

        private void BUT_connect2_Click(object sender, EventArgs e)
        {
            if (BUT_connect2.Text == "Disconnect")
            {
                try
                {
                    if (this.comPort2 != null && this.comPort2.BaseStream.IsOpen)
                    {
                        statusLine("Closing COM 2");
                        this.comPort2.Close();
                        BUT_connect2.Text = "Connect";
                    }
                }
                catch { }

                return;
            }

            lbl_com2_status.Text = "Connecting to " + CMB_serialport2.Text + "...";
            switch (CMB_serialport2.Text)
            {
                case "TCP":
                    this.comPort2.BaseStream = new TcpSerial();
                    break;
                case "UDP":
                    this.comPort2.BaseStream = new UdpSerial();
                    break;
                case "WS":
                    this.comPort2.BaseStream = new WebSocket();
                    break;
                case "UDPCl":
                    this.comPort2.BaseStream = new UdpSerialConnect();
                    break;
                default:
                    this.comPort2.BaseStream = new SerialPort();
                    break;
            }

            try
            {
                this.comPort2.BaseStream.PortName = CMB_serialport2.Text;
                if (CMB_baudrate2.Text != "" && CMB_baudrate2.Text != "0" && CMB_baudrate2.Text.IsNumber())
                    comPort2.BaseStream.BaudRate = int.Parse(CMB_baudrate2.Text);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
            }

            this.comPort2.OnPacketReceived += this.packetReceivedHandler2;



            // do the connect
            this.comPort2.Open(false, false, false);


            if (!this.comPort2.BaseStream.IsOpen)
            {
                statusLine("{DUAL} comport 2 is closed. existing connect");
                try
                {
                    //_connectionControl.IsConnected(false);
                    //UpdateConnectIcon();
                    this.comPort2.Close();
                }
                catch
                {
                }

                return;
            }



            this.comPort2.giveComport = false;
            lbl_com2_status.Text = "Com Port Opened...";
            this.comPort2.getHeartBeat();
            lbl_com2_status.Text = "Got Heartbeat.... ";
            statusLine("{DUAL} Comm Port 2 Open");

            Settings.Instance["dsp_com2_port"] = CMB_serialport2.Text;
            Settings.Instance["dsp_com2_baud"] = CMB_baudrate2.Text;


            this.start_thread();

            this.setupTCPConnection();


        }


 

        void DoAcceptTcpClientCallback(IAsyncResult ar)
        {
            // Get the listener that handles the client request.
            TcpListener listener = (TcpListener)ar.AsyncState;

            // End the operation and display the received data on  
            // the console.
            TcpClient client = listener.EndAcceptTcpClient(ar);

            ((TcpSerial)outputTCP).client = client;

            listener.BeginAcceptTcpClient(new AsyncCallback(DoAcceptTcpClientCallback), listener);

            statusLine("{DUAL} TCP Client Connected " + listener.LocalEndpoint.ToString());

            this.Invoke((MethodInvoker)delegate
            {
                this.lbl_TCP_Status.Text = "Connected to: " + listener.LocalEndpoint.ToString();
            });
        }

        private void BUT_restart_TCP_Click(object sender, EventArgs e)
        {
            if (this.outputTCP != null) {
                statusLine("Closing and Disposing of TCP Server");
                ((TcpSerial)outputTCP).client.Close();

                this.outputTCP.Close();
                lbl_TCP_Status.Text = "Closed";
                this.outputTCP.Dispose();
            }
            setupTCPConnection();
        }

        private void BUT_connetMP_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {


                // COM1
                this.led_com1_rx.On = (DateTime.Now < this.com1_last_HB);
                this.led_com1_tx.On = (DateTime.Now < this.com1_last_TX);
                this.led_com1_ftp.On = (DateTime.Now < this.com1_last_FTP);
                this.led_com1_ack.On = (DateTime.Now < this.com1_last_ACK);
                this.vpb_com1.Value = this.comPort1.MAV.cs.linkqualitygcs;
                if (this.vpb_com1.Value < 25) this.vpb_com1.maxline = 25;

                //COM2
                this.led_com2_rx.On = (DateTime.Now < this.com2_last_HB);
                this.led_com2_tx.On = (DateTime.Now < this.com2_last_TX);
                this.led_com2_ftp.On = (DateTime.Now < this.com2_last_FTP);
                this.led_com2_ack.On = (DateTime.Now < this.com2_last_ACK);
                this.vpb_com2.Value = this.comPort2.MAV.cs.linkqualitygcs;
                if (this.vpb_com2.Value < 25) this.vpb_com2.maxline = 25;

        }

        private void setupTCPConnection()
        {
            try
            {
                Console.WriteLine("{DUAL} Starting TCP Connection.... ");
                lbl_TCP_Status.Text = "Requesting TCP Connection...";


                if (this.outputTCP == null) {
                    this.outputTCP = new TcpSerial(); //new UdpSerial() { ConfigRef = "SerialOutputPassUDP", Port = "14550" };//  new UdpSerialConnect() { ConfigRef = "SerialOutputPassUDPCL" };
                }
                
                if (!this.outputTCP.IsOpen)
                {
                    this.listener = new TcpListener(System.Net.IPAddress.Any, 14558);
                    this.listener.Start(0);
                    this.listener.BeginAcceptTcpClient(new AsyncCallback(DoAcceptTcpClientCallback), this.listener);
                    statusLine("{DUAL} TCP Listener Open");
                    Console.WriteLine(("{DUAL} TCP Listener is Open!"));
                    lbl_TCP_Status.Text = "TCP Service Started at port " + 14558;
                }
                else
                {
                    statusLine("TCP Already running?");
                }
            }
            catch (Exception ex)
            {
                statusLine("Could not setup TCP Connection");
                Console.WriteLine("{DUAL} TCP Startup Exception: " + ex.ToString());
            }
            Console.WriteLine("{DUAL} TCP Startup Done.");
        }
        private void mainloop()
        {
            //Console.WriteLine("{DUAL}Trying to Connect....");
            //Thread.Sleep(5000);
            //this.comPort1.BaseStream = new SerialPort();
            //this.comPort1.BaseStream.PortName = "COM40";
            //this.comPort1.BaseStream.BaudRate = 19200;

            //this.comPort1.OnPacketReceived += this.packetReceivedHandler;
            ////comPort1.OnPacketSent += packetSentHandler;

            //// do the connect
            //this.comPort1.Open(false, false, false);

            //this.comPort1.giveComport = false;
            try
            {
                DateTime lastPrint = DateTime.Now;
                MavlinkParse mlParser1,mlParser2,mlParserCMD = new MavlinkParse();


                this.threadrun = true;

                while (this.threadrun)
                {
                    Thread.Sleep(1);



                    // must be open, we have bytes, we are not yielding the port,
                    // the thread is meant to be running and we only spend 1 seconds max in this read loop
                    // Let's flip flop this so that every other read cycle we switch com ports to read. 
                    // Exception is that comPort1 has over 400 bytes to read (shoudl be rare)

                    DateTime endRead = DateTime.Now.AddMilliseconds(100);




                    // give 100 ms to com1
                    while (this.comPort1.BaseStream != null && this.comPort1.BaseStream.IsOpen && this.comPort1.BaseStream.BytesToRead > 10 &&
                            this.comPort1.giveComport == false && DateTime.Now < endRead)
                    {
                        try
                        {
                            this.comPort1.readPacket();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("{DUAL} Read Packet Error: " + ex);
                        }
                    }
                    this.comPort1.MAV.cs.UpdateCurrentSettings(null, false, this.comPort1, this.comPort1.MAV);

                    endRead = DateTime.Now.AddMilliseconds(100);
                    while (this.comPort2.BaseStream != null &&  this.comPort2.BaseStream.IsOpen && this.comPort2.BaseStream.BytesToRead > 10 &&
                            this.comPort2.giveComport == false && DateTime.Now < endRead)
                    {
                        try
                        {
                            this.comPort2.readPacket();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("{DUAL} Read Packet Error: " + ex);
                        }
                    }
                    this.comPort2.MAV.cs.UpdateCurrentSettings(null, false, this.comPort2, this.comPort2.MAV);

                    ushort lq1 = 0; 
                    ushort lq2 = 0;

                    // TODO: need to add a line here to make this part only run every few seconds. 
                    if (lastPrint.Second != DateTime.Now.Second) { 
                        // COM 1
                        if (this.comPort1 != null && this.comPort1.BaseStream != null && this.comPort1.BaseStream.IsOpen)
                        {

                            Console.WriteLine("{DUAL} COM 1 Open: " + this.comPort1.BaseStream.IsOpen + " " + this.comPort1.BaseStream.ToString() + " LQ: " + this.comPort1.MAV.cs.linkqualitygcs);
                            this.Invoke((MethodInvoker)delegate
                            {
                                String s = ""; 
                                s =  string.Format("{0,-20}{1}\n", "Quality:",        comPort1.MAV.cs.linkqualitygcs);
                                s += string.Format("{0,-20}{1}\n", "Packets RX: ",    comPort1.MAV.packetsnotlost);
                                s += string.Format("{0,-20}{1}\n", "Packets Lost:",   comPort1.MAV.packetslost);
                                s += string.Format("{0,-20}{1}\n", "RX / Sec: ",      packetRXCount1);
                                s += string.Format("{0,-20}{1}\n", "TX / Sec: ",      packetSentCount1);
                                lbl_com1_status.Text = s;
                                packetRXCount1 = 0;
                                packetSentCount1 = 0;

                                lq1 = comPort1.MAV.cs.linkqualitygcs;

                                this.BUT_connect1.Text = "Disconnect";

                            });
                        }
                        else
                        {
                            if (this.BUT_connect1.Text == "Disconnect")
                            {
                                statusLine("{DUAL} WARNING! COMPORT1 BaseStream not open.");
                            }
                            //statusLine("{DUAL} COMPORT1 BaseStream not open.");
                            this.BUT_connect1.Text = "Connect";
                        }
                        // COM 2
                        if (this.comPort2 != null && this.comPort2.BaseStream != null && this.comPort2.BaseStream.IsOpen)
                        {

                            Console.WriteLine("{DUAL} COM 2 Open: " + this.comPort1.BaseStream.IsOpen + " " + this.comPort2.BaseStream.ToString() + " LQ: " + this.comPort2.MAV.cs.linkqualitygcs);
                            this.Invoke((MethodInvoker)delegate
                            {
                                String s = "";
                                s = string.Format("{0,-20}{1}\n", "Quality:", comPort2.MAV.cs.linkqualitygcs);
                                s += string.Format("{0,-20}{1}\n", "Packets RX: ", comPort2.MAV.packetsnotlost);
                                s += string.Format("{0,-20}{1}\n", "Packets Lost:", comPort2.MAV.packetslost);
                                s += string.Format("{0,-20}{1}\n", "RX / Sec: ", packetRXCount2);
                                s += string.Format("{0,-20}{1}\n", "TX / Sec: ", packetSentCount2);
                                lbl_com2_status.Text = s;
                                packetRXCount2 = 0;
                                packetSentCount2 = 0;

                                lq2 = comPort2.MAV.cs.linkqualitygcs;

                                this.BUT_connect2.Text = "Disconnect";

                            });
                        }
                        else
                        {
                            if (this.BUT_connect2.Text == "Disconnect")
                            {
                                statusLine("{DUAL} WARNING! COMPORT2 BaseStream not open.");
                            }
                            //statusLine("{DUAL} COMPORT1 BaseStream not open.");
                            this.BUT_connect2.Text = "Connect";
                        }

                        this.Invoke((MethodInvoker)delegate
                        {
                            updateCOMPlot(lq1, lq2);
                        });

                        lastPrint = DateTime.Now;
                    }


                    
                    while (outputTCP.BytesToRead > 0)
                    {
                        //MAVLinkMessage msg = mlParser.ReadPacket(outputTCP.BaseStream);

                        //if (msg != null)
                        //{
                        //    Console.WriteLine("{DUAL} Forwarding Message: " + msg.ToString());
                        //    //this.comPort1.BaseStream.Write(msg.buffer, 0, msg.buffer.Length);
                        //    cmdQueue.Enqueue(msg);


                        //    //packetSentCount1++;
                        //    //com1_last_TX = DateTime.Now.AddMilliseconds(200);
                        //}
                        var len = outputTCP.BytesToRead;

                        byte[] buf = new byte[len];

                        len = outputTCP.Read(buf, 0, len);

                        this.comPort1.BaseStream.Write(buf, 0, len); ;

                    }

                    //DateTime endWrite = DateTime.Now.AddMilliseconds(100);
                    //while (cmdQueue.Count > 0 && DateTime.Now < endWrite)
                    //{
                    //    Console.WriteLine("{DUAL} OUTPUT QUEUE Count: " + cmdQueue.Count);
                    //    try
                    //    {
                    //        MAVLinkMessage msg = null; 
                             
                    //        if (this.comPort1.BaseStream != null && this.comPort1.BaseStream.IsOpen)
                    //        {
                    //            if (this.comPort1.giveComport == false)
                    //            {
                                    
                    //                cmdQueue.TryDequeue(out msg);
                    //                Console.WriteLine("{DUAL} -------------- Pretending to Write: " + msg.ToString());
                    //                packetSentCount1++;
                    //                com1_last_TX = DateTime.Now.AddMilliseconds(200);
                    //            }
                    //        } else
                    //        {
                    //            while (cmdQueue.TryDequeue(out msg)) ;
                    //        }
                    //    } catch (Exception ex)
                    //    {
                    //        Console.WriteLine("{DUAL} Exception in cmds write out: " + ex.ToString());
                    //    }
                    //}


                }
            } catch (Exception ex)
            {
                Console.WriteLine("Error in Dual Loop: " + ex);
            } finally
            {
                this.threadrun = false;
            }
            
        }
        
    }
}
