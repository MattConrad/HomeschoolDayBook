using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections.Specialized;
using Microsoft.Reporting.WinForms;

namespace HomeSchoolDayBook
{
    /// <summary>
    /// if you want to override report viewer msgs, see:
    /// ms-help://MS.VSCC.v90/MS.MSDNQTR.v90.en/rs_vsrptoverview/html/4e624d4e-6a74-7316-d76b-d0c9aaab4a8d.htm
    /// </summary>
    public partial class frpReportViewer : frbHSDAppearance
    {
        string _sRDLCPath;
        string _sDataSourceName;
        NameValueCollection _nvcParams;
        DataTable _dtReportData;

        public frpReportViewer(string sRDLCPath, string sDataSourceName, NameValueCollection nvcParams, DataTable dtReportData)
        {
            InitializeComponent();

            _sRDLCPath = sRDLCPath;
            _sDataSourceName = sDataSourceName;
            _nvcParams = nvcParams;
            _dtReportData = dtReportData;
        }

        private void frmPopReportViewer_Load(object sender, EventArgs e)
        {
            InitReportViewer();
            this.reportViewer1.RefreshReport();
        }

        private ReportParameter[] GetReportParameters(NameValueCollection _nvcParams)
        {
            List<ReportParameter> lstRParams = new List<ReportParameter>();

            foreach (string sPName in _nvcParams.Keys) {
                ReportParameter rp = new ReportParameter(sPName, _nvcParams[sPName]);
                lstRParams.Add(rp);
            }

            return lstRParams.ToArray();
        }

        private void InitReportViewer()
        {
            reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            reportViewer1.LocalReport.ReportEmbeddedResource = "HomeSchoolDayBook." + _sRDLCPath;

            ReportParameter[] rptParams = GetReportParameters(_nvcParams);
            reportViewer1.LocalReport.SetParameters(rptParams);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource(_sDataSourceName, _dtReportData));
        }

    }
}