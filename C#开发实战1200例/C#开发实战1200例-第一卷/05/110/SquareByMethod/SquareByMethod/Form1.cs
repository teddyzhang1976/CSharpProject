using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SquareByMethod
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public double SquareNum(double num)
        {
            return num * num;//求一个数的平方
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string strNum = textBox1.Text.Trim();//记录TextBox文本框中的内容
            if (strNum != "")//判断是否输入了数据
            {
                try
                {
                    textBox2.Text = SquareNum(double.Parse(strNum)).ToString();//调用自定义方法进行求平方运算
                }
                catch
                {
                    MessageBox.Show("请输入正确的数字！");
                }
            }
        }
    }
}
