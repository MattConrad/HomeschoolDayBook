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
    public partial class frbHSDAppearance : Form
    {
//        private DataGridViewCellStyle _dgvsColorStyle;

        public frbHSDAppearance()
        {
            InitializeComponent();
            InitAppearances();
        }

        private void InitAppearances()
        {
            //this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.BackColor = System.Drawing.Color.LightCyan;

            //_dgvsColorStyle = new DataGridViewCellStyle();
            //_dgvsColorStyle.BackColor = Color.Ivory;

        }

        public void DisplayHSDKryptonized(System.Windows.Forms.Control.ControlCollection ctls)
        {
            foreach (Control c in ctls) {
                if (c.Controls != null)
                    DisplayHSDKryptonized(c.Controls);

                if (c is IHSDKryChangeListener)
                    ((IHSDKryChangeListener)c).DisplayWithCurrentPalette();
            }
        }


    }
}