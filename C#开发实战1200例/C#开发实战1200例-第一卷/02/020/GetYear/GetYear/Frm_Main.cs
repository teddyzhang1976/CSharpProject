using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GetYear
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_GetMessage_Click(object sender, EventArgs e)
        {
            ushort P_usint_temp;//定义局部变量
            if (ushort.TryParse(//将输入字符串转换为数值
                txt_year.Text, out P_usint_temp))
            {
                MessageBox.Show(//输出计算结果
                    (P_usint_temp % 4 == 0 && P_usint_temp % 100 != 0)//判断是否为闰年
                    || P_usint_temp % 400 == 0 ? "输入的是闰年！" : "输入的不是闰年！",
                    "提示！");
            }
            else
            {
                MessageBox.Show(//提示输入数值不正确
                    "请输入正确数值！", "提示！");
            }
        }
    }
}
