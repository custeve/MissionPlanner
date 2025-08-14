namespace MissionPlanner
{
    partial class ADSB_Control
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
            this.butADSB1 = new MissionPlanner.Controls.MyButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.rtADSBList = new System.Windows.Forms.RichTextBox();
            this.numDevID = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numDevID)).BeginInit();
            this.SuspendLayout();
            // 
            // butADSB1
            // 
            this.butADSB1.Location = new System.Drawing.Point(4, 4);
            this.butADSB1.Name = "butADSB1";
            this.butADSB1.Size = new System.Drawing.Size(143, 31);
            this.butADSB1.TabIndex = 0;
            this.butADSB1.Text = "Run ADSB";
            this.butADSB1.TextColorNotEnabled = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(87)))), ((int)(((byte)(4)))));
            this.butADSB1.UseVisualStyleBackColor = true;
            this.butADSB1.Click += new System.EventHandler(this.butADSB1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // rtADSBList
            // 
            this.rtADSBList.Font = new System.Drawing.Font("Lucida Sans Typewriter", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtADSBList.Location = new System.Drawing.Point(4, 82);
            this.rtADSBList.Name = "rtADSBList";
            this.rtADSBList.Size = new System.Drawing.Size(446, 308);
            this.rtADSBList.TabIndex = 1;
            this.rtADSBList.Text = "";
            // 
            // numDevID
            // 
            this.numDevID.Location = new System.Drawing.Point(214, 11);
            this.numDevID.Name = "numDevID";
            this.numDevID.Size = new System.Drawing.Size(42, 20);
            this.numDevID.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(153, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Device ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(230, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 36);
            this.label2.TabIndex = 4;
            this.label2.Text = "Dump1090.exe must be installed at c:\\dump1090\\\r\nConnect to localhost:30005 to get" +
    " callsigns working. \r\nIf using FA Direct Etherenet: 169.254.145.55:30005\r\n";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ADSB_Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numDevID);
            this.Controls.Add(this.rtADSBList);
            this.Controls.Add(this.butADSB1);
            this.Name = "ADSB_Control";
            this.Size = new System.Drawing.Size(453, 393);
            ((System.ComponentModel.ISupportInitialize)(this.numDevID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.MyButton butADSB1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RichTextBox rtADSBList;
        private System.Windows.Forms.NumericUpDown numDevID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
