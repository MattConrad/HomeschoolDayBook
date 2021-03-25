using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HomeSchoolDayBook
{
    public partial class frwFirstTimeSubjectsB4 : frbHSDWizard
    {
        public frwFirstTimeSubjectsB4()
        {
            InitializeComponent();
        }

        private void frwFirstTimeSubjectsB4_Load(object sender, EventArgs e)
        {
            txtSubject1.Enter += new EventHandler(SelectAllText);
            txtSubject2.Enter += new EventHandler(SelectAllText);
            txtSubject3.Enter += new EventHandler(SelectAllText);
            txtSubject4.Enter += new EventHandler(SelectAllText);
            txtSubject5.Enter += new EventHandler(SelectAllText);
            txtSubject6.Enter += new EventHandler(SelectAllText);
            txtSubject7.Enter += new EventHandler(SelectAllText);
            txtSubject8.Enter += new EventHandler(SelectAllText);
            txtSubject9.Enter += new EventHandler(SelectAllText);
            txtSubject10.Enter += new EventHandler(SelectAllText);
            txtSubject11.Enter += new EventHandler(SelectAllText);
            txtSubject12.Enter += new EventHandler(SelectAllText);
        }

        private void btnMoveBackToSuggestedSubjects_Click(object sender, EventArgs e)
        {
            WizMovePrevForm();
        }

        private void btnSaveSubjectsAndFinish_Click(object sender, EventArgs e)
        {
            List<string> lstSubjects = GetSubjectsList();

            if (lstSubjects.Count < 1) {
                MessageBox.Show("You must enter at least one subject in your homeschool.", "Incomplete Data:");
                return;
            }

            SaveWizardSubjects(lstSubjects.ToArray());

            WizMoveNamedForm("conclusion5");
        }

        private List<string> GetSubjectsList()
        {
            List<string> lstSubj = new List<string>();

            if (txtSubject1.Text.Trim().Length > 0)
                lstSubj.Add(txtSubject1.Text);

            if (txtSubject2.Text.Trim().Length > 0)
                lstSubj.Add(txtSubject2.Text);

            if (txtSubject3.Text.Trim().Length > 0)
                lstSubj.Add(txtSubject3.Text);

            if (txtSubject4.Text.Trim().Length > 0)
                lstSubj.Add(txtSubject4.Text);

            if (txtSubject5.Text.Trim().Length > 0)
                lstSubj.Add(txtSubject5.Text);

            if (txtSubject6.Text.Trim().Length > 0)
                lstSubj.Add(txtSubject6.Text);

            if (txtSubject7.Text.Trim().Length > 0)
                lstSubj.Add(txtSubject7.Text);

            if (txtSubject8.Text.Trim().Length > 0)
                lstSubj.Add(txtSubject8.Text);

            if (txtSubject9.Text.Trim().Length > 0)
                lstSubj.Add(txtSubject9.Text);

            if (txtSubject10.Text.Trim().Length > 0)
                lstSubj.Add(txtSubject10.Text);

            if (txtSubject11.Text.Trim().Length > 0)
                lstSubj.Add(txtSubject11.Text);

            if (txtSubject12.Text.Trim().Length > 0)
                lstSubj.Add(txtSubject12.Text);

            return lstSubj;
        }

        private void SaveWizardSubjects(string[] sSubjects)
        {
            foreach (string sSubject in sSubjects) {
                HSDMain.CEDbH.SaveNewCSubject(sSubject, true);
            }
        }

        private void SelectAllText(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }



    }
}