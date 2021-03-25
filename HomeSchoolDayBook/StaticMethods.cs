using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace HomeSchoolDayBook
{
    class StaticMethods
    {
        private static Dictionary<string, string> _dictPlural;
       
        public static void InitCodeTables()
        {
            HSDMain.hashCodeTables = new Dictionary<string, DataTable>();

            RefreshCodeTable("uc_kids_all");
            RefreshCodeTable("uc_kids_active");
            RefreshCodeTable("uc_subjects_all");
            RefreshCodeTable("uc_subjects_active");
            RefreshCodeTable("uc_reports_active");
            RefreshCodeTable("uc_palettes_active");
            RefreshCodeTable("uc_settings_all");
        }

        public static void InitPluralization()
        {
            _dictPlural = new Dictionary<string, string>();
            _dictPlural["entry"] = "entries";
            _dictPlural["minute"] = "minutes";
            _dictPlural["hour"] = "hours";
            _dictPlural["day"] = "days";
            _dictPlural["time"] = "times";
            _dictPlural["use"] = "uses";
        }

        public static string Pluralize(int iCount, string sSingularWord)
        {
            if (!_dictPlural.ContainsKey(sSingularWord))
                throw new ArgumentException("Could not pluralize the word '" + sSingularWord + "'.");

            return (iCount == 1) ? sSingularWord : _dictPlural[sSingularWord];
        }

        public static void RefreshCodeTable(string sCodeTable)
        {
            HSDMain.hashCodeTables[sCodeTable] = HSDMain.CEDbH.GetCodeTableData(sCodeTable);
        }
    }
}
