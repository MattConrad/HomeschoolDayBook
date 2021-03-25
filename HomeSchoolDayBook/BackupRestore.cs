using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlServerCe;

namespace HomeSchoolDayBook
{
    class BackupRestore
    {
        private void CheckAndRestoreFromBackup(string sRFile)
        {
            string sInvalidRestore = ValidateRestoreFile(sRFile);

            if (sInvalidRestore != "") {
                MessageBox.Show("The file \"" + sRFile + "\" is invalid:\n\n"
                    + sInvalidRestore
                    + "\n\nChoose a different file to restore Homeschool Day Book data.", "Invalid Restore File:");
                return;
            }

            //if we get this far, it was a valid backup.
            DialogResult dlgConfirmRestore = MessageBox.Show(
                "You are about to overwrite Homeschool Day Book from backup.  "
                + "If you continue, your current Day Book data will be lost.  "
                + "You will only have the data contained in the backup."
                + "\n\nDo not continue unless you are confident this is what you want."
                + "\n\nAre you sure you want to overwrite Day Book using this backup file?"
                , "Confirm Restore From Backup:", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

            if (dlgConfirmRestore != DialogResult.Yes) {
                MessageBox.Show("Restore cancelled.", "Restore Cancelled:");
                return;
            }

            if (!CloseDBWithRetry()) {
                MessageBox.Show("Active database could not be closed.  Restore cannot proceed."
                    + "\n\nRestart Homeschool Day Book and try your restore again.  If you get this error again, "
                    + "reboot your computer and try again after rebooting.", "Database error:");
                return;
            }

            try {
                //we don't create a .restorebak if we are restoring FROM a .restorebak.
                string sCreateRBAKFailure;
                if (Path.GetExtension(sRFile).ToLower() != ".restorebak")
                    sCreateRBAKFailure = CreateRestoreBAKFile();
                else
                    sCreateRBAKFailure = "";

                string sRestoreFailure = RestoreFromBackup(sRFile);

                if (sRestoreFailure != "") {
                    MessageBox.Show("Restore from backup FAILED.  Error message:\n\n"
                        + sRestoreFailure
                        + "\n\nRestart Homeschool Day Book and try your restore again.  If you get this error again, "
                        + "reboot your computer and try again after rebooting.", "Restore From Backup Failure:");                
                }
                // i hope we never come here, but for now let's pester the user if we do.
                else if (sCreateRBAKFailure != "") {
                    MessageBox.Show("Restore from backup succeeded.  "
                        + "However, an attempt to create an extra backup file failed:\n\n"
                        + sCreateRBAKFailure
                        + "\n\nYou should be able to use your restored Day Book, but please "
                        + "send the above error to info@HomeSchoolDayBook.com.", "Restore From Backup Success (qualified):");
                }
                else {
                    MessageBox.Show("Restore from backup succeeded.\n\nYou may continue using Homeschool Day Book with your restored data.", "Restore From Backup Success:");
                }
            }
            finally {
                HSDMain.CEDbH.ToggleDBConn("open");
            }
        }

        /// <summary>
        /// True if db was closed, false if not.
        /// </summary>
        /// <returns></returns>
        private bool CloseDBWithRetry()
        {
            HSDMain.CEDbH.ToggleDBConn("close");

            int iDBChecks = 0;
            while (!HSDMain.CEDbH.IsDbClosed() && iDBChecks < 20) {
                System.Threading.Thread.Sleep(100);
                iDBChecks++;
            }

            if (HSDMain.CEDbH.IsDbClosed())
                return true;
            else
                return false;
        }

        /// <summary>
        /// This method trusts that the db is closed before it is called.  Do not call while db is open.
        /// </summary>
        public void CreateAutomaticDBBackups()
        {
            DateTime datBakA;
            DateTime datBakB;
            string sBakA = HSDMain.sDBDirectory + @"backup\daybook.autobaka";
            string sBakB = HSDMain.sDBDirectory + @"backup\daybook.autobakb";

            //if there is no .bak file at all, we can treat same as very old file.
            datBakA = (File.Exists(sBakA)) ? File.GetLastWriteTime(sBakA) : new DateTime(1900, 01, 01);
            datBakB = (File.Exists(sBakB)) ? File.GetLastWriteTime(sBakB) : new DateTime(1900, 01, 01);

            string sSDF = HSDMain.sDBDirectory + HSDMain.sDBFileName;

            //IF bakB is old and bakA exists, we copy existing bakA to bakB.
            if (File.Exists(sBakA) && (datBakB.Date.AddDays(4) < DateTime.Today))
                File.Copy(sBakA, sBakB, true);

            //always copy sdf to bakA.  this does mean that any user mistakes will get backed up on close.  crash-corruptions won't.
            File.Copy(sSDF, sBakA, true);
        }

        /// <summary>
        /// This method trusts that the db is closed before it is called.  Do not call while db is open.
        /// Return value is failure error message: "" means OK.
        /// Also, beware circular .restorebak cycle.  Caller is responsible for checking this.
        /// </summary>
        private string CreateRestoreBAKFile()
        {
            try {
                string sRestoreBAK = HSDMain.sDBDirectory + @"backup\daybook.restorebak";
                string sSDF = HSDMain.sDBDirectory + HSDMain.sDBFileName;

                File.Copy(sSDF, sRestoreBAK, true);

                return "";
            }
            catch (Exception x) {
                return x.Message;
            }
        }

        public void PromptBackupLocationAndSave()
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.DefaultExt = "dbk";
            dlg.AddExtension = true;
            //we can trust the dlg path checking, but we will do our own overwrite checking.
            dlg.CheckPathExists = true;
            dlg.OverwritePrompt = false;
            dlg.Filter = "Homeschool Day Book Backup (*.dbk) |*.dbk";
            DialogResult dlgResult = dlg.ShowDialog();

            if (dlgResult == DialogResult.OK) {

                string sBFile = dlg.FileName;

                if (File.Exists(sBFile) && (Path.GetExtension(sBFile) == ".dbk")) {
                    DialogResult dlgOverwrite = MessageBox.Show(
                        "The file \"" + sBFile + "\" already exists.  If you continue, you will overwrite "
                        + "the existing file.  The information there will be gone forever."
                        + "\n\nDo you want to overwrite the existing file with a new backup?",
                        "Overwrite existing backup?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                    //if user says either No or Cancel, exit routine completely.
                    if (dlgOverwrite != DialogResult.Yes)
                        return;
                }

                if (File.Exists(sBFile) && (Path.GetExtension(sBFile) != ".dbk")) {
                    MessageBox.Show("The file \"" + sBFile + "\" already exists.  This file does not appear "
                        + "to be a Homeschool Day Book backup file.  It cannot be overwritten."
                        + "\n\nChoose another name for your backup file.", "Invalid Backup File:");
                }
                else {
                    SaveBackupFile(sBFile);
                }
            }
            else {
                MessageBox.Show("Backup cancelled.", "Backup Cancelled:");
            }
        }

        public void PromptRestoreFileLocationAndRestore()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Homeschool Day Book Backup (*.dbk) |*.dbk|All Files (*.*) |*.*";
            dlg.CheckFileExists = true;
            DialogResult dlgResult = dlg.ShowDialog();

            if (dlgResult == DialogResult.OK) {
                string sRFile = dlg.FileName;
                CheckAndRestoreFromBackup(sRFile);
            }
        }


        /// <summary>
        /// This method trusts that the db is closed before it is called.  Do not call while db is open.
        /// Return value is failure error message: "" means OK.
        /// </summary>
        private string RestoreFromBackup(string sRFile)
        {
            try {
                string sSDF = HSDMain.sDBDirectory + HSDMain.sDBFileName;
                File.Copy(sRFile, sSDF, true);

                return "";
            }
            catch (Exception x) {
                return x.Message;
            }
        }

        /// <summary>
        /// Closes and re-opens db conn.  This method WILL overwrite if the file exists.  Caller is responsible for any checking of overwrites before calling.
        /// </summary>
        /// <param name="sBackupFile"></param>
        private void SaveBackupFile(string sBackupFile)
        {
            if (!CloseDBWithRetry()) {
                MessageBox.Show("Problem with database, database could not be closed.  Backup cannot proceed."
                    + "\n\nRestart Homeschool Day Book and try your backup again.  If you get this error again, "
                    + "reboot your computer and try again after rebooting.", "Database error:");
                return;
            }

            string sSDF = HSDMain.sDBDirectory + HSDMain.sDBFileName;
            try {
                File.Copy(sSDF, sBackupFile, true);
                MessageBox.Show("The backup file \"" + sBackupFile + "\" was created successfully."
                    + "\n\nTo protect against hard drive failure, keep backups somewhere different "
                    + "from the computer where you run Homeschool Day Book.",
                    "Backup Succeeded:");
            }
            catch (Exception x) {
                MessageBox.Show("Saving backup file failed.  You may be trying to save to a "
                    + "location where you do not have permissions, or the save location "
                    + "may be out of room, or some other hard drive/network error may have occured.  "
                    + "The failed backup attempt gave this error message:\n\n"
                    + x.Message
                    + "\n\nFix the error or retry your save to a different location.", "Backup Failed:");
            }
            finally {
                HSDMain.CEDbH.ToggleDBConn("open");
            }
        }

