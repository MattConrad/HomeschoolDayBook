namespace HomeSchoolDayBook
{
    partial class frcManageSubjects
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
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lblInstructionsEdit = new HomeSchoolDayBook.HSDSubKryptonPanelLabel();
            this.lblInstructionsAddNew = new HomeSchoolDayBook.HSDSubKryptonPanelLabel();
            this.lblDisabledDueToUnsavedData = new HomeSchoolDayBook.HSDSubKryptonPanelLabel();
            this.lbcIsActive = new HomeSchoolDayBook.HSDSubKryptonPanelLabel();
            this.chkIsActive = new HomeSchoolDayBook.HSDKCheckBox();
            this.lbcSubjectName = new HomeSchoolDayBook.HSDSubKryptonPanelLabel();
            this.txtSubjectName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.lstSubjects = new HomeSchoolDayBook.HSDKListBox();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlMain)).BeginInit();
            this.kpnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // kpnlMain
            // 
            this.kpnlMain.Controls.Add(this.btnCancel);
            this.kpnlMain.Controls.Add(this.btnSave);
            this.kpnlMain.Controls.Add(this.lblInstructionsEdit);
            this.kpnlMain.Controls.Add(this.lblInstructionsAddNew);
            this.kpnlMain.Controls.Add(this.lblDisabledDueToUnsavedData);
            this.kpnlMain.Controls.Add(this.lbcIsActive);
            this.kpnlMain.Controls.Add(this.chkIsActive);
            this.kpnlMain.Controls.Add(this.lbcSubjectName);
            this.kpnlMain.Controls.Add(this.txtSubjectName);
            this.kpnlMain.Controls.Add(this.lstSubjects);
            this.kpnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpnlMain.Location = new System.Drawing.Point(0, 0);
            this.kpnlMain.Name = "kpnlMain";
            this.kpnlMain.Size = new System.Drawing.Size(611, 697);
            this.kpnlMain.TabIndex = 30;
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(313, 280);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(140, 28);
            this.btnCancel.TabIndex = 39;
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
            this.btnSave.Size = new System.Drawing.Size(140, 28);
            this.btnSave.TabIndex = 38;
            this.btnSave.Text = "(no changes to save)";
            this.btnSave.Values.ExtraText = "";
            this.btnSave.Values.Image = null;
            this.btnSave.Values.ImageStates.ImageCheckedNormal = null;
            this.btnSave.Values.ImageStates.ImageCheckedPressed = null;
            this.btnSave.Values.ImageStates.ImageCheckedTracking = null;
            this.btnSave.Values.Text = "(no changes to save)";
            // 
            // lblInstructionsEdit
            // 
            this.lblInstructionsEdit.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.lblInstructionsEdit.Location = new System.Drawing.Point(99, 32);
            this.lblInstructionsEdit.Name = "lblInstructionsEdit";
            this.lblInstructionsEdit.Size = new System.Drawing.Size(308, 19);
            this.lblInstructionsEdit.TabIndex = 37;
            this.lblInstructionsEdit.Text = "To edit an existing subject, choose a kid from the list below.";
            this.lblInstructionsEdit.Values.ExtraText = "";
            this.lblInstructionsEdit.Values.Image = null;
            this.lblInstructionsEdit.Values.Text = "To edit an existing subject, choose a kid from the list below.";
            // 
            // lblInstructionsAddNew
            // 
            this.lblInstructionsAddNew.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.lblInstructionsAddNew.Location = new System.Drawing.Point(99, 16);
            this.lblInstructionsAddNew.Name = "lblInstructionsAddNew";
            this.lblInstructionsAddNew.Size = new System.Drawing.Size(409, 19);
            this.lblInstructionsAddNew.TabIndex = 36;
            this.lblInstructionsAddNew.Text = "To add a new subject, just start entering data and click Save when you are done.";
            this.lblInstructionsAddNew.Values.ExtraText = "";
            this.lblInstructionsAddNew.Values.Image = null;
            this.lblInstructionsAddNew.Values.Text = "To add a new subject, just start entering data and click Save when you are done.";
            // 
            // lblDisabledDueToUnsavedData
            // 
            this.lblDisabledDueToUnsavedData.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.lblDisabledDueToUnsavedData.Location = new System.Drawing.Point(99, 32);
            this.lblDisabledDueToUnsavedData.Name = "lblDisabledDueToUnsavedData";
            this.lblDisabledDueToUnsavedData.Size = new System.Drawing.Size(413, 19);
            this.lblDisabledDueToUnsavedData.TabIndex = 35;
            this.lblDisabledDueToUnsavedData.Text = "You can not choose a different subject until your changes are saved or cancelled." +
                "";
            this.lblDisabledDueToUnsavedData.Values.ExtraText = "";
            this.lblDisabledDueToUnsavedData.Values.Image = null;
            this.lblDisabledDueToUnsavedData.Values.Text = "You can not choose a different subject until your changes are saved or cancelled." +
                "";
            this.lblDisabledDueToUnsavedData.Visible = false;
            // 
            // lbcIsActive
            // 
            this.lbcIsActive.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.lbcIsActive.Location = new System.Drawing.Point(168, 224);
            this.lbcIsActive.Name = "lbcIsActive";
            this.lbcIsActive.Size = new System.Drawing.Size(54, 19);
            this.lbcIsActive.TabIndex = 34;
            this.lbcIsActive.Text = "Is Active:";
            this.lbcIsActive.Values.ExtraText = "";
            this.lbcIsActive.Values.Image = null;
            this.lbcIsActive.Values.Text = "Is Active:";
            // 
            // chkIsActive
            // 
            this.chkIsActive.Location = new System.Drawing.Point(269, 227);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(19, 13);
            this.chkIsActive.TabIndex = 33;
            // 
            // lbcSubjectName
            // 
            this.lbcSubjectName.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.lbcSubjectName.Location = new System.Drawing.Point(168, 184);
            this.lbcSubjectName.Name = "lbcSubjectName";
            this.lbcSubjectName.Size = new System.Drawing.Size(82, 19);
            this.lbcSubjectName.TabIndex = 31;
            this.lbcSubjectName.Text = "Subject Name:";
            this.lbcSubjectName.Values.ExtraText = "";
            this.lbcSubjectName.Values.Image = null;
            this.lbcSubjectName.Values.Text = "Subject Name:";
            // 
            // txtSubjectName
            // 
            this.txtSubjectName.Location = new System.Drawing.Point(264, 182);
            this.txtSubjectName.MaxLength = 49;
            this.txtSubjectName.Name = "txtSubjectName";
            this.txtSubjectName.Size = new System.Drawing.Size(178, 22);
            this.txtSubjectName.TabIndex = 32;
            // 
            // lstSubjects
            // 
            this.lstSubjects.FormattingEnabled = true;
            this.lstSubjects.Location = new System.Drawing.Point(181, 56);
            this.lstSubjects.Name = "lstSubjects";
            this.lstSubjects.Size = new System.Drawing.Size(248, 95);
            this.lstSubjects.TabIndex = 30;
            // 
            // frcManageSubjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 697);
            this.Controls.Add(this.kpnlMain);
            this.Name = "frcManageSubjects";
            this.Text = "Manage Subjects:";
            ((System.ComponentModel.ISupportInitialize)(this.kpnlMain)).EndInit();
            this.kpnlMain.ResumeLayout(false);
            this.kpnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kpnlMain;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSave;
        private HomeSchoolDayBook.HSDSubKryptonPanelLabel lblInstructionsEdit;
        private HomeSchoolDayBook.HSDSubKryptonPanelLabel lblInstructionsAddNew;
        private HomeSchoolDayBook.HSDSubKryptonPanelLabel lblDisabledDueToUnsavedData;
        private HomeSchoolDayBook.HSDSubKryptonPanelLabel lbcIsActive;
        private HSDKCheckBox chkIsActive;
        private HomeSchoolDayBook.HSDSubKryptonPanelLabel lbcSubjectName;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSubjectName;
        private HSDKListBox lstSubjects;

    }
}