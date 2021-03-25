using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HomeSchoolDayBook
{
    public partial class frpSplash : frbHSDAppearance
    {
        public frpSplash()
        {
            InitializeComponent();
            DisplayVersionNumber();
        }

        private void DisplayVersionNumber()
        {
            System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
            string sAsmVersion = asm.GetName().Version.ToString();
            //messy calc to get version string through "A.b" and no further.  will break once major version gets 2 digits.
            sAsmVersion = sAsmVersion.Substring(0, sAsmVersion.IndexOf('.', 2));
            lblSplashVersion.Text = "Version " + sAsmVersion;
        }

        public void RefreshLabels()
        {
            this.lblSplashTitle.Refresh();
            this.lblSplashVersion.Refresh();
        }

        public void CloseSplash()
        {
            this.Hide();
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            RefreshLabels();
        }
    }
}
