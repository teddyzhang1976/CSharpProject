using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SoftReg
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        SoftReg softreg = new SoftReg();//实例化类对象
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = softreg.getMNum();//生成机器码
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = softreg.getRNum(textBox1.Text);//根据机器码生成注册码
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();//退出应用程序
        }
    }
}
