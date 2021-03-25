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
    /// Two conventions you must know:
    /// 
    /// We are using the Tag property of the each form to contain a reference
    /// back to the instance of frpWizardHost.  This is required to handle
    /// all the navigation stuff.  Kind of ugly but no one but me needs to use.  :)
    /// 
    /// We use the Text property of each form to contain a string which can
    /// be used to navigate to that form by name.  This would normally be the
    /// caption of the form, but frbHSDWizard inherited forms will never show
    /// the caption, so we can use .Text as a string key instead.
    /// 
    /// 
    /// 
    /// This is the base form from which to create "wizard" popup sequences.
    /// These are created inside the form frpWizardHost as child forms
    /// inside a panel.
    /// </summary>
    public partial class frbHSDWizard : frbHSDAppearance
    {
        private Control _ctlDefaultFocus;

        public Control DefaultFocusControl
        {
            get { return _ctlDefaultFocus; }
            set { _ctlDefaultFocus = value; }
        }

        public frbHSDWizard()
        {
            InitializeComponent();
            //full @ 1024x768: parent panel: 859, 696, this form: 857, 697
            //current: parent panel 609, 696, this form: 611, 697
            this.ClientSize = new System.Drawing.Size(530, 581);
        }

        protected void DisplayDefaultFocus()
        {
            if (DefaultFocusControl != null && DefaultFocusControl.CanSelect)
                DefaultFocusControl.Select();
        }

        protected void WizMovePrevForm()
        {
            ((frpWizardHost)this.Tag).DisplayNewWizardForm(-1);
        }

        protected void WizMoveNextForm()
        {
            ((frpWizardHost)this.Tag).DisplayNewWizardForm(1);
        }

        protected void WizMoveNamedForm(string sTextName)
        {
            ((frpWizardHost)this.Tag).DisplayNewWizardForm(sTextName);
        }

        protected void WizFinish()
        {
            ((frpWizardHost)this.Tag).QuitWizard();
        }

    }
}