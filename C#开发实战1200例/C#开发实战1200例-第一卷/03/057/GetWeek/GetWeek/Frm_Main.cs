using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GetWeek
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_GetWeek_Click(object sender, EventArgs e)
        {
            MessageBox.Show("今天是： "//显示星期信息
                + DateTime.Now.ToString("dddd"), "提示！");
        }
    }
}
