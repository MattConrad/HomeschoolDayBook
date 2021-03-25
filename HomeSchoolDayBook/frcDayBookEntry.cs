using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace HomeSchoolDayBook
{
    public partial class frcDayBookEntry : frbHSDChild
    {
        private bool _isNewEntry;
        private bool _bIgnoreChangesToData;

        public frcDayBookEntry()
        {
            InitializeComponent();
            InitEventHandlers();
            DefaultFocusControl = dtpDayBookEntryDates;
        }

        private void frmDayBookEntry_Load(object sender, EventArgs e)
        {
            InitDataControls();  //eventually cascades down to PrepareEntryDisplay.
        }

        public override void EntryRoutines()
        {
            RefreshCheckboxControls();
            base.EntryRoutines();
        }

        /// <summary>
        /// It is possible to change the title listing from other screens (alter entry dates),
        /// so we need to update it each time we come here.
        /// </summary>
        public override void ShowAndRunEntryRoutines()
        {
            RefreshTitleListing(dtpDayBookEntryDates.Value);
            base.ShowAndRunEntryRoutines();
        }

        private void btnCancelChanges_Click(object sender, EventArgs e)
        {
            PrepareEntryDisplay();
            DisplayDefaultFocus();
        }

        private void btnSaveAndStay_Click(object sender, EventArgs e)
        {
            SaveEntry();    //cascades down to PrepareEntryDisplay.
            DisplayDefaultFocus();
        }

        private void btnSaveAndNew_Click(object sender, EventArgs e)
        {
            SaveEntry();    //cascades down to PrepareEntryDisplay.
            lstDayBookEntryTitles.SelectedIndex = 0;      //always "new entry"
            //DisplayDefaultFocus();
            if (txtEntryTitle.CanSelect)
                txtEntryTitle.Focus();
        }

        private void lstDayBookEntryTitles_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrepareEntryDisplay();
        }

        private void dtpDayBookEntryDates_ValueChanged(object sender, EventArgs e)
        {
            RefreshTitleListing(dtpDayBookEntryDates.Value);
            DisplayProgressText(false);
        }

        private void DisplayClearedEntryData()
        {
            ckpSubjectsActive.ClearChecksEventless();
            ckpKidsActive.ClearChecksEventless();

            txiTimeSpentHours.Text = "";
            txiTimeSpentMinutes.Text = "";
            txtEntryTitle.Text = "";
            txtEntryText.Text = "";
        }

        private void DisplayDefaultKidsForNewEntry()
        {
            List<int> lstDefaultKids = new List<int>();
            DataTable dt = HSDMain.hashCodeTables["uc_kids_all"];

            foreach(DataRow dr in dt.Rows) {
                if ((bool)dr["is_default_involved"])
                    lstDefaultKids.Add((int)dr["kid_id"]);
            }

            ckpKidsActive.DisplayDataChecks(lstDefaultKids);
        }

        private void DisplayProgressText(bool bShowText)
        {
            if (!bShowText)
                lblProgress.Text = "";
            else {
                int iTotalMinutes = 0;
                int iTotalEntries = 0;

                HSDMain.CEDbH.SGetDEntriesTotalsByDate(dtpDayBookEntryDates.Value, out iTotalMinutes, out iTotalEntries);
                int iHours = GetHoursOrMinutesFromMinutes(iTotalMinutes, "h");
                int iMinutes = GetHoursOrMinutesFromMinutes(iTotalMinutes, "m");
                //Today you have recorded xx entries, with a total time of yy hours and zz minutes."
                if (dtpDayBookEntryDates.Value == DateTime.Today)
                    lblProgress.Text = "Today you have recorded "
                        + iTotalEntries + " " + StaticMethods.Pluralize(iTotalEntries, "entry") + ", \nwith a total time of "
                        + iHours + " " + StaticMethods.Pluralize(iHours, "hour") + " \nand "
                        + iMinutes + " " + StaticMethods.Pluralize(iMinutes, "minute") + ".";
                else
                    lblProgress.Text = "For " + dtpDayBookEntryDates.Value.ToString("d") + ", you have "
                        + iTotalEntries + " " + StaticMethods.Pluralize(iTotalEntries, "entry") + ", \nwith a total time of "
                        + iHours + " " + StaticMethods.Pluralize(iHours, "hour") + " \nand "
                        + iMinutes + " " + StaticMethods.Pluralize(iMinutes, "minute") + ".";
            }
        }

        private void DisplaySaveButtonCaptions()
        {
            if (!btnSaveAndStay.Enabled) {
                btnSaveAndStay.Text = "(no changes to save)";
                btnSaveAndNew.Text = "(no changes to save)";
                btnCancelChanges.Text = "(no changes to cancel)";
            } else {
                if (_isNewEntry) {
                    btnSaveAndStay.Text = "Sa&ve New Entry";
                    btnCancelChanges.Text = "&Cancel New Entry";
                } else {
                    btnSaveAndStay.Text = "Sa&ve Changes to Entry";
                    btnCancelChanges.Text = "&Cancel Changes";
                }

                btnSaveAndNew.Text = "Save and Start &Next Entry";
            }
        }

        private void DisplayScreenForDataNeedsSaving(bool bSaveIsEnabled)
        {
            btnSaveAndStay.Enabled = bSaveIsEnabled;
            btnSaveAndNew.Enabled = bSaveIsEnabled;
            btnCancelChanges.Enabled = bSaveIsEnabled;

            dtpDayBookEntryDates.Enabled = !bSaveIsEnabled;
            lstDayBookEntryTitles.Enabled = !bSaveIsEnabled;

            lbcDayBookEntryDates.Visible = !bSaveIsEnabled;
            lbcDayBookEntryTitles.Visible = !bSaveIsEnabled;
            lblDisabledDueToUnsavedData.Visible = bSaveIsEnabled;

            DisplaySaveButtonCaptions();
        }

        /// <summary>
        /// This method should only be called from OUTSIDE this child form.
        /// Goes around a bunch of UI checks that are needed inside this form.
        /// </summary>
        /// <param name="datEntry"></param>
        /// <param name="iEntryID"></param>
        public void DisplaySelectedEntry(DateTime datEntry, int iEntryID)
        {
            dtpDayBookEntryDates.Value = datEntry;  //refreshes lstDayBookEntryTitles.
            lstDayBookEntryTitles.SelectedValue = iEntryID;
        }

        private void GetAndDisplayEntryData(int iEntryID)
        {
            DataTable dtK = HSDMain.CEDbH.SGetDKidsByEntryID(iEntryID);
            ckpKidsActive.DisplayDataChecks(dtK, "kid_id");

            DataTable dtA = HSDMain.CEDbH.SGetDSubjectsByEntryID(iEntryID);
            ckpSubjectsActive.DisplayDataChecks(dtA, "subject_id");

            DataRow drE = HSDMain.CEDbH.SGetDEntryByID(iEntryID);
            txtEntryTitle.Text = drE["entry_title"].ToString();
            txtEntryText.Text = drE["entry_text"].ToString();

            txiTimeSpentHours.Text = "";
            txiTimeSpentMinutes.Text = "";
            if (drE["minutes_spent"] != DBNull.Value) {
                int iMinutesSpent = (int)drE["minutes_spent"];

                if (iMinutesSpent >= 60)
                    txiTimeSpentHours.Text = (iMinutesSpent / 60).ToString();

                if (iMinutesSpent > 0)
                    txiTimeSpentMinutes.Text = (iMinutesSpent % 60).ToString();
            }
        }

        private int GetHoursOrMinutesFromMinutes(int iMinutes, string sGetHorM)
        {
            if (sGetHorM == "h")
                return (iMinutes / 60);
            else if (sGetHorM == "m")
                return (iMinutes % 60);
            else
                throw new ArgumentException("Hours/minutes designator must be 'h' or 'm'.");
        }

        private void InitDataControls()
        {
            DisplayProgressText(false);
            RefreshCheckboxControls();
            dtpDayBookEntryDates.Value = DateTime.Today;  //invokes RefreshTitleListing + entry cascade.
            InitEntryTitleAutocomplete();
        }

        private void InitEntryTitleAutocomplete()
        {
            DataTable dt = HSDMain.CEDbH.SGetDEntryTitlesDistinctRecent();
            AutoCompleteStringCollection lstAC = new AutoCompleteStringCollection();
            foreach (DataRow dr in dt.Rows)
                lstAC.Add(dr["entry_title"].ToString());
            txtEntryTitle.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtEntryTitle.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtEntryTitle.AutoCompleteCustomSource = lstAC;
        }

        private void InitEventHandlers()
        {
            this.lstDayBookEntryTitles.SelectedIndexChanged += new System.EventHandler(this.lstDayBookEntryTitles_SelectedIndexChanged);
            this.dtpDayBookEntryDates.ValueChanged += new System.EventHandler(this.dtpDayBookEntryDates_ValueChanged);
            this.btnCancelChanges.Click += new System.EventHandler(this.btnCancelChanges_Click);
            this.btnSaveAndNew.Click += new System.EventHandler(this.btnSaveAndNew_Click);
            this.btnSaveAndStay.Click += new System.EventHandler(this.btnSaveAndStay_Click);

            this.ckpSubjectsActive.CheckBoxValueChanged += new EventHandler(SetDirtyData);
            this.ckpKidsActive.CheckBoxValueChanged += new EventHandler(SetDirtyData);
            this.txtEntryTitle.TextChanged += new EventHandler(SetDirtyData);
            this.txiTimeSpentHours.TextChanged += new EventHandler(SetDirtyData);
            this.txiTimeSpentMinutes.TextChanged += new EventHandler(SetDirtyData);
            this.txtEntryText.TextChanged += new EventHandler(SetDirtyData);
        }

        public override bool IsExitAllowed()
        {
            if (!btnSaveAndStay.Enabled)
                return true;

            DialogResult dlgr = MessageBox.Show("You have unsaved changes.  If you continue, you will " 
                + "lose these changes.  Choose 'No' to stay here and save your changes.\n\n"
                + "Are you sure you want to leave and lose your changes?", "Lose Unsaved Changes?", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

            if (dlgr == DialogResult.Yes) {
                PrepareEntryDisplay();
                return true;                    
            } else {
                return false;
            }
        }

        private void PrepareEditedEntry(int iEntryID)
        {
            _isNewEntry = false;
            DisplaySaveButtonCaptions();
            DisplayClearedEntryData();
            GetAndDisplayEntryData(iEntryID);
        }

        private void PrepareNewEntry()
        {
            _isNewEntry = true;
            DisplaySaveButtonCaptions();
            DisplayClearedEntryData();
            DisplayDefaultKidsForNewEntry();
        }

        private void PrepareEntryDisplay()
        {
            if (lstDayBookEntryTitles.SelectedIndex == -1) return;   // setting selindex = -1 should ALWAYS be followed by a non-negative index setting.

            _bIgnoreChangesToData = true;

            if (lstDayBookEntryTitles.SelectedIndex == 0)
                PrepareNewEntry();
            else
                PrepareEditedEntry((int)lstDayBookEntryTitles.SelectedValue);

            DisplayScreenForDataNeedsSaving(false);
            DisplaySaveButtonCaptions();

            _bIgnoreChangesToData = false;
        }

        public void RefreshCheckboxControls()
        {
            ckpSubjectsActive.RefreshListing(HSDMain.hashCodeTables["uc_subjects_active"], "subject_desc", "subject_id");
            ckpKidsActive.RefreshListing(HSDMain.hashCodeTables["uc_kids_active"], "first_name", "kid_id");
            DisplayDefaultKidsForNewEntry();
        }

        private void RefreshTitleListing(DateTime dateToShow)
        {
            DataTable dt = HSDMain.CEDbH.SGetDEntryTitlesByTargetDate(dateToShow, true);

            lstDayBookEntryTitles.SelectedIndex = -1;        //this is to prep IndexChanged firing later.
            lstDayBookEntryTitles.DataSource = null;
            lstDayBookEntryTitles.Items.Clear();
            lstDayBookEntryTitles.DisplayMember = "entry_title";
            lstDayBookEntryTitles.ValueMember = "entry_id";
            lstDayBookEntryTitles.DataSource = dt;

            //HACK: the IndexChanged fires 3 times here.  once when setting to -1 (no big deal)
            // then when setting the datasource, and again below when checking default entry.
            // probably twice is enough.   :)
        }

        private void SaveEntry()
        {
            int iEntryID = -1;

            int iHoursPartSpent = txiTimeSpentHours.Text.Length > 0 ? int.Parse(txiTimeSpentHours.Text) : 0;
            int iMinutesPartSpent = txiTimeSpentMinutes.Text.Length > 0 ? int.Parse(txiTimeSpentMinutes.Text) : 0;
            int iTotalMinutesSpent = (iHoursPartSpent * 60) + iMinutesPartSpent;

            if (_isNewEntry) {
                iEntryID = HSDMain.CEDbH.SaveNewDEntry(dtpDayBookEntryDates.Value, 0,
                    txtEntryTitle.Text, iTotalMinutesSpent, txtEntryText.Text, ckpKidsActive.GetCheckedIDs(), ckpSubjectsActive.GetCheckedIDs());
            } else {
                iEntryID = (int)lstDayBookEntryTitles.SelectedValue;
                HSDMain.CEDbH.SaveEditedDEntry(iEntryID, dtpDayBookEntryDates.Value, 0,
                    txtEntryTitle.Text, iTotalMinutesSpent, txtEntryText.Text, ckpKidsActive.GetCheckedIDs(), ckpSubjectsActive.GetCheckedIDs());
            }

            UpdateEntryTitleAutocomplete(txtEntryTitle.Text);  //must do this BEFORE refreshing title listing.
            RefreshTitleListing(dtpDayBookEntryDates.Value);
            lstDayBookEntryTitles.SelectedValue = iEntryID;
            DisplayProgressText(true);
        }

        private void SetDirtyData(object sender, EventArgs e)
        {
            if (_bIgnoreChangesToData)
                return;

            DisplayScreenForDataNeedsSaving(true);
        }
        
        /// <summary>
        /// If they add a distinct new title, add to autocomplete.  Works for edit existing title too,
        /// although if they edit, we don't remove the old title.  This is probably OK.
        /// </summary>
        /// <param name="p"></param>
        private void UpdateEntryTitleAutocomplete(string sEntryTitle)
        {
            if (!txtEntryTitle.AutoCompleteCustomSource.Contains(sEntryTitle))
                txtEntryTitle.AutoCompleteCustomSource.Add(sEntryTitle);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.Size.ToString());
            MessageBox.Show(this.kpnlMain.Size.ToString());
        }

    }
}