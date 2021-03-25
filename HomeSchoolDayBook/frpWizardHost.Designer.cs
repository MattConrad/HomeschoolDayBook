namespace HomeSchoolDayBook
{
    partial class frpWizardHost
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlWizardPages = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlWizardPages
            // 
            this.pnlWizardPages.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlWizardPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWizardPages.Location = new System.Drawing.Point(0, 0);
            this.pnlWizardPages.Name = "pnlWizardPages";
            this.pnlWizardPages.Size = new System.Drawing.Size(454, 572);
            this.pnlWizardPages.TabIndex = 0;
            // 
            // frpWizardHost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 572);
            this.ControlBox = false;
            this.Controls.Add(this.pnlWizardPages);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frpWizardHost";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frpPopWizardHost";
            this.Load += new System.EventHandler(this.frpPopWizardHost_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlWizardPages;
    }
}