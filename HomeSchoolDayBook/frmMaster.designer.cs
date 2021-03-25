namespace HomeSchoolDayBook
{
    partial class frmMaster
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
            this.components = new System.ComponentModel.Container();
            this.pnlSidebar = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.radReporting = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.radSystemSettings = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.radManageEntries = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.radManageKids = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.radManageSubjects = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.radAttendance = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnTellSize = new System.Windows.Forms.Button();
            this.radDayBookEntries = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.pnlMain = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kborderMainLeft = new ComponentFactory.Krypton.Toolkit.KryptonBorderEdge();
            this.kmgr = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.kchksetSidebar = new ComponentFactory.Krypton.Toolkit.KryptonCheckSet(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pnlSidebar)).BeginInit();
            this.pnlSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.Controls.Add(this.radReporting);
            this.pnlSidebar.Controls.Add(this.radSystemSettings);
            this.pnlSidebar.Controls.Add(this.radManageEntries);
            this.pnlSidebar.Controls.Add(this.radManageKids);
            this.pnlSidebar.Controls.Add(this.radManageSubjects);
            this.pnlSidebar.Controls.Add(this.radAttendance);
            this.pnlSidebar.Controls.Add(this.btnTellSize);
            this.pnlSidebar.Controls.Add(this.radDayBookEntries);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(187, 700);
            this.pnlSidebar.TabIndex = 0;
            // 
            // radReporting
            // 
            this.radReporting.Dock = System.Windows.Forms.DockStyle.Top;
            this.radReporting.Location = new System.Drawing.Point(0, 168);
            this.radReporting.Name = "radReporting";
            this.radReporting.Size = new System.Drawing.Size(187, 28);
            this.radReporting.TabIndex = 14;
            this.radReporting.Text = "Printable Reports";
            this.radReporting.Values.ExtraText = "(F7)";
            this.radReporting.Values.Image = null;
            this.radReporting.Values.Text = "Printable Reports";
            // 
            // radSystemSettings
            // 
            this.radSystemSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.radSystemSettings.Location = new System.Drawing.Point(0, 140);
            this.radSystemSettings.Name = "radSystemSettings";
            this.radSystemSettings.Size = new System.Drawing.Size(187, 28);
            this.radSystemSettings.TabIndex = 13;
            this.radSystemSettings.Text = "System Settings";
            this.radSystemSettings.Values.ExtraText = "(F6)";
            this.radSystemSettings.Values.Image = null;
            this.radSystemSettings.Values.Text = "System Settings";
            // 
            // radManageEntries
            // 
            this.radManageEntries.Dock = System.Windows.Forms.DockStyle.Top;
            this.radManageEntries.Location = new System.Drawing.Point(0, 112);
            this.radManageEntries.Name = "radManageEntries";
            this.radManageEntries.Size = new System.Drawing.Size(187, 28);
            this.radManageEntries.TabIndex = 10;
            this.radManageEntries.Text = "Manage Entries";
            this.radManageEntries.Values.ExtraText = "(F5)";
            this.radManageEntries.Values.Image = null;
            this.radManageEntries.Values.Text = "Manage Entries";
            // 
            // radManageKids
            // 
            this.radManageKids.Dock = System.Windows.Forms.DockStyle.Top;
            this.radManageKids.Location = new System.Drawing.Point(0, 84);
            this.radManageKids.Name = "radManageKids";
            this.radManageKids.Size = new System.Drawing.Size(187, 28);
            this.radManageKids.TabIndex = 9;
            this.radManageKids.Text = "Manage Kids";
            this.radManageKids.Values.ExtraText = "(F4)";
            this.radManageKids.Values.Image = null;
            this.radManageKids.Values.Text = "Manage Kids";
            // 
            // radManageSubjects
            // 
            this.radManageSubjects.Dock = System.Windows.Forms.DockStyle.Top;
            this.radManageSubjects.Location = new System.Drawing.Point(0, 56);
            this.radManageSubjects.Name = "radManageSubjects";
            this.radManageSubjects.Size = new System.Drawing.Size(187, 28);
            this.radManageSubjects.TabIndex = 8;
            this.radManageSubjects.Text = "Manage Subjects";
            this.radManageSubjects.Values.ExtraText = "(F3)";
            this.radManageSubjects.Values.Image = null;
            this.radManageSubjects.Values.Text = "Manage Subjects";
            // 
            // radAttendance
            // 
            this.radAttendance.Dock = System.Windows.Forms.DockStyle.Top;
            this.radAttendance.Location = new System.Drawing.Point(0, 28);
            this.radAttendance.Name = "radAttendance";
            this.radAttendance.Size = new System.Drawing.Size(187, 28);
            this.radAttendance.TabIndex = 7;
            this.radAttendance.Text = "Attendance";
            this.radAttendance.Values.ExtraText = "(F2)";
            this.radAttendance.Values.Image = null;
            this.radAttendance.Values.Text = "Attendance";
            // 
            // btnTellSize
            // 
            this.btnTellSize.Location = new System.Drawing.Point(34, 248);
            this.btnTellSize.Name = "btnTellSize";
            this.btnTellSize.Size = new System.Drawing.Size(78, 96);
            this.btnTellSize.TabIndex = 6;
            this.btnTellSize.Text = "TEST BUTTON ONLY!";
            this.btnTellSize.UseVisualStyleBackColor = true;
            this.btnTellSize.Visible = false;
            // 
            // radDayBookEntries
            // 
            this.radDayBookEntries.Checked = true;
            this.radDayBookEntries.Dock = System.Windows.Forms.DockStyle.Top;
            this.radDayBookEntries.Location = new System.Drawing.Point(0, 0);
            this.radDayBookEntries.Name = "radDayBookEntries";
            this.radDayBookEntries.Size = new System.Drawing.Size(187, 28);
            this.radDayBookEntries.TabIndex = 0;
            this.radDayBookEntries.Text = "Day Book Entries";
            this.radDayBookEntries.Values.ExtraText = "(F1)";
            this.radDayBookEntries.Values.Image = null;
            this.radDayBookEntries.Values.Text = "Day Book Entries";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.kborderMainLeft);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(187, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(609, 700);
            this.pnlMain.TabIndex = 1;
            // 
            // kborderMainLeft
            // 
            this.kborderMainLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.kborderMainLeft.Location = new System.Drawing.Point(0, 0);
            this.kborderMainLeft.Name = "kborderMainLeft";
            this.kborderMainLeft.Size = new System.Drawing.Size(1, 700);
            this.kborderMainLeft.TabIndex = 0;
            this.kborderMainLeft.Text = "kryptonBorderEdge1";
            // 
            // kchksetSidebar
            // 
            this.kchksetSidebar.CheckButtons.Add(this.radDayBookEntries);
            this.kchksetSidebar.CheckButtons.Add(this.radManageEntries);
            this.kchksetSidebar.CheckButtons.Add(this.radManageKids);
            this.kchksetSidebar.CheckButtons.Add(this.radManageSubjects);
            this.kchksetSidebar.CheckButtons.Add(this.radAttendance);
            this.kchksetSidebar.CheckButtons.Add(this.radSystemSettings);
            this.kchksetSidebar.CheckButtons.Add(this.radReporting);
            this.kchksetSidebar.CheckedButton = this.radDayBookEntries;
            // 
            // frmMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(796, 700);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlSidebar);
            this.Name = "frmMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Homeschool Day Book:";
            ((System.ComponentModel.ISupportInitialize)(this.pnlSidebar)).EndInit();
            this.pnlSidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }


        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel pnlSidebar;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel pnlMain;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton radDayBookEntries;
        private System.Windows.Forms.Button btnTellSize;
        public ComponentFactory.Krypton.Toolkit.KryptonManager kmgr;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckSet kchksetSidebar;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton radManageEntries;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton radManageKids;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton radManageSubjects;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton radAttendance;
        private ComponentFactory.Krypton.Toolkit.KryptonBorderEdge kborderMainLeft;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton radSystemSettings;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton radReporting;

    }
}