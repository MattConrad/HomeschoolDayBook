using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HomeSchoolDayBook
{
    public partial class frwFirstTimeIntro1 : frbHSDWizard
    {
        public frwFirstTimeIntro1()
        {
            InitializeComponent();
        }

        private void btnYesGetStarted_Click(object sender, EventArgs e)
        {
            WizMoveNextForm();
        }

        private void btnQuitWizard_Click(object sender, EventArgs e)
        {
            WizFinish();
        }


    }
}