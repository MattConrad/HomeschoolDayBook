using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HomeSchoolDayBook
{
    /// <summary>
    /// This is the base form from which all the "child" forms are created.  The purpose
    /// of this form is to set up structures like EntryRoutines() that are needed by
    /// all child forms.
    /// 
    /// Color customization is needed for all forms, even non-child forms, and so it
    /// is found in HSDBaseColorForm (one level up) rather than here.
    /// </summary>
    public partial class frbHSDChild : frbHSDAppearance
    {
        private Control _ctlDefaultFocus;

        public Control DefaultFocusControl
        {
            get { return _ctlDefaultFocus; }
            set { _ctlDefaultFocus = value; }
        }

        public frbHSDChild()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            //full @ 1024x768: parent panel: 859, 696, this form: 857, 697
            //current: parent panel 609, 696, this form: 611, 697
            this.ClientSize = new System.Drawing.Size(611, 698);
            this.DoubleBuffered = true;

            //*not* doing anything with ProcessDialogChar.
            //might later if shortcut keys get more complex.
        }

        protected void DisplayDefaultFocus()
        {
            if (DefaultFocusControl != null && DefaultFocusControl.CanSelect)
                DefaultFocusControl.Select();
        }

        public virtual bool IsExitAllowed()
        {
            return true;
        }

        public virtual void EntryRoutines() { }

        public virtual void ExitRoutines() { }

        /// <summary>
        /// This routine is not usually overridden.  Usually overrides
        /// will be applied to the virtual methods called from here.
        /// </summary>
        public virtual void ShowAndRunEntryRoutines()
        {
            //NOTE: removed suspend/resume b/c double buffereing.
//            this.SuspendLayout();
            this.Show();
            this.EntryRoutines();
            this.DisplayDefaultFocus();
//            this.ResumeLayout();
        }


    }
}