using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;


namespace HomeSchoolDayBook
{
    public interface IHSDKryChangeListener
    {
        void DisplayWithCurrentPalette();
    }

    public class HSDKCheckboxPanel : FlowLayoutPanel, IHSDKryChangeListener
    {
        public event EventHandler CheckBoxValueChanged;
        private Dictionary<int, int> _hashIDToIndex;
        private bool _bRaiseValueChanged;
        private int _iNumberOfColumns;

        public HSDKCheckboxPanel()
        {
            _bRaiseValueChanged = true;
            _hashIDToIndex = new Dictionary<int, int>();
        }

        public int NumberOfColumns
        {
            get { return _iNumberOfColumns; }
            set { _iNumberOfColumns = value; }
        }

        protected virtual void OnCheckBoxValueChanged(object sender, EventArgs e)
        {
            //only raise if bool is set to on.
            if (_bRaiseValueChanged)
                CheckBoxValueChanged(this, e);  //just drop the checkbox on the floor, at least for now.
        }

        public void ClearChecksEventless()
        {
            _bRaiseValueChanged = false;

            foreach (HSDKCheckBox chk in this.Controls)
                chk.Checked = false;

            _bRaiseValueChanged = true;
        }

        /// <summary>
        /// Accepts list of CHECKED IDs.
        /// </summary>
        /// <param name="lstCheckedIDs"></param>
        public void DisplayDataChecks(List<int> lstCheckedIDs)
        {
            this.ClearChecksEventless();

            _bRaiseValueChanged = false;

            foreach (int iID in lstCheckedIDs)
            {
                //sometimes this control won't contain the ID they ask for (e.g. recently deactivated IDs).  in this case, just skip.
                if (_hashIDToIndex.ContainsKey(iID))
                    ((HSDKCheckBox)this.Controls[_hashIDToIndex[iID]]).Checked = true;
            }

            _bRaiseValueChanged = true;
        }

        /// <summary>
        /// Accepts datatable and ID column of CHECKED IDs.
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="sIDColumn"></param>
        public void DisplayDataChecks(DataTable dt, string sIDColumn)
        {
            List<int> lstIDs = new List<int>();

            foreach (DataRow dr in dt.Rows)
                lstIDs.Add((int)dr[sIDColumn]);

            DisplayDataChecks(lstIDs);
        }

        public List<int> GetCheckedIDs()
        {
            List<int> lstIDs = new List<int>();

            foreach (HSDKCheckBox chk in this.Controls)
                if (chk.Checked == true) 
                    lstIDs.Add((int)chk.Tag);

            return lstIDs;
        }

        public void DisplayWithCurrentPalette()
        {
            IPalette krPalette = HSDMain.kryMgr.GlobalPalette;

            this.BackColor = krPalette.GetBackColor1(PaletteBackStyle.PanelClient, PaletteState.Normal);
        }

