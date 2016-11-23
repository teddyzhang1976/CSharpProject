using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ALitterArms
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = 0, b = 0, c = 0;//定义变量
            for (int i = 1; i < 100; i++)//遍历
            {
                Math.DivRem(i, 3, out a);//3行一列时取余
                Math.DivRem(i, 5, out b);//5行一列时取余
                Math.DivRem(i, 7, out c);//7行一列时取余
                if (a == 1 && b == 0 && c == 5)//如果3种方式的余数符合要求
                {
                    textBox1.Text = i.ToString();//显示人数
                    return;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label2.Text = "韩信点兵是一道古代数学题，内容是：韩信带" + "\r" + "兵不足百人，三人一行排列多一个，七人一行" + "\r" + "排列少两个，五人一行排列正好。";
        }
    }
}
