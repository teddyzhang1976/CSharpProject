using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CalcByClass
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int i = 0;//记录第一个数
        int j = 0;//记录第二个数
        string type = "";//记录运算类型
        //数字1
        private void button1_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox1.Text) != 0)//判断是否已经输入了数字
                textBox1.Text += "1";//如果已经输入，并且不是0，则加1
            else
                textBox1.Text = "1";
        }
        //数字2
        private void button2_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox1.Text) != 0)
                textBox1.Text += "2";
            else
                textBox1.Text = "2";
        }
        //数字3
        private void button3_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox1.Text) != 0)
                textBox1.Text += "3";
            else
                textBox1.Text = "3";
        }
        //数字4
        private void button5_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox1.Text) != 0)
                textBox1.Text += "4";
            else
                textBox1.Text = "4";
        }
        //数字5
        private void button4_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox1.Text) != 0)
                textBox1.Text += "5";
            else
                textBox1.Text = "5";
        }
        //数字6
        private void button6_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox1.Text) != 0)
                textBox1.Text += "6";
            else
                textBox1.Text = "6";
        }
        //数字7
        private void button7_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox1.Text) != 0)
                textBox1.Text += "7";
            else
                textBox1.Text = "7";
        }
        //数字8
        private void button8_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox1.Text) != 0)
                textBox1.Text += "8";
            else
                textBox1.Text = "8";
        }
        //数字9
        private void button9_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox1.Text) != 0)
                textBox1.Text += "9";
            else
                textBox1.Text = "9";
        }
        //数字0
        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }
        //加法运算
        private void button12_Click(object sender, EventArgs e)
        {
            i = Convert.ToInt32(textBox1.Text);//记录第一个数
            type = "+";//记录运算类型
            textBox1.Text = "0";//清空文本框
        }
        //减法运算
        private void button13_Click(object sender, EventArgs e)
        {
            i = Convert.ToInt32(textBox1.Text);
            type = "-";
            textBox1.Text = "0";
        }
        //乘法运算
        private void button14_Click(object sender, EventArgs e)
        {
            i = Convert.ToInt32(textBox1.Text);
            type = "*";
            textBox1.Text = "0";
        }
        //除法运算
        private void button15_Click(object sender, EventArgs e)
        {
            i = Convert.ToInt32(textBox1.Text);
            type = "/";
            textBox1.Text = "0";
        }
        //等号
        private void button11_Click(object sender, EventArgs e)
        {
            j = Convert.ToInt32(textBox1.Text);//记录第二个数
            CCount myCount = new CCount();//实例化类对象
            if (type == "/" && j == 0)//判断运算类型是不是除法
            {
                MessageBox.Show("被除数不能为0");
            }
            else
            {
                textBox1.Text = myCount.Sum(i, j, type).ToString();//计算结果
            }
        }
        //清空文本框
        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";//清空文本框
        }
    }
    public class CCount
    {
        public int Sum(int a, int b, string type)//定义一个方法，用来计算两个数的和、差、积、商
        {
            switch (type)//判断运算符类型
            {
                case "+":
                    return a + b; break;//计算两个数的和
                case "-":
                    return a - b; break;//计算两个数的差
                case "*":
                    return a * b; break;//计算两个数的积
                case "/":
                    return a / b; break;//计算两个数的商
                default:
                    return 0; break;
            }
        }
    }
}
