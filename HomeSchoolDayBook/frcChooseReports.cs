using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HomeSchoolDayBook
{
    public partial class frcChooseReports : frbHSDChild
    {
        public frcChooseReports()
        {
            InitializeComponent();
            InitDataControls();
            DefaultFocusControl = lstChooseReport;
        }

        public override void EntryRoutines()
        {
            ReInitKidsAndSubjects();
            base.EntryRoutines();
        }

        private void lstChooseReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayEnabledControlsForSelectedReport();
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            if (lstChooseReport.SelectedIndex < 0) return;

            btnViewReport.Enabled = false;
            lblInstructionsReportLoading.Visible = true;
            lblInstructionsReportLoading.Refresh();

            try {
                DataRowView drv = (DataRowView)this.lstChooseReport.SelectedItem;

                NameValueCollection nvcParams = GetReportParams(drv["parameters"].ToString());
                DataTable dtRpt = GetReportDatatable(drv["datatable_key"].ToString());

                frpReportViewer fpReportViewer = new frpReportViewer(drv["rdlc_name"].ToString(), drv["data_source"].ToString(), nvcParams, dtRpt);
                fpReportViewer.ShowDialog(this);
            }
            finally {
                btnViewReport.Enabled = true;
                lblInstructionsReportLoading.Visible = false;
            }
        }

        private void DisplayEnabledControlsForSelectedReport()
        {
            if (lstChooseReport.SelectedIndex < 0) return;

            lbcStartDate.Enabled = false;
            dtpStartDate.Enabled = false;
            lbcEndDate.Enabled = false;
            dtpEndDate.Enabled = false;
            lbcKids.Enabled = false;
            cmboKids.Enabled = false;
            lbcSubjects.Enabled = false;
            cmboSubjects.Enabled = false;

            DataRowView drv = (DataRowView)this.lstChooseReport.SelectedItem;
            string[] sPNames = drv["parameters"].ToString().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string sPName in sPNames)
            {
                if (sPName == "start_date") {
                    lbcStartDate.Enabled = true;
                    dtpStartDate.Enabled = true;
                } else if (sPName == "end_date") {
                    lbcEndDate.Enabled = true;
                    dtpEndDate.Enabled = true;
                } else if (sPName == "kid_id") {
                    lbcKids.Enabled = true;
                    cmboKids.Enabled = true;
                } else if (sPName == "subject_id") {
                    lbcSubjects.Enabled = true;
                    cmboSubjects.Enabled = true;
                }
            }
        }

        private NameValueCollection GetReportParams(string sParamList)
        {
            NameValueCollection nvcP = new NameValueCollection();
            string[] sPNames = sParamList.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string sPName in sPNames) {
                if (sPName == "title")
                    nvcP.Add(sPName, lstChooseReport.Text);
                else if (sPName == "start_date")
                    nvcP.Add(sPName, dtpStartDate.Value.ToString("yyyy-MM-dd"));
                else if (sPName == "end_date")
                    nvcP.Add(sPName, dtpEndDate.Value.ToString("yyyy-MM-dd"));
                else
                    nvcP.Add(sPName, sPName);
            }

            return nvcP;
        }

        private DataTable GetReportDatatable(string sDTKey)
        {
            DataTable dt;

            if (sDTKey == "entries_full_by_date") {
                dt = HSDMain.CEDbH.SGetREntriesByDate(dtpStartDate.Value, dtpEndDate.Value, (int)cmboKids.SelectedValue, (int)cmboSubjects.SelectedValue);
            } else if (sDTKey == "entries_titles_by_date") {
                dt = HSDMain.CEDbH.SGetREntriesByDate(dtpStartDate.Value, dtpEndDate.Value, (int)cmboKids.SelectedValue, (int)cmboSubjects.SelectedValue);
            }
            else if (sDTKey == "time_spent_per_date_by_kid") {
                dt = HSDMain.CEDbH.SGetRTimeSpentPerDateByKid(dtpStartDate.Value, dtpEndDate.Value, (int)cmboKids.SelectedValue);
            }
            else if (sDTKey == "time_spent_per_subject_by_kid") {
                dt = HSDMain.CEDbH.SGetRTimeSpentPerSubjectByKid(dtpStartDate.Value, dtpEndDate.Value, (int)cmboKids.SelectedValue, (int)cmboSubjects.SelectedValue);
            }
            else if (sDTKey == "attendance_by_kid") {
                dt = HSDMain.CEDbH.SGetRAttendanceByKid(dtpStartDate.Value, dtpEndDate.Value, (int)cmboKids.SelectedValue);
            }
            else
                throw new ArgumentException("Unknown data query key supplied for report.");

            return dt;
        }

        private void InitDataControls()
        {
            DataTable dtReports = HSDMain.CEDbH.GetCodeTableData("uc_reports_active");

            lstChooseReport.SelectedIndex = -1;
            lstChooseReport.DisplayMember = "display_name";
            lstChooseReport.ValueMember = "report_id";
            lstChooseReport.DataSource = dtReports;

            dtpStartDate.Value = DateTime.Today.AddMonths(-1);
            dtpEndDate.Value = DateTime.Today;

            ReInitKidsAndSubjects();
        }

        private void ReInitKidsAndSubjects()
        {
            DataTable dtKids = HSDMain.CEDbH.GetCodeTableData("uc_kids_active_with_all_kids");
            DataTable dtSubjects = HSDMain.CEDbH.GetCodeTableData("uc_subjects_active_with_all_subjects");

            cmboKids.DataSource = null;
            cmboKids.Items.Clear();
            cmboSubjects.DataSource = null;
            cmboSubjects.Items.Clear();

            cmboKids.DisplayMember = "first_name";
            cmboKids.ValueMember = "kid_id";
            cmboKids.DataSource = dtKids;

            cmboSubjects.DisplayMember = "subject_desc";
            cmboSubjects.ValueMember = "subject_id";
            cmboSubjects.DataSource = dtSubjects;
        }

    }
}