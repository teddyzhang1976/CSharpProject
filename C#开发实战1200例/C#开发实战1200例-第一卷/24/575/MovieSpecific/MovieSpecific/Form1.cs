using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MovieSpecific
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;//启动计时器
            pictureBox1.Visible = false;//隐藏PictureBox控件
            label1.Visible = true;//显示Label控件
        }
        private void button3_Click(object sender, EventArgs e)
        {
            label1.Visible = false;//隐藏Label控件
            timer1.Enabled = true;//启动计时器
            pictureBox1.Visible = true;//显示PictureBox控件
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Font = new Font(label1.Font.FontFamily, label1.Font.Size + 1);//使字体逐步加一
            pictureBox1.Size = new Size(pictureBox1.Size.Width + 5, pictureBox1.Size.Height + 5);//使图片逐渐增大
        }
    }
}