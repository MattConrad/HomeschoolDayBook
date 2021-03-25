using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HomeSchoolDayBook
{
    public partial class frwFirstTimeKids2 : frbHSDWizard
    {
        public frwFirstTimeKids2()
        {
            InitializeComponent();
        }

        private void frwFirstTimeKids2_Load(object sender, EventArgs e)
        {
            txtFName1.Enter += new EventHandler(SelectAllText);
            txtFName2.Enter += new EventHandler(SelectAllText);
            txtFName3.Enter += new EventHandler(SelectAllText);
            txtFName4.Enter += new EventHandler(SelectAllText);
            txtFName5.Enter += new EventHandler(SelectAllText);
            txtFName6.Enter += new EventHandler(SelectAllText);
            txtFName7.Enter += new EventHandler(SelectAllText);
        }

        private void btnMoveNext_Click(object sender, EventArgs e)
        {
            List<string> lstFNames = GetFNamesList();

            if (lstFNames.Count < 1) {
                MessageBox.Show("You must enter a first name for at least one kid in your homeschool.", "Incomplete Data:");
                return;
            }

            SaveWizardKids(lstFNames.ToArray());

            WizMoveNextForm();
        }

        private List<string> GetFNamesList()
        {
            List<string> lstFN = new List<string>();

            if (txtFName1.Text.Trim().Length > 0)
                lstFN.Add(txtFName1.Text);

            if (txtFName2.Text.Trim().Length > 0)
                lstFN.Add(txtFName2.Text);

            if (txtFName3.Text.Trim().Length > 0)
                lstFN.Add(txtFName3.Text);

            if (txtFName4.Text.Trim().Length > 0)
                lstFN.Add(txtFName4.Text);

            if (txtFName5.Text.Trim().Length > 0)
                lstFN.Add(txtFName5.Text);

            if (txtFName6.Text.Trim().Length > 0)
                lstFN.Add(txtFName6.Text);

            if (txtFName7.Text.Trim().Length > 0)
                lstFN.Add(txtFName7.Text);

            return lstFN;
        }

        private void SaveWizardKids(string[] sFNames)
        {
            foreach (string sFName in sFNames) {
                HSDMain.CEDbH.SaveNewCKid(sFName, true, true);
            }
        }

        private void SelectAllText(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }


    }
}