using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlServerCe;

/*
 * 02/05/09:
 * added several default values to uc_setting, some of which are now used & required.
 * 
 * 11/04/08:
 * added uc_palette, populated, added row to uc_setting (KryptonPalette).
 * 
 * 09/05/08:
 * dropped tables ut_calendar and ud_attendance.
 * 
 * 08/15/08:
 * rewrote all the sqlcmd declaration stuff to use custom .sql file format.  eeee!
 * 
 * 08/05/08:
 * upgraded to CE 3.5.  this seems to have fixed the bug from 04/30/08.  hurray.
 * should test this again later with a perfectly clean db, though.
 * 
 * 07/02/08:
 * we are NOT using < @end_date as a standard approach.  we were, but I changed my mind.
 * effectively, this means that entry dates can never include a time component.  I think
 * we were really locked into this already.  so no point in extra complexity of adding
 * a day to end date and using <.  using <= with actual day should work fine.
 * 
 * 04/30/08:  there is a weird bug with the SqlCeCommand object (at least I think that is the fault).
 *  if we run _sqcGetDTitlesAndNewByTargetDate when there are NO entries in the db, then further invocations
 *  of that cmd IGNORE the where clause and return all results.  wrong!  tried a few things to fix,
 *  one that works is setting .Connection to null and then back to the active connection.  rather than
 *  doing this every select query time, we just do this after saving new (since saving new is the only 
 *  possible path to this error).
 * 
*/

namespace HomeSchoolDayBook
{
    class CEDBHandler
    {
        private SqlCeCommand _sqcGetCKidsActive;
        private SqlCeCommand _sqcGetCKidsAll;
        private SqlCeCommand _sqcGetCReportsActive;
        private SqlCeCommand _sqcGetCSubjectsActive;
        private SqlCeCommand _sqcGetCSubjectsAll;
        private SqlCeCommand _sqcGetCPalettesActive;
        private SqlCeCommand _sqcGetCSettingsAll;
        private SqlCeCommand _sqcGetDAttendanceByDateRange;
        private SqlCeCommand _sqcGetDTitlesByTargetDate;
        private SqlCeCommand _sqcGetDTitlesByDateRange;
        private SqlCeCommand _sqcGetDEntryByID;
        private SqlCeCommand _sqcGetDEntriesMinutesByDate;
        private SqlCeCommand _sqcGetDEntriesCountByDate;
        private SqlCeCommand _sqcGetDEntriesMinutesAll;
        private SqlCeCommand _sqcGetDEntriesCountAll;
        private SqlCeCommand _sqcGetDKidsByID;
        private SqlCeCommand _sqcGetDSubjectsByID;
        private SqlCeCommand _sqcGetDNewIDValue;     //works for ANY table.  be careful with this one.
        private SqlCeCommand _sqcGetREntriesByDate;
        private SqlCeCommand _sqcGetDEntryTitlesDistinct90Days;
        private SqlCeCommand _sqcAddCKid;
        private SqlCeCommand _sqcAddCSubject;
        private SqlCeCommand _sqcAddCSetting;
        private SqlCeCommand _sqcAddDEntry;
        private SqlCeCommand _sqcAddDEntrySubject;
        private SqlCeCommand _sqcAddDEntryKid;
        private SqlCeCommand _sqcEditCKid;
        private SqlCeCommand _sqcEditCSubject;
        private SqlCeCommand _sqcEditDEntry;
        private SqlCeCommand _sqcEditDEntryDate;
        private SqlCeCommand _sqcEditCSetting;
        private SqlCeCommand _sqcDeleteDSubjectsByEntryID;
        private SqlCeCommand _sqcDeleteDKidsByEntryID;
        private SqlCeCommand _sqcDeleteDEntryByEntryID;
        private SqlCeCommand _sqcGetRTimeSpentPerSubjectByKid;
        private SqlCeCommand _sqcGetRTimeSpentPerDateByKid;
        private SqlCeCommand _sqcGetRAttendance;

        private SqlCeConnection _sqlConn;

        public CEDBHandler()
        {
            InitDBConn();
            InitSqlCmds();
            ToggleDBConn("open");
            //PrepareSqlCmds();     remember cmd.Prepare.  if you really want to go here, do upon initialization.
        }

        ~CEDBHandler()
        {
            if (_sqlConn.State != ConnectionState.Closed)
                ToggleDBConn("close");
        }

        public DataTable GetCodeTableData(string sTableName)
        {
            SqlCeDataAdapter da = null;
            if (sTableName == "uc_kids_active")
                da = new SqlCeDataAdapter(_sqcGetCKidsActive);
            else if (sTableName == "uc_kids_all")
                da = new SqlCeDataAdapter(_sqcGetCKidsAll);
            else if (sTableName == "uc_kids_all_with_new")
                da = new SqlCeDataAdapter(_sqcGetCKidsAll);
            else if (sTableName == "uc_kids_active_with_all_kids")
                da = new SqlCeDataAdapter(_sqcGetCKidsActive);
            else if (sTableName == "uc_reports_active")
                da = new SqlCeDataAdapter(_sqcGetCReportsActive);
            else if (sTableName == "uc_subjects_active")
                da = new SqlCeDataAdapter(_sqcGetCSubjectsActive);
            else if (sTableName == "uc_subjects_all")
                da = new SqlCeDataAdapter(_sqcGetCSubjectsAll);
            else if (sTableName == "uc_subjects_all_with_new")
                da = new SqlCeDataAdapter(_sqcGetCSubjectsAll);
            else if (sTableName == "uc_subjects_active_with_all_subjects")
                da = new SqlCeDataAdapter(_sqcGetCSubjectsActive);
            else if (sTableName == "uc_palettes_active")
                da = new SqlCeDataAdapter(_sqcGetCPalettesActive);
            else if (sTableName == "uc_settings_all")
                da = new SqlCeDataAdapter(_sqcGetCSettingsAll);
            else
                throw new ArgumentException("Cannot find code table '" + sTableName + "'.");

            DataTable dt = new DataTable();
            da.Fill(dt);

            if (sTableName == "uc_kids_all_with_new")
                InsertRowAtTopOfDT(ref dt, "first_name_w_active", "kid_id", "(add new kid)");

            if (sTableName == "uc_subjects_all_with_new")
                InsertRowAtTopOfDT(ref dt, "subject_desc_w_active", "subject_id", "(add new subject)");

            if (sTableName == "uc_kids_active_with_all_kids")
                InsertRowAtTopOfDT(ref dt, "first_name", "kid_id", "(all kids)");

            if (sTableName == "uc_subjects_active_with_all_subjects")
                InsertRowAtTopOfDT(ref dt, "subject_desc", "subject_id", "(all subjects)");

            if (sTableName == "uc_settings_all")
                dt.PrimaryKey = new DataColumn[] { dt.Columns["setting_name"] };

            return dt;
        }

        private string GetConnString(string sFilePath) 
        {
            string sConn = "Data Source='" + sFilePath
                + "';Encrypt Database=False"
                + ";Persist Security Info=False;";

            return sConn;
        }

