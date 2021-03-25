namespace HomeSchoolDayBook
{
    partial class frpReportViewer
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
            if (disposing && (components != null))
            {
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.DT22VariousBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hsdReportDS = new HomeSchoolDayBook.hsdReportDS();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.DT22VariousBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hsdReportDS)).BeginInit();
            this.SuspendLayout();
            // 
            // DT22VariousBindingSource
            // 
            this.DT22VariousBindingSource.DataMember = "DT22Various";
            this.DT22VariousBindingSource.DataSource = this.hsdReportDS;
            // 
            // hsdReportDS
            // 
            this.hsdReportDS.DataSetName = "hsdReportDS";
            this.hsdReportDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.DocumentMapCollapsed = true;
            this.reportViewer1.DocumentMapWidth = 25;
            reportDataSource2.Name = "hsdReportDS_DT22Various";
            reportDataSource2.Value = this.DT22VariousBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "HomeSchoolDayBook.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ShowBackButton = false;
            this.reportViewer1.ShowDocumentMapButton = false;
            this.reportViewer1.ShowFindControls = false;
            this.reportViewer1.ShowZoomControl = false;
            this.reportViewer1.Size = new System.Drawing.Size(682, 641);
            this.reportViewer1.TabIndex = 0;
            // 
            // frpReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 641);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frpReportViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Printable Reports:";
            this.Load += new System.EventHandler(this.frmPopReportViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DT22VariousBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hsdReportDS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource DT22VariousBindingSource;
        private hsdReportDS hsdReportDS;
    }
}