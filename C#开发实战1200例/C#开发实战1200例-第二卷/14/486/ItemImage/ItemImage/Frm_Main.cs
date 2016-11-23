using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
namespace ItemImage
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string strPath = Application.StartupPath.Substring(//得到报表路径
                0, Application.StartupPath.Substring(0,
                Application.StartupPath.LastIndexOf("\\")).LastIndexOf("\\"));
            strPath += @"\CrystalReport1.rpt";//添加文件名称
            this.crystalReportViewer1.ReportSource = strPath;//将报表绑定到CrystalReportView控件
        }
    }
}