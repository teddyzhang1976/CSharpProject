using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TryNum
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_true_Click(object sender, EventArgs e)
        {
            double P_dbl_value;//定义变量
            if (double.TryParse(//判断输入信息是否正确
                txt_value.Text, out P_dbl_value))
            {
                //txt_value.Clear();//清空TextBox
                MessageBox.Show("输入的数值正确！");//提示正确信息
            }
            else
            {
                MessageBox.Show(//提示错误信息
                    "输入的数值有误，请重新输入！","提示！");
            }
        }
    }
}
