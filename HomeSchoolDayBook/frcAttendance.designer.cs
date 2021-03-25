namespace HomeSchoolDayBook
{
    partial class frcAttendance
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.kpnlMain = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.lblInstructionsAttendClick = new HomeSchoolDayBook.HSDSubKryptonPanelLabel();
            this.lblInstructionsAttendPlaceholders = new HomeSchoolDayBook.HSDSubKryptonPanelLabel();
            this.lblInstructionsAttendDefintion = new HomeSchoolDayBook.HSDSubKryptonPanelLabel();
            this.lbcMonthShown = new HomeSchoolDayBook.HSDSubKryptonPanelLabel();
            this.dtpMonthShown = new HomeSchoolDayBook.HSDKDateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlMain)).BeginInit();
            this.kpnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // kpnlMain
            // 
            this.kpnlMain.Controls.Add(this.lblInstructionsAttendClick);
            this.kpnlMain.Controls.Add(this.lblInstructionsAttendPlaceholders);
            this.kpnlMain.Controls.Add(this.lblInstructionsAttendDefintion);
            this.kpnlMain.Controls.Add(this.lbcMonthShown);
            this.kpnlMain.Controls.Add(this.dtpMonthShown);
            this.kpnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpnlMain.Location = new System.Drawing.Point(0, 0);
            this.kpnlMain.Name = "kpnlMain";
            this.kpnlMain.Size = new System.Drawing.Size(611, 697);
            this.kpnlMain.TabIndex = 37;
            // 
            // lblInstructionsAttendClick
            // 
            this.lblInstructionsAttendClick.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.lblInstructionsAttendClick.Location = new System.Drawing.Point(8, 640);
            this.lblInstructionsAttendClick.Name = "lblInstructionsAttendClick";
            this.lblInstructionsAttendClick.Size = new System.Drawing.Size(387, 19);
            this.lblInstructionsAttendClick.TabIndex = 39;
            this.lblInstructionsAttendClick.Text = "You can click on any day above to be taken to the entries for that day.";
            this.lblInstructionsAttendClick.Values.ExtraText = "";
            this.lblInstructionsAttendClick.Values.Image = null;
            this.lblInstructionsAttendClick.Values.Text = "You can click on any day above to be taken to the entries for that day.";
            // 
            // lblInstructionsAttendPlaceholders
            // 
            this.lblInstructionsAttendPlaceholders.AutoSize = false;
            this.lblInstructionsAttendPlaceholders.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.lblInstructionsAttendPlaceholders.Location = new System.Drawing.Point(8, 584);
            this.lblInstructionsAttendPlaceholders.Name = "lblInstructionsAttendPlaceholders";
            this.lblInstructionsAttendPlaceholders.Size = new System.Drawing.Size(723, 48);
            this.lblInstructionsAttendPlaceholders.StateCommon.ShortText.MultiLine = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.lblInstructionsAttendPlaceholders.TabIndex = 38;
            this.lblInstructionsAttendPlaceholders.Text = "If you only want to add an attendance record, it is OK to enter a placeholder dia" +
                "ry entry with title \"Attendance\", no time spent, and no subjects.";
            this.lblInstructionsAttendPlaceholders.Values.ExtraText = "";
            this.lblInstructionsAttendPlaceholders.Values.Image = null;
            this.lblInstructionsAttendPlaceholders.Values.Text = "If you only want to add an attendance record, it is OK to enter a placeholder dia" +
                "ry entry with title \"Attendance\", no time spent, and no subjects.";
            // 
            // lblInstructionsAttendDefintion
            // 
            this.lblInstructionsAttendDefintion.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.lblInstructionsAttendDefintion.Location = new System.Drawing.Point(8, 560);
            this.lblInstructionsAttendDefintion.Name = "lblInstructionsAttendDefintion";
            this.lblInstructionsAttendDefintion.Size = new System.Drawing.Size(397, 19);
            this.lblInstructionsAttendDefintion.TabIndex = 37;
            this.lblInstructionsAttendDefintion.Text = "The attendance list shows all the kids who had an entry for the given day.";
            this.lblInstructionsAttendDefintion.Values.ExtraText = "";
            this.lblInstructionsAttendDefintion.Values.Image = null;
            this.lblInstructionsAttendDefintion.Values.Text = "The attendance list shows all the kids who had an entry for the given day.";
            // 
            // lbcMonthShown
            // 
            this.lbcMonthShown.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.lbcMonthShown.Location = new System.Drawing.Point(182, 23);
            this.lbcMonthShown.Name = "lbcMonthShown";
            this.lbcMonthShown.Size = new System.Drawing.Size(120, 19);
            this.lbcMonthShown.TabIndex = 35;
            this.lbcMonthShown.Text = "Show Attendance For:";
            this.lbcMonthShown.Values.ExtraText = "";
            this.lbcMonthShown.Values.Image = null;
            this.lbcMonthShown.Values.Text = "Show Attendance For:";
            // 
            // dtpMonthShown
            // 
            this.dtpMonthShown.CustomFormat = "MMMM yyyy";
            this.dtpMonthShown.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMonthShown.Location = new System.Drawing.Point(309, 22);
            this.dtpMonthShown.Name = "dtpMonthShown";
            this.dtpMonthShown.Size = new System.Drawing.Size(123, 20);
            this.dtpMonthShown.TabIndex = 34;
            this.dtpMonthShown.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // frcAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 697);
            this.Controls.Add(this.kpnlMain);
            this.Name = "frcAttendance";
            this.Text = "Attendance:";
            this.Load += new System.EventHandler(this.frcAttendance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kpnlMain)).EndInit();
            this.kpnlMain.ResumeLayout(false);
            this.kpnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kpnlMain;
        private HomeSchoolDayBook.HSDSubKryptonPanelLabel lblInstructionsAttendClick;
        private HomeSchoolDayBook.HSDSubKryptonPanelLabel lblInstructionsAttendPlaceholders;
        private HomeSchoolDayBook.HSDSubKryptonPanelLabel lblInstructionsAttendDefintion;
        private HomeSchoolDayBook.HSDSubKryptonPanelLabel lbcMonthShown;
        private HSDKDateTimePicker dtpMonthShown;


    }
}