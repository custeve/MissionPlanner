
namespace MissionPlanner.Controls
{
    partial class AntTracker
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
            this.label1 = new System.Windows.Forms.Label();
            this.CMB_baudrate = new System.Windows.Forms.ComboBox();
            this.BUT_connect = new MissionPlanner.Controls.MyButton();
            this.CMB_serialport = new System.Windows.Forms.ComboBox();
            this.TXT_GCS_position = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TXT_rot_position = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TXT_AC_position = new System.Windows.Forms.Label();
            this.lineSeparator1 = new MissionPlanner.Controls.LineSeparator();
            this.TXT_AZ_MAV = new System.Windows.Forms.TextBox();
            this.TXT_EL_MAV = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lineSeparator2 = new MissionPlanner.Controls.LineSeparator();
            this.but_usc_connect = new MissionPlanner.Controls.MyButton();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_status = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_ch0 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_ch1 = new System.Windows.Forms.TextBox();
            this.checkStateRenderer1 = new BrightIdeasSoftware.CheckStateRenderer();
            this.cb_auto = new System.Windows.Forms.CheckBox();
            this.num_ch0 = new System.Windows.Forms.NumericUpDown();
            this.num_ch1 = new System.Windows.Forms.NumericUpDown();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.but_az_0 = new System.Windows.Forms.Button();
            this.but_el_0 = new System.Windows.Forms.Button();
            this.but_az_max = new System.Windows.Forms.Button();
            this.but_el_90 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.USE_MC = new MissionPlanner.Controls.MyButton();
            ((System.ComponentModel.ISupportInitialize)(this.num_ch0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_ch1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 415);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Pick the PWM Port for Rotator";
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
            this.CMB_baudrate.Location = new System.Drawing.Point(131, 431);
            this.CMB_baudrate.Name = "CMB_baudrate";
            this.CMB_baudrate.Size = new System.Drawing.Size(97, 21);
            this.CMB_baudrate.TabIndex = 20;
            // 
            // BUT_connect
            // 
            this.BUT_connect.Location = new System.Drawing.Point(242, 428);
            this.BUT_connect.Name = "BUT_connect";
            this.BUT_connect.Size = new System.Drawing.Size(75, 23);
            this.BUT_connect.TabIndex = 19;
            this.BUT_connect.Text = "Connect";
            this.BUT_connect.TextColorNotEnabled = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(87)))), ((int)(((byte)(4)))));
            this.BUT_connect.UseVisualStyleBackColor = true;
            this.BUT_connect.Click += new System.EventHandler(this.BUT_connect_Click);
            // 
            // CMB_serialport
            // 
            this.CMB_serialport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMB_serialport.FormattingEnabled = true;
            this.CMB_serialport.Location = new System.Drawing.Point(4, 432);
            this.CMB_serialport.Name = "CMB_serialport";
            this.CMB_serialport.Size = new System.Drawing.Size(121, 21);
            this.CMB_serialport.TabIndex = 18;
            // 
            // TXT_GCS_position
            // 
            this.TXT_GCS_position.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_GCS_position.Location = new System.Drawing.Point(3, 117);
            this.TXT_GCS_position.Name = "TXT_GCS_position";
            this.TXT_GCS_position.Size = new System.Drawing.Size(351, 26);
            this.TXT_GCS_position.TabIndex = 22;
            this.TXT_GCS_position.Text = "0,0,0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "GCS Position ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 465);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Rotator Position";
            // 
            // TXT_rot_position
            // 
            this.TXT_rot_position.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_rot_position.Location = new System.Drawing.Point(4, 479);
            this.TXT_rot_position.Name = "TXT_rot_position";
            this.TXT_rot_position.Size = new System.Drawing.Size(313, 26);
            this.TXT_rot_position.TabIndex = 24;
            this.TXT_rot_position.Text = "0,0,0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "AC Position ";
            // 
            // TXT_AC_position
            // 
            this.TXT_AC_position.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_AC_position.Location = new System.Drawing.Point(3, 157);
            this.TXT_AC_position.Name = "TXT_AC_position";
            this.TXT_AC_position.Size = new System.Drawing.Size(351, 26);
            this.TXT_AC_position.TabIndex = 26;
            this.TXT_AC_position.Text = "0,0,0";
            // 
            // lineSeparator1
            // 
            this.lineSeparator1.Location = new System.Drawing.Point(7, 405);
            this.lineSeparator1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lineSeparator1.MaximumSize = new System.Drawing.Size(1500, 2);
            this.lineSeparator1.MinimumSize = new System.Drawing.Size(0, 2);
            this.lineSeparator1.Name = "lineSeparator1";
            this.lineSeparator1.Size = new System.Drawing.Size(310, 2);
            this.lineSeparator1.TabIndex = 28;
            // 
            // TXT_AZ_MAV
            // 
            this.TXT_AZ_MAV.Location = new System.Drawing.Point(86, 26);
            this.TXT_AZ_MAV.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TXT_AZ_MAV.Name = "TXT_AZ_MAV";
            this.TXT_AZ_MAV.Size = new System.Drawing.Size(76, 20);
            this.TXT_AZ_MAV.TabIndex = 29;
            // 
            // TXT_EL_MAV
            // 
            this.TXT_EL_MAV.Location = new System.Drawing.Point(86, 49);
            this.TXT_EL_MAV.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TXT_EL_MAV.Name = "TXT_EL_MAV";
            this.TXT_EL_MAV.Size = new System.Drawing.Size(76, 20);
            this.TXT_EL_MAV.TabIndex = 30;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "AZ to MAV";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "EL to MAV";
            // 
            // lineSeparator2
            // 
            this.lineSeparator2.Location = new System.Drawing.Point(6, 185);
            this.lineSeparator2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lineSeparator2.MaximumSize = new System.Drawing.Size(1500, 2);
            this.lineSeparator2.MinimumSize = new System.Drawing.Size(0, 2);
            this.lineSeparator2.Name = "lineSeparator2";
            this.lineSeparator2.Size = new System.Drawing.Size(310, 2);
            this.lineSeparator2.TabIndex = 33;
            // 
            // but_usc_connect
            // 
            this.but_usc_connect.Location = new System.Drawing.Point(241, 193);
            this.but_usc_connect.Name = "but_usc_connect";
            this.but_usc_connect.Size = new System.Drawing.Size(75, 23);
            this.but_usc_connect.TabIndex = 34;
            this.but_usc_connect.Text = "Connect";
            this.but_usc_connect.TextColorNotEnabled = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(87)))), ((int)(((byte)(4)))));
            this.but_usc_connect.UseVisualStyleBackColor = true;
            this.but_usc_connect.Click += new System.EventHandler(this.but_usc_connect_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 197);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 13);
            this.label7.TabIndex = 35;
            this.label7.Text = "Pololu Maestro Controller";
            // 
            // txt_status
            // 
            this.txt_status.Location = new System.Drawing.Point(69, 223);
            this.txt_status.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_status.Name = "txt_status";
            this.txt_status.Size = new System.Drawing.Size(248, 20);
            this.txt_status.TabIndex = 36;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 226);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 37;
            this.label8.Text = "Connection";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(129, 249);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 13);
            this.label9.TabIndex = 39;
            this.label9.Text = "Channel 0 (AZ)";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txt_ch0
            // 
            this.txt_ch0.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txt_ch0.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ch0.Location = new System.Drawing.Point(124, 266);
            this.txt_ch0.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_ch0.Name = "txt_ch0";
            this.txt_ch0.Size = new System.Drawing.Size(91, 17);
            this.txt_ch0.TabIndex = 38;
            this.txt_ch0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(225, 249);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 13);
            this.label10.TabIndex = 41;
            this.label10.Text = "Channel 1 (EL)";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txt_ch1
            // 
            this.txt_ch1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txt_ch1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ch1.Location = new System.Drawing.Point(220, 266);
            this.txt_ch1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_ch1.Name = "txt_ch1";
            this.txt_ch1.Size = new System.Drawing.Size(91, 17);
            this.txt_ch1.TabIndex = 40;
            this.txt_ch1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cb_auto
            // 
            this.cb_auto.AutoSize = true;
            this.cb_auto.Location = new System.Drawing.Point(154, 198);
            this.cb_auto.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cb_auto.Name = "cb_auto";
            this.cb_auto.Size = new System.Drawing.Size(79, 17);
            this.cb_auto.TabIndex = 42;
            this.cb_auto.Text = "Auto Track";
            this.cb_auto.UseVisualStyleBackColor = true;
            // 
            // num_ch0
            // 
            this.num_ch0.Location = new System.Drawing.Point(124, 284);
            this.num_ch0.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.num_ch0.Name = "num_ch0";
            this.num_ch0.Size = new System.Drawing.Size(90, 20);
            this.num_ch0.TabIndex = 43;
            // 
            // num_ch1
            // 
            this.num_ch1.Location = new System.Drawing.Point(220, 285);
            this.num_ch1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.num_ch1.Name = "num_ch1";
            this.num_ch1.Size = new System.Drawing.Size(90, 20);
            this.num_ch1.TabIndex = 44;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 266);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 13);
            this.label11.TabIndex = 45;
            this.label11.Text = "Current output Value";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 285);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(109, 13);
            this.label12.TabIndex = 46;
            this.label12.Text = "Mapped output Value";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // but_az_0
            // 
            this.but_az_0.Location = new System.Drawing.Point(124, 307);
            this.but_az_0.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.but_az_0.Name = "but_az_0";
            this.but_az_0.Size = new System.Drawing.Size(90, 19);
            this.but_az_0.TabIndex = 47;
            this.but_az_0.Text = "AZ = 0";
            this.but_az_0.UseVisualStyleBackColor = true;
            this.but_az_0.Click += new System.EventHandler(this.but_az_0_Click);
            // 
            // but_el_0
            // 
            this.but_el_0.Location = new System.Drawing.Point(220, 308);
            this.but_el_0.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.but_el_0.Name = "but_el_0";
            this.but_el_0.Size = new System.Drawing.Size(90, 19);
            this.but_el_0.TabIndex = 48;
            this.but_el_0.Text = "EL = 0";
            this.but_el_0.UseVisualStyleBackColor = true;
            this.but_el_0.Click += new System.EventHandler(this.but_el_0_Click);
            // 
            // but_az_max
            // 
            this.but_az_max.Location = new System.Drawing.Point(124, 353);
            this.but_az_max.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.but_az_max.Name = "but_az_max";
            this.but_az_max.Size = new System.Drawing.Size(90, 19);
            this.but_az_max.TabIndex = 49;
            this.but_az_max.Text = "AZ = 360";
            this.but_az_max.UseVisualStyleBackColor = true;
            this.but_az_max.Click += new System.EventHandler(this.but_az_max_Click);
            // 
            // but_el_90
            // 
            this.but_el_90.Location = new System.Drawing.Point(220, 353);
            this.but_el_90.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.but_el_90.Name = "but_el_90";
            this.but_el_90.Size = new System.Drawing.Size(90, 19);
            this.but_el_90.TabIndex = 50;
            this.but_el_90.Text = "EL = 90";
            this.but_el_90.UseVisualStyleBackColor = true;
            this.but_el_90.Click += new System.EventHandler(this.but_el_90_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(124, 331);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 19);
            this.button1.TabIndex = 51;
            this.button1.Text = "AZ = 180";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(220, 332);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 19);
            this.button2.TabIndex = 52;
            this.button2.Text = "EL=45";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // USE_MC
            // 
            this.USE_MC.Location = new System.Drawing.Point(241, 103);
            this.USE_MC.Name = "USE_MC";
            this.USE_MC.Size = new System.Drawing.Size(75, 23);
            this.USE_MC.TabIndex = 53;
            this.USE_MC.Text = "Use Map Center";
            this.USE_MC.TextColorNotEnabled = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(87)))), ((int)(((byte)(4)))));
            this.USE_MC.UseVisualStyleBackColor = true;
            this.USE_MC.Click += new System.EventHandler(this.USE_MC_Click);
            // 
            // AntTracker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.USE_MC);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.but_el_90);
            this.Controls.Add(this.but_az_max);
            this.Controls.Add(this.but_el_0);
            this.Controls.Add(this.but_az_0);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.num_ch1);
            this.Controls.Add(this.num_ch0);
            this.Controls.Add(this.cb_auto);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt_ch1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txt_ch0);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_status);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.but_usc_connect);
            this.Controls.Add(this.lineSeparator2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TXT_EL_MAV);
            this.Controls.Add(this.TXT_AZ_MAV);
            this.Controls.Add(this.lineSeparator1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TXT_AC_position);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TXT_rot_position);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TXT_GCS_position);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CMB_baudrate);
            this.Controls.Add(this.BUT_connect);
            this.Controls.Add(this.CMB_serialport);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AntTracker";
            this.Size = new System.Drawing.Size(333, 518);
            ((System.ComponentModel.ISupportInitialize)(this.num_ch0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_ch1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CMB_baudrate;
        private MyButton BUT_connect;
        private System.Windows.Forms.ComboBox CMB_serialport;
        private System.Windows.Forms.Label TXT_GCS_position;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label TXT_rot_position;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label TXT_AC_position;
        private LineSeparator lineSeparator1;
        private System.Windows.Forms.TextBox TXT_AZ_MAV;
        private System.Windows.Forms.TextBox TXT_EL_MAV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private LineSeparator lineSeparator2;
        private MyButton but_usc_connect;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_status;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_ch0;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_ch1;
        private BrightIdeasSoftware.CheckStateRenderer checkStateRenderer1;
        private System.Windows.Forms.CheckBox cb_auto;
        private System.Windows.Forms.NumericUpDown num_ch0;
        private System.Windows.Forms.NumericUpDown num_ch1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button but_az_0;
        private System.Windows.Forms.Button but_el_0;
        private System.Windows.Forms.Button but_az_max;
        private System.Windows.Forms.Button but_el_90;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private MyButton USE_MC;
    }
}
