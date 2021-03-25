namespace HomeSchoolDayBook
{
    partial class frcManageKids
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
            this.lblInstructionsEdit = new HomeSchoolDayBook.HSDSubKryptonPanelLabel();
            this.lblInstructionsAddNew = new HomeSchoolDayBook.HSDSubKryptonPanelLabel();
            this.lblDisabledDueToUnsavedData = new HomeSchoolDayBook.HSDSubKryptonPanelLabel();
            this.lbcIsDefaultInvolved = new HomeSchoolDayBook.HSDSubKryptonPanelLabel();
            this.chkIsDefaultInvolved = new HomeSchoolDayBook.HSDKCheckBox();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lbcIsActive = new HomeSchoolDayBook.HSDSubKryptonPanelLabel();
            this.chkIsActive = new HomeSchoolDayBook.HSDKCheckBox();
            this.lbcFirstName = new HomeSchoolDayBook.HSDSubKryptonPanelLabel();
            this.txtFirstName = new HomeSchoolDayBook.HSDKTextBox();
            this.lstKids = new HomeSchoolDayBook.HSDKListBox();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlMain)).BeginInit();
            this.kpnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // kpnlMain
            // 
            this.kpnlMain.Controls.Add(this.lblInstructionsEdit);
            this.kpnlMain.Controls.Add(this.lblInstructionsAddNew);
            this.kpnlMain.Controls.Add(this.lblDisabledDueToUnsavedData);
            this.kpnlMain.Controls.Add(this.lbcIsDefaultInvolved);
            this.kpnlMain.Controls.Add(this.chkIsDefaultInvolved);
            this.kpnlMain.Controls.Add(this.btnCancel);
            this.kpnlMain.Controls.Add(this.btnSave);
            this.kpnlMain.Controls.Add(this.lbcIsActive);
            this.kpnlMain.Controls.Add(this.chkIsActive);
            this.kpnlMain.Controls.Add(this.lbcFirstName);
            this.kpnlMain.Controls.Add(this.txtFirstName);
            this.kpnlMain.Controls.Add(this.lstKids);
            this.kpnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpnlMain.Location = new System.Drawing.Point(0, 0);
            this.kpnlMain.Name = "kpnlMain";
            this.kpnlMain.Size = new System.Drawing.Size(611, 697);
            this.kpnlMain.TabIndex = 25;
            // 
            // lblInstructionsEdit
            // 
            this.lblInstructionsEdit.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.lblInstructionsEdit.Location = new System.Drawing.Point(109, 32);
            this.lblInstructionsEdit.Name = "lblInstructionsEdit";
            this.lblInstructionsEdit.Size = new System.Drawing.Size(287, 19);
            this.lblInstructionsEdit.TabIndex = 36;
            this.lblInstructionsEdit.Text = "To edit an existing kid, choose a kid from the list below.";
            this.lblInstructionsEdit.Values.ExtraText = "";
            this.lblInstructionsEdit.Values.Image = null;
            this.lblInstructionsEdit.Values.Text = "To edit an existing kid, choose a kid from the list below.";
            // 
            // lblInstructionsAddNew
            // 
            this.lblInstructionsAddNew.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.lblInstructionsAddNew.Location = new System.Drawing.Point(109, 16);
            this.lblInstructionsAddNew.Name = "lblInstructionsAddNew";
            this.lblInstructionsAddNew.Size = new System.Drawing.Size(389, 19);
            this.lblInstructionsAddNew.TabIndex = 35;
            this.lblInstructionsAddNew.Text = "To add a new kid, just start entering data and click Save when you are done.";
            this.lblInstructionsAddNew.Values.ExtraText = "";
            this.lblInstructionsAddNew.Values.Image = null;
            this.lblInstructionsAddNew.Values.Text = "To add a new kid, just start entering data and click Save when you are done.";
            // 
            // lblDisabledDueToUnsavedData
            // 
            this.lblDisabledDueToUnsavedData.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.lblDisabledDueToUnsavedData.Location = new System.Drawing.Point(109, 32);
            this.lblDisabledDueToUnsavedData.Name = "lblDisabledDueToUnsavedData";
            this.lblDisabledDueToUnsavedData.Size = new System.Drawing.Size(393, 19);
            this.lblDisabledDueToUnsavedData.TabIndex = 34;
            this.lblDisabledDueToUnsavedData.Text = "You can not choose a different kid until your changes are saved or cancelled.";
            this.lblDisabledDueToUnsavedData.Values.ExtraText = "";
            this.lblDisabledDueToUnsavedData.Values.Image = null;
            this.lblDisabledDueToUnsavedData.Values.Text = "You can not choose a different kid until your changes are saved or cancelled.";
            this.lblDisabledDueToUnsavedData.Visible = false;
            // 
            // lbcIsDefaultInvolved
            // 
            this.lbcIsDefaultInvolved.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.lbcIsDefaultInvolved.Location = new System.Drawing.Point(144, 208);
            this.lbcIsDefaultInvolved.Name = "lbcIsDefaultInvolved";
            this.lbcIsDefaultInvolved.Size = new System.Drawing.Size(86, 19);
            this.lbcIsDefaultInvolved.TabIndex = 33;
            this.lbcIsDefaultInvolved.Text = "Starts Involved:";
            this.lbcIsDefaultInvolved.Values.ExtraText = "";
            this.lbcIsDefaultInvolved.Values.Image = null;
            this.lbcIsDefaultInvolved.Values.Text = "Starts Involved:";
            // 
            // chkIsDefaultInvolved
            // 
            this.chkIsDefaultInvolved.AutoSize = true;
            this.chkIsDefaultInvolved.Checked = true;
            this.chkIsDefaultInvolved.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsDefaultInvolved.Location = new System.Drawing.Point(249, 208);
            this.chkIsDefaultInvolved.Name = "chkIsDefaultInvolved";
            this.chkIsDefaultInvolved.Size = new System.Drawing.Size(219, 17);
            this.chkIsDefaultInvolved.TabIndex = 27;
            this.chkIsDefaultInvolved.Text = " (new entries start with this kid \'checked\')";
            this.chkIsDefaultInvolved.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(313, 280);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(140, 28);
            this.btnCancel.TabIndex = 30;
            this.btnCancel.Text = "(no changes to cancel)";
            this.btnCancel.Values.ExtraText = "";
            this.btnCancel.Values.Image = null;
            this.btnCancel.Values.ImageStates.ImageCheckedNormal = null;
            this.btnCancel.Values.ImageStates.ImageCheckedPressed = null;
            this.btnCancel.Values.ImageStates.ImageCheckedTracking = null;
            this.btnCancel.Values.Text = "(no changes to cancel)";
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(158, 280);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(144, 28);
            this.btnSave.TabIndex = 29;
            this.btnSave.Text = "(no changes to save)";
            this.btnSave.Values.ExtraText = "";
            this.btnSave.Values.Image = null;
            this.btnSave.Values.ImageStates.ImageCheckedNormal = null;
            this.btnSave.Values.ImageStates.ImageCheckedPressed = null;
            this.btnSave.Values.ImageStates.ImageCheckedTracking = null;
            this.btnSave.Values.Text = "(no changes to save)";
            // 
            // lbcIsActive
            // 
            this.lbcIsActive.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.lbcIsActive.Location = new System.Drawing.Point(143, 240);
            this.lbcIsActive.Name = "lbcIsActive";
            this.lbcIsActive.Size = new System.Drawing.Size(54, 19);
            this.lbcIsActive.TabIndex = 32;
            this.lbcIsActive.Text = "Is Active:";
            this.lbcIsActive.Values.ExtraText = "";
            this.lbcIsActive.Values.Image = null;
            this.lbcIsActive.Values.Text = "Is Active:";
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsActive.Location = new System.Drawing.Point(249, 240);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(15, 14);
            this.chkIsActive.TabIndex = 28;
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // lbcFirstName
            // 
            this.lbcFirstName.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.lbcFirstName.Location = new System.Drawing.Point(143, 180);
            this.lbcFirstName.Name = "lbcFirstName";
            this.lbcFirstName.Size = new System.Drawing.Size(62, 19);
            this.lbcFirstName.TabIndex = 31;
            this.lbcFirstName.Text = "Kid Name:";
            this.lbcFirstName.Values.ExtraText = "";
            this.lbcFirstName.Values.Image = null;
            this.lbcFirstName.Values.Text = "Kid Name:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(249, 176);
            this.txtFirstName.MaxLength = 49;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.SelectAllOnEnter = true;
            this.txtFirstName.Size = new System.Drawing.Size(141, 20);
            this.txtFirstName.TabIndex = 26;
            // 
            // lstKids
            // 
            this.lstKids.FormattingEnabled = true;
            this.lstKids.Location = new System.Drawing.Point(193, 56);
            this.lstKids.Name = "lstKids";
            this.lstKids.Size = new System.Drawing.Size(224, 95);
            this.lstKids.TabIndex = 25;
            // 
            // frcManageKids
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 697);
            this.Controls.Add(this.kpnlMain);
            this.Name = "frcManageKids";
            this.Text = "Manage Kids:";
            ((System.ComponentModel.ISupportInitialize)(this.kpnlMain)).EndInit();
            this.kpnlMain.ResumeLayout(false);
            this.kpnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kpnlMain;
        private HomeSchoolDayBook.HSDSubKryptonPanelLabel lblInstructionsEdit;
        private HomeSchoolDayBook.HSDSubKryptonPanelLabel lblInstructionsAddNew;
        private HomeSchoolDayBook.HSDSubKryptonPanelLabel lblDisabledDueToUnsavedData;
        private HomeSchoolDayBook.HSDSubKryptonPanelLabel lbcIsDefaultInvolved;
        private HomeSchoolDayBook.HSDKCheckBox chkIsDefaultInvolved;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSave;
        private HomeSchoolDayBook.HSDSubKryptonPanelLabel lbcIsActive;
        private HomeSchoolDayBook.HSDKCheckBox chkIsActive;
        private HomeSchoolDayBook.HSDSubKryptonPanelLabel lbcFirstName;
        private HSDKTextBox txtFirstName;
        private HSDKListBox lstKids;
    }
}