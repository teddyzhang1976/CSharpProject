using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UseExpressions
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string strrpor = Application.StartupPath.Substring(0,//得到报表路径信息
                Application.StartupPath.Substring(0, 
                Application.StartupPath.LastIndexOf("\\")).LastIndexOf("\\"));
            strrpor += @"\CrystalReport1.rpt";//添加报表文件名称
            this.crystalReportViewer1.ReportSource = strrpor;//将报表绑定到CrystalReportViewer控件
        }
    }
}