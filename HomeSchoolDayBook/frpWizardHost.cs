using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HomeSchoolDayBook
{
    public partial class frpWizardHost : frbHSDAppearance
    {
        private List<frbHSDWizard> _lstWizForms;
        private int _iCurrentWizFormIdx;

        public frpWizardHost(List<frbHSDWizard> lstWizardForms)
        {
            InitializeComponent();
            _lstWizForms = lstWizardForms;
            _iCurrentWizFormIdx = 0;
            InitPanelWithWizardForms();

            this.KeyDown += new KeyEventHandler(frpWizardHost_KeyDown);
        }

        private void frpWizardHost_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.F4) {
                MessageBox.Show("You must either complete the setup wizard or quit using the Quit button on the first screen.", "Invalid Exit:");
                e.Handled = true;
            }
        }

        private void frpPopWizardHost_Load(object sender, EventArgs e)
        {
            DisplayNewWizardForm(0);
        }

        /// <summary>
        /// Load the next/prev page in the wizard.
        /// </summary>
        /// <param name="iIndexDelta">Presently, should always be 1, -1, or 0.</param>
        public void DisplayNewWizardForm(int iIndexDelta)
        {
            int iNewIndex = _iCurrentWizFormIdx + iIndexDelta;

            if (iNewIndex < 0 || (iNewIndex > _lstWizForms.Count - 1))
                throw new ArgumentException("System Error: the wizard process requested a next/prev screen that does not exist.");

            frbHSDWizard fwCurrent = _lstWizForms[_iCurrentWizFormIdx];
            frbHSDWizard fwNew = _lstWizForms[iNewIndex];

            fwCurrent.Hide();
            fwNew.Show();

            _iCurrentWizFormIdx = iNewIndex;
        }

        public void DisplayNewWizardForm(string sTextName)
        {
            int iNewIndex = -1;

            for (int i = 0; i < _lstWizForms.Count; i++) {
                if (_lstWizForms[i].Text == sTextName) {
                    iNewIndex = i;
                    break;
                }
            }

            if (iNewIndex < 0)
                throw new ArgumentException("System Error: the wizard process requested a named screen that does not exist.");

            frbHSDWizard fwCurrent = _lstWizForms[_iCurrentWizFormIdx];
            frbHSDWizard fwNew = _lstWizForms[iNewIndex];

            fwCurrent.Hide();
            fwNew.Show();

            _iCurrentWizFormIdx = iNewIndex;
        }

        private void InitPanelWithWizardForms()
        {
            foreach (frbHSDWizard fw in _lstWizForms) {
                fw.FormBorderStyle = FormBorderStyle.None;
                fw.TopLevel = false;
                fw.Visible = false;
                fw.Tag = this;          //this is important...
                pnlWizardPages.Controls.Add(fw);
            }
        }

        public void QuitWizard()
        {
            this.Close();
        }
    }
}
