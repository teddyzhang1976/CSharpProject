using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Encrypt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Encrypt_Click(object sender, EventArgs e)
        {
            int P_int_Num, P_int_Key;//定义两个值类型变量
            if (int.TryParse(txt_Num.Text, out P_int_Num)//判断输入是否是数值
                && int.TryParse(txt_Key.Text, out P_int_Key))
            {
                txt_Encrypt.Text = (P_int_Num ^ P_int_Key).ToString();//加密数值
            }
            else
            {
                MessageBox.Show("请输入数值", "出现错误！");//提示输入信息不正确
            }
        }

        private void btn_Revert_Click(object sender, EventArgs e)
        {
            int P_int_Key, P_int_Encrypt;//定义两个值类型变量
            if (int.TryParse(txt_Encrypt.Text, out P_int_Key)//判断输入是否是数值
                && int.TryParse(txt_Key.Text, out P_int_Encrypt))
            {
                txt_Revert.Text = (P_int_Encrypt ^ P_int_Key).ToString();//解密数值
            }
            else
            {
                MessageBox.Show("请输入数值", "出现错误！");//提示输入信息不正确
            }
        }
    }
}
