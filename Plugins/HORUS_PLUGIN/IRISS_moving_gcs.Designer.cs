
namespace MissionPlanner.Controls
{
    partial class IRISS_moving_gcs
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
            this.chk_relalt = new System.Windows.Forms.CheckBox();
            this.CHK_updateRallyPnt = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CMB_updaterate = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CMB_baudrate = new System.Windows.Forms.ComboBox();
            this.BUT_connect = new MissionPlanner.Controls.MyButton();
            this.CMB_serialport = new System.Windows.Forms.ComboBox();
            this.USE_MC = new MissionPlanner.Controls.MyButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cb_use_course = new System.Windows.Forms.CheckBox();
            this.num_no_gps_hdg = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.TXT_gps_out = new System.Windows.Forms.TextBox();
            this.LBL_location = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.num_no_gps_hdg)).BeginInit();
            this.SuspendLayout();
            // 
            // chk_relalt
            // 
            this.chk_relalt.AutoSize = true;
            this.chk_relalt.Location = new System.Drawing.Point(271, 51);
            this.chk_relalt.Name = "chk_relalt";
            this.chk_relalt.Size = new System.Drawing.Size(77, 17);
            this.chk_relalt.TabIndex = 19;
            this.chk_relalt.Text = "RelativeAlt";
            this.chk_relalt.UseVisualStyleBackColor = true;
            // 
            // CHK_updateRallyPnt
            // 
            this.CHK_updateRallyPnt.AutoSize = true;
            this.CHK_updateRallyPnt.Location = new System.Drawing.Point(142, 51);
            this.CHK_updateRallyPnt.Name = "CHK_updateRallyPnt";
            this.CHK_updateRallyPnt.Size = new System.Drawing.Size(123, 17);
            this.CHK_updateRallyPnt.TabIndex = 18;
            this.CHK_updateRallyPnt.Text = "Update Rally Point 0";
            this.CHK_updateRallyPnt.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(254, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Select your update rate\r\n";
            // 
            // CMB_updaterate
            // 
            this.CMB_updaterate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMB_updaterate.FormattingEnabled = true;
            this.CMB_updaterate.Items.AddRange(new object[] {
            "2hz",
            "1hz",
            "0.5hz",
            "0.25hz"});
            this.CMB_updaterate.Location = new System.Drawing.Point(281, 30);
            this.CMB_updaterate.Name = "CMB_updaterate";
            this.CMB_updaterate.Size = new System.Drawing.Size(75, 21);
            this.CMB_updaterate.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Pick the Nmea gps port and baud rate\r\n";
            // 
            // CMB_baudrate
            // 
            this.CMB_baudrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMB_baudrate.FormattingEnabled = true;
            this.CMB_baudrate.Items.AddRange(new object[] {
            "4800",
            "9600",
            "14400",
            "19200",
            "28800",
            "38400",
            "57600",
            "115200"});
            this.CMB_baudrate.Location = new System.Drawing.Point(142, 29);
            this.CMB_baudrate.Name = "CMB_baudrate";
            this.CMB_baudrate.Size = new System.Drawing.Size(97, 21);
            this.CMB_baudrate.TabIndex = 12;
            // 
            // BUT_connect
            // 
            this.BUT_connect.Location = new System.Drawing.Point(362, 28);
            this.BUT_connect.Name = "BUT_connect";
            this.BUT_connect.Size = new System.Drawing.Size(75, 23);
            this.BUT_connect.TabIndex = 11;
            this.BUT_connect.Text = "Connect";
            this.BUT_connect.TextColorNotEnabled = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(87)))), ((int)(((byte)(4)))));
            this.BUT_connect.UseVisualStyleBackColor = true;
            this.BUT_connect.Click += new System.EventHandler(this.BUT_connect_Click);
            // 
            // CMB_serialport
            // 
            this.CMB_serialport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMB_serialport.FormattingEnabled = true;
            this.CMB_serialport.Location = new System.Drawing.Point(15, 30);
            this.CMB_serialport.Name = "CMB_serialport";
            this.CMB_serialport.Size = new System.Drawing.Size(121, 21);
            this.CMB_serialport.TabIndex = 10;
            this.CMB_serialport.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.CMB_serialport_MouseDoubleClick);
            // 
            // USE_MC
            // 
            this.USE_MC.Location = new System.Drawing.Point(362, 54);
            this.USE_MC.Name = "USE_MC";
            this.USE_MC.Size = new System.Drawing.Size(75, 23);
            this.USE_MC.TabIndex = 20;
            this.USE_MC.Text = "Use Map Center";
            this.USE_MC.TextColorNotEnabled = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(87)))), ((int)(((byte)(4)))));
            this.USE_MC.UseVisualStyleBackColor = true;
            this.USE_MC.Click += new System.EventHandler(this.USE_MC_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cb_use_course
            // 
            this.cb_use_course.AutoSize = true;
            this.cb_use_course.Checked = true;
            this.cb_use_course.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_use_course.Location = new System.Drawing.Point(15, 51);
            this.cb_use_course.Name = "cb_use_course";
            this.cb_use_course.Size = new System.Drawing.Size(105, 17);
            this.cb_use_course.TabIndex = 21;
            this.cb_use_course.Text = "Use GPS course";
            this.cb_use_course.UseVisualStyleBackColor = true;
            // 
            // num_no_gps_hdg
            // 
            this.num_no_gps_hdg.DecimalPlaces = 1;
            this.num_no_gps_hdg.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_no_gps_hdg.Increment = new decimal(new int[] {
            45,
            0,
            0,
            0});
            this.num_no_gps_hdg.Location = new System.Drawing.Point(380, 82);
            this.num_no_gps_hdg.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.num_no_gps_hdg.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            65536});
            this.num_no_gps_hdg.Name = "num_no_gps_hdg";
            this.num_no_gps_hdg.Size = new System.Drawing.Size(57, 17);
            this.num_no_gps_hdg.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(317, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 9);
            this.label3.TabIndex = 23;
            this.label3.Text = "Non-GPS HDG";
            // 
            // TXT_gps_out
            // 
            this.TXT_gps_out.BackColor = System.Drawing.SystemColors.Menu;
            this.TXT_gps_out.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TXT_gps_out.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_gps_out.Location = new System.Drawing.Point(159, 82);
            this.TXT_gps_out.Margin = new System.Windows.Forms.Padding(0);
            this.TXT_gps_out.Name = "TXT_gps_out";
            this.TXT_gps_out.ReadOnly = true;
            this.TXT_gps_out.Size = new System.Drawing.Size(191, 10);
            this.TXT_gps_out.TabIndex = 24;
            this.TXT_gps_out.Text = "...";
            this.TXT_gps_out.WordWrap = false;
            // 
            // LBL_location
            // 
            this.LBL_location.BackColor = System.Drawing.SystemColors.Menu;
            this.LBL_location.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LBL_location.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_location.Location = new System.Drawing.Point(9, 72);
            this.LBL_location.Margin = new System.Windows.Forms.Padding(0);
            this.LBL_location.Multiline = true;
            this.LBL_location.Name = "LBL_location";
            this.LBL_location.ReadOnly = true;
            this.LBL_location.Size = new System.Drawing.Size(150, 29);
            this.LBL_location.TabIndex = 25;
            this.LBL_location.Text = "...";
            // 
            // IRISS_moving_gcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LBL_location);
            this.Controls.Add(this.TXT_gps_out);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.num_no_gps_hdg);
            this.Controls.Add(this.cb_use_course);
            this.Controls.Add(this.USE_MC);
            this.Controls.Add(this.chk_relalt);
            this.Controls.Add(this.CHK_updateRallyPnt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CMB_updaterate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CMB_baudrate);
            this.Controls.Add(this.BUT_connect);
            this.Controls.Add(this.CMB_serialport);
            this.Name = "IRISS_moving_gcs";
            this.Size = new System.Drawing.Size(551, 126);
            ((System.ComponentModel.ISupportInitialize)(this.num_no_gps_hdg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chk_relalt;
        private System.Windows.Forms.CheckBox CHK_updateRallyPnt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CMB_updaterate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CMB_baudrate;
        private MyButton BUT_connect;
        private System.Windows.Forms.ComboBox CMB_serialport;
        private MyButton USE_MC;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox cb_use_course;
        private System.Windows.Forms.NumericUpDown num_no_gps_hdg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TXT_gps_out;
        private System.Windows.Forms.TextBox LBL_location;
    }
}
