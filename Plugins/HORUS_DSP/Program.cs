using System;
using System.Windows.Forms;
using MissionPlanner.Comms;
using MissionPlanner.ArduPilot;

namespace MissionPlanner
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.Run(new Dual_Serial_Ports());
        }
    }
}
