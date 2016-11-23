using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MoveFontInForm
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)//用Timer来控制滚动速度
        {
            label1.Left -= 2;//设置label1左边缘与其容器的工作区左边缘之间的距离
            if (label1.Right < 0)//当label1右边缘与其容器的工作区左边缘之间的距离小于0时
            {
                label1.Left = this.Width;//设置label1左边缘与其容器的工作区左边缘之间的距离为该窗体的宽度
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;//开始滚动
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;//停止滚动
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();//关闭窗体
        }
    }
}