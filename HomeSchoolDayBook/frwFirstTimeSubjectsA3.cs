using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HomeSchoolDayBook
{
    public partial class frwFirstTimeSubjectsA3 : frbHSDWizard
    {
        string[] _sSubjects;

        public frwFirstTimeSubjectsA3()
        {
            InitializeComponent();
            InitSubjectList();
        }

        private void frwFirstTimeSubjectsA3_Load(object sender, EventArgs e)
        {
            txtSubjects.Lines = _sSubjects;
        }

        private void InitSubjectList()
        {
            List<string> lstSubjects = new List<string>();

            lstSubjects.Add("Art");
            lstSubjects.Add("English");
            lstSubjects.Add("History");
            lstSubjects.Add("Math");
            lstSubjects.Add("Phys Ed/Health");
            lstSubjects.Add("Reading");
            lstSubjects.Add("Religion");
            lstSubjects.Add("Science");

            _sSubjects = lstSubjects.ToArray();
        }

        private void btnUseListAndFinish_Click(object sender, EventArgs e)
        {
            foreach (string sSubject in _sSubjects) {
                HSDMain.CEDbH.SaveNewCSubject(sSubject, true);
            }

            WizMoveNamedForm("conclusion5");
        }

        private void btnGoToCustomSubjects_Click(object sender, EventArgs e)
        {
            WizMoveNextForm();
        }

    }
}