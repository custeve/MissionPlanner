using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MissionPlanner
{
    public partial class HORUS_TAB : UserControl
    {

        private Plugin.PluginHost _host = null;
        const double M2FT = 3.28084;
        const double MS2MPH = 2.23694;
        const double M2MILE = 0.000621371;

        public HORUS_TAB()
        {
            InitializeComponent();

            qv_alt_m.desc = "(m) ASL";
            qv_alt_m.numberformat = "0.0";
            qv_alt_m.number = 0.0D;
            qv_alt_m.numberColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(252))))); 
            qv_alt_m.numberColorBackup = System.Drawing.Color.Empty;

            qv_alt_ft.desc = "(ft) ASL";
            qv_alt_ft.numberformat = "0.0";
            qv_alt_ft.number = 0.0D;
            qv_alt_ft.numberColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(86)))));
            qv_alt_ft.numberColorBackup = System.Drawing.Color.Empty;

            qv_agl_m.desc = "(m) AGL";
            qv_agl_m.numberformat = "0.0";
            qv_agl_m.number = 0.0D;
            qv_agl_m.numberColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(252)))));
            qv_agl_m.numberColorBackup = System.Drawing.Color.Empty;

            qv_agl_ft.desc = "(ft) AGL";
            qv_agl_ft.numberformat = "0.0";
            qv_agl_ft.number = 0.0D;
            qv_agl_ft.numberColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(86)))));
            qv_agl_ft.numberColorBackup = System.Drawing.Color.Empty;

            qv_vrate_ms.desc = "Vz (m/s)";
            qv_vrate_ms.numberformat = "0.0";
            qv_vrate_ms.number = 0.0D;
            qv_vrate_ms.numberColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(252)))));
            qv_vrate_ms.numberColorBackup = System.Drawing.Color.Empty;

            qv_vrate_fts.desc = "Vz (ft/s)";
            qv_vrate_fts.numberformat = "0.0";
            qv_vrate_fts.number = 0.0D;
            qv_vrate_fts.numberColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(86)))));
            qv_vrate_fts.numberColorBackup = System.Drawing.Color.Empty;

            qv_spd_ms.desc = "Vg (m/s)";
            qv_spd_ms.numberformat = "0.0";
            qv_spd_ms.number = 0.0D;
            qv_spd_ms.numberColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(252)))));
            qv_spd_ms.numberColorBackup = System.Drawing.Color.Empty;

            qv_spd_mph.desc = "Vg (mph)";
            qv_spd_mph.numberformat = "0.0";
            qv_spd_mph.number = 0.0D;
            qv_spd_mph.numberColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(86)))));
            qv_spd_mph.numberColorBackup = System.Drawing.Color.Empty;

            qv_dist_km.desc = "Dist (km)";
            qv_dist_km.numberformat = "0.0";
            qv_dist_km.number = 0.0D;
            qv_dist_km.numberColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(252)))));
            qv_dist_km.numberColorBackup = System.Drawing.Color.Empty;

            qv_dist_mi.desc = "Dist (mi)";
            qv_dist_mi.numberformat = "0.0";
            qv_dist_mi.number = 0.0D;
            qv_dist_mi.numberColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(86)))));
            qv_dist_mi.numberColorBackup = System.Drawing.Color.Empty;

            timer1.Start();
        }

        public void setHost(Plugin.PluginHost host)
        {
            _host = host;
            

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_host != null)
            {
                qv_alt_m.number = _host.cs.altasl;
                qv_alt_ft.number = _host.cs.altasl * M2FT;

                qv_agl_m.number = _host.cs.alt;
                qv_agl_ft.number = _host.cs.alt * M2FT;

                qv_vrate_ms.number = -_host.cs.vz;
                qv_vrate_fts.number = -_host.cs.vz * M2FT;

                qv_spd_ms.number = _host.cs.groundspeed;
                qv_spd_mph.number = _host.cs.groundspeed * MS2MPH;

                qv_dist_km.number = _host.cs.DistToHome / 1000.0;
                qv_dist_mi.number = _host.cs.DistToHome * M2MILE; 


            }
        }
    }
}
