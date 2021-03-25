using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HomeSchoolDayBook
{

    public partial class frcAttendance : frbHSDChild
    {
//        private System.Windows.Forms.ToolTip ttip;

        private List<HSDKAttendButton> _lstAttendBtns;   
        private Boolean _bHaveMouse;
        private Point _ptSOriginal = new Point();
        private Point _ptSLast = new Point();

        public frcAttendance()
        {
            InitializeComponent();
            InitEventHandlers();
            //this.ttip = new System.Windows.Forms.ToolTip(this.components);
            InitDataControls();
            DefaultFocusControl = this.dtpMonthShown;
            lblInstructionsAttendPlaceholders.Text = "If you only want to add an attendance record, it is OK to enter a placeholder entry \nwith title \"Attendance\", no time spent, and no subjects.";
        }

        private void frcAttendance_Load(object sender, EventArgs e)
        {
            dtpMonthShown.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);

            //this.ttip.AutoPopDelay = 5000;
            //this.ttip.InitialDelay = 250;
            //this.ttip.AutomaticDelay = 250;
            //this.ttip.AutoPopDelay = 250;

            //this.MouseDown += new MouseEventHandler(MouseActor_MouseDown);
            //this.MouseUp += new MouseEventHandler(MouseActor_MouseUp);
            //this.MouseMove += new MouseEventHandler(MouseActor_MouseMove);
            //_bHaveMouse = false;
        }

        public override void EntryRoutines()
        {
            RefreshAttendanceListing();
            base.EntryRoutines();
        }

        public override void ExitRoutines()
        {
            //DisplayUncheckedAttendances();
            base.ExitRoutines();
        }

        private void AttendButton_Click(object sender, EventArgs e)
        {
            DateTime datAttend = ((HSDKAttendButton)sender).AttendDate;
            HSDMain.fMaster.DisplayEntryFormAndSelectedEntry(datAttend, -1);
        }

        private void AttendButton_MouseEnter(object sender, EventArgs e)
        {
            //the MouseLeave event is not always firing, so we backstop the border fix here.  is fast enough.
            foreach (HSDKAttendButton abtn in _lstAttendBtns)
                if (abtn.BorderStyle == BorderStyle.FixedSingle)
                    abtn.BorderStyle = BorderStyle.Fixed3D;

            ((HSDKAttendButton)sender).BorderStyle = BorderStyle.FixedSingle;
        }

        private void AttendButton_MouseLeave(object sender, EventArgs e)
        {
            ((HSDKAttendButton)sender).BorderStyle = BorderStyle.Fixed3D;
        }

        private void dtpMonthShown_ValueChanged(object sender, EventArgs e)
        {
            RefreshAttendanceListing();
        }

        private void InitDataControls()
        {
            Decimal decAttendScaling = HSDMain.SysSettings.GetSettingDecimal("AttendanceDisplayScaling");
            InitDayControlsForTablePanel(decAttendScaling);
        }

        private void InitEventHandlers()
        {
            this.dtpMonthShown.ValueChanged += new System.EventHandler(this.dtpMonthShown_ValueChanged);
        }

        private void InitDayControlsForTablePanel(Decimal decScaling)
        {
            int iLblHeight = 13;
            int iChkHeight = (int)(74 * decScaling);
            int iChkWidth = (int)(84 * decScaling);
            int iChkHSpacer = 1;
            int iChkWSpacer = 1;

            int iGridTop = this.dtpMonthShown.Top + this.dtpMonthShown.Height + 20;
            int iGridLeft = (this.Width - (iChkWidth * 7) - (iChkWSpacer * 6)) / 2;

            string[] sDaysOfWeek = new string[] {"Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
            for (int i = 0; i < 7; i++) {
                Label lbl = new Label();
                lbl.AutoSize = false;
                lbl.Height = iLblHeight;
                lbl.Width = iChkWidth;
                lbl.Top = iGridTop;
                lbl.Left = iGridLeft + (iChkWidth * i) + (iChkWSpacer * i);
                lbl.Text = sDaysOfWeek[i];
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                this.Controls.Add(lbl);
            }

            //reset the top of the grid to compensate for header labels.
            iGridTop = iGridTop + iLblHeight + iChkHSpacer;

            _lstAttendBtns = new List<HSDKAttendButton>();
            for (int i = 0; i < 6; i++) {
                for (int j = 0; j < 7; j++) {
                    int iIndex = (i * 7) + j;
                    HSDKAttendButton abtn = new HSDKAttendButton();
                    abtn.Name = "abtn_" + iIndex;
                    abtn.Height = iChkHeight;
                    abtn.Width = iChkWidth;
                    abtn.Top = iGridTop + (iChkHeight * i) + (iChkHSpacer * i);
                    abtn.Left = iGridLeft + (iChkWidth * j) + (iChkWSpacer * j);
                    abtn.Click += new EventHandler(AttendButton_Click);
                    abtn.MouseEnter += new EventHandler(AttendButton_MouseEnter);
                    abtn.MouseLeave +=new EventHandler(AttendButton_MouseLeave);
                    //abtn.MouseDown += new MouseEventHandler(MouseActor_MouseDown);
                    //abtn.MouseUp += new MouseEventHandler(MouseActor_MouseUp);
                    //abtn.MouseMove += new MouseEventHandler(MouseActor_MouseMove);
                    this.kpnlMain.Controls.Add(abtn);
                    _lstAttendBtns.Add(abtn);
                }
            }
        }

        public void GetFirstAndLastCalendarDisplayedDates(DateTime datFirstOfMonth, out DateTime datFirstShown, out DateTime datLastShown)
        {
            //the calendar always shows 6 weeks. the first of the month 
            //that we're focused on is always on the top week
            //UNLESS it falls on a Sunday, then it's on the second week.
            //so we use that and work backwards to find first shown day.
            //the last shown day is just the first shown day + 41 days.
            if (datFirstOfMonth.DayOfWeek == DayOfWeek.Sunday)
                datFirstShown = datFirstOfMonth.AddDays(-7);
            else
                datFirstShown = datFirstOfMonth.AddDays(-(int)datFirstOfMonth.DayOfWeek);

            datLastShown = datFirstShown.AddDays(41);
        }

        private void RefreshAttendanceListing()
        {
            DateTime datFirstShown;
            DateTime datLastShown;

            GetFirstAndLastCalendarDisplayedDates(new DateTime(dtpMonthShown.Value.Year, dtpMonthShown.Value.Month, 1), out datFirstShown, out datLastShown);

            DataView dvEachKid = HSDMain.CEDbH.SGetDAttendanceByDateRange(datFirstShown, datLastShown).DefaultView;
            List<string> lstKids = new List<string>();

            for (int i = 0; i < _lstAttendBtns.Count; i++) {
                DateTime datCurrent = datFirstShown.AddDays(i);
                dvEachKid.RowFilter = String.Format("entry_date = #{0}#", datCurrent.ToString("yyyy-MM-dd"));

                lstKids = new List<string>();

                if (dvEachKid.Count > 0) {
                    foreach (DataRowView drv in dvEachKid) {
                        lstKids.Add(drv["first_name"].ToString());
                    }
                }
                _lstAttendBtns[i].RefreshDateAndAttendees(datCurrent, lstKids);
            }
        }

        //private void CheckAndHandleRBOverlaps()
        //{
        //    int iX = Math.Min(_ptSOriginal.X, _ptSLast.X);
        //    int iY = Math.Min(_ptSOriginal.Y, _ptSLast.Y);
        //    int iWidth = Math.Abs(_ptSOriginal.X - _ptSLast.X);
        //    int iHeight = Math.Abs(_ptSOriginal.Y - _ptSLast.Y);

        //    Rectangle rectSel = new Rectangle(iX, iY, iWidth, iHeight);

        //    foreach (AttendCheckBox achk in _lstAttendBtns) {
        //        Rectangle rectAtt = achk.RectangleToScreen(achk.ClientRectangle);

        //        if (rectAtt.Contains(rectSel))
        //            break;  //the selection is entirely within the button.  is a CLICK.  do NOTHING.

        //        if (rectSel.IntersectsWith(rectAtt))
        //            achk.Checked = !achk.Checked;
        //    }
        //}

        //public void MouseActor_MouseDown(Object sender, MouseEventArgs e)
        //{
        //    _bHaveMouse = true;
        //    ((Control)sender).Capture = true;
        //    _ptSOriginal = ((Control)sender).PointToScreen(e.Location);
        //    // Special value lets us know that no previous rectangle needs to be erased.
        //    _ptSLast.X = -1;
        //    _ptSLast.Y = -1;
        //    System.Diagnostics.Debug.WriteLine("MyMouseDown: " + ((Control)sender).Name + " " + _ptSOriginal.X + " " + _ptSOriginal.Y);
        //}

        //// Convert and normalize the points and draw the reversible frame.
        //private void MyDrawReversibleRectangle(Point p1, Point p2)
        //{
        //    Rectangle rc = new Rectangle();

        //    rc.X = Math.Min(p1.X, p2.X);
        //    rc.Y = Math.Min(p1.Y, p2.Y);
        //    rc.Width = Math.Abs(p1.X - p2.X);
        //    rc.Height = Math.Abs(p1.Y - p2.Y);

        //    // Draw the reversible frame.
        //    ControlPaint.DrawReversibleFrame(rc, Color.Red, FrameStyle.Dashed);
        //}

        //public void MouseActor_MouseUp(Object sender, MouseEventArgs e)
        //{
        //    // Set internal flag to know we no longer "have the mouse".
        //    _bHaveMouse = false;

        //    // If we have drawn previously, first check overlaps, draw again in that spot to remove the lines.
        //    if (_ptSLast.X != -1) {
        //        //Point ptSCurrent = this.PointToScreen(new Point(e.X, e.Y));
        //        Point ptSCurrent = ((Control)sender).PointToScreen(e.Location);
        //        MyDrawReversibleRectangle(_ptSOriginal, _ptSLast);
        //        CheckAndHandleRBOverlaps();     //this is ours, only run if "real" rect, also run AFTER reversing rect.
        //    }
        //    // Set flags to know that there is no "previous" line to reverse.
        //    _ptSLast.X = -1;
        //    _ptSLast.Y = -1;
        //    _ptSOriginal.X = -1;
        //    _ptSOriginal.Y = -1;
        //}

        //public void MouseActor_MouseMove(Object sender, MouseEventArgs e)
        //{
        //    Point ptSCurrent = ((Control)sender).PointToScreen(e.Location);
        //    // If we "have the mouse", then we draw our lines.
        //    if (_bHaveMouse) {
        //        // If we have drawn previously, draw again in that spot to remove the lines.
        //        if (_ptSLast.X != -1) {
        //            MyDrawReversibleRectangle(_ptSOriginal, _ptSLast);
        //        }
        //        // Update last point.
        //        _ptSLast = ptSCurrent;
        //        // Draw new lines.
        //        MyDrawReversibleRectangle(_ptSOriginal, ptSCurrent);
        //    }
        //}

    }

 }