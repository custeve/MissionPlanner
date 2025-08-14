namespace MissionPlanner
{
    partial class HORUS_TAB
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.qv_alt_m = new MissionPlanner.Controls.QuickView();
            this.qv_alt_ft = new MissionPlanner.Controls.QuickView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.qv_vrate_fts = new MissionPlanner.Controls.QuickView();
            this.qv_vrate_ms = new MissionPlanner.Controls.QuickView();
            this.qv_spd_mph = new MissionPlanner.Controls.QuickView();
            this.qv_spd_ms = new MissionPlanner.Controls.QuickView();
            this.qv_dist_mi = new MissionPlanner.Controls.QuickView();
            this.qv_dist_km = new MissionPlanner.Controls.QuickView();
            this.qv_agl_ft = new MissionPlanner.Controls.QuickView();
            this.qv_agl_m = new MissionPlanner.Controls.QuickView();
            this.SuspendLayout();
            // 
            // qv_alt_m
            // 
            this.qv_alt_m.desc = "Alt ASL (m)";
            this.qv_alt_m.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qv_alt_m.Location = new System.Drawing.Point(3, 3);
            this.qv_alt_m.Name = "qv_alt_m";
            this.qv_alt_m.number = -9999D;
            this.qv_alt_m.numberColor = System.Drawing.Color.Empty;
            this.qv_alt_m.numberColorBackup = System.Drawing.Color.Empty;
            this.qv_alt_m.numberformat = "0.00";
            this.qv_alt_m.Size = new System.Drawing.Size(172, 83);
            this.qv_alt_m.TabIndex = 1;
            this.qv_alt_m.Text = "quickView1";
            // 
            // qv_alt_ft
            // 
            this.qv_alt_ft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.qv_alt_ft.desc = "";
            this.qv_alt_ft.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qv_alt_ft.Location = new System.Drawing.Point(155, 3);
            this.qv_alt_ft.Name = "qv_alt_ft";
            this.qv_alt_ft.number = -9999D;
            this.qv_alt_ft.numberColor = System.Drawing.Color.Empty;
            this.qv_alt_ft.numberColorBackup = System.Drawing.Color.Empty;
            this.qv_alt_ft.numberformat = "0.00";
            this.qv_alt_ft.Size = new System.Drawing.Size(172, 83);
            this.qv_alt_ft.TabIndex = 2;
            this.qv_alt_ft.Text = "quickView1";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // qv_vrate_fts
            // 
            this.qv_vrate_fts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.qv_vrate_fts.desc = "";
            this.qv_vrate_fts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qv_vrate_fts.Location = new System.Drawing.Point(155, 237);
            this.qv_vrate_fts.Name = "qv_vrate_fts";
            this.qv_vrate_fts.number = -9999D;
            this.qv_vrate_fts.numberColor = System.Drawing.Color.Empty;
            this.qv_vrate_fts.numberColorBackup = System.Drawing.Color.Empty;
            this.qv_vrate_fts.numberformat = "0.00";
            this.qv_vrate_fts.Size = new System.Drawing.Size(172, 83);
            this.qv_vrate_fts.TabIndex = 4;
            this.qv_vrate_fts.Text = "quickView1";
            // 
            // qv_vrate_ms
            // 
            this.qv_vrate_ms.desc = "Alt ASL (m)";
            this.qv_vrate_ms.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qv_vrate_ms.Location = new System.Drawing.Point(3, 237);
            this.qv_vrate_ms.Name = "qv_vrate_ms";
            this.qv_vrate_ms.number = -9999D;
            this.qv_vrate_ms.numberColor = System.Drawing.Color.Empty;
            this.qv_vrate_ms.numberColorBackup = System.Drawing.Color.Empty;
            this.qv_vrate_ms.numberformat = "0.00";
            this.qv_vrate_ms.Size = new System.Drawing.Size(172, 83);
            this.qv_vrate_ms.TabIndex = 3;
            this.qv_vrate_ms.Text = "quickView1";
            // 
            // qv_spd_mph
            // 
            this.qv_spd_mph.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.qv_spd_mph.desc = "";
            this.qv_spd_mph.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qv_spd_mph.Location = new System.Drawing.Point(155, 159);
            this.qv_spd_mph.Name = "qv_spd_mph";
            this.qv_spd_mph.number = -9999D;
            this.qv_spd_mph.numberColor = System.Drawing.Color.Empty;
            this.qv_spd_mph.numberColorBackup = System.Drawing.Color.Empty;
            this.qv_spd_mph.numberformat = "0.00";
            this.qv_spd_mph.Size = new System.Drawing.Size(172, 83);
            this.qv_spd_mph.TabIndex = 6;
            this.qv_spd_mph.Text = "quickView1";
            // 
            // qv_spd_ms
            // 
            this.qv_spd_ms.desc = "Alt ASL (m)";
            this.qv_spd_ms.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qv_spd_ms.Location = new System.Drawing.Point(3, 159);
            this.qv_spd_ms.Name = "qv_spd_ms";
            this.qv_spd_ms.number = -9999D;
            this.qv_spd_ms.numberColor = System.Drawing.Color.Empty;
            this.qv_spd_ms.numberColorBackup = System.Drawing.Color.Empty;
            this.qv_spd_ms.numberformat = "0.00";
            this.qv_spd_ms.Size = new System.Drawing.Size(172, 83);
            this.qv_spd_ms.TabIndex = 5;
            this.qv_spd_ms.Text = "quickView1";
            // 
            // qv_dist_mi
            // 
            this.qv_dist_mi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.qv_dist_mi.desc = "";
            this.qv_dist_mi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qv_dist_mi.Location = new System.Drawing.Point(155, 315);
            this.qv_dist_mi.Name = "qv_dist_mi";
            this.qv_dist_mi.number = -9999D;
            this.qv_dist_mi.numberColor = System.Drawing.Color.Empty;
            this.qv_dist_mi.numberColorBackup = System.Drawing.Color.Empty;
            this.qv_dist_mi.numberformat = "0.00";
            this.qv_dist_mi.Size = new System.Drawing.Size(172, 83);
            this.qv_dist_mi.TabIndex = 8;
            this.qv_dist_mi.Text = "quickView1";
            // 
            // qv_dist_km
            // 
            this.qv_dist_km.desc = "Alt ASL (m)";
            this.qv_dist_km.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qv_dist_km.Location = new System.Drawing.Point(3, 315);
            this.qv_dist_km.Name = "qv_dist_km";
            this.qv_dist_km.number = -9999D;
            this.qv_dist_km.numberColor = System.Drawing.Color.Empty;
            this.qv_dist_km.numberColorBackup = System.Drawing.Color.Empty;
            this.qv_dist_km.numberformat = "0.00";
            this.qv_dist_km.Size = new System.Drawing.Size(172, 83);
            this.qv_dist_km.TabIndex = 7;
            this.qv_dist_km.Text = "quickView1";
            // 
            // qv_agl_ft
            // 
            this.qv_agl_ft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.qv_agl_ft.desc = "";
            this.qv_agl_ft.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qv_agl_ft.Location = new System.Drawing.Point(155, 81);
            this.qv_agl_ft.Name = "qv_agl_ft";
            this.qv_agl_ft.number = -9999D;
            this.qv_agl_ft.numberColor = System.Drawing.Color.Empty;
            this.qv_agl_ft.numberColorBackup = System.Drawing.Color.Empty;
            this.qv_agl_ft.numberformat = "0.00";
            this.qv_agl_ft.Size = new System.Drawing.Size(172, 83);
            this.qv_agl_ft.TabIndex = 10;
            this.qv_agl_ft.Text = "quickView1";
            // 
            // qv_agl_m
            // 
            this.qv_agl_m.desc = "Alt ASL (m)";
            this.qv_agl_m.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qv_agl_m.Location = new System.Drawing.Point(3, 81);
            this.qv_agl_m.Name = "qv_agl_m";
            this.qv_agl_m.number = -9999D;
            this.qv_agl_m.numberColor = System.Drawing.Color.Empty;
            this.qv_agl_m.numberColorBackup = System.Drawing.Color.Empty;
            this.qv_agl_m.numberformat = "0.00";
            this.qv_agl_m.Size = new System.Drawing.Size(172, 83);
            this.qv_agl_m.TabIndex = 9;
            this.qv_agl_m.Text = "quickView1";
            // 
            // HORUS_TAB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.qv_agl_ft);
            this.Controls.Add(this.qv_agl_m);
            this.Controls.Add(this.qv_dist_mi);
            this.Controls.Add(this.qv_dist_km);
            this.Controls.Add(this.qv_spd_mph);
            this.Controls.Add(this.qv_spd_ms);
            this.Controls.Add(this.qv_vrate_fts);
            this.Controls.Add(this.qv_vrate_ms);
            this.Controls.Add(this.qv_alt_ft);
            this.Controls.Add(this.qv_alt_m);
            this.Name = "HORUS_TAB";
            this.Size = new System.Drawing.Size(364, 489);
            this.ResumeLayout(false);

        }

        #endregion
        private Controls.QuickView qv_alt_m;
        private Controls.QuickView qv_alt_ft;
        private System.Windows.Forms.Timer timer1;
        private Controls.QuickView qv_vrate_fts;
        private Controls.QuickView qv_vrate_ms;
        private Controls.QuickView qv_spd_mph;
        private Controls.QuickView qv_spd_ms;
        private Controls.QuickView qv_dist_mi;
        private Controls.QuickView qv_dist_km;
        private Controls.QuickView qv_agl_ft;
        private Controls.QuickView qv_agl_m;
    }
}
