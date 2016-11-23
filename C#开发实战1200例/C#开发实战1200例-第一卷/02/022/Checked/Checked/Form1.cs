using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Checked
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Get_Click(object sender, EventArgs e)
        {
            byte bt_One, bt_Two;//定义两个byte类型变量
            if (byte.TryParse(//对两个byte类型变量赋值
                txt_Add_One.Text, out bt_One) 
                && byte.TryParse(txt_Add_Two.Text, out bt_Two))
            {
                try
                {
                    checked { bt_One += bt_Two; }//使用checke关键字判断是否有溢出
                    txt_Result.Text = bt_One.ToString();//输出相加后的结果
                }
                catch (OverflowException ex)
                {
                    MessageBox.Show(ex.Message,"出错！");//输出异常信息
                }
            }
            else
            {
                MessageBox.Show("请输入255以内的数字!");//输出错误信息
            }
        }
    }
}
