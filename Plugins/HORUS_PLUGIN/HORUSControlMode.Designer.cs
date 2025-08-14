
namespace MissionPlanner.Controls
{
    partial class HORUSControlMode
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
            this.setFBWA = new MissionPlanner.Controls.MyButton();
            this.setAuto = new MissionPlanner.Controls.MyButton();
            this.setGuided = new MissionPlanner.Controls.MyButton();
            this.setRTL = new MissionPlanner.Controls.MyButton();
            this.butBalloon = new MissionPlanner.Controls.MyButton();
            this.butParachute = new MissionPlanner.Controls.MyButton();
            this.SuspendLayout();
            // 
            // setFBWA
            // 
            this.setFBWA.Location = new System.Drawing.Point(4, 14);
            this.setFBWA.Name = "setFBWA";
            this.setFBWA.Size = new System.Drawing.Size(66, 48);
            this.setFBWA.TabIndex = 0;
            this.setFBWA.Text = "Set FBWA";
            this.setFBWA.TextColor = System.Drawing.Color.Black;
            this.setFBWA.TextColorNotEnabled = System.Drawing.Color.Black;
            this.setFBWA.UseVisualStyleBackColor = true;
            this.setFBWA.Click += new System.EventHandler(this.setFBWA_Click);
            // 
            // setAuto
            // 
            this.setAuto.Location = new System.Drawing.Point(76, 14);
            this.setAuto.Name = "setAuto";
            this.setAuto.Size = new System.Drawing.Size(66, 48);
            this.setAuto.TabIndex = 1;
            this.setAuto.Text = "Set AUTO";
            this.setAuto.TextColor = System.Drawing.Color.Black;
            this.setAuto.TextColorNotEnabled = System.Drawing.Color.Black;
            this.setAuto.UseVisualStyleBackColor = true;
            this.setAuto.Click += new System.EventHandler(this.setAuto_Click);
            // 
            // setGuided
            // 
            this.setGuided.Location = new System.Drawing.Point(148, 14);
            this.setGuided.Name = "setGuided";
            this.setGuided.Size = new System.Drawing.Size(67, 48);
            this.setGuided.TabIndex = 2;
            this.setGuided.Text = "Set Manual";
            this.setGuided.TextColor = System.Drawing.Color.Black;
            this.setGuided.TextColorNotEnabled = System.Drawing.Color.Black;
            this.setGuided.UseVisualStyleBackColor = true;
            this.setGuided.Click += new System.EventHandler(this.setManual_Click);
            // 
            // setRTL
            // 
            this.setRTL.BGGradBot = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.setRTL.BGGradTop = System.Drawing.Color.DarkOrange;
            this.setRTL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setRTL.Location = new System.Drawing.Point(4, 68);
            this.setRTL.Name = "setRTL";
            this.setRTL.Size = new System.Drawing.Size(67, 48);
            this.setRTL.TabIndex = 3;
            this.setRTL.Text = "Set RTL";
            this.setRTL.TextColor = System.Drawing.Color.Black;
            this.setRTL.TextColorNotEnabled = System.Drawing.Color.Black;
            this.setRTL.UseVisualStyleBackColor = true;
            this.setRTL.Click += new System.EventHandler(this.setRTL_Click);
            // 
            // butBalloon
            // 
            this.butBalloon.BGGradBot = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.butBalloon.BGGradTop = System.Drawing.Color.Red;
            this.butBalloon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butBalloon.Location = new System.Drawing.Point(77, 68);
            this.butBalloon.Name = "butBalloon";
            this.butBalloon.Size = new System.Drawing.Size(67, 48);
            this.butBalloon.TabIndex = 4;
            this.butBalloon.Text = "Cut Away Balloon ";
            this.butBalloon.TextColor = System.Drawing.Color.Black;
            this.butBalloon.TextColorNotEnabled = System.Drawing.Color.Black;
            this.butBalloon.UseVisualStyleBackColor = true;
            this.butBalloon.Click += new System.EventHandler(this.butBalloon_Click);
            // 
            // butParachute
            // 
            this.butParachute.BGGradBot = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.butParachute.BGGradTop = System.Drawing.Color.Red;
            this.butParachute.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butParachute.Location = new System.Drawing.Point(148, 68);
            this.butParachute.Name = "butParachute";
            this.butParachute.Size = new System.Drawing.Size(67, 48);
            this.butParachute.TabIndex = 5;
            this.butParachute.Text = "Parachute";
            this.butParachute.TextColor = System.Drawing.Color.Black;
            this.butParachute.TextColorNotEnabled = System.Drawing.Color.Black;
            this.butParachute.UseVisualStyleBackColor = true;
            this.butParachute.Click += new System.EventHandler(this.butParachute_Click);
            // 
            // HORUSControlMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.butParachute);
            this.Controls.Add(this.butBalloon);
            this.Controls.Add(this.setRTL);
            this.Controls.Add(this.setGuided);
            this.Controls.Add(this.setAuto);
            this.Controls.Add(this.setFBWA);
            this.Name = "HORUSControlMode";
            this.Size = new System.Drawing.Size(223, 129);
            this.Load += new System.EventHandler(this.IRISSControlMode_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MyButton setFBWA;
        private MyButton setAuto;
        private MyButton setGuided;
        private MyButton setRTL;
        private MyButton butBalloon;
        private MyButton butParachute;
    }
}
