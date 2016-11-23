using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DaffodilAccount
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        //水仙花数的算法是一个三位数，每一位数的立方相加等于该数本身。
        private void button1_Click(object sender, EventArgs e)
        {
            int a = 0, b = 0, c = 0;//定义变量
            listBox1.Items.Clear();//清空listBox1控件
            for (int i = 100; i <= 1000; i++)//遍历所有3位数
            {
                a = i / 100;//获取3位数中的第一个数
                Math.DivRem(i, 100, out b);//获取3位数中的后两位数
                b = b / 10;//获取3位数中的第二位数
                Math.DivRem(i, 10, out c);//获取3位数中的第3位数
                a = a * a * a;//计算第一位数的立方
                b = b * b * b;//计算第二位数的立方
                c = c * c * c;//计算第3位数的立方
                if ((a + b + c) == i)//如果符合水仙花数
                    listBox1.Items.Add(i.ToString());//显示当前3位数
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "水仙花数的算法是一个三位数，每一位数的立方相"+"\r"+"加等于该数本身。";
        }
    }
}
