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
    public partial class frcManageEntries : frbHSDChild
    {
        public frcManageEntries()
        {
            InitializeComponent();
            InitEventHandlers();
            InitDataControls();
            DefaultFocusControl = dgvEntries;
            RefreshEntriesTable();
        }

        private void btnSaveCorrectedDate_Click(object sender, EventArgs e)
        {
            SaveAlteredEntryDate();
        }

        private void btnDestroyEntry_Click(object sender, EventArgs e)
        {
            DialogResult dlgr = MessageBox.Show("You have are about to destroy the entry '"
                + lbdSelectedEntryTitle.Text + "'.  If you continue, this entry will be gone forever.\n\n"
                + "Are you sure you want to destroy this entry permanently?", "Destroy Information Forever?",
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

            if (dlgr == DialogResult.Yes)
                SaveDestroyedEntry();
        }

        private void cmboChooseMgmtAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayControlsByActionType((string)cmboChooseMgmtAction.SelectedValue);
        }

        private void dgvEntries_SelectionChanged(object sender, EventArgs e)
        {
            DisplayControlsByDGVSelection();
        }

        private void dgvEntries_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; //this is a HEADER row dblclick, ignore it.

            DateTime datEntryDate = (DateTime)dgvEntries[1, e.RowIndex].Value;
            int iEntryID = (int)dgvEntries[0, e.RowIndex].Value;

            HSDMain.fMaster.DisplayEntryFormAndSelectedEntry(datEntryDate, iEntryID);
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpStartDate.Value > dtpEndDate.Value)
                dtpEndDate.Value = dtpStartDate.Value;
            RefreshEntriesTable();
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpStartDate.Value > dtpEndDate.Value)
                dtpStartDate.Value = dtpEndDate.Value;
            RefreshEntriesTable();
        }

        private void DisplayControlsByActionType(string sActionType)
        {
            btnDestroyEntry.Visible = false;
            btnSaveCorrectedDate.Visible = false;
            dtpCorrectedEntryDate.Visible = false;
            lbcCorrectedEntryDate.Visible = false;

            if (sActionType == "correct_date") {
                btnSaveCorrectedDate.Visible = true;
                dtpCorrectedEntryDate.Visible = true;
                lbcCorrectedEntryDate.Visible = true;
            } else if (sActionType == "destroy_entry")
                btnDestroyEntry.Visible = true;
            else if (sActionType == "no_selection") { } 
            else
                throw new ArgumentException("Invalid action type " + sActionType + " received for managing entries.");
        }

        /// <summary>
        /// Notice that this method always calls DisplayControlsByActionType.
        /// </summary>
        private void DisplayControlsByDGVSelection()
        {
            if (dgvEntries.CurrentRow == null) {
                cmboChooseMgmtAction.Visible = false;
                lbdChooseMgmtActionNoEntrySelected.Visible = true;
                lbdSelectedEntryDate.Text = "(none)";
                lbdSelectedEntryTitle.Text = "(none)";
                DisplayControlsByActionType("no_selection");
            } else {
                cmboChooseMgmtAction.Visible = true;
                lbdChooseMgmtActionNoEntrySelected.Visible = false;
                lbdSelectedEntryDate.Text = ((DateTime)dgvEntries[1, dgvEntries.CurrentRow.Index].Value).ToString("d");
                lbdSelectedEntryTitle.Text = dgvEntries[2, dgvEntries.CurrentRow.Index].Value.ToString();
                DisplayControlsByActionType((string)cmboChooseMgmtAction.SelectedValue);
            }
        }

        public override void EntryRoutines()
        {
            RefreshEntriesTable();
            base.EntryRoutines();
        }

        private void InitDataControls()
        {
            DataTable dtMgmtActions = new DataTable("dt_mgmt_actions");

            dtMgmtActions.Columns.Add("DisplayColumn", typeof(string));
            dtMgmtActions.Columns.Add("ValueColumn", typeof(string));
            dtMgmtActions.Rows.Add(new string[] { "Alter Entry Date", "correct_date" });
            dtMgmtActions.Rows.Add(new string[] { "Destroy Entry", "destroy_entry" });

            cmboChooseMgmtAction.DisplayMember = "DisplayColumn";
            cmboChooseMgmtAction.ValueMember = "ValueColumn";
            cmboChooseMgmtAction.DataSource = dtMgmtActions;
            cmboChooseMgmtAction.SelectedIndex = 1;   //can't use -1, or kaboom b/c null valuemember.
            cmboChooseMgmtAction.SelectedIndex = 0;

            dtpEndDate.Value = DateTime.Today.AddDays(1);
            dtpStartDate.Value = DateTime.Today.AddMonths(-1);
            dtpCorrectedEntryDate.Value = DateTime.Today;
        }

        private void InitEventHandlers()
        {
            this.dtpStartDate.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);
            this.dtpEndDate.ValueChanged += new System.EventHandler(this.dtpEndDate_ValueChanged);
            this.cmboChooseMgmtAction.SelectedIndexChanged += new System.EventHandler(this.cmboChooseMgmtAction_SelectedIndexChanged);
            this.btnDestroyEntry.Click += new System.EventHandler(this.btnDestroyEntry_Click);
            this.btnSaveCorrectedDate.Click += new System.EventHandler(this.btnSaveCorrectedDate_Click);
            dgvEntries.SelectionChanged += new EventHandler(dgvEntries_SelectionChanged);
            dgvEntries.CellDoubleClick += new DataGridViewCellEventHandler(dgvEntries_CellDoubleClick);
        }

        private void RefreshEntriesTable()
        {
            lbdSelectedEntryDate.Text = "(none)";
            lbdSelectedEntryTitle.Text = "(none)";

            DataTable dt = HSDMain.CEDbH.SGetDEntryTitlesByDateRange(dtpStartDate.Value, dtpEndDate.Value);
            dgvEntries.DataSource = dt;

            dgvEntries.Columns[0].Visible = false;  //entry_id
            dgvEntries.Columns[3].Visible = false;  //entry_date
            dgvEntries.Columns[4].Visible = false;  //priority

            dgvEntries.Columns[1].HeaderCell.Value = "Entry Date";
            dgvEntries.Columns[2].HeaderCell.Value = "Entry Title";

            dgvEntries.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvEntries.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DisplayControlsByDGVSelection();
        }

        private void SaveAlteredEntryDate()
        {
            HSDMain.CEDbH.SaveEditedDEntryDate((int)dgvEntries[0, dgvEntries.CurrentRow.Index].Value, dtpCorrectedEntryDate.Value);
            RefreshEntriesTable();
            MessageBox.Show("The entry date was corrected successfully.", "Save Succeeded:");
        }

        private void SaveDestroyedEntry()
        {
            HSDMain.CEDbH.SaveDeletedDEntry((int)dgvEntries[0, dgvEntries.CurrentRow.Index].Value);
            RefreshEntriesTable();
            MessageBox.Show("The entry was destroyed successfully.", "Destroy Succeeded:");
        }

    }
}