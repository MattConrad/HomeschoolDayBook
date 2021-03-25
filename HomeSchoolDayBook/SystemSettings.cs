using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace HomeSchoolDayBook
{
    /// <summary>
    /// 2010-12-28 v1.10:
    /// ok, let's break a bunch of new ground: 
    /// new system setting AttendanceDisplayScaling, a decimal.
    /// added GetSettingDecimal() to extract this, but more importantly, added
    /// CheckAddAndReinitSettings() which checks for missing sys settings and
    /// adds them if they're not present. This will run on every single launch,
    /// which once would have bothered me, but unless there's an add it's all 
    /// in memory anyway. Set up CheckAddAndReinitSettings() so that it should
    /// be easy to add new settings later if wanted.
    /// 
    /// Manage system settings from a single class.  This will, I hope, simplify syssetting handling.
    /// Right now, we are assuming that all used values are pre-initialized in the data table.
    /// I.e., if we ever ask for a value and it is missing it is my programming mistake.
    /// Originally planned on type converting in the hash, but changed my mind, 3 typed methods instead.
    /// </summary>
    class SystemSettings
    {
        Dictionary<string, string> _hashSettings;

        public SystemSettings()
        {
            ReinitSettings();
            CheckAddAndReinitSettings();
        }

        private void CheckAddAndReinitSettings()
        {
            bool bReinitSettings = false;

            if (!_hashSettings.ContainsKey("AttendanceDisplayScaling"))
            {
                bReinitSettings = true;
                HSDMain.CEDbH.SaveNewCSetting("AttendanceDisplayScaling", "decimal", "1.00");
            }

            if (bReinitSettings)
                ReinitSettings();
        }

        public bool GetSettingBool(string sSettingName)
        {
            if (!_hashSettings.ContainsKey(sSettingName))
                throw new ArgumentException("Setting '" + sSettingName + "' was not found in the list of settings.");

            string sValue = _hashSettings[sSettingName];

            //need to check here.  if we have "frog" don't want to return false.
            if (sValue != "1" && sValue != "0")
                throw new ArgumentException("Invalid value for boolean '" + sSettingName + "'.");

            if (sValue == "1")
                return true;
            else
                return false;
        }

        public Decimal GetSettingDecimal(string sSettingName)
        {
            if (!_hashSettings.ContainsKey(sSettingName))
                throw new ArgumentException("Setting '" + sSettingName + "' was not found in the list of settings.");

            //here we can just assume I am calling correctly and let exceptions throw if not.
            string sValue = _hashSettings[sSettingName];
            return Decimal.Parse(sValue);
        }

        public int GetSettingInt(string sSettingName)
        {
            if (!_hashSettings.ContainsKey(sSettingName))
                throw new ArgumentException("Setting '" + sSettingName + "' was not found in the list of settings.");

            //here we can just assume I am calling correctly and let exceptions throw if not.
            string sValue = _hashSettings[sSettingName];
            return int.Parse(sValue);
        }

        public string GetSettingString(string sSettingName)
        {
            if (!_hashSettings.ContainsKey(sSettingName))
                throw new ArgumentException("Setting '" + sSettingName + "' was not found in the list of settings.");

            return _hashSettings[sSettingName];
        }

        private void ReinitSettings()
        {
            _hashSettings = new Dictionary<string, string>();
            DataTable dt = HSDMain.CEDbH.GetCodeTableData("uc_settings_all");

            foreach (DataRow dr in dt.Rows) {
                string sKey = dr["setting_name"].ToString();
                string sValue = dr["setting_value"].ToString();
                _hashSettings[sKey] = sValue;
            }
        }

        /// <summary>
        /// At least for now, this only needs to edit, not add.
        /// </summary>
        /// <param name="sSettingName"></param>
        public void SaveSetting(string sSettingName, string sSettingValue)
        {
            HSDMain.CEDbH.SaveEditedCSetting(sSettingName, sSettingValue);
            ReinitSettings();
        }

    }
}
