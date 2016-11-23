using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AgreeArithmetic
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();//清空ListBox控件
            int p = 0, n = 0, a = 1, b = 1;//定义变量
            try
            {
                p = Convert.ToInt32(textBox1.Text);//将字符型转换成数值型
            }
            catch//出现错误
            {
                MessageBox.Show("请输入数值型数据");//弹出提示框
                textBox1.Text = "15";
                return;
            }
            for (n = 1; n <= p; n++)//对输入的数值进行遍历
            {
                listBox1.Items.Add(a.ToString());//输出数值
                listBox1.Items.Add(b.ToString());//输出数值
                a = a + b;//获取前两个数的和
                b = a + b;//获取前两个数的和
            }
        }
    }
}