        private Dictionary<string, FieldInfo> GetDeclaredSqlCmds()
        {
            Dictionary<string, FieldInfo> dictFI = new Dictionary<string, FieldInfo>();
            Type t = Assembly.GetExecutingAssembly().GetType("HomeSchoolDayBook.CEDBHandler");
            MemberInfo[] mbrs = t.GetMembers(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (MemberInfo mbr in mbrs) {
                if (mbr.MemberType == MemberTypes.Field) {
                    //                    System.Windows.Forms.MessageBox.Show(fld.FieldType.ToString());
                    FieldInfo fld = (FieldInfo)mbr;
                    if (fld.FieldType == typeof(SqlCeCommand))
                        dictFI[fld.Name] = fld;
                }
            }

            return dictFI;
        }

        private SqlCeCommand GetSqlCmdFromTextsAndParams(List<string> lstSQLTexts, List<string> lstSQLParams)
        {
            string sSQL = String.Join(Environment.NewLine, lstSQLTexts.ToArray());
            SqlCeCommand sqc = new SqlCeCommand(sSQL, _sqlConn);

            foreach (string sPDef in lstSQLParams) {
                string[] sParts = sPDef.Split(new char[] { ' ' });

                if (sPDef.StartsWith(":pb"))
                    sqc.Parameters.Add(sParts[1], SqlDbType.Bit);
                else if (sPDef.StartsWith(":pd"))
                    sqc.Parameters.Add(sParts[1], SqlDbType.DateTime);
                else if (sPDef.StartsWith(":pt"))
                    sqc.Parameters.Add(sParts[1], SqlDbType.NText);
                else if (sPDef.StartsWith(":pi"))
                    sqc.Parameters.Add(sParts[1], SqlDbType.Int);
                else if (sPDef.StartsWith(":pc")) {
                    string sSize = sParts[0].Substring(3);
                    int iSize = int.Parse(sSize);
                    sqc.Parameters.Add(sParts[1], SqlDbType.NVarChar, iSize);
                }
                else
                    throw new ArgumentException("Invalid parameter definition header '" + sParts[0] + "'.");
            }

            return sqc;
        }

        private void InitDBConn()
        {
            string sFilePath = HSDMain.sDBDirectory + HSDMain.sDBFileName;

            string sConn = GetConnString(sFilePath);

            _sqlConn = new SqlCeConnection(sConn);
        }

        private void InitSqlCmds()
        {
            Dictionary<string, FieldInfo> dictLocalSqc = GetDeclaredSqlCmds();

            Assembly asmbCurrent = System.Reflection.Assembly.GetExecutingAssembly();
            //encoding issues?
            System.IO.TextReader streamSQL = new System.IO.StreamReader(asmbCurrent.GetManifestResourceStream("HomeSchoolDayBook.resSQLCommands.sql"));

            try {
                List<string> lstSQLTexts = new List<string>();
                List<string> lstSQLParams = new List<string>();
                while (streamSQL.Peek() != -1) {
                    string sLine = streamSQL.ReadLine();

                    if (sLine.Trim().StartsWith("--")) { }      //comment, do nothing
                    else if (sLine.Trim().Length < 1) { }       //blank, do nothing
                    else if (sLine.Trim().StartsWith(":p"))     //parameter
                        lstSQLParams.Add(sLine);
                    else if (sLine.Trim().StartsWith(":n")) {   //the name of the sqlcmd.  means we're done with this sqlcmd.
                        string sSqcName = sLine.Split(new char[] { ' ' })[1];     //unfortunately, is no "split on all whitespace" in String.Split.  Could use Regex.Split, but for now, we'll trust myself.
                        dictLocalSqc[sSqcName].SetValue(this, GetSqlCmdFromTextsAndParams(lstSQLTexts, lstSQLParams));
                        lstSQLTexts = new List<string>();
                        lstSQLParams = new List<string>();
                    }
                    else                                        //is "standard" SQL, part of the query.  we hope.  :)
                        lstSQLTexts.Add(sLine);
                }
            }
            finally {
                streamSQL.Close();
            }

            //maybe take this out later.
            foreach (FieldInfo f in dictLocalSqc.Values) {
                if (f.GetValue(this) == null)
                    throw new InvalidOperationException("SQL Command '" + f.Name + "' was not defined properly during initialization.");
            }
        }

        /// <summary>
        /// This is a perhaps-brittle method to add an "add new" or "all subjects/kids" row at the top of a table that will
        /// be used to populate a listbox/cmbobox.  It only fills in the DisplayMember and ValueMember columns.
        /// It assumes -1 for the ValueMember column (could param this).  It always puts the new row
        /// at the top.  Any extra columns in the code table (like priority) are NOT filled in,
        /// which may create problems if you forget what you're doing.
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="sDisplayCol"></param>
        /// <param name="sValueCol"></param>
        /// <param name="sDisplayText"></param>
        private void InsertRowAtTopOfDT(ref DataTable dt, string sDisplayCol, string sValueCol, string sDisplayText)
        {
            DataRow dr = dt.NewRow();
            dr[sValueCol] = -1;
            dr[sDisplayCol] = sDisplayText;

            dt.Rows.InsertAt(dr, 0);
        }

        public bool IsDbClosed()
        {
            return (_sqlConn.State == ConnectionState.Closed);
        }

        public void SaveEditedCKid(int iKidID, string sFirstName, bool isDefaultInvolved, bool isActive)
        {
            _sqcEditCKid.Parameters["@kid_id"].Value = iKidID;
            _sqcEditCKid.Parameters["@first_name"].Value = sFirstName;
            _sqcEditCKid.Parameters["@is_default_involved"].Value = isDefaultInvolved;
            _sqcEditCKid.Parameters["@is_active"].Value = isActive;

            _sqcEditCKid.ExecuteNonQuery();
        }

        public int SaveNewCKid(string sFirstName, bool isDefaultInvolved, bool isActive)
        {
            _sqcAddCKid.Parameters["@first_name"].Value = sFirstName;
            _sqcAddCKid.Parameters["@is_default_involved"].Value = isDefaultInvolved;
            _sqcAddCKid.Parameters["@is_active"].Value = isActive;

            _sqcAddCKid.ExecuteNonQuery();
            int iKidID = (int)(decimal)_sqcGetDNewIDValue.ExecuteScalar();

            return iKidID;
        }

        public void SaveEditedCSubject(int iSubjectID, string sSubjectName, bool isActive)
        {
            _sqcEditCSubject.Parameters["@subject_id"].Value = iSubjectID;
            _sqcEditCSubject.Parameters["@subject_desc"].Value = sSubjectName;
            _sqcEditCSubject.Parameters["@is_active"].Value = isActive;

            _sqcEditCSubject.ExecuteNonQuery();
        }

        public int SaveNewCSubject(string sSubjectName, bool isActive)
        {
            _sqcAddCSubject.Parameters["@subject_desc"].Value = sSubjectName;
            _sqcAddCSubject.Parameters["@is_active"].Value = isActive;

            _sqcAddCSubject.ExecuteNonQuery();
            int iSubjectID = (int)(decimal)_sqcGetDNewIDValue.ExecuteScalar();

            return iSubjectID;
        }

        public void SaveDeletedDEntry(int iEntryID)
        {
            _sqcDeleteDKidsByEntryID.Parameters["@entry_id"].Value = iEntryID;
            _sqcDeleteDSubjectsByEntryID.Parameters["@entry_id"].Value = iEntryID;
            _sqcDeleteDEntryByEntryID.Parameters["@entry_id"].Value = iEntryID;

            SqlCeTransaction sqTran = _sqlConn.BeginTransaction();
            _sqcDeleteDKidsByEntryID.Transaction = sqTran;
            _sqcDeleteDSubjectsByEntryID.Transaction = sqTran;
            _sqcDeleteDEntryByEntryID.Transaction = sqTran;

            try {
                _sqcDeleteDKidsByEntryID.ExecuteNonQuery();
                _sqcDeleteDSubjectsByEntryID.ExecuteNonQuery();
                _sqcDeleteDEntryByEntryID.ExecuteNonQuery();

                sqTran.Commit();
            } catch {
                sqTran.Rollback();
                throw;
            }
        }

        public void SaveEditedDEntry(int iEntryID, DateTime datEntryDate, byte bitIsNoPublish, 
            string sEntryTitle, SqlInt32 iMinutesSpent, string sEntryText,
            List<int> lstKidIDs, List<int> lstsubjectIDs)
        {
            _sqcEditDEntry.Parameters["@entry_id"].Value = iEntryID;
            _sqcEditDEntry.Parameters["@is_no_publish"].Value = bitIsNoPublish;
            _sqcEditDEntry.Parameters["@entry_title"].Value = sEntryTitle;
            _sqcEditDEntry.Parameters["@minutes_spent"].Value = iMinutesSpent;
            _sqcEditDEntry.Parameters["@entry_text"].Value = sEntryText;

            _sqcDeleteDKidsByEntryID.Parameters["@entry_id"].Value = iEntryID;
            _sqcDeleteDSubjectsByEntryID.Parameters["@entry_id"].Value = iEntryID;

            SqlCeTransaction sqTran = _sqlConn.BeginTransaction();
            _sqcEditDEntry.Transaction = sqTran;
            _sqcDeleteDKidsByEntryID.Transaction = sqTran;
            _sqcDeleteDSubjectsByEntryID.Transaction = sqTran;
            _sqcAddDEntryKid.Transaction = sqTran;
            _sqcAddDEntrySubject.Transaction = sqTran;

            try {
                _sqcEditDEntry.ExecuteNonQuery();
                _sqcDeleteDKidsByEntryID.ExecuteNonQuery();
                _sqcDeleteDSubjectsByEntryID.ExecuteNonQuery();

                foreach (int iKidID in lstKidIDs)
                {
                    _sqcAddDEntryKid.Parameters["@entry_id"].Value = iEntryID;
                    _sqcAddDEntryKid.Parameters["@kid_id"].Value = iKidID;
                    _sqcAddDEntryKid.ExecuteNonQuery();
                }

                foreach (int isubjectID in lstsubjectIDs)
                {
                    _sqcAddDEntrySubject.Parameters["@entry_id"].Value = iEntryID;
                    _sqcAddDEntrySubject.Parameters["@subject_id"].Value = isubjectID;
                    _sqcAddDEntrySubject.ExecuteNonQuery();
                }

                sqTran.Commit();
            } catch {
                sqTran.Rollback();
                throw;
            }
        }

        /// <summary>
        /// Save an edited entry date.  Current UI makes this difficult.
        /// </summary>
        /// <param name="iEntryID"></param>
        /// <param name="dateEntryDate"></param>
        public void SaveEditedDEntryDate(int iEntryID, DateTime dateEditedEntryDate)
        {
            _sqcEditDEntryDate.Parameters["@entry_id"].Value = iEntryID;
            _sqcEditDEntryDate.Parameters["@entry_date"].Value = dateEditedEntryDate;

            _sqcEditDEntryDate.ExecuteNonQuery();
        }

        public int SaveNewDEntry(DateTime datEntryDate, byte bitIsNoPublish, 
            string sEntryTitle, SqlInt32 iMinutesSpent, string sEntryText,
            List<int> lstKidIDs, List<int> lstSubjectIDs)
        {
            _sqcAddDEntry.Parameters["@entry_date"].Value = datEntryDate;
            _sqcAddDEntry.Parameters["@is_no_publish"].Value = bitIsNoPublish;
            _sqcAddDEntry.Parameters["@entry_title"].Value = sEntryTitle;
            _sqcAddDEntry.Parameters["@minutes_spent"].Value = iMinutesSpent;
            _sqcAddDEntry.Parameters["@entry_text"].Value = sEntryText;
            _sqcAddDEntry.Parameters["@priority"].Value = 0;  //default to 0.

            SqlCeTransaction sqTran = _sqlConn.BeginTransaction();
            _sqcAddDEntry.Transaction = sqTran;
            _sqcAddDEntryKid.Transaction = sqTran;
            _sqcAddDEntrySubject.Transaction = sqTran;
            _sqcGetDNewIDValue.Transaction = sqTran;

            int iEntryID = -1;
            try {
                _sqcAddDEntry.ExecuteNonQuery();
                iEntryID = (int)(decimal)_sqcGetDNewIDValue.ExecuteScalar();

                foreach (int iKidID in lstKidIDs) {
                    _sqcAddDEntryKid.Parameters["@entry_id"].Value = iEntryID;
                    _sqcAddDEntryKid.Parameters["@kid_id"].Value = iKidID;
                    _sqcAddDEntryKid.ExecuteNonQuery();
                }

                foreach (int isubjectID in lstSubjectIDs) {
                    _sqcAddDEntrySubject.Parameters["@entry_id"].Value = iEntryID;
                    _sqcAddDEntrySubject.Parameters["@subject_id"].Value = isubjectID;
                    _sqcAddDEntrySubject.ExecuteNonQuery();
                }

                sqTran.Commit();
            }
            catch {
                sqTran.Rollback();
                throw;
            }

            return iEntryID;
        }

        /// <summary>
        /// sSettingValue may actually be an int or decimal, expressed as a string.
        /// </summary>
        /// <param name="sSettingName"></param>
        /// <param name="sSettingValue"></param>
        public void SaveEditedCSetting(string sSettingName, string sSettingValue)
        {
            _sqcEditCSetting.Parameters["@setting_name"].Value = sSettingName;
            _sqcEditCSetting.Parameters["@setting_value"].Value = sSettingValue;

            _sqcEditCSetting.ExecuteNonQuery();
        }

        /// <summary>
        /// Add a new system setting to the db. Should ONLY be called from 
        /// SystemSettings:CheckAddAndReinitSettings().
        /// </summary>
        /// <param name="sSettingName"></param>
        /// <param name="sDataType"></param>
        /// <param name="sSettingValue"></param>
        public void SaveNewCSetting(string sSettingName, string sDataType, string sSettingValue)
        {
            _sqcAddCSetting.Parameters["@setting_name"].Value = sSettingName;
            _sqcAddCSetting.Parameters["@datatype"].Value = sDataType;
            _sqcAddCSetting.Parameters["@setting_value"].Value = sSettingValue;

            _sqcAddCSetting.ExecuteNonQuery();
        }

        public int SaveAndGetIncrementedTrialUse()
        {
            //note that SysSettings depends on CEDbH, two potentially circular calls here.
            int iTrialUses = HSDMain.SysSettings.GetSettingInt("TrialUses");
            iTrialUses++;
            HSDMain.SysSettings.SaveSetting("TrialUses", iTrialUses.ToString());

            return iTrialUses;
        }

        public DataTable SGetDAttendanceByDateRange(DateTime datStart, DateTime datEnd)
        {
            _sqcGetDAttendanceByDateRange.Parameters["@start_date"].Value = datStart;
            _sqcGetDAttendanceByDateRange.Parameters["@end_date"].Value = datEnd;

            DataTable dt = new DataTable();
            SqlCeDataAdapter da = new SqlCeDataAdapter(_sqcGetDAttendanceByDateRange);
            da.Fill(dt);

            return dt;
        }

        public DataRow SGetDEntryByID(int iEntryID)
        {
            _sqcGetDEntryByID.Parameters["@entry_id"].Value = iEntryID;

            DataTable dt = new DataTable();
            SqlCeDataAdapter da = new SqlCeDataAdapter(_sqcGetDEntryByID);
            da.Fill(dt);

            return dt.Rows[0];
        }

        public DataTable SGetDSubjectsByEntryID(int iEntryID)
        {
            _sqcGetDSubjectsByID.Parameters["@entry_id"].Value = iEntryID;

            DataTable dt = new DataTable();
            SqlCeDataAdapter da = new SqlCeDataAdapter(_sqcGetDSubjectsByID);
            da.Fill(dt);

            return dt;
        }

        public void SGetDEntriesTotalsByDate(DateTime datEntry, out int iMinutesByDate, out int iCountByDate)
        {
            object oResults;
            
            _sqcGetDEntriesMinutesByDate.Parameters["@entry_date"].Value = datEntry;
            oResults = _sqcGetDEntriesMinutesByDate.ExecuteScalar();
            iMinutesByDate = (oResults != null) ? (int)oResults : 0;

            _sqcGetDEntriesCountByDate.Parameters["@entry_date"].Value = datEntry;
            oResults = _sqcGetDEntriesCountByDate.ExecuteScalar();
            iCountByDate = (oResults != null) ? (int)oResults : 0;
        }

        public void SGetDEntriesTotalsAll(out int iMinutesAll, out int iCountAll)
        {
            object oResults;

            oResults = _sqcGetDEntriesMinutesAll.ExecuteScalar();
            iMinutesAll = (oResults != null) ? (int)oResults : 0;

            oResults = _sqcGetDEntriesCountAll.ExecuteScalar();
            iCountAll = (oResults != null) ? (int)oResults : 0;
        }

        public DataTable SGetDKidsByEntryID(int iEntryID)
        {
            _sqcGetDKidsByID.Parameters["@entry_id"].Value = iEntryID;

            DataTable dt = new DataTable();
            SqlCeDataAdapter da = new SqlCeDataAdapter(_sqcGetDKidsByID);
            da.Fill(dt);

            return dt;
        }

        public DataTable SGetDEntryTitlesByTargetDate(DateTime datTarget, bool bIncludeRowForNew)
        {
            _sqcGetDTitlesByTargetDate.Parameters["@target_date"].Value = datTarget;

            DataTable dt = new DataTable();
            SqlCeDataAdapter da = new SqlCeDataAdapter(_sqcGetDTitlesByTargetDate);
            da.Fill(dt);

            if (bIncludeRowForNew)
                InsertRowAtTopOfDT(ref dt, "entry_title", "entry_id", "(new entry)");

            return dt;
        }

        public DataTable SGetDEntryTitlesByDateRange(DateTime datStart, DateTime datEnd)
        {
            _sqcGetDTitlesByDateRange.Parameters["@start_date"].Value = datStart;
            _sqcGetDTitlesByDateRange.Parameters["@end_date"].Value = datEnd;

            DataTable dt = new DataTable();
            SqlCeDataAdapter da = new SqlCeDataAdapter(_sqcGetDTitlesByDateRange);
            da.Fill(dt);

            return dt;
        }

        public DataTable SGetDEntryTitlesDistinctRecent()
        {
            DataTable dt = new DataTable();
            SqlCeDataAdapter da = new SqlCeDataAdapter(_sqcGetDEntryTitlesDistinct90Days);
            da.Fill(dt);

            return dt;
        }


        public DataTable SGetRAttendanceByKid(DateTime datStart, DateTime datEnd, int iKidID)
        {
            _sqcGetRAttendance.Parameters["@start_date"].Value = datStart;
            _sqcGetRAttendance.Parameters["@end_date"].Value = datEnd;
            _sqcGetRAttendance.Parameters["@kid_id"].Value = iKidID;

            DataTable dt = new DataTable();
            SqlCeDataAdapter da = new SqlCeDataAdapter(_sqcGetRAttendance);
            da.Fill(dt);

            return dt;
        }

        public DataTable SGetREntriesByDate(DateTime datStart, DateTime datEnd, int iKidID, int iSubjectID)
        {
            _sqcGetREntriesByDate.Parameters["@start_date"].Value = datStart;
            _sqcGetREntriesByDate.Parameters["@end_date"].Value = datEnd;
            _sqcGetREntriesByDate.Parameters["@kid_id"].Value = iKidID;
            _sqcGetREntriesByDate.Parameters["@subject_id"].Value = iSubjectID;

            DataTable dt = new DataTable();
            SqlCeDataAdapter da = new SqlCeDataAdapter(_sqcGetREntriesByDate);
            da.Fill(dt);

            return dt;
        }

        public DataTable SGetRTimeSpentPerSubjectByKid(DateTime datStart, DateTime datEnd, int iKidID, int iSubjectID)
        {
            _sqcGetRTimeSpentPerSubjectByKid.Parameters["@start_date"].Value = datStart;
            _sqcGetRTimeSpentPerSubjectByKid.Parameters["@end_date"].Value = datEnd;
            _sqcGetRTimeSpentPerSubjectByKid.Parameters["@kid_id"].Value = iKidID;
            _sqcGetRTimeSpentPerSubjectByKid.Parameters["@subject_id"].Value = iSubjectID;

            DataTable dt = new DataTable();
            SqlCeDataAdapter da = new SqlCeDataAdapter(_sqcGetRTimeSpentPerSubjectByKid);
            da.Fill(dt);

            return dt;
        }

        public DataTable SGetRTimeSpentPerDateByKid(DateTime datStart, DateTime datEnd, int iKidID)
        {
            _sqcGetRTimeSpentPerDateByKid.Parameters["@start_date"].Value = datStart;
            _sqcGetRTimeSpentPerDateByKid.Parameters["@end_date"].Value = datEnd;
            _sqcGetRTimeSpentPerDateByKid.Parameters["@kid_id"].Value = iKidID;

            DataTable dt = new DataTable();
            SqlCeDataAdapter da = new SqlCeDataAdapter(_sqcGetRTimeSpentPerDateByKid);
            da.Fill(dt);

            return dt;
        }

        /// <summary>
        /// DO NOT USE THIS EXCEPT AT APP OPEN AND APP CLOSE.
        /// </summary>
        /// <param name="sOpenOrClose"></param>
        public void ToggleDBConn(string sOpenOrClose)
        {
            if (sOpenOrClose == "open")
                _sqlConn.Open();
            else if (sOpenOrClose == "close")
                _sqlConn.Close();
            else
                throw new ArgumentException("Invalid argument for opening/closing db connection.");
        }

    }
}
