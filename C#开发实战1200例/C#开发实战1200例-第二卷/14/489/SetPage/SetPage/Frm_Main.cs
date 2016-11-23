using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SetPage
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            CrystalReport1 P_CrystalReport = new CrystalReport1();//创建报表对象
            CRViewer_Message.ReportSource = P_CrystalReport;//将报表绑定到CrystalReportViewer控件
        }
    }
}
