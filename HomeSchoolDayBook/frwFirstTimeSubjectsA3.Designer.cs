namespace HomeSchoolDayBook
{
    partial class frwFirstTimeSubjectsA3
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
            this.kpnlMain = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.txtSubjects = new HomeSchoolDayBook.HSDKTextBox();
            this.btnGoToCustomSubjects = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.label1 = new HomeSchoolDayBook.HSDSubKryptonPanelLabel();
            this.btnUseListAndFinish = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lblSubjectsCanChange = new HomeSchoolDayBook.HSDSubKryptonPanelLabel();
            this.lblSubjectsSuggestListIntro = new HomeSchoolDayBook.HSDSubKryptonPanelLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlMain)).BeginInit();
            this.kpnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // kpnlMain
            // 
            this.kpnlMain.Controls.Add(this.txtSubjects);
            this.kpnlMain.Controls.Add(this.btnGoToCustomSubjects);
            this.kpnlMain.Controls.Add(this.label1);
            this.kpnlMain.Controls.Add(this.btnUseListAndFinish);
            this.kpnlMain.Controls.Add(this.lblSubjectsCanChange);
            this.kpnlMain.Controls.Add(this.lblSubjectsSuggestListIntro);
            this.kpnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpnlMain.Location = new System.Drawing.Point(0, 0);
            this.kpnlMain.Name = "kpnlMain";
            this.kpnlMain.Size = new System.Drawing.Size(447, 547);
            this.kpnlMain.TabIndex = 6;
            // 
            // txtSubjects
            // 
            this.txtSubjects.Location = new System.Drawing.Point(123, 56);
            this.txtSubjects.Multiline = true;
            this.txtSubjects.Name = "txtSubjects";
            this.txtSubjects.ReadOnly = true;
            this.txtSubjects.SelectAllOnEnter = true;
            this.txtSubjects.Size = new System.Drawing.Size(199, 176);
            this.txtSubjects.TabIndex = 6;
            // 
            // btnGoToCustomSubjects
            // 
            this.btnGoToCustomSubjects.Location = new System.Drawing.Point(57, 392);
            this.btnGoToCustomSubjects.Name = "btnGoToCustomSubjects";
            this.btnGoToCustomSubjects.Size = new System.Drawing.Size(329, 28);
            this.btnGoToCustomSubjects.TabIndex = 8;
            this.btnGoToCustomSubjects.Text = "I\'d like to enter my own list of subjects from scratch.";
            this.btnGoToCustomSubjects.Values.ExtraText = "";
            this.btnGoToCustomSubjects.Values.Image = null;
            this.btnGoToCustomSubjects.Values.ImageStates.ImageCheckedNormal = null;
            this.btnGoToCustomSubjects.Values.ImageStates.ImageCheckedPressed = null;
            this.btnGoToCustomSubjects.Values.ImageStates.ImageCheckedTracking = null;
            this.btnGoToCustomSubjects.Values.Text = "I\'d like to enter my own list of subjects from scratch.";
            this.btnGoToCustomSubjects.Click += new System.EventHandler(this.btnGoToCustomSubjects_Click);
            // 
            // label1
            // 
            this.label1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.label1.Location = new System.Drawing.Point(54, 352);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(318, 33);
            this.label1.TabIndex = 11;
            this.label1.Text = "If you have a different list of subjects in mind, you can go to a \ncustom entry s" +
                "creen instead.";
            this.label1.Values.ExtraText = "";
            this.label1.Values.Image = null;
            this.label1.Values.Text = "If you have a different list of subjects in mind, you can go to a \ncustom entry s" +
                "creen instead.";
            // 
            // btnUseListAndFinish
            // 
            this.btnUseListAndFinish.Location = new System.Drawing.Point(57, 304);
            this.btnUseListAndFinish.Name = "btnUseListAndFinish";
            this.btnUseListAndFinish.Size = new System.Drawing.Size(329, 28);
            this.btnUseListAndFinish.TabIndex = 7;
            this.btnUseListAndFinish.Text = "Yes, use the list above to get started.";
            this.btnUseListAndFinish.Values.ExtraText = "";
            this.btnUseListAndFinish.Values.Image = null;
            this.btnUseListAndFinish.Values.ImageStates.ImageCheckedNormal = null;
            this.btnUseListAndFinish.Values.ImageStates.ImageCheckedPressed = null;
            this.btnUseListAndFinish.Values.ImageStates.ImageCheckedTracking = null;
            this.btnUseListAndFinish.Values.Text = "Yes, use the list above to get started.";
            this.btnUseListAndFinish.Click += new System.EventHandler(this.btnUseListAndFinish_Click);
            // 
            // lblSubjectsCanChange
            // 
            this.lblSubjectsCanChange.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.lblSubjectsCanChange.Location = new System.Drawing.Point(55, 248);
            this.lblSubjectsCanChange.Name = "lblSubjectsCanChange";
            this.lblSubjectsCanChange.Size = new System.Drawing.Size(314, 48);
            this.lblSubjectsCanChange.TabIndex = 10;
            this.lblSubjectsCanChange.Text = "The quickest way to get started is to use the list above.  Later \nyou can add sub" +
                "jects or adjust the name of a subject using \n\"Manage Subjects\" in Homeschool Day" +
                " Book.";
            this.lblSubjectsCanChange.Values.ExtraText = "";
            this.lblSubjectsCanChange.Values.Image = null;
            this.lblSubjectsCanChange.Values.Text = "The quickest way to get started is to use the list above.  Later \nyou can add sub" +
                "jects or adjust the name of a subject using \n\"Manage Subjects\" in Homeschool Day" +
                " Book.";
            // 
            // lblSubjectsSuggestListIntro
            // 
            this.lblSubjectsSuggestListIntro.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.lblSubjectsSuggestListIntro.Location = new System.Drawing.Point(57, 32);
            this.lblSubjectsSuggestListIntro.Name = "lblSubjectsSuggestListIntro";
            this.lblSubjectsSuggestListIntro.Size = new System.Drawing.Size(357, 19);
            this.lblSubjectsSuggestListIntro.TabIndex = 9;
            this.lblSubjectsSuggestListIntro.Text = "Here\'s a suggested list of subjects for starting Homeschool Day Book:";
            this.lblSubjectsSuggestListIntro.Values.ExtraText = "";
            this.lblSubjectsSuggestListIntro.Values.Image = null;
            this.lblSubjectsSuggestListIntro.Values.Text = "Here\'s a suggested list of subjects for starting Homeschool Day Book:";
            // 
            // frwFirstTimeSubjectsA3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 547);
            this.Controls.Add(this.kpnlMain);
            this.Name = "frwFirstTimeSubjectsA3";
            this.Text = "subjectsa3";
            this.Load += new System.EventHandler(this.frwFirstTimeSubjectsA3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kpnlMain)).EndInit();
            this.kpnlMain.ResumeLayout(false);
            this.kpnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kpnlMain;
        private HSDKTextBox txtSubjects;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnGoToCustomSubjects;
        private HomeSchoolDayBook.HSDSubKryptonPanelLabel label1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnUseListAndFinish;
        private HomeSchoolDayBook.HSDSubKryptonPanelLabel lblSubjectsCanChange;
        private HomeSchoolDayBook.HSDSubKryptonPanelLabel lblSubjectsSuggestListIntro;


    }
}