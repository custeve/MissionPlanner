
namespace MissionPlanner.Controls
{
    partial class HORUS_PreFlight
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
            this.BUT_arm = new MissionPlanner.Controls.MyButton();
            this.BUT_asCal = new MissionPlanner.Controls.MyButton();
            this.TXT_msgBox = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.BUT_SET_AUTO = new MissionPlanner.Controls.MyButton();
            this.CB_pilotReady = new System.Windows.Forms.CheckBox();
            this.CB_IsArmed = new System.Windows.Forms.CheckBox();
            this.CB_notFlying = new System.Windows.Forms.CheckBox();
            this.CB_notAuto = new System.Windows.Forms.CheckBox();
            this.CB_payload_rdy = new System.Windows.Forms.CheckBox();
            this.CB_paco_rdy = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.cb_openHORUSPanel = new System.Windows.Forms.CheckBox();
            this.scrollableControl1 = new System.Windows.Forms.ScrollableControl();
            this.lblParams = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.cbMission = new System.Windows.Forms.CheckBox();
            this.but_openDSP = new MissionPlanner.Controls.MyButton();
            this.scrollableControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BUT_arm
            // 
            this.BUT_arm.Enabled = false;
            this.BUT_arm.Location = new System.Drawing.Point(13, 192);
            this.BUT_arm.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BUT_arm.Name = "BUT_arm";
            this.BUT_arm.Size = new System.Drawing.Size(100, 28);
            this.BUT_arm.TabIndex = 0;
            this.BUT_arm.Text = "ARM";
            this.BUT_arm.TextColorNotEnabled = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(87)))), ((int)(((byte)(4)))));
            this.BUT_arm.UseVisualStyleBackColor = true;
            this.BUT_arm.Click += new System.EventHandler(this.BUT_arm_Click);
            // 
            // BUT_asCal
            // 
            this.BUT_asCal.Location = new System.Drawing.Point(13, 128);
            this.BUT_asCal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BUT_asCal.Name = "BUT_asCal";
            this.BUT_asCal.Size = new System.Drawing.Size(100, 28);
            this.BUT_asCal.TabIndex = 1;
            this.BUT_asCal.Text = "Airsped Cal";
            this.BUT_asCal.TextColorNotEnabled = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(87)))), ((int)(((byte)(4)))));
            this.BUT_asCal.UseVisualStyleBackColor = true;
            this.BUT_asCal.Click += new System.EventHandler(this.BUT_asCal_Click);
            // 
            // TXT_msgBox
            // 
            this.TXT_msgBox.Location = new System.Drawing.Point(8, 454);
            this.TXT_msgBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TXT_msgBox.Name = "TXT_msgBox";
            this.TXT_msgBox.Size = new System.Drawing.Size(433, 102);
            this.TXT_msgBox.TabIndex = 4;
            this.TXT_msgBox.Text = "";
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // BUT_SET_AUTO
            // 
            this.BUT_SET_AUTO.Enabled = false;
            this.BUT_SET_AUTO.Location = new System.Drawing.Point(13, 356);
            this.BUT_SET_AUTO.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BUT_SET_AUTO.Name = "BUT_SET_AUTO";
            this.BUT_SET_AUTO.Size = new System.Drawing.Size(100, 28);
            this.BUT_SET_AUTO.TabIndex = 6;
            this.BUT_SET_AUTO.Text = "Set Auto";
            this.BUT_SET_AUTO.TextColorNotEnabled = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(87)))), ((int)(((byte)(4)))));
            this.BUT_SET_AUTO.UseVisualStyleBackColor = true;
            this.BUT_SET_AUTO.Click += new System.EventHandler(this.BUT_SET_AUTO_Click);
            // 
            // CB_pilotReady
            // 
            this.CB_pilotReady.AutoSize = true;
            this.CB_pilotReady.Enabled = false;
            this.CB_pilotReady.Location = new System.Drawing.Point(10, 327);
            this.CB_pilotReady.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CB_pilotReady.Name = "CB_pilotReady";
            this.CB_pilotReady.Size = new System.Drawing.Size(112, 20);
            this.CB_pilotReady.TabIndex = 10;
            this.CB_pilotReady.Text = "Pilot is Ready";
            this.CB_pilotReady.UseVisualStyleBackColor = true;
            // 
            // CB_IsArmed
            // 
            this.CB_IsArmed.AutoSize = true;
            this.CB_IsArmed.BackColor = System.Drawing.SystemColors.ControlDark;
            this.CB_IsArmed.Location = new System.Drawing.Point(13, 227);
            this.CB_IsArmed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CB_IsArmed.Name = "CB_IsArmed";
            this.CB_IsArmed.Size = new System.Drawing.Size(69, 20);
            this.CB_IsArmed.TabIndex = 12;
            this.CB_IsArmed.Text = "Armed";
            this.CB_IsArmed.UseVisualStyleBackColor = false;
            // 
            // CB_notFlying
            // 
            this.CB_notFlying.AutoSize = true;
            this.CB_notFlying.BackColor = System.Drawing.SystemColors.ControlDark;
            this.CB_notFlying.Location = new System.Drawing.Point(10, 305);
            this.CB_notFlying.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CB_notFlying.Name = "CB_notFlying";
            this.CB_notFlying.Size = new System.Drawing.Size(89, 20);
            this.CB_notFlying.TabIndex = 13;
            this.CB_notFlying.Text = "Not Flying";
            this.CB_notFlying.UseVisualStyleBackColor = false;
            // 
            // CB_notAuto
            // 
            this.CB_notAuto.AutoSize = true;
            this.CB_notAuto.BackColor = System.Drawing.SystemColors.ControlDark;
            this.CB_notAuto.Location = new System.Drawing.Point(11, 163);
            this.CB_notAuto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CB_notAuto.Name = "CB_notAuto";
            this.CB_notAuto.Size = new System.Drawing.Size(118, 20);
            this.CB_notAuto.TabIndex = 14;
            this.CB_notAuto.Text = "Mode Not Auto";
            this.CB_notAuto.UseVisualStyleBackColor = false;
            // 
            // CB_payload_rdy
            // 
            this.CB_payload_rdy.AutoSize = true;
            this.CB_payload_rdy.Location = new System.Drawing.Point(10, 252);
            this.CB_payload_rdy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CB_payload_rdy.Name = "CB_payload_rdy";
            this.CB_payload_rdy.Size = new System.Drawing.Size(124, 20);
            this.CB_payload_rdy.TabIndex = 15;
            this.CB_payload_rdy.Text = "Payload Ready";
            this.CB_payload_rdy.UseVisualStyleBackColor = true;
            // 
            // CB_paco_rdy
            // 
            this.CB_paco_rdy.AutoSize = true;
            this.CB_paco_rdy.Location = new System.Drawing.Point(10, 279);
            this.CB_paco_rdy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CB_paco_rdy.Name = "CB_paco_rdy";
            this.CB_paco_rdy.Size = new System.Drawing.Size(127, 20);
            this.CB_paco_rdy.TabIndex = 16;
            this.CB_paco_rdy.Text = "PAC-O Checklist";
            this.CB_paco_rdy.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(10, 81);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(130, 20);
            this.checkBox1.TabIndex = 17;
            this.checkBox1.Text = "Ant Track Ready";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // cb_openHORUSPanel
            // 
            this.cb_openHORUSPanel.AutoSize = true;
            this.cb_openHORUSPanel.Location = new System.Drawing.Point(11, 39);
            this.cb_openHORUSPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb_openHORUSPanel.Name = "cb_openHORUSPanel";
            this.cb_openHORUSPanel.Size = new System.Drawing.Size(114, 36);
            this.cb_openHORUSPanel.TabIndex = 18;
            this.cb_openHORUSPanel.Text = "Open HORUS\r\nPanel";
            this.cb_openHORUSPanel.UseVisualStyleBackColor = true;
            this.cb_openHORUSPanel.CheckedChanged += new System.EventHandler(this.cb_openHORUSPanel_CheckedChanged);
            // 
            // scrollableControl1
            // 
            this.scrollableControl1.Controls.Add(this.lblParams);
            this.scrollableControl1.Font = new System.Drawing.Font("Lucida Sans Typewriter", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scrollableControl1.Location = new System.Drawing.Point(147, 7);
            this.scrollableControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.scrollableControl1.Name = "scrollableControl1";
            this.scrollableControl1.Size = new System.Drawing.Size(299, 398);
            this.scrollableControl1.TabIndex = 19;
            this.scrollableControl1.Text = "scrollableControl1";
            // 
            // lblParams
            // 
            this.lblParams.AutoSize = true;
            this.lblParams.Location = new System.Drawing.Point(5, 5);
            this.lblParams.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblParams.Name = "lblParams";
            this.lblParams.Size = new System.Drawing.Size(49, 13);
            this.lblParams.TabIndex = 0;
            this.lblParams.Text = "label1";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.groupBox1.Location = new System.Drawing.Point(11, 412);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(435, 34);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Setup Mission Planner Panel This Wide";
            // 
            // timer2
            // 
            this.timer2.Interval = 2000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // cbMission
            // 
            this.cbMission.AutoSize = true;
            this.cbMission.Location = new System.Drawing.Point(11, 107);
            this.cbMission.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbMission.Name = "cbMission";
            this.cbMission.Size = new System.Drawing.Size(116, 20);
            this.cbMission.TabIndex = 21;
            this.cbMission.Text = "Check Mission";
            this.cbMission.UseVisualStyleBackColor = true;
            // 
            // but_openDSP
            // 
            this.but_openDSP.Location = new System.Drawing.Point(13, 7);
            this.but_openDSP.Margin = new System.Windows.Forms.Padding(4);
            this.but_openDSP.Name = "but_openDSP";
            this.but_openDSP.Size = new System.Drawing.Size(100, 28);
            this.but_openDSP.TabIndex = 22;
            this.but_openDSP.Text = "Open DSP";
            this.but_openDSP.TextColorNotEnabled = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(87)))), ((int)(((byte)(4)))));
            this.but_openDSP.UseVisualStyleBackColor = true;
            this.but_openDSP.Click += new System.EventHandler(this.but_openDSP_Click);
            // 
            // HORUS_PreFlight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.but_openDSP);
            this.Controls.Add(this.cbMission);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.scrollableControl1);
            this.Controls.Add(this.cb_openHORUSPanel);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.CB_paco_rdy);
            this.Controls.Add(this.CB_payload_rdy);
            this.Controls.Add(this.CB_notAuto);
            this.Controls.Add(this.CB_notFlying);
            this.Controls.Add(this.CB_IsArmed);
            this.Controls.Add(this.CB_pilotReady);
            this.Controls.Add(this.BUT_SET_AUTO);
            this.Controls.Add(this.TXT_msgBox);
            this.Controls.Add(this.BUT_asCal);
            this.Controls.Add(this.BUT_arm);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "HORUS_PreFlight";
            this.Size = new System.Drawing.Size(452, 570);
            this.scrollableControl1.ResumeLayout(false);
            this.scrollableControl1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyButton BUT_arm;
        private MyButton BUT_asCal;
        private System.Windows.Forms.RichTextBox TXT_msgBox;
        private System.Windows.Forms.Timer timer1;
        private MyButton BUT_SET_AUTO;
        private System.Windows.Forms.CheckBox CB_pilotReady;
        private System.Windows.Forms.CheckBox CB_IsArmed;
        private System.Windows.Forms.CheckBox CB_notFlying;
        private System.Windows.Forms.CheckBox CB_notAuto;
        private System.Windows.Forms.CheckBox CB_payload_rdy;
        private System.Windows.Forms.CheckBox CB_paco_rdy;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox cb_openHORUSPanel;
        private System.Windows.Forms.ScrollableControl scrollableControl1;
        private System.Windows.Forms.Label lblParams;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.CheckBox cbMission;
        private MyButton but_openDSP;
    }
}
