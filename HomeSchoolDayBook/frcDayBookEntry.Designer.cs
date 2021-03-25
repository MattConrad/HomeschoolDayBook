namespace HomeSchoolDayBook
{
    partial class frcDayBookEntry
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
            this.dtpDayBookEntryDates = new HomeSchoolDayBook.HSDKDateTimePicker();
            this.lblProgress = new HomeSchoolDayBook.HSDSubKryptonPanelLabel();
            this.lstDayBookEntryTitles = new HomeSchoolDayBook.HSDKListBox();
            this.lbcHoursMinutesSlash = new HomeSchoolDayBook.HSDSubKryptonPanelLabel();
            this.txiTimeSpentMinutes = new HomeSchoolDayBook.HSDKTextBoxInteger();
            this.txiTimeSpentHours = new HomeSchoolDayBook.HSDKTextBoxInteger();
            this.lbcTimeSpentHoursMinutes = new HomeSchoolDayBook.HSDSubKryptonPanelLabel();
            this.txtEntryTitle = new HomeSchoolDayBook.HSDKTextBox();
            this.txtEntryText = new HomeSchoolDayBook.HSDKTextBox();
            this.lbcEntryText = new HomeSchoolDayBook.HSDSubKryptonPanelLabel();
            this.ckpKidsActive = new HomeSchoolDayBook.HSDKCheckboxPanel();
            this.ckpSubjectsActive = new HomeSchoolDayBook.HSDKCheckboxPanel();
            this.btnCancelChanges = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSaveAndNew = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSaveAndStay = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lbcDayBookEntryTitles = new HomeSchoolDayBook.HSDSubKryptonPanelLabel();
            this.lbcDayBookEntryDates = new HomeSchoolDayBook.HSDSubKryptonPanelLabel();
            this.lblDisabledDueToUnsavedData = new HomeSchoolDayBook.HSDSubKryptonPanelLabel();
            this.lbcTimeSpent = new HomeSchoolDayBook.HSDSubKryptonPanelLabel();
            this.lbcEntryTitle = new HomeSchoolDayBook.HSDSubKryptonPanelLabel();
            this.lbcKidsInvolved = new HomeSchoolDayBook.HSDSubKryptonPanelLabel();
            this.lbcSubjects = new HomeSchoolDayBook.HSDSubKryptonPanelLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlMain)).BeginInit();
            this.kpnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // kpnlMain
            // 
            this.kpnlMain.Controls.Add(this.dtpDayBookEntryDates);
            this.kpnlMain.Controls.Add(this.lblProgress);
            this.kpnlMain.Controls.Add(this.lstDayBookEntryTitles);
            this.kpnlMain.Controls.Add(this.lbcHoursMinutesSlash);
            this.kpnlMain.Controls.Add(this.txiTimeSpentMinutes);
            this.kpnlMain.Controls.Add(this.txiTimeSpentHours);
            this.kpnlMain.Controls.Add(this.lbcTimeSpentHoursMinutes);
            this.kpnlMain.Controls.Add(this.txtEntryTitle);
            this.kpnlMain.Controls.Add(this.txtEntryText);
            this.kpnlMain.Controls.Add(this.lbcEntryText);
            this.kpnlMain.Controls.Add(this.ckpKidsActive);
            this.kpnlMain.Controls.Add(this.ckpSubjectsActive);
            this.kpnlMain.Controls.Add(this.btnCancelChanges);
            this.kpnlMain.Controls.Add(this.btnSaveAndNew);
            this.kpnlMain.Controls.Add(this.btnSaveAndStay);
            this.kpnlMain.Controls.Add(this.lbcDayBookEntryTitles);
            this.kpnlMain.Controls.Add(this.lbcDayBookEntryDates);
            this.kpnlMain.Controls.Add(this.lblDisabledDueToUnsavedData);
            this.kpnlMain.Controls.Add(this.lbcTimeSpent);
            this.kpnlMain.Controls.Add(this.lbcEntryTitle);
            this.kpnlMain.Controls.Add(this.lbcKidsInvolved);
            this.kpnlMain.Controls.Add(this.lbcSubjects);
            this.kpnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpnlMain.Location = new System.Drawing.Point(0, 0);
            this.kpnlMain.Name = "kpnlMain";
            this.kpnlMain.Size = new System.Drawing.Size(611, 697);
            this.kpnlMain.TabIndex = 23;
            // 
            // dtpDayBookEntryDates
            // 
            this.dtpDayBookEntryDates.Location = new System.Drawing.Point(66, 32);
            this.dtpDayBookEntryDates.Name = "dtpDayBookEntryDates";
            this.dtpDayBookEntryDates.Size = new System.Drawing.Size(195, 20);
            this.dtpDayBookEntryDates.TabIndex = 0;
            this.dtpDayBookEntryDates.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // lblProgress
            // 
            this.lblProgress.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.lblProgress.Location = new System.Drawing.Point(72, 56);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(190, 48);
            this.lblProgress.TabIndex = 33;
            this.lblProgress.Text = "Today you have recorded xx entries, \nwith a total time of yy hours \nand zz minute" +
                "s.";
            this.lblProgress.Values.ExtraText = "";
            this.lblProgress.Values.Image = null;
            this.lblProgress.Values.Text = "Today you have recorded xx entries, \nwith a total time of yy hours \nand zz minute" +
                "s.";
            // 
            // lstDayBookEntryTitles
            // 
            this.lstDayBookEntryTitles.FormattingEnabled = true;
            this.lstDayBookEntryTitles.Location = new System.Drawing.Point(301, 32);
            this.lstDayBookEntryTitles.Name = "lstDayBookEntryTitles";
            this.lstDayBookEntryTitles.Size = new System.Drawing.Size(233, 95);
            this.lstDayBookEntryTitles.TabIndex = 1;
            // 
            // lbcHoursMinutesSlash
            // 
            this.lbcHoursMinutesSlash.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.lbcHoursMinutesSlash.Location = new System.Drawing.Point(329, 168);
            this.lbcHoursMinutesSlash.Name = "lbcHoursMinutesSlash";
            this.lbcHoursMinutesSlash.Size = new System.Drawing.Size(15, 19);
            this.lbcHoursMinutesSlash.TabIndex = 6;
            this.lbcHoursMinutesSlash.Text = "/";
            this.lbcHoursMinutesSlash.Values.ExtraText = "";
            this.lbcHoursMinutesSlash.Values.Image = null;
            this.lbcHoursMinutesSlash.Values.Text = "/";
            // 
            // txiTimeSpentMinutes
            // 
            this.txiTimeSpentMinutes.Location = new System.Drawing.Point(345, 164);
            this.txiTimeSpentMinutes.MaxLength = 3;
            this.txiTimeSpentMinutes.Name = "txiTimeSpentMinutes";
            this.txiTimeSpentMinutes.Size = new System.Drawing.Size(28, 20);
            this.txiTimeSpentMinutes.TabIndex = 4;
            this.txiTimeSpentMinutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txiTimeSpentHours
            // 
            this.txiTimeSpentHours.Location = new System.Drawing.Point(300, 164);
            this.txiTimeSpentHours.MaxLength = 2;
            this.txiTimeSpentHours.Name = "txiTimeSpentHours";
            this.txiTimeSpentHours.Size = new System.Drawing.Size(28, 20);
            this.txiTimeSpentHours.TabIndex = 3;
            this.txiTimeSpentHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbcTimeSpentHoursMinutes
            // 
            this.lbcTimeSpentHoursMinutes.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.lbcTimeSpentHoursMinutes.Location = new System.Drawing.Point(382, 168);
            this.lbcTimeSpentHoursMinutes.Name = "lbcTimeSpentHoursMinutes";
            this.lbcTimeSpentHoursMinutes.Size = new System.Drawing.Size(96, 19);
            this.lbcTimeSpentHoursMinutes.TabIndex = 31;
            this.lbcTimeSpentHoursMinutes.Text = "(hours / minutes)";
            this.lbcTimeSpentHoursMinutes.Values.ExtraText = "";
            this.lbcTimeSpentHoursMinutes.Values.Image = null;
            this.lbcTimeSpentHoursMinutes.Values.Text = "(hours / minutes)";
            // 
            // txtEntryTitle
            // 
            this.txtEntryTitle.Location = new System.Drawing.Point(64, 164);
            this.txtEntryTitle.MaxLength = 99;
            this.txtEntryTitle.Name = "txtEntryTitle";
            this.txtEntryTitle.SelectAllOnEnter = true;
            this.txtEntryTitle.Size = new System.Drawing.Size(216, 20);
            this.txtEntryTitle.TabIndex = 2;
            // 
            // txtEntryText
            // 
            this.txtEntryText.Location = new System.Drawing.Point(60, 224);
            this.txtEntryText.Multiline = true;
            this.txtEntryText.Name = "txtEntryText";
            this.txtEntryText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEntryText.SelectAllOnEnter = false;
            this.txtEntryText.Size = new System.Drawing.Size(491, 85);
            this.txtEntryText.TabIndex = 5;
            // 
            // lbcEntryText
            // 
            this.lbcEntryText.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.lbcEntryText.Location = new System.Drawing.Point(63, 206);
            this.lbcEntryText.Name = "lbcEntryText";
            this.lbcEntryText.Size = new System.Drawing.Size(79, 19);
            this.lbcEntryText.TabIndex = 23;
            this.lbcEntryText.Text = "What We Did:";
            this.lbcEntryText.Values.ExtraText = "";
            this.lbcEntryText.Values.Image = null;
            this.lbcEntryText.Values.Text = "What We Did:";
            // 
            // ckpKidsActive
            // 
            this.ckpKidsActive.AutoScroll = true;
            this.ckpKidsActive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ckpKidsActive.Location = new System.Drawing.Point(62, 340);
            this.ckpKidsActive.Name = "ckpKidsActive";
            this.ckpKidsActive.NumberOfColumns = 4;
            this.ckpKidsActive.Size = new System.Drawing.Size(489, 53);
            this.ckpKidsActive.TabIndex = 6;
            // 
            // ckpSubjectsActive
            // 
            this.ckpSubjectsActive.AutoScroll = true;
            this.ckpSubjectsActive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ckpSubjectsActive.Location = new System.Drawing.Point(61, 432);
            this.ckpSubjectsActive.Name = "ckpSubjectsActive";
            this.ckpSubjectsActive.NumberOfColumns = 4;
            this.ckpSubjectsActive.Size = new System.Drawing.Size(489, 75);
            this.ckpSubjectsActive.TabIndex = 7;
            // 
            // btnCancelChanges
            // 
            this.btnCancelChanges.Enabled = false;
            this.btnCancelChanges.Location = new System.Drawing.Point(392, 520);
            this.btnCancelChanges.Name = "btnCancelChanges";
            this.btnCancelChanges.Size = new System.Drawing.Size(155, 28);
            this.btnCancelChanges.TabIndex = 10;
            this.btnCancelChanges.Text = "&Cancel Changes";
            this.btnCancelChanges.Values.ExtraText = "";
            this.btnCancelChanges.Values.Image = null;
            this.btnCancelChanges.Values.ImageStates.ImageCheckedNormal = null;
            this.btnCancelChanges.Values.ImageStates.ImageCheckedPressed = null;
            this.btnCancelChanges.Values.ImageStates.ImageCheckedTracking = null;
            this.btnCancelChanges.Values.Text = "&Cancel Changes";
            // 
            // btnSaveAndNew
            // 
            this.btnSaveAndNew.Enabled = false;
            this.btnSaveAndNew.Location = new System.Drawing.Point(64, 520);
            this.btnSaveAndNew.Name = "btnSaveAndNew";
            this.btnSaveAndNew.Size = new System.Drawing.Size(155, 28);
            this.btnSaveAndNew.TabIndex = 8;
            this.btnSaveAndNew.Text = "Save and Start &Next Entry";
            this.btnSaveAndNew.Values.ExtraText = "";
            this.btnSaveAndNew.Values.Image = null;
            this.btnSaveAndNew.Values.ImageStates.ImageCheckedNormal = null;
            this.btnSaveAndNew.Values.ImageStates.ImageCheckedPressed = null;
            this.btnSaveAndNew.Values.ImageStates.ImageCheckedTracking = null;
            this.btnSaveAndNew.Values.Text = "Save and Start &Next Entry";
            // 
            // btnSaveAndStay
            // 
            this.btnSaveAndStay.Enabled = false;
            this.btnSaveAndStay.Location = new System.Drawing.Point(228, 520);
            this.btnSaveAndStay.Name = "btnSaveAndStay";
            this.btnSaveAndStay.Size = new System.Drawing.Size(155, 28);
            this.btnSaveAndStay.TabIndex = 9;
            this.btnSaveAndStay.Text = "Sa&ve Changes to Entry";
            this.btnSaveAndStay.Values.ExtraText = "";
            this.btnSaveAndStay.Values.Image = null;
            this.btnSaveAndStay.Values.ImageStates.ImageCheckedNormal = null;
            this.btnSaveAndStay.Values.ImageStates.ImageCheckedPressed = null;
            this.btnSaveAndStay.Values.ImageStates.ImageCheckedTracking = null;
            this.btnSaveAndStay.Values.Text = "Sa&ve Changes to Entry";
            // 
            // lbcDayBookEntryTitles
            // 
            this.lbcDayBookEntryTitles.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.lbcDayBookEntryTitles.Location = new System.Drawing.Point(314, 13);
            this.lbcDayBookEntryTitles.Name = "lbcDayBookEntryTitles";
            this.lbcDayBookEntryTitles.Size = new System.Drawing.Size(67, 19);
            this.lbcDayBookEntryTitles.TabIndex = 37;
            this.lbcDayBookEntryTitles.Text = "Entry Titles:";
            this.lbcDayBookEntryTitles.Values.ExtraText = "";
            this.lbcDayBookEntryTitles.Values.Image = null;
            this.lbcDayBookEntryTitles.Values.Text = "Entry Titles:";
            // 
            // lbcDayBookEntryDates
            // 
            this.lbcDayBookEntryDates.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.lbcDayBookEntryDates.Location = new System.Drawing.Point(72, 13);
            this.lbcDayBookEntryDates.Name = "lbcDayBookEntryDates";
            this.lbcDayBookEntryDates.Size = new System.Drawing.Size(69, 19);
            this.lbcDayBookEntryDates.TabIndex = 35;
            this.lbcDayBookEntryDates.Text = "Entry Dates:";
            this.lbcDayBookEntryDates.Values.ExtraText = "";
            this.lbcDayBookEntryDates.Values.Image = null;
            this.lbcDayBookEntryDates.Values.Text = "Entry Dates:";
            // 
            // lblDisabledDueToUnsavedData
            // 
            this.lblDisabledDueToUnsavedData.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.lblDisabledDueToUnsavedData.Location = new System.Drawing.Point(104, 13);
            this.lblDisabledDueToUnsavedData.Name = "lblDisabledDueToUnsavedData";
            this.lblDisabledDueToUnsavedData.Size = new System.Drawing.Size(403, 19);
            this.lblDisabledDueToUnsavedData.TabIndex = 36;
            this.lblDisabledDueToUnsavedData.Text = "You can not choose a different entry until your changes are saved or cancelled.";
            this.lblDisabledDueToUnsavedData.Values.ExtraText = "";
            this.lblDisabledDueToUnsavedData.Values.Image = null;
            this.lblDisabledDueToUnsavedData.Values.Text = "You can not choose a different entry until your changes are saved or cancelled.";
            this.lblDisabledDueToUnsavedData.Visible = false;
            // 
            // lbcTimeSpent
            // 
            this.lbcTimeSpent.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.lbcTimeSpent.Location = new System.Drawing.Point(300, 146);
            this.lbcTimeSpent.Name = "lbcTimeSpent";
            this.lbcTimeSpent.Size = new System.Drawing.Size(69, 19);
            this.lbcTimeSpent.TabIndex = 27;
            this.lbcTimeSpent.Text = "Time Spent:";
            this.lbcTimeSpent.Values.ExtraText = "";
            this.lbcTimeSpent.Values.Image = null;
            this.lbcTimeSpent.Values.Text = "Time Spent:";
            // 
            // lbcEntryTitle
            // 
            this.lbcEntryTitle.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.lbcEntryTitle.Location = new System.Drawing.Point(67, 146);
            this.lbcEntryTitle.Name = "lbcEntryTitle";
            this.lbcEntryTitle.Size = new System.Drawing.Size(34, 19);
            this.lbcEntryTitle.TabIndex = 25;
            this.lbcEntryTitle.Text = "Title:";
            this.lbcEntryTitle.Values.ExtraText = "";
            this.lbcEntryTitle.Values.Image = null;
            this.lbcEntryTitle.Values.Text = "Title:";
            // 
            // lbcKidsInvolved
            // 
            this.lbcKidsInvolved.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.lbcKidsInvolved.Location = new System.Drawing.Point(60, 320);
            this.lbcKidsInvolved.Name = "lbcKidsInvolved";
            this.lbcKidsInvolved.Size = new System.Drawing.Size(79, 19);
            this.lbcKidsInvolved.TabIndex = 21;
            this.lbcKidsInvolved.Text = "Kids Involved:";
            this.lbcKidsInvolved.Values.ExtraText = "";
            this.lbcKidsInvolved.Values.Image = null;
            this.lbcKidsInvolved.Values.Text = "Kids Involved:";
            // 
            // lbcSubjects
            // 
            this.lbcSubjects.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.lbcSubjects.Location = new System.Drawing.Point(73, 412);
            this.lbcSubjects.Name = "lbcSubjects";
            this.lbcSubjects.Size = new System.Drawing.Size(54, 19);
            this.lbcSubjects.TabIndex = 20;
            this.lbcSubjects.Text = "Subjects:";
            this.lbcSubjects.Values.ExtraText = "";
            this.lbcSubjects.Values.Image = null;
            this.lbcSubjects.Values.Text = "Subjects:";
            // 
            // frcDayBookEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 697);
            this.Controls.Add(this.kpnlMain);
            this.Name = "frcDayBookEntry";
            this.Text = "Day Book Entry";
            this.Load += new System.EventHandler(this.frmDayBookEntry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kpnlMain)).EndInit();
            this.kpnlMain.ResumeLayout(false);
            this.kpnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kpnlMain;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancelChanges;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSaveAndNew;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSaveAndStay;
        private HSDKCheckboxPanel ckpSubjectsActive;
        private HomeSchoolDayBook.HSDSubKryptonPanelLabel lbcSubjects;
        private HomeSchoolDayBook.HSDSubKryptonPanelLabel lbcKidsInvolved;
        private HSDKCheckboxPanel ckpKidsActive;
        private HSDKTextBox txtEntryText;
        private HomeSchoolDayBook.HSDSubKryptonPanelLabel lbcEntryText;
        private HomeSchoolDayBook.HSDSubKryptonPanelLabel lbcHoursMinutesSlash;
        private HSDKTextBoxInteger txiTimeSpentMinutes;
        private HSDKTextBoxInteger txiTimeSpentHours;
        private HomeSchoolDayBook.HSDSubKryptonPanelLabel lbcTimeSpentHoursMinutes;
        private HomeSchoolDayBook.HSDSubKryptonPanelLabel lbcTimeSpent;
        private HomeSchoolDayBook.HSDSubKryptonPanelLabel lbcEntryTitle;
        private HSDKTextBox txtEntryTitle;
        private HSDKListBox lstDayBookEntryTitles;
        private HomeSchoolDayBook.HSDSubKryptonPanelLabel lblProgress;
        private HSDKDateTimePicker dtpDayBookEntryDates;
        private HomeSchoolDayBook.HSDSubKryptonPanelLabel lbcDayBookEntryTitles;
        private HomeSchoolDayBook.HSDSubKryptonPanelLabel lbcDayBookEntryDates;
        private HomeSchoolDayBook.HSDSubKryptonPanelLabel lblDisabledDueToUnsavedData;

    }
}

