using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace HomeSchoolDayBook
{
    public partial class frcManageSubjects : frbHSDChild
    {
        bool _bIgnoreChangesToData;
        bool _bAbortSelIndexChanged;
        bool _isAddNew;
        string _sPreEditSubjectName;

        public frcManageSubjects()
        {
            InitializeComponent();
            InitEventHandlers();
            DefaultFocusControl = lstSubjects;
        }

        private void InitEventHandlers()
        {
            this.Load += new System.EventHandler(this.frmManageSubjects_Load);

            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.lstSubjects.SelectedIndexChanged += new System.EventHandler(this.lstSubjects_SelectedIndexChanged);

            this.txtSubjectName.TextChanged += new EventHandler(SetDirtyData);
            this.chkIsActive.CheckedChanged += new EventHandler(SetDirtyData);
        }

        private void frmManageSubjects_Load(object sender, EventArgs e)
        {

            RefreshListing();
            DisplayAddNewOrEditInstructions();   //we might not have any kids entered yet!
            lstSubjects.SelectedIndex = -1;
            lstSubjects.SelectedIndex = 0;      // force the sel index changed routine to run.
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DisplayCancelledSave();
            DisplayDefaultFocus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateSubject() != "") {
                MessageBox.Show("The following errors prevented saving data:\n\n"
                    + ValidateSubject()
                    + "\n\nCorrect the errors and try your save again.", "Invalid Data:");
                return;
            }

            if (_isAddNew == false && _sPreEditSubjectName != txtSubjectName.Text) {
                DialogResult dlgr = MessageBox.Show("You are about to change the name of "
                    + "this subject from '" + _sPreEditSubjectName + "' to '" + txtSubjectName.Text + "'.  "
                    + "This will also change any previous entries marked '" + _sPreEditSubjectName + "'.\n\n"
                    + "Are you sure you want to make this change?", "WARNING: Change old data?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                if (dlgr == DialogResult.No) return;
            }

            SaveData();
        }

        private void lstSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_bAbortSelIndexChanged) return;

            if (lstSubjects.SelectedIndex < 0) return;

            DisplayAddNewOrEditInstructions();

            if (lstSubjects.SelectedIndex == 0) {
                DisplayNewSubject();
            } else {
                DisplayExistingSubject((DataRowView)lstSubjects.SelectedItem);
            }
        }

        private void DisplayAddNewOrEditInstructions()
        {
            if (lstSubjects.SelectedIndex == 0) {
                lblInstructionsAddNew.Text = "To add a new subject, just start entering data and click Save when you are done.";
                if (lstSubjects.Items.Count > 1)
                    lblInstructionsEdit.Text = "To edit an existing subject, choose a subject from the list below.";
                else
                    lblInstructionsEdit.Text = "";
            } else {
                lblInstructionsAddNew.Text = "To add a new subject, choose '(add new subject)' at the top of the list shown below.";
                lblInstructionsEdit.Text = "To edit the selected subject, just change the data and click Save when you are done.";
            }
        }

        private void DisplayCancelledSave()
        {
            if (lstSubjects.SelectedIndex == 0) {
                DisplayNewSubject();
            } else {
                DisplayExistingSubject((DataRowView)lstSubjects.SelectedItem);
            }

            DisplayScreenForDataNeedsSaving(false);
        }

        private void DisplayExistingSubject(DataRowView drv)
        {
            _isAddNew = false;
            _bIgnoreChangesToData = true;
            _sPreEditSubjectName = (string)drv["subject_desc"];
            txtSubjectName.Text = (string)drv["subject_desc"];
            chkIsActive.Checked = (bool)drv["is_active"];
            _bIgnoreChangesToData = false;
        }

        private void DisplayNewSubject()
        {
            _isAddNew = true;
            _bIgnoreChangesToData = true;
            _sPreEditSubjectName = "";
            txtSubjectName.Text = "";
            chkIsActive.Checked = true;
            _bIgnoreChangesToData = false;
        }

        private void DisplayScreenForDataNeedsSaving(bool bSaveIsEnabled)
        {
            btnSave.Enabled = bSaveIsEnabled;
            btnCancel.Enabled = bSaveIsEnabled;

            lstSubjects.Enabled = !bSaveIsEnabled;

            lblInstructionsAddNew.Visible = !bSaveIsEnabled;
            lblInstructionsEdit.Visible = !bSaveIsEnabled;
            lblDisabledDueToUnsavedData.Visible = bSaveIsEnabled;

            DisplaySaveButtonCaptions();
        }

        private void DisplaySaveButtonCaptions()
        {
            if (btnSave.Enabled) {

                btnCancel.Text = "&Cancel Changes";
                if (_isAddNew)
                    btnSave.Text = "Sa&ve New Subject";
                else
                    btnSave.Text = "Sa&ve Edited Subject";

            } else {
                btnCancel.Text = "(no changes to cancel)";
                btnSave.Text = "(no changes to save)";
            }
        }

        public override bool IsExitAllowed()
        {
            if (!btnSave.Enabled)
                return true;

            DialogResult dlgr = MessageBox.Show("You have unsaved changes.  If you continue, you will "
                + "lose these changes.  Choose 'No' to stay here and save your changes.\n\n"
                + "Are you sure you want to leave and lose your changes?", "Lose Unsaved Changes?",
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

            if (dlgr == DialogResult.Yes) {
                DisplayCancelledSave();
                return true;
            } else {
                return false;
            }
        }

        private void RefreshListing()
        {
            _bAbortSelIndexChanged = true;

            lstSubjects.DataSource = null;
            lstSubjects.Items.Clear();

            DataTable dt = HSDMain.CEDbH.GetCodeTableData("uc_subjects_all_with_new");
            lstSubjects.DisplayMember = "subject_desc_w_active";
            lstSubjects.ValueMember = "subject_id";
            lstSubjects.DataSource = dt;

            _bAbortSelIndexChanged = false;
        }

        private void SaveData()
        {
            int iSubjectID;

            if (_isAddNew) {
                iSubjectID = HSDMain.CEDbH.SaveNewCSubject(txtSubjectName.Text, chkIsActive.Checked);
                //no, after adding new let's return back to "(add new)" which has value of -1.
                iSubjectID = -1;
            }
            else {
                iSubjectID = (int)lstSubjects.SelectedValue;
                HSDMain.CEDbH.SaveEditedCSubject(iSubjectID, txtSubjectName.Text, chkIsActive.Checked);
            }

            StaticMethods.RefreshCodeTable("uc_subjects_active_with_all_subjects");
            StaticMethods.RefreshCodeTable("uc_subjects_active");
            StaticMethods.RefreshCodeTable("uc_subjects_all");
            RefreshListing();
            //tweak SelInd to force event firing when SelVal changes.
            lstSubjects.SelectedIndex = -1;
            lstSubjects.SelectedValue = iSubjectID;
            DisplayScreenForDataNeedsSaving(false);
            DisplayDefaultFocus();
        }

        private void SetDirtyData(object sender, EventArgs e)
        {
            if (_bIgnoreChangesToData) return;

            DisplayScreenForDataNeedsSaving(true);
        }

        private string ValidateSubject()
        {
            string sErr = "";

            if (txtSubjectName.Text.Trim().Length < 1)
                sErr += "Subject must have a name.";

            return sErr;
        }
    }
}