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
    public partial class frcManageKids : frbHSDChild
    {
        bool _bIgnoreChangesToData;
        bool _bAbortSelIndexChanged;
        bool _isAddNew;

        public frcManageKids()
        {
            InitializeComponent();
            InitEventHandlers();
            DefaultFocusControl = lstKids;
        }

        private void frmManageKids_Load(object sender, EventArgs e)
        {
            RefreshListing();
            DisplayAddNewOrEditInstructions();   //we might not have any kids entered yet!
            lstKids.SelectedIndex = -1;
            lstKids.SelectedIndex = 0;      // force the sel index changed routine to run.
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DisplayCancelledSave();
            DisplayDefaultFocus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateKid() != "") {
                MessageBox.Show("The following errors prevented saving data:\n\n"
                    + ValidateKid()
                    + "\n\nCorrect the errors and try your save again.", "Invalid Data:");
                return;
            }

            SaveData();
        }

        private void lstKids_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_bAbortSelIndexChanged) return;

            if (lstKids.SelectedIndex < 0) return;

            DisplayAddNewOrEditInstructions();

            if (lstKids.SelectedIndex == 0) {
                DisplayNewKid();
            } else {
                DisplayExistingKid((DataRowView)lstKids.SelectedItem);
            }
        }

        private void DisplayAddNewOrEditInstructions()
        {
            if (lstKids.SelectedIndex == 0) {
                lblInstructionsAddNew.Text = "To add a new kid, just start entering data and click Save when you are done.";
                if (lstKids.Items.Count > 1)
                    lblInstructionsEdit.Text = "To edit an existing kid, choose a kid from the list below.";
                else
                    lblInstructionsEdit.Text = "";
            } else {
                lblInstructionsAddNew.Text = "To add a new kid, choose '(add new kid)' at the top of the list shown below.";
                lblInstructionsEdit.Text = "To edit the selected kid, just change the data and click Save when you are done.";
            }
        }

        private void DisplayCancelledSave()
        {
            if (lstKids.SelectedIndex == 0) {
                DisplayNewKid();
            } else {
                DisplayExistingKid((DataRowView)lstKids.SelectedItem);
            }

            DisplayScreenForDataNeedsSaving(false);
        }

        private void DisplayExistingKid(DataRowView drv)
        {
            _isAddNew = false;

            _bIgnoreChangesToData = true;

            txtFirstName.Text = (string)drv["first_name"];
            chkIsDefaultInvolved.Checked = (bool)drv["is_default_involved"];
            chkIsActive.Checked = (bool)drv["is_active"];
            
            _bIgnoreChangesToData = false;
        }

        private void DisplayNewKid()
        {
            _isAddNew = true;

            _bIgnoreChangesToData = true;

            txtFirstName.Text = "";
            chkIsDefaultInvolved.Checked = true;
            chkIsActive.Checked = true;

            _bIgnoreChangesToData = false;
        }

        private void DisplayScreenForDataNeedsSaving(bool bSaveIsEnabled)
        {
            btnSave.Enabled = bSaveIsEnabled;
            btnCancel.Enabled = bSaveIsEnabled;

            lstKids.Enabled = !bSaveIsEnabled;

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
                    btnSave.Text = "Sa&ve New Kid";
                else
                    btnSave.Text = "Sa&ve Edited Kid";

            } else {
                btnCancel.Text = "(no changes to cancel)";
                btnSave.Text = "(no changes to save)";
            }
        }

        private void InitEventHandlers()
        {
            this.Load += new System.EventHandler(this.frmManageKids_Load);

            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.lstKids.SelectedIndexChanged += new System.EventHandler(this.lstKids_SelectedIndexChanged);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.txtFirstName.TextChanged += new EventHandler(SetDirtyData);
            this.chkIsActive.CheckedChanged += new EventHandler(SetDirtyData);
            this.chkIsDefaultInvolved.CheckedChanged += new EventHandler(SetDirtyData);
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

            lstKids.DataSource = null;
            lstKids.Items.Clear();

            DataTable dt = HSDMain.CEDbH.GetCodeTableData("uc_kids_all_with_new");
            lstKids.DisplayMember = "first_name_w_active";
            lstKids.ValueMember = "kid_id";
            lstKids.DataSource = dt;

            _bAbortSelIndexChanged = false;
        }

        private void SaveData()
        {
            int iKidID;

            if (_isAddNew) {
                iKidID = HSDMain.CEDbH.SaveNewCKid(txtFirstName.Text, chkIsDefaultInvolved.Checked, chkIsActive.Checked);
                //no, after adding new let's return back to "(add new)" which has value of -1.
                iKidID = -1;
            } else {
                iKidID = (int)lstKids.SelectedValue;
                HSDMain.CEDbH.SaveEditedCKid(iKidID, txtFirstName.Text, chkIsDefaultInvolved.Checked, chkIsActive.Checked);
            }

            StaticMethods.RefreshCodeTable("uc_kids_active_with_all_kids");
            StaticMethods.RefreshCodeTable("uc_kids_active");
            StaticMethods.RefreshCodeTable("uc_kids_all");

            RefreshListing();
            //tweak SelInd to force event firing when SelVal changes.
            lstKids.SelectedIndex = -1;
            lstKids.SelectedValue = iKidID;
            DisplayScreenForDataNeedsSaving(false);
            DisplayDefaultFocus();
        }

        private void SetDirtyData(object sender, EventArgs e)
        {
            if (_bIgnoreChangesToData) return;

            DisplayScreenForDataNeedsSaving(true);
        }

        private string ValidateKid()
        {
            string sErr = "";

            if (txtFirstName.Text.Trim().Length < 1)
                sErr += "Kid must have a first name.";

            return sErr;
        }


    }
}