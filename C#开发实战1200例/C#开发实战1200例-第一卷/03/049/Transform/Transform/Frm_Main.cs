using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Transform
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_transform_Click(object sender, EventArgs e)
        {
            int P_int_temp;//定义整型变量
            if (int.TryParse(txt_lower.Text,out P_int_temp))
            {
                txt_upper.Text = //获取转换为大写金额的字符串
                    new Upper().NumToChinese(txt_lower.Text);
            }
            else
            {
                MessageBox.Show(//错误提示信息
                    "请输入正确整数数值","提示！");
            }
        }
    }
}
