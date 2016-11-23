using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HundredChicken
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = 0, b = 0, c = 0, p = 0;//定义变量
            for (a = 1; a <= 19; a++)//公鸡的百元中的遍历
            {
                for (b = 1; b <= 33; b++)//母鸡在百元中的遍历
                {
                    c = 100 - a - b;//获取百中除了公鸡和母鸡后，小鸡的总钱数
                    Math.DivRem(c, 3, out p);//计算小鸡的个数
                    if (((5 * a + 3 * b + c / 3) == 100) && p == 0)//如果公鸡、母鸡和小鸡的总钱数加起来为100
                    {
                        textBox1.Text = a.ToString();//显示公鸡的个数
                        textBox2.Text = b.ToString();//显示母鸡的个数
                        textBox3.Text = c.ToString();//显示小鸡的个数
                        return;
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label4.Text="公鸡5元一只，母鸡3元一只，小鸡3"+"\r"+"只一元，用100元买100只鸡";
        }

    }
}
