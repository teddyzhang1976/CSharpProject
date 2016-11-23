using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StartForm
{
    public partial class Frm_Start : Form
    {
        public Frm_Start()
        {
            InitializeComponent();
        }

        private void Frm_Start_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;//设置启动窗体为无标题栏窗体
            this.BackgroundImage = Image.FromFile("start.jpg");//设置启动窗体的背景图片
            this.BackgroundImageLayout = ImageLayout.Stretch;//设置图片自动适应窗体大小
            this.timer1.Start();//启动计时器
            this.timer1.Interval = 10000;//设置启动窗体停留时间
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();//关闭启动窗体
        }

        private void Frm_Start_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.timer1.Stop();//关闭计时器
        }
    }
}
