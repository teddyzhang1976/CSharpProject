using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AddShart
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            string strPath = Application.StartupPath.Substring(0,//设置报表路径
            Application.StartupPath.Substring(0,
            Application.StartupPath.LastIndexOf("\\")).LastIndexOf("\\"));
            strPath += @"\CrystalReport1.rpt";//添加服表文件名称
            this.crystalReportViewer1.ReportSource = strPath;//将报表绑定到CrystalReportViewer控件
        }
    }
}
