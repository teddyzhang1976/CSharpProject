using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GetDays
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Get_Click(object sender, EventArgs e)
        {
            if (DateTime.IsLeapYear(int.Parse(//判断是否为闰年
                DateTime.Now.ToString("yyyy"))))
            {
                MessageBox.Show("本年有366天","提示！");//显示天数信息
            }
            else
            {
                MessageBox.Show("本年有365天", "提示！");//显示天数信息
            }
        }
    }
}
