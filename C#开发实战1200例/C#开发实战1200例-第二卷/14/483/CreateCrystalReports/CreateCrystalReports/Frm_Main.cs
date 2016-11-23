using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CreateCrystalReports
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            string strPath = Application.StartupPath.Substring(//计算报表路径
                0, Application.StartupPath.Substring(0,
                Application.StartupPath.LastIndexOf("\\")).LastIndexOf("\\"));
            strPath += @"\StudentReport.rpt";//添加报表名称
            this.crystalReportViewer1.ReportSource = strPath;//将报表绑定到CrystalReportViewer控件
        }
    }
}
