using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TypesCalc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static int Add(int x, int y)//定义一个静态方法Add，返回值为int类型，有两个int类型的参数
        {
            return x + y;
        }
        public double Add(int x, double y)//重新定义方法Add，它与第一个方法的返回值类型及参数类型不同
        {
            return x + y;
        }
        public double Add(double x, double y)//重新定义方法Add，它与第一个方法的返回值类型及参数类型不同
        {
            return x + y;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButton1.Checked)//判断int单选按钮是否选中
                {
                    //计算两个int类型数据的和
                    textBox3.Text = (Convert.ToInt32(textBox1.Text) + Convert.ToInt32(textBox2.Text)).ToString();
                }
                else if (radioButton2.Checked)//判断int+double单选按钮是否选中
                {
                    //计算int类型数据和double类型数据的和
                    textBox3.Text = (Convert.ToInt32(textBox1.Text) + Convert.ToDouble(textBox2.Text)).ToString();
                }
                else if (radioButton3.Checked)//判断double单选按钮是否选中
                {
                    //计算两个double类型数据的和
                    textBox3.Text = (Convert.ToDouble(textBox1.Text) + Convert.ToDouble(textBox2.Text)).ToString();
                }
            }
            catch { }
        }
    }
}