        public void RefreshListing(DataTable dt, string sDisplayColumn, string sIDColumn)
        {
            for (int i = this.Controls.Count - 1; i >= 0; i--)
                this.Controls.RemoveAt(i);

            //"this.Width" ain't right at construction time, so calculate chk.Width now.
            //we subtract off _iNumberOfColumns before dividing to ensure we *don't* get horiz scrollbar.  we will, if we don't fudge the width a bit smaller than control - scrollbar.
            int iChkWidth = (this.Width - SystemInformation.VerticalScrollBarWidth - _iNumberOfColumns) / _iNumberOfColumns;

            _hashIDToIndex.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                HSDKCheckBox chk = new HSDKCheckBox();
                chk.Width = iChkWidth;
                chk.Text = (string)dr[sDisplayColumn];
                chk.Tag = (int)dr[sIDColumn];
                chk.Margin = Padding.Empty;
                chk.Padding = new Padding(1);
                chk.AutoEllipsis = true;
                chk.CheckedChanged += new EventHandler(OnCheckBoxValueChanged);
                chk.DisplayWithCurrentPalette();
                this.Controls.Add(chk);
                _hashIDToIndex.Add((int)chk.Tag, this.Controls.Count - 1);
            }
        }
    }

    public class HSDKDateTimePicker : DateTimePicker, IHSDKryChangeListener
    {
        private Color _backColor = SystemColors.Window;

        public override Color BackColor
        {
            get { return _backColor; }
            set {
                _backColor = value;
                Invalidate();
            }
        }

        public void DisplayWithCurrentPalette()
        {
            IPalette krPalette = HSDMain.kryMgr.GlobalPalette;

            this.BackColor = krPalette.GetBackColor1(PaletteBackStyle.InputControlStandalone, PaletteState.Normal);
            this.ForeColor = krPalette.GetContentShortTextColor1(PaletteContentStyle.InputControlStandalone, PaletteState.Normal);
            this.Font = krPalette.GetContentShortTextFont(PaletteContentStyle.LabelNormalPanel, PaletteState.Normal);
            this.CalendarMonthBackground = krPalette.GetBackColor1(PaletteBackStyle.InputControlStandalone, PaletteState.Normal);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == (int)0x0014 /* WM_ERASEBKGND */) {
                Graphics g = Graphics.FromHdc(m.WParam);
                g.FillRectangle(new SolidBrush(_backColor), ClientRectangle);
                g.Dispose();
                return;
            }
            base.WndProc(ref m);
        }
    }

    public class HSDKCheckBox : CheckBox, IHSDKryChangeListener
    {
        public void DisplayWithCurrentPalette()
        {
            IPalette krPalette = HSDMain.kryMgr.GlobalPalette;

            this.BackColor = krPalette.GetBackColor1(PaletteBackStyle.PanelClient, PaletteState.Normal);
            this.ForeColor = krPalette.GetContentShortTextColor1(PaletteContentStyle.LabelNormalPanel, PaletteState.Normal);
            this.Font = krPalette.GetContentShortTextFont(PaletteContentStyle.LabelNormalPanel, PaletteState.Normal);
        }
    }

    public class HSDKComboBox : ComboBox, IHSDKryChangeListener
    {
        public void DisplayWithCurrentPalette()
        {
            IPalette krPalette = HSDMain.kryMgr.GlobalPalette;

            this.BackColor = krPalette.GetBackColor1(PaletteBackStyle.InputControlStandalone, PaletteState.Normal);
            this.ForeColor = krPalette.GetContentShortTextColor1(PaletteContentStyle.InputControlStandalone, PaletteState.Normal);
            this.Font = krPalette.GetContentShortTextFont(PaletteContentStyle.InputControlStandalone, PaletteState.Normal);
        }
    }

    public class HSDKLabel : Label, IHSDKryChangeListener
    {
        public void DisplayWithCurrentPalette()
        {
            IPalette krPalette = HSDMain.kryMgr.GlobalPalette;

            this.BackColor = krPalette.GetBackColor1(PaletteBackStyle.PanelClient, PaletteState.Normal);
            this.ForeColor = krPalette.GetContentShortTextColor1(PaletteContentStyle.LabelNormalPanel, PaletteState.Normal);
            this.Font = krPalette.GetContentShortTextFont(PaletteContentStyle.LabelNormalPanel, PaletteState.Normal);
        }
    }

    public class HSDKListBox : ListBox, IHSDKryChangeListener
    {
        public void DisplayWithCurrentPalette()
        {
            IPalette krPalette = HSDMain.kryMgr.GlobalPalette;

            this.BackColor = krPalette.GetBackColor1(PaletteBackStyle.InputControlStandalone, PaletteState.Normal);
            this.ForeColor = krPalette.GetContentShortTextColor1(PaletteContentStyle.InputControlStandalone, PaletteState.Normal);
            this.Font = krPalette.GetContentShortTextFont(PaletteContentStyle.InputControlStandalone, PaletteState.Normal);
        }
    }

    public class HSDKTextBox : TextBox, IHSDKryChangeListener
    {
        bool _bSelectAllOnEnter = true;

        public bool SelectAllOnEnter
        {
            get { return _bSelectAllOnEnter; }
            set { _bSelectAllOnEnter = value; }
        }

        protected override void OnEnter(EventArgs e)
        {
            if (_bSelectAllOnEnter)
                this.SelectAll();

            base.OnEnter(e);
        }

        public void DisplayWithCurrentPalette()
        {
            IPalette krPalette = HSDMain.kryMgr.GlobalPalette;

            this.BackColor = krPalette.GetBackColor1(PaletteBackStyle.InputControlStandalone, PaletteState.Normal);
            this.ForeColor = krPalette.GetContentShortTextColor1(PaletteContentStyle.InputControlStandalone, PaletteState.Normal);
            this.Font = krPalette.GetContentShortTextFont(PaletteContentStyle.InputControlStandalone, PaletteState.Normal);
        }
    }

    public class HSDKTextBoxInteger : TextBox, IHSDKryChangeListener
    {
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar <= 32 || (e.KeyChar >= '0' && e.KeyChar <= '9'))
                base.OnKeyPress(e);
            else
                e.Handled = true;
        }

        protected override void OnEnter(EventArgs e)
        {
            this.SelectAll();
            base.OnEnter(e);
        }

        public void DisplayWithCurrentPalette()
        {
            IPalette krPalette = HSDMain.kryMgr.GlobalPalette;

            this.BackColor = krPalette.GetBackColor1(PaletteBackStyle.InputControlStandalone, PaletteState.Normal);
            this.ForeColor = krPalette.GetContentShortTextColor1(PaletteContentStyle.InputControlStandalone, PaletteState.Normal);
            this.Font = krPalette.GetContentShortTextFont(PaletteContentStyle.InputControlStandalone, PaletteState.Normal);
        }
    }

    public class HSDSubKryptonPanelLabel : KryptonLabel
    {
        public HSDSubKryptonPanelLabel()
        {
            this.LabelStyle = LabelStyle.NormalPanel;
        }
    }

    /// <summary>
    /// This is called a button bc it acts like one, but observe it inherits from Label.
    /// </summary>
    public class HSDKAttendButton : Label, IHSDKryChangeListener
    {
        private DateTime _datAttend;
        private List<string> _lstANames;

        public HSDKAttendButton() 
        {
            _datAttend = new DateTime(1900, 01, 01);
            _lstANames = new List<string>();
            this.BorderStyle = BorderStyle.Fixed3D;
            this.TextAlign = ContentAlignment.TopLeft;
            this.AutoEllipsis = true;
        }

        public DateTime AttendDate
        {
            get { return _datAttend; }
            set { _datAttend = value; }
        }

        public void DisplayWithCurrentPalette()
        {
            IPalette krPalette = HSDMain.kryMgr.GlobalPalette;

            this.BackColor = krPalette.GetBackColor1(PaletteBackStyle.ButtonStandalone, PaletteState.Normal);
            this.ForeColor = krPalette.GetContentShortTextColor1(PaletteContentStyle.ButtonStandalone, PaletteState.Normal);
            this.Font = krPalette.GetContentShortTextFont(PaletteContentStyle.ButtonStandalone, PaletteState.Normal);
        }

        public void RefreshDateAndAttendees(DateTime datOfAttend, List<string> lstAttendees)
        {
            _datAttend = datOfAttend;
            _lstANames = lstAttendees;

            RefreshDisplay();
        }

        private void RefreshDisplay()
        {
            this.Text = _datAttend.ToString("MMM dd")
                + "\r\n"
                + string.Join(" ", _lstANames.ToArray());

            //this.Values.Text = _datAttend.ToString("MMM dd");
            //this.Values.ExtraText = string.Join(" ", _lstANames.ToArray());
        }
    }

    public class KryptonDGVModified : KryptonDataGridView, IHSDKryChangeListener
    {
        public void DisplayWithCurrentPalette()
        {
            IPalette krPalette = HSDMain.kryMgr.GlobalPalette;

            this.RowsDefaultCellStyle.BackColor = krPalette.GetBackColor1(PaletteBackStyle.InputControlStandalone, PaletteState.Normal);
        }
    }


}
