using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GetYesterDay
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_GetYesterday_Click(object sender, EventArgs e)
        {
            MessageBox.Show(//显示前一天日期
                "昨天是：" + DateTime.Now.AddDays(-1).
                ToString("yyyy年M月d日"), "提示！");
        }
    }
}
