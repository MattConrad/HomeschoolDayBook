namespace HomeSchoolDayBook
{
    partial class frpSplash
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
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblSplashTitle = new System.Windows.Forms.Label();
            this.lblSplashVersion = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblSplashTitle
            // 
            this.lblSplashTitle.AutoSize = true;
            this.lblSplashTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSplashTitle.Location = new System.Drawing.Point(42, 32);
            this.lblSplashTitle.Name = "lblSplashTitle";
            this.lblSplashTitle.Size = new System.Drawing.Size(309, 24);
            this.lblSplashTitle.TabIndex = 0;
            this.lblSplashTitle.Text = "Loading: Homeschool Day Book";
            // 
            // lblSplashVersion
            // 
            this.lblSplashVersion.AutoSize = true;
            this.lblSplashVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSplashVersion.Location = new System.Drawing.Point(161, 72);
            this.lblSplashVersion.Name = "lblSplashVersion";
            this.lblSplashVersion.Size = new System.Drawing.Size(71, 13);
            this.lblSplashVersion.TabIndex = 1;
            this.lblSplashVersion.Text = "Version 1.0";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 250;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frpSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(393, 126);
            this.Controls.Add(this.lblSplashVersion);
            this.Controls.Add(this.lblSplashTitle);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frpSplash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Homeschool Day Book (Loading)";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSplashTitle;
        private System.Windows.Forms.Label lblSplashVersion;
        private System.Windows.Forms.Timer timer1;
    }
}