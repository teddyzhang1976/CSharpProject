using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports;

namespace DisplayStudent
{
    public partial class DisplayStudent : Form
    {
        public DisplayStudent()
        {
            InitializeComponent();
        }

        private void DisplayStudent_Load(object sender,EventArgs e)
        {
            crystalReportViewer1.ReportSource = new CrystalReport1();//将报表绑定到CrystalReportViewer控件
        }
    }
}