        private string ValidateRestoreFile(string sRFile)
        {
            string sRFileError = "";
            string sDBConn = "Data Source='" + sRFile
                + "';Encrypt Database=False"
                + ";Persist Security Info=False;";

            SqlCeConnection sqlRFConn = new SqlCeConnection(sDBConn);
            try {
                sqlRFConn.Open();
                SqlCeCommand sqcmdTest = new SqlCeCommand("select * from uc_setting", sqlRFConn);
                int iRows = sqcmdTest.ExecuteNonQuery();  //ExecuteNonQuery returns -1, unfortuantely.
            }
            catch {
                if (sqlRFConn.State == ConnectionState.Open)
                    sqlRFConn.Close();

                //adding error details will only confuse the user.
                sRFileError = "File is not a Day Book backup, or it has been corrupted.";
                return sRFileError;
            }

            try {
                //if we get this far, it's a valid day book backup.  must check version #.
                //  do not want to restore a backup from a previous version that won't run anymore!
                SqlCeDataAdapter sqda = new SqlCeDataAdapter("select setting_name, datatype, setting_value from uc_setting where setting_name = 'DatabaseVersion'", sqlRFConn);
                DataTable dtVN = new DataTable();
                sqda.Fill(dtVN);

                Decimal dRestoreDBVersion = 0.0M;
                //if we don't have any records, is pre 1.06 database, db version 1.00.
                //  should be impossible to have > 1 record, bc setting_name is PK on uc_setting.
                if (dtVN.Rows.Count == 0) {
                    dRestoreDBVersion = 1.00M;
                }
                else {
                    string sVersionNumber = dtVN.Rows[0]["setting_value"].ToString();
                    if (!decimal.TryParse(sVersionNumber, out dRestoreDBVersion)) {
                        sRFileError = "Could not read database version from backup (parse decimal error). "
                            + "Cannot restore. Email info@HomeSchoolDayBook.com for help.";
                        return sRFileError;
                    }
                }

                if (dRestoreDBVersion != HSDMain.dDBVersion) {
                    sRFileError = "This backup file is incompatible with your version of Homeschool Day Book.  "
                        + "(backup dbv " + dRestoreDBVersion + ", Day Book dbv " + HSDMain.dDBVersion +")";
                    return sRFileError;
                }
            }
            finally {
                sqlRFConn.Close();
            }

            //since we've been blasting out return statements above, this should be "".
            return sRFileError;
        }

    }
}
