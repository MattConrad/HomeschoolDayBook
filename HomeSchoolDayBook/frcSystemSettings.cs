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
    public partial class frcSystemSettings : frbHSDChild
    {
        public frcSystemSettings()
        {
            InitializeComponent();
            InitDataControls();
            DisplayDataControlSettings();
            DisplayVersionNumber();
            //event handler must init AFTER InitDataControlSettings.
            this.cmboAppearance.SelectedIndexChanged += new System.EventHandler(this.cmboAppearance_SelectedIndexChanged);
            DefaultFocusControl = this.cmboAppearance;
        }

        private void btnApplyAttendanceScreenScaling_Click(object sender, EventArgs e)
        {
            Decimal decNewScaling;
            if (decimal.TryParse(txtApplyAttendanceScreenScaling.Text, out decNewScaling))
            {
                if (decNewScaling <= 2.00M && decNewScaling >= 0.5M)
                {
                    HSDMain.SysSettings.SaveSetting("AttendanceDisplayScaling", decNewScaling.ToString("#.##"));
                    MessageBox.Show("Attendance screen scaling applied successfully. You will need to restart Day Book to see the changes.", "Apply Attendance Screen Scaling Success:");
                }
                else
                {
                    txtApplyAttendanceScreenScaling.Text = "1.00";
                    MessageBox.Show("Invalid scale setting. Typical values for scaling are 1.00, 1.25, or 1.50.\nUse 1.00 if you're not sure.", "Apply Attendance Screen Scaling Failure:");
                }
            }
            else
            {
                txtApplyAttendanceScreenScaling.Text = "1.00";
                MessageBox.Show("Attendance scaling must be a decimal number. Typical values for scaling are 1.00, 1.25, or 1.50.\nUse 1.00 if you're not sure.", "Apply Attendance Screen Scaling Failure:");
            }
        }

        private void btnBackupDayBook_Click(object sender, EventArgs e)
        {
            BackupRestore oBR = new BackupRestore();
            oBR.PromptBackupLocationAndSave();
        }

        private void btnResetScreenDisplayWarnings_Click(object sender, EventArgs e)
        {
            HSDMain.SysSettings.SaveSetting("ShowScreenResWarning", "1");
            HSDMain.SysSettings.SaveSetting("ShowDPIWarning", "1");

            MessageBox.Show("Users with non-standard displays will see warnings next time the program is loaded.  Note that warnings only display once each time they are reset.  Repeated display of warnings will require repeated resets.", "Screen Display Warnings Reset:");
        }

        private void btnRestoreFromBackup_Click(object sender, EventArgs e)
        {
            BackupRestore oBR = new BackupRestore();
            oBR.PromptRestoreFileLocationAndRestore();
        }

        private void cmboAppearance_SelectedIndexChanged(object sender, EventArgs e)
        {
            HSDMain.fMaster.DisplayKryptonPalette((int)cmboAppearance.SelectedValue);
            HSDMain.SysSettings.SaveSetting("KryptonPalette", cmboAppearance.SelectedValue.ToString());
        }

        public override void EntryRoutines()
        {
            DisplayDataControlSettings();
            base.EntryRoutines();
        }

        private void DisplayDataControlSettings()
        {
            cmboAppearance.SelectedValue = HSDMain.SysSettings.GetSettingInt("KryptonPalette");
            txtApplyAttendanceScreenScaling.Text = HSDMain.SysSettings.GetSettingDecimal("AttendanceDisplayScaling").ToString();
        }

        private void DisplayVersionNumber()
        {
            System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
            string sAsmVersion = asm.GetName().Version.ToString();
            lbdVersionNumber.Text = sAsmVersion;
        }

        private void InitDataControls()
        {
            DataTable dt = HSDMain.CEDbH.GetCodeTableData("uc_palettes_active");
            cmboAppearance.DisplayMember = "palette_name";
            cmboAppearance.ValueMember = "palette_id";
            cmboAppearance.DataSource = dt;
        }


    }
}