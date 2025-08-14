using MissionPlanner.Utilities;
using Onvif.Core.Client.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MissionPlanner
{
    public partial class ADSB_Control : UserControl
    {

        Process adsbProcess;
        private Plugin.PluginHost _host = null;
        private ProcessStartInfo proc1 = new ProcessStartInfo();

        public ADSB_Control()
        {
            InitializeComponent();

            timer1.Start();
        }


        public void setHost(Plugin.PluginHost host)
        {
            _host = host;
        }

        public void closeADSB()
        {
            if (adsbProcess != null && !adsbProcess.HasExited)
                adsbProcess.Kill();
        }

        private void butADSB1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Starting ADSB Receiver");
            //string strCmdText;
            //strCmdText = "/c C:\\dump1090\\dump1090.bat";
            //System.Diagnostics.Process.Start("CMD.exe", strCmdText);

            //https://github.com/MalcolmRobb/dump1090 
            //dump1090.exe --interactive --net --net-ro-size 500 --net-ro-rate 5 --net-buffer 5 --net-beast --mlat --device-index 1

            //string anyCommand = @"C:\dump1090\dump1090.bat";
            string anyCommand = string.Format("C:\\dump1090\\dump1090.exe --interactive --net --net-ro-size 500 --net-ro-rate 5 --net-buffer 5 --net-beast --mlat --device-index {0}", numDevID.Value );
            proc1.UseShellExecute = true;

            proc1.WorkingDirectory = @"C:\dump1090\";
            proc1.WindowStyle = ProcessWindowStyle.Normal;
            proc1.FileName = @"C:\Windows\System32\cmd.exe";
            proc1.Arguments = "/k " + anyCommand;

            adsbProcess = Process.Start(proc1);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            rtADSBList.Clear();
            rtADSBList.Text = System.DateTime.Now.ToString("HH:mm:ss tt") + "\n\n";
            try {
                if (_host == null || _host.MainForm == null) return;
                rtADSBList.Text += "Hex".PadRight(7) +
                                   "CS".PadRight(9) +
                                   "Alt".PadRight(7) +
                                   "Lat".PadRight(7) +
                                   "Lng".PadRight(9) +
                                    "\n"; 
                foreach (adsb.PointLatLngAltHdg plla in _host.MainForm.adsbPlanes.Values)
                {
                    rtADSBList.Text += plla.Tag.PadRight(7) +
                                        plla.CallSign.PadRight(9) +
                                        plla.Alt.ToString("0").PadRight(7) + 
                                        plla.Lat.ToString("0.000").PadRight(7) +
                                        plla.Lng.ToString("0.000").PadRight(9) + 
                                        "\n";


                }
            }
            catch (Exception ex) {
                rtADSBList.Text += ex.ToString();
            }
            
        }
    }
}
