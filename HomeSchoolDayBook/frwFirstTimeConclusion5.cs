using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace HomeSchoolDayBook
{
    public partial class frwFirstTimeConclusion5 : frbHSDWizard
    {
        public frwFirstTimeConclusion5()
        {
            InitializeComponent();
            this.Load += new EventHandler(frwFirstTimeConclusion5_Load);
            FixLabels();
        }

        void frwFirstTimeConclusion5_Load(object sender, EventArgs e)
        {
            FixLabels();
        }

        private void btnSetupComplete_Click(object sender, EventArgs e)
        {
            WizFinish();
        }

        private void FixLabels()
        {
            foreach (Control c in this.kpnlMain.Controls) {
                if (c is Label) {
                    ((Label)c).BackColor = kpnlMain.BackColor;
                }
            }
        }


    }
}
