using MissionPlanner.Grid;
using System;
using System.Windows.Forms;
using MissionPlanner.Controls;
using MissionPlanner.Utilities;
using SharpKml.Dom.Atom;
using MissionPlanner;

namespace HORUS_plugin_Plugin
{
    public class HORUS_plugin_Plugin : MissionPlanner.Plugin.Plugin
    {
        //TabPage
        private System.Windows.Forms.TabPage tab = new System.Windows.Forms.TabPage();
        private System.Windows.Forms.TabPage tab2 = new System.Windows.Forms.TabPage();
        private System.Windows.Forms.TabPage tab3 = new System.Windows.Forms.TabPage();
        private System.Windows.Forms.TabPage tab4 = new System.Windows.Forms.TabPage();
        private TabControl tabctrl;
        private HORUS_PreFlight pf = new HORUS_PreFlight();
        private HORUSControlMode controlMode = new HORUSControlMode();
        private MAVLinkInspectorControl mavLink = null;
        private HORUS_TAB ht = new HORUS_TAB();
        private Dual_Serial_Ports dspTab = new Dual_Serial_Ports();
        

        public override string Name
        {
            get { return "HORUS Control"; }
        }

        public override string Version
        {
            get { return "0.01"; }
        }

        public override string Author
        {
            get { return "Steven Borenstein"; }
        }

        public override bool Init()
        {
            return true;
        }

        public override bool Loaded()
        {
            

            pf.setHost(Host);
            ht.setHost(Host);

            mavLink = new MAVLinkInspectorControl(Host.comPort);

            //TODO Uncomment once Beta is updates
            Host.MainForm.FlightData.TabListOriginal.Add(tab);
            Host.MainForm.FlightData.TabListOriginal.Add(tab2);
            Host.MainForm.FlightData.TabListOriginal.Add(tab3);
            //Host.MainForm.FlightData.TabListOriginal.Add(tab4);

            tabctrl = Host.MainForm.FlightData.tabControlactions;
            // set the display name
            tab.Text = "HORUS-Preflight";
            tab2.Text = "MAVLink";
            tab3.Text = "HORUS";
            //tab4.Text = "Dual Serial";
            // set the internal id
            tab.Name = "HORUS_PF";
            tab2.Name = "MAVLink";
            tab3.Name = "HORUS";
            //tab4.Name = "Dual_Serial";
            // add the usercontrol to the tabpage

            tab.Controls.Add(pf);
            tab3.Controls.Add(ht);
            tab2.Controls.Add(mavLink);
           // tab4.Controls.Add(dspTab);
           

            tabctrl.TabPages.Insert(5, tab2);
            tabctrl.TabPages.Insert(5, tab3);
            tabctrl.TabPages.Insert(5, tab);
            //tabctrl.TabPages.Insert(5, tab4); 

            ThemeManager.ApplyThemeTo(tab);
            ThemeManager.ApplyThemeTo(tab2);
            ThemeManager.ApplyThemeTo(tab3);
            //ThemeManager.ApplyThemeTo(tab4);

            forceSettings();

            if (Settings.Instance.GetBoolean("horus_panel_visible"))
            {
                tabctrl.SelectedIndex = 5;
            }

            return true;
        }


        private void forceSettings()
        {
            

            string tabs = Settings.Instance["tabcontrolactions"];

            // setup default if doesnt exist
            if (tabs == null)
            {
                CustomMessageBox.Show("Restart Mission Planner to enable HORUS Tab. Disable Plugin if Not Required CTRL-P");
                Host.MainForm.FlightData.saveTabControlActions();
                tabs = Settings.Instance["tabcontrolactions"];
                Settings.Instance.Save();
            }
        }


        public override bool Exit()
        {
            return true;
        }
    }
}
