using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GetCode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Get_Click(object sender, EventArgs e)
        {
            try
            {
                char chr = txt_chr.Text[0];//获得一个汉字字符
                byte[] gb2312_bt = //使用gb2312编码方式获得字节序列
                    Encoding.GetEncoding("gb2312").GetBytes(new Char[] { chr });
                int n = (int)gb2312_bt[0] << 8;//将字节序列的第一个字节向左移8位
                n += (int)gb2312_bt[1];//第一个字节移8位后与第二个字节相加得到汉字编码
                txt_Num.Text = n.ToString();//显示汉字编码
            }
            catch (Exception)
            {
                MessageBox.Show(//异常提示信息
                    "请输入汉字字符！", "出现错误！");
            }
        }
    }
}
