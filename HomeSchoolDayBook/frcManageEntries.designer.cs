namespace HomeSchoolDayBook
{
    partial class frcManageEntries
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
            this.lblInstructionsDoubleClickTitle = new HomeSchoolDayBook.HSDSubKryptonPanelLabel();
            this.lblInstructionsSortHeader = new HomeSchoolDayBook.HSDSubKryptonPanelLabel();
            this.kgrpDGV = new ComponentFactory.Krypton.Toolkit.KryptonGroup();
            this.dgvEntries = new HomeSchoolDayBook.KryptonDGVModified();
            this.lbcEndDate = new HomeSchoolDayBook.HSDSubKryptonPanelLabel();
            this.lbcStartDate = new HomeSchoolDayBook.HSDSubKryptonPanelLabel();
            this.dtpEndDate = new HomeSchoolDayBook.HSDKDateTimePicker();
            this.dtpStartDate = new HomeSchoolDayBook.HSDKDateTimePicker();
            this.lbdChooseMgmtActionNoEntrySelected = new HomeSchoolDayBook.HSDSubKryptonPanelLabel();
            this.cmboChooseMgmtAction = new HomeSchoolDayBook.HSDKComboBox();
            this.lbcChooseMgmtAction = new HomeSchoolDayBook.HSDSubKryptonPanelLabel();
            this.btnDestroyEntry = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lbdSelectedEntryTitle = new HomeSchoolDayBook.HSDSubKryptonPanelLabel();
            this.lbcSelectedEntryTitle = new HomeSchoolDayBook.HSDSubKryptonPanelLabel();
            this.lbdSelectedEntryDate = new HomeSchoolDayBook.HSDSubKryptonPanelLabel();
            this.lbcCorrectedEntryDate = new HomeSchoolDayBook.HSDSubKryptonPanelLabel();
            this.dtpCorrectedEntryDate = new HomeSchoolDayBook.HSDKDateTimePicker();
            this.lbcSelectedEntryDate = new HomeSchoolDayBook.HSDSubKryptonPanelLabel();
            this.btnSaveCorrectedDate = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlMain)).BeginInit();
            this.kpnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kgrpDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kgrpDGV.Panel)).BeginInit();
            this.kgrpDGV.Panel.SuspendLayout();
            this.kgrpDGV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntries)).BeginInit();
            this.SuspendLayout();
            // 
            // kpnlMain
            // 
            this.kpnlMain.Controls.Add(this.lblInstructionsDoubleClickTitle);
            this.kpnlMain.Controls.Add(this.lblInstructionsSortHeader);
            this.kpnlMain.Controls.Add(this.kgrpDGV);
            this.kpnlMain.Controls.Add(this.lbcEndDate);
            this.kpnlMain.Controls.Add(this.lbcStartDate);
            this.kpnlMain.Controls.Add(this.dtpEndDate);
            this.kpnlMain.Controls.Add(this.dtpStartDate);
            this.kpnlMain.Controls.Add(this.lbdChooseMgmtActionNoEntrySelected);
            this.kpnlMain.Controls.Add(this.cmboChooseMgmtAction);
            this.kpnlMain.Controls.Add(this.lbcChooseMgmtAction);
            this.kpnlMain.Controls.Add(this.btnDestroyEntry);
            this.kpnlMain.Controls.Add(this.lbdSelectedEntryTitle);
            this.kpnlMain.Controls.Add(this.lbcSelectedEntryTitle);
            this.kpnlMain.Controls.Add(this.lbdSelectedEntryDate);
            this.kpnlMain.Controls.Add(this.lbcCorrectedEntryDate);
            this.kpnlMain.Controls.Add(this.dtpCorrectedEntryDate);
            this.kpnlMain.Controls.Add(this.lbcSelectedEntryDate);
            this.kpnlMain.Controls.Add(this.btnSaveCorrectedDate);
            this.kpnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpnlMain.Location = new System.Drawing.Point(0, 0);
            this.kpnlMain.Name = "kpnlMain";
            this.kpnlMain.Size = new System.Drawing.Size(611, 697);
            this.kpnlMain.TabIndex = 40;
            // 
            // lblInstructionsDoubleClickTitle
            // 
            this.lblInstructionsDoubleClickTitle.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.lblInstructionsDoubleClickTitle.Location = new System.Drawing.Point(40, 568);
            this.lblInstructionsDoubleClickTitle.Name = "lblInstructionsDoubleClickTitle";
            this.lblInstructionsDoubleClickTitle.Size = new System.Drawing.Size(311, 19);
            this.lblInstructionsDoubleClickTitle.TabIndex = 58;
            this.lblInstructionsDoubleClickTitle.Text = "You can double-click the title of an entry to go to that entry.";
            this.lblInstructionsDoubleClickTitle.Values.ExtraText = "";
            this.lblInstructionsDoubleClickTitle.Values.Image = null;
            this.lblInstructionsDoubleClickTitle.Values.Text = "You can double-click the title of an entry to go to that entry.";
            // 
            // lblInstructionsSortHeader
            // 
            this.lblInstructionsSortHeader.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.lblInstructionsSortHeader.Location = new System.Drawing.Point(40, 536);
            this.lblInstructionsSortHeader.Name = "lblInstructionsSortHeader";
            this.lblInstructionsSortHeader.Size = new System.Drawing.Size(518, 19);
            this.lblInstructionsSortHeader.TabIndex = 57;
            this.lblInstructionsSortHeader.Text = "You can click on \"Entry Date\" or \"Entry Title\" at the top of the listing to chang" +
                "e how the list is ordered.";
            this.lblInstructionsSortHeader.Values.ExtraText = "";
            this.lblInstructionsSortHeader.Values.Image = null;
            this.lblInstructionsSortHeader.Values.Text = "You can click on \"Entry Date\" or \"Entry Title\" at the top of the listing to chang" +
                "e how the list is ordered.";
            // 
            // kgrpDGV
            // 
            this.kgrpDGV.Location = new System.Drawing.Point(129, 88);
            this.kgrpDGV.Name = "kgrpDGV";
            // 
            // kgrpDGV.Panel
            // 
            this.kgrpDGV.Panel.Controls.Add(this.dgvEntries);
            this.kgrpDGV.Size = new System.Drawing.Size(352, 264);
            this.kgrpDGV.StateCommon.Border.Color1 = System.Drawing.Color.Black;
            this.kgrpDGV.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kgrpDGV.TabIndex = 56;
            // 
            // dgvEntries
            // 
            this.dgvEntries.AllowUserToAddRows = false;
            this.dgvEntries.AllowUserToDeleteRows = false;
            this.dgvEntries.AllowUserToResizeColumns = false;
            this.dgvEntries.AllowUserToResizeRows = false;
            this.dgvEntries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEntries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEntries.Location = new System.Drawing.Point(0, 0);
            this.dgvEntries.MultiSelect = false;
            this.dgvEntries.Name = "dgvEntries";
            this.dgvEntries.ReadOnly = true;
            this.dgvEntries.RowHeadersVisible = false;
            this.dgvEntries.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEntries.Size = new System.Drawing.Size(350, 262);
            this.dgvEntries.StandardTab = true;
            this.dgvEntries.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.dgvEntries.TabIndex = 52;
            // 
            // lbcEndDate
            // 
            this.lbcEndDate.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.lbcEndDate.Location = new System.Drawing.Point(231, 56);
            this.lbcEndDate.Name = "lbcEndDate";
            this.lbcEndDate.Size = new System.Drawing.Size(23, 19);
            this.lbcEndDate.TabIndex = 55;
            this.lbcEndDate.Text = "to:";
            this.lbcEndDate.Values.ExtraText = "";
            this.lbcEndDate.Values.Image = null;
            this.lbcEndDate.Values.Text = "to:";
            // 
            // lbcStartDate
            // 
            this.lbcStartDate.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.lbcStartDate.Location = new System.Drawing.Point(155, 24);
            this.lbcStartDate.Name = "lbcStartDate";
            this.lbcStartDate.Size = new System.Drawing.Size(103, 19);
            this.lbcStartDate.TabIndex = 54;
            this.lbcStartDate.Text = "Show Entries from:";
            this.lbcStartDate.Values.ExtraText = "";
            this.lbcStartDate.Values.Image = null;
            this.lbcStartDate.Values.Text = "Show Entries from:";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(265, 52);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(190, 20);
            this.dtpEndDate.TabIndex = 53;
            this.dtpEndDate.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(265, 20);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(190, 20);
            this.dtpStartDate.TabIndex = 52;
            this.dtpStartDate.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // lbdChooseMgmtActionNoEntrySelected
            // 
            this.lbdChooseMgmtActionNoEntrySelected.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.lbdChooseMgmtActionNoEntrySelected.Location = new System.Drawing.Point(315, 432);
            this.lbdChooseMgmtActionNoEntrySelected.Name = "lbdChooseMgmtActionNoEntrySelected";
            this.lbdChooseMgmtActionNoEntrySelected.Size = new System.Drawing.Size(103, 19);
            this.lbdChooseMgmtActionNoEntrySelected.TabIndex = 50;
            this.lbdChooseMgmtActionNoEntrySelected.Text = "(no entry selected)";
            this.lbdChooseMgmtActionNoEntrySelected.Values.ExtraText = "";
            this.lbdChooseMgmtActionNoEntrySelected.Values.Image = null;
            this.lbdChooseMgmtActionNoEntrySelected.Values.Text = "(no entry selected)";
            this.lbdChooseMgmtActionNoEntrySelected.Visible = false;
            // 
            // cmboChooseMgmtAction
            // 
            this.cmboChooseMgmtAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboChooseMgmtAction.FormattingEnabled = true;
            this.cmboChooseMgmtAction.Location = new System.Drawing.Point(316, 431);
            this.cmboChooseMgmtAction.Name = "cmboChooseMgmtAction";
            this.cmboChooseMgmtAction.Size = new System.Drawing.Size(124, 21);
            this.cmboChooseMgmtAction.TabIndex = 40;
            // 
            // lbcChooseMgmtAction
            // 
            this.lbcChooseMgmtAction.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.lbcChooseMgmtAction.Location = new System.Drawing.Point(171, 432);
            this.lbcChooseMgmtAction.Name = "lbcChooseMgmtAction";
            this.lbcChooseMgmtAction.Size = new System.Drawing.Size(132, 19);
            this.lbcChooseMgmtAction.TabIndex = 49;
            this.lbcChooseMgmtAction.Text = "Action you want to take:";
            this.lbcChooseMgmtAction.Values.ExtraText = "";
            this.lbcChooseMgmtAction.Values.Image = null;
            this.lbcChooseMgmtAction.Values.Text = "Action you want to take:";
            // 
            // btnDestroyEntry
            // 
            this.btnDestroyEntry.Location = new System.Drawing.Point(244, 464);
            this.btnDestroyEntry.Name = "btnDestroyEntry";
            this.btnDestroyEntry.Size = new System.Drawing.Size(103, 28);
            this.btnDestroyEntry.TabIndex = 43;
            this.btnDestroyEntry.Text = "&Destroy Entry";
            this.btnDestroyEntry.Values.ExtraText = "";
            this.btnDestroyEntry.Values.Image = null;
            this.btnDestroyEntry.Values.ImageStates.ImageCheckedNormal = null;
            this.btnDestroyEntry.Values.ImageStates.ImageCheckedPressed = null;
            this.btnDestroyEntry.Values.ImageStates.ImageCheckedTracking = null;
            this.btnDestroyEntry.Values.Text = "&Destroy Entry";
            // 
            // lbdSelectedEntryTitle
            // 
            this.lbdSelectedEntryTitle.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.lbdSelectedEntryTitle.Location = new System.Drawing.Point(316, 400);
            this.lbdSelectedEntryTitle.Name = "lbdSelectedEntryTitle";
            this.lbdSelectedEntryTitle.Size = new System.Drawing.Size(42, 19);
            this.lbdSelectedEntryTitle.TabIndex = 48;
            this.lbdSelectedEntryTitle.Text = "(none)";
            this.lbdSelectedEntryTitle.Values.ExtraText = "";
            this.lbdSelectedEntryTitle.Values.Image = null;
            this.lbdSelectedEntryTitle.Values.Text = "(none)";
            // 
            // lbcSelectedEntryTitle
            // 
            this.lbcSelectedEntryTitle.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.lbcSelectedEntryTitle.Location = new System.Drawing.Point(176, 400);
            this.lbcSelectedEntryTitle.Name = "lbcSelectedEntryTitle";
            this.lbcSelectedEntryTitle.Size = new System.Drawing.Size(108, 19);
            this.lbcSelectedEntryTitle.TabIndex = 47;
            this.lbcSelectedEntryTitle.Text = "Selected Entry Title:";
            this.lbcSelectedEntryTitle.Values.ExtraText = "";
            this.lbcSelectedEntryTitle.Values.Image = null;
            this.lbcSelectedEntryTitle.Values.Text = "Selected Entry Title:";
            // 
            // lbdSelectedEntryDate
            // 
            this.lbdSelectedEntryDate.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.lbdSelectedEntryDate.Location = new System.Drawing.Point(316, 376);
            this.lbdSelectedEntryDate.Name = "lbdSelectedEntryDate";
            this.lbdSelectedEntryDate.Size = new System.Drawing.Size(42, 19);
            this.lbdSelectedEntryDate.TabIndex = 46;
            this.lbdSelectedEntryDate.Text = "(none)";
            this.lbdSelectedEntryDate.Values.ExtraText = "";
            this.lbdSelectedEntryDate.Values.Image = null;
            this.lbdSelectedEntryDate.Values.Text = "(none)";
            // 
            // lbcCorrectedEntryDate
            // 
            this.lbcCorrectedEntryDate.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.lbcCorrectedEntryDate.Location = new System.Drawing.Point(86, 469);
            this.lbcCorrectedEntryDate.Name = "lbcCorrectedEntryDate";
            this.lbcCorrectedEntryDate.Size = new System.Drawing.Size(117, 19);
            this.lbcCorrectedEntryDate.TabIndex = 45;
            this.lbcCorrectedEntryDate.Text = "Corrected Entry Date:";
            this.lbcCorrectedEntryDate.Values.ExtraText = "";
            this.lbcCorrectedEntryDate.Values.Image = null;
            this.lbcCorrectedEntryDate.Values.Text = "Corrected Entry Date:";
            // 
            // dtpCorrectedEntryDate
            // 
            this.dtpCorrectedEntryDate.Location = new System.Drawing.Point(214, 468);
            this.dtpCorrectedEntryDate.Name = "dtpCorrectedEntryDate";
            this.dtpCorrectedEntryDate.Size = new System.Drawing.Size(192, 20);
            this.dtpCorrectedEntryDate.TabIndex = 41;
            this.dtpCorrectedEntryDate.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // lbcSelectedEntryDate
            // 
            this.lbcSelectedEntryDate.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.lbcSelectedEntryDate.Location = new System.Drawing.Point(176, 376);
            this.lbcSelectedEntryDate.Name = "lbcSelectedEntryDate";
            this.lbcSelectedEntryDate.Size = new System.Drawing.Size(110, 19);
            this.lbcSelectedEntryDate.TabIndex = 44;
            this.lbcSelectedEntryDate.Text = "Selected Entry Date:";
            this.lbcSelectedEntryDate.Values.ExtraText = "";
            this.lbcSelectedEntryDate.Values.Image = null;
            this.lbcSelectedEntryDate.Values.Text = "Selected Entry Date:";
            // 
            // btnSaveCorrectedDate
            // 
            this.btnSaveCorrectedDate.Location = new System.Drawing.Point(422, 464);
            this.btnSaveCorrectedDate.Name = "btnSaveCorrectedDate";
            this.btnSaveCorrectedDate.Size = new System.Drawing.Size(103, 28);
            this.btnSaveCorrectedDate.TabIndex = 42;
            this.btnSaveCorrectedDate.Text = "Sa&ve New Date";
            this.btnSaveCorrectedDate.Values.ExtraText = "";
            this.btnSaveCorrectedDate.Values.Image = null;
            this.btnSaveCorrectedDate.Values.ImageStates.ImageCheckedNormal = null;
            this.btnSaveCorrectedDate.Values.ImageStates.ImageCheckedPressed = null;
            this.btnSaveCorrectedDate.Values.ImageStates.ImageCheckedTracking = null;
            this.btnSaveCorrectedDate.Values.Text = "Sa&ve New Date";
            // 
            // frcManageEntries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 697);
            this.Controls.Add(this.kpnlMain);
            this.Name = "frcManageEntries";
            this.Text = "Manage Entries/View Entry Listing:";
            ((System.ComponentModel.ISupportInitialize)(this.kpnlMain)).EndInit();
            this.kpnlMain.ResumeLayout(false);
            this.kpnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kgrpDGV.Panel)).EndInit();
            this.kgrpDGV.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kgrpDGV)).EndInit();
            this.kgrpDGV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntries)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kpnlMain;
        private HomeSchoolDayBook.HSDSubKryptonPanelLabel lbcEndDate;
        private HomeSchoolDayBook.HSDSubKryptonPanelLabel lbcStartDate;
        private HSDKDateTimePicker dtpEndDate;
        private HSDKDateTimePicker dtpStartDate;
        private HomeSchoolDayBook.HSDSubKryptonPanelLabel lbdChooseMgmtActionNoEntrySelected;
        private HSDKComboBox cmboChooseMgmtAction;
        private HomeSchoolDayBook.HSDSubKryptonPanelLabel lbcChooseMgmtAction;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnDestroyEntry;
        private HomeSchoolDayBook.HSDSubKryptonPanelLabel lbdSelectedEntryTitle;
        private HomeSchoolDayBook.HSDSubKryptonPanelLabel lbcSelectedEntryTitle;
        private HomeSchoolDayBook.HSDSubKryptonPanelLabel lbdSelectedEntryDate;
        private HomeSchoolDayBook.HSDSubKryptonPanelLabel lbcCorrectedEntryDate;
        private HSDKDateTimePicker dtpCorrectedEntryDate;
        private HomeSchoolDayBook.HSDSubKryptonPanelLabel lbcSelectedEntryDate;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSaveCorrectedDate;
        private ComponentFactory.Krypton.Toolkit.KryptonGroup kgrpDGV;
        //private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvEntries;
        private HomeSchoolDayBook.KryptonDGVModified dgvEntries;
        private HSDSubKryptonPanelLabel lblInstructionsSortHeader;
        private HSDSubKryptonPanelLabel lblInstructionsDoubleClickTitle;

    }
}

