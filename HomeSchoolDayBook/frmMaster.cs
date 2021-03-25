using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace HomeSchoolDayBook
{
    public partial class frmMaster : frbHSDAppearance
    {
        frcDayBookEntry _fDayBookEntry;
        frcManageKids _fManageKids;
        frcManageSubjects _fManageSubjects;
        frcAttendance _fAttendance;
        frcManageEntries _fManageEntries;
        frcSystemSettings _fSystemSettings;
        frcChooseReports _fReporting;
        frbHSDChild _currForm;
        KryptonCheckButton _radLastValid;

        Dictionary<Keys, KryptonCheckButton> _hashFnKeyToRad;
        Dictionary<KryptonCheckButton, frbHSDChild> _hashRadToChildForm;

        int iRadLittleHeight;
        int iRadBigHeight;

        public frmMaster()
        {
            this.FormClosed += new FormClosedEventHandler(frmMaster_FormClosed);
            InitializeComponent();
            InitEventHandlers();
            HSDMain.kryMgr = this.kmgr;     //must come before InitChildForms();
            InitChildFormsAndDictionaries();
            InitAndApplySystemSettings();
            iRadLittleHeight = 28;
            iRadBigHeight = 56;
            this.radDayBookEntries.Height = iRadBigHeight;
            _radLastValid = this.radDayBookEntries;
            CreateAllHandles((Control)this);    //we don't have textboxes on frmMaster, but just the same.
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (_hashFnKeyToRad.ContainsKey(keyData)) {
                _hashFnKeyToRad[keyData].PerformClick();
                return true;
            }

            return base.ProcessDialogKey(keyData);
        }

        private void frmMaster_FormClosed(object sender, FormClosedEventArgs e)
        {
            HSDMain.CEDbH.ToggleDBConn("close");

            if (HSDMain.CEDbH.IsDbClosed()) {
                BackupRestore oBak = new BackupRestore();
                oBak.CreateAutomaticDBBackups();
            }
        }

        private void frmMaster_Load(object sender, System.EventArgs e)
        {
            CheckAndWarnScreenSettings();
            HSDMain.fSplash.CloseSplash();

            if (IsNoKidsAndNoSubjects()) {
                DisplayFirstTimeWizard();
                StaticMethods.RefreshCodeTable("uc_subjects_active_with_all_subjects");
                StaticMethods.RefreshCodeTable("uc_subjects_active");
                StaticMethods.RefreshCodeTable("uc_subjects_all");
                StaticMethods.RefreshCodeTable("uc_kids_active_with_all_kids");
                StaticMethods.RefreshCodeTable("uc_kids_active");
                StaticMethods.RefreshCodeTable("uc_kids_all");
            }

            _currForm.ShowAndRunEntryRoutines();
        }

        private void kchksetSidebar_CheckedButtonChanged(object sender, EventArgs e)
        {
            KryptonCheckButton radNew = kchksetSidebar.CheckedButton;

            if (_radLastValid == radNew) return;

            if (radNew.Checked == true) {
                if (_currForm.IsExitAllowed()) {
                    this.pnlSidebar.SuspendLayout();
                    DisplayNewForm(_hashRadToChildForm[radNew]);
                    _radLastValid.Height = iRadLittleHeight;
                    radNew.Height = iRadBigHeight;
                    _radLastValid = radNew;
                    this.pnlSidebar.ResumeLayout();
                }
                else {
                    if (_radLastValid != null && _radLastValid.CanSelect)
                        _radLastValid.Select();

                    _radLastValid.PerformClick();
                }
            }
        }

        public void CheckAndWarnScreenSettings()
        {
            Rectangle rectScreen = System.Windows.Forms.Screen.PrimaryScreen.Bounds;

            float fDPIX = this.CreateGraphics().DpiX;
            float fDPIY = this.CreateGraphics().DpiY;

            bool bShowResWarning = HSDMain.SysSettings.GetSettingBool("ShowScreenResWarning");
            bool bShowDPIWarning = HSDMain.SysSettings.GetSettingBool("ShowDPIWarning");

            if (bShowResWarning && (rectScreen.Width < 1024 || rectScreen.Height < 768)) {
                MessageBox.Show("Homeschool Day Book does not display well at screen sizes smaller than 1024 x 768.\r\n\r\n"
                    + "You can change your screen size using Control Panel--look for the icon 'Display' or the area labeled 'Appearance and Themes'.", "Unsupported Screen Size:");

                MessageBox.Show("Please email info@HomeSchoolDayBook.com and let us know that you were affected by this limitation.", "Feedback Request:");

                HSDMain.SysSettings.SaveSetting("ShowScreenResWarning", "0");
            }

            if (bShowDPIWarning && (fDPIX != 96 || fDPIY != 96)) {
                MessageBox.Show("Homeschool Day Book may not display well under your screen settings. (DPI: " + fDPIX + ", " + fDPIY + ".)", "Unsupported DPI Settings:");

                MessageBox.Show("Please email info@HomeSchoolDayBook.com and let us know that you were affected by this limitation.", "Feedback Request:");

                HSDMain.SysSettings.SaveSetting("ShowDPIWarning", "0");
            }
        }

        /// <summary>
        /// There is an obscure app-crashing bug with Krypton forms/controls that Phil has 
        /// vaguely suggested may be caused by tweaking control values before the control has a handle.
        /// So, I'm taking a stab at a fix by creating all the handles early.
        /// </summary>
        /// <param name="c"></param>
        private void CreateAllHandles(Control c)
        {
            IntPtr p;
            //c.CreateHandle is inaccessible due to protection level.
            // Control.CreateControl and Control.Handle say you can instantiate the handle by accessing the property.
            p = c.Handle;

            if (c.Controls != null)
                foreach (Control cc in c.Controls)
                    CreateAllHandles(cc);
        }

        /// <summary>
        /// Must check IsExitAllowed PRIOR to calling this routine.
        /// </summary>
        /// <param name="sFormKey"></param>
        private void DisplayNewForm(frbHSDChild newForm)
        {
            if (newForm == _currForm) return;

            _currForm.ExitRoutines();
            newForm.ShowAndRunEntryRoutines();
            _currForm.Hide();                   //having this *after* newForm.Show() reduces ugly flicker.  still don't look great.  :(
            _currForm = newForm;
        }

        public void DisplayEntryFormAndSelectedEntry(DateTime datEntry, int iEntryID)
        {
            //we should not be running this from inside frcDayBookEntry.  if we are, exit.
            if (radDayBookEntries.Checked) return;

            radDayBookEntries.Checked = true;
            //must run fD.DisplaySelectedEntry LAST, otherwise selection will get overwritten by entry routines.
            _fDayBookEntry.DisplaySelectedEntry(datEntry, iEntryID);
        }

        private void DisplayFirstTimeWizard()
        {
            List<frbHSDWizard> lstWizForms = new List<frbHSDWizard>();
            //adding these in order is important.
            lstWizForms.Add(new frwFirstTimeIntro1());
            lstWizForms.Add(new frwFirstTimeKids2());
            lstWizForms.Add(new frwFirstTimeSubjectsA3());
            lstWizForms.Add(new frwFirstTimeSubjectsB4());
            lstWizForms.Add(new frwFirstTimeConclusion5());

            foreach (frbHSDWizard fw in lstWizForms) {
                fw.Dock = DockStyle.Fill;
                fw.DisplayHSDKryptonized(fw.Controls);
                CreateAllHandles((Control)fw);
            }

            frpWizardHost fpW = new frpWizardHost(lstWizForms);
            fpW.Text = "First Time Setup:";
            fpW.ShowDialog(this);
        }

        private void DisplayFunctionKeyHints(bool bShowHints)
        {
            if (bShowHints) {
                foreach (Keys keyCode in _hashFnKeyToRad.Keys) {
                    _hashFnKeyToRad[keyCode].Values.ExtraText = "(" + keyCode.ToString() + ")";
                }
            }
            else {
                foreach (KryptonCheckButton rad in kchksetSidebar.CheckButtons) {
                    rad.Values.ExtraText = "";
                }
            }
        }

        public void DisplayKryptonPalette(int iKryptonPalette)
        {
            kmgr.GlobalPaletteMode = (PaletteModeManager)iKryptonPalette;

            this.DisplayHSDKryptonized(this.Controls);

            foreach (Form f in _hashRadToChildForm.Values) {
                ((frbHSDAppearance)f).DisplayHSDKryptonized(f.Controls);
            }
        }

        private void InitChildFormsAndDictionaries()
        {
            _fDayBookEntry = new frcDayBookEntry();
            _fAttendance = new frcAttendance();
            _fManageSubjects = new frcManageSubjects();
            _fManageKids = new frcManageKids();
            _fManageEntries = new frcManageEntries();
            _fSystemSettings = new frcSystemSettings();
            _fReporting = new frcChooseReports();

            _hashRadToChildForm = new Dictionary<KryptonCheckButton, frbHSDChild>();
            _hashRadToChildForm[this.radDayBookEntries] = _fDayBookEntry;
            _hashRadToChildForm[this.radAttendance] = _fAttendance;
            _hashRadToChildForm[this.radManageSubjects] = _fManageSubjects;
            _hashRadToChildForm[this.radManageKids] = _fManageKids;
            _hashRadToChildForm[this.radManageEntries] = _fManageEntries;
            _hashRadToChildForm[this.radSystemSettings] = _fSystemSettings;
            _hashRadToChildForm[this.radReporting] = _fReporting;

            _hashFnKeyToRad = new Dictionary<Keys, KryptonCheckButton>();
            _hashFnKeyToRad[Keys.F1] = this.radDayBookEntries;
            _hashFnKeyToRad[Keys.F2] = this.radAttendance;
            _hashFnKeyToRad[Keys.F3] = this.radManageSubjects;
            _hashFnKeyToRad[Keys.F4] = this.radManageKids;
            _hashFnKeyToRad[Keys.F5] = this.radManageEntries;
            _hashFnKeyToRad[Keys.F6] = this.radSystemSettings;
            _hashFnKeyToRad[Keys.F7] = this.radReporting;

            foreach (Form f in _hashRadToChildForm.Values) {
                CreateAllHandles(f);
                f.FormBorderStyle = FormBorderStyle.None;
                f.TopLevel = false;
                f.Visible = false;
                f.Dock = DockStyle.Fill;
                ((frbHSDAppearance)f).DisplayHSDKryptonized(f.Controls);
                pnlMain.Controls.Add(f);
            }

            _currForm = _fDayBookEntry;
        }

        private void InitEventHandlers()
        {
            this.Load += new System.EventHandler(this.frmMaster_Load);

            this.btnTellSize.Click += new System.EventHandler(this.btnTellSize_Click);
            this.kchksetSidebar.CheckedButtonChanged += new System.EventHandler(this.kchksetSidebar_CheckedButtonChanged);
            //this.kbutTogglePalette.Click += new System.EventHandler(this.kbutTogglePalette_Click);
        }

        private bool IsNoKidsAndNoSubjects()
        {
            if (HSDMain.hashCodeTables["uc_kids_all"].Rows.Count < 1
                && HSDMain.hashCodeTables["uc_subjects_all"].Rows.Count < 1)
                return true;
            else
                return false;
        }

        private void InitAndApplySystemSettings()
        {
            DisplayKryptonPalette(HSDMain.SysSettings.GetSettingInt("KryptonPalette"));
        }

        private void btnTellSize_Click(object sender, EventArgs e)
        {
            //MessageSize();

            DivideByZeroException x3 = new DivideByZeroException("By George, I think we got it!  It's surreal!  It's encroaching senility!  This is 3rd exception & it has amps and \"quotes\" and apo's and =s, Div By Zero.");
            NullReferenceException x2 = new NullReferenceException("This is 2nd exception, NRE.", x3);
            ArgumentException x1 = new ArgumentException("This is the outer exception, an argument exception.", x2);

            try {
                throw x3;
            }
            catch {
                try {
                    throw x2;
                }
                catch {
                    throw x1;
                }
            }

            //HomeschoolDayBook.KryptonMessageBox.Show("test msg", "test caption");
            //MessageBox.Show("" + this.pnlSidebar.StateCommon.GetBackColor1(PaletteState.Normal).ToString());
            //MessageBox.Show("" + this.pnlSidebar.StateCommon.GetBackColor1(PaletteState.Normal).ToKnownColor().ToString());

            //MessageBox.Show(System.Environment.OSVersion.VersionString);
            //MessageBox.Show(" " + this.Width + ", " + this.Height);
        }



    }
}