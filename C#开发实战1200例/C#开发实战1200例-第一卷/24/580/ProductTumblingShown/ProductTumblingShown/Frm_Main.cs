using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ProductTumblingShown
{
    public partial class Frm_Main : Form
    {
        int left = 0;
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            left = 10; 				//初始化变量left的值
            this.panel1.Left += left; 	//设置panel1控件距容器左边缘之间的距离
            int width = this.Width - this.panel1.Width; 	//初始化变量width
            if (this.panel1.Left > width) 	//当panel1控件距容器左边缘之间的距离大于width时
            {
                this.timer1.Enabled = false; 		//禁用计时器timer1
                this.timer2.Enabled = true; 		//启用计时器timer2
                this.pictureBox1.Image = this.imageList1.Images[0];//设置pictureBox1控件中显示的图片
                this.pictureBox2.Image = this.imageList2.Images[0];//设置pictureBox2控件中显示的图片
                this.pictureBox3.Image = this.imageList3.Images[0];//设置pictureBox3控件中显示的图片
            }
        }
        private void Frm_Main_Load(object sender, EventArgs e)
        {
            this.pictureBox1.Image = this.imageList1.Images[0]; 	//设置pictureBox1控件中显示的图片
            this.pictureBox2.Image = this.imageList2.Images[0]; 	//设置pictureBox2控件中显示的图片
            this.pictureBox3.Image = this.imageList3.Images[0]; 	//设置pictureBox3控件中显示的图片
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            left = -10; 	//初始化left的值
            this.panel1.Left += left; 	//设置panel1距容器左边缘之间的距离
            if (this.panel1.Left < 0) 		//当panel1距容器左边缘之间的距离小于0时
            {
                this.timer1.Enabled = true; 		//启用计时器timer1
                this.timer2.Enabled = false; 		//禁用计时器timer2
                this.pictureBox1.Image = this.imageList1.Images[1]; //设置pictureBox1控件中显示的图片
                this.pictureBox2.Image = this.imageList2.Images[1]; //设置pictureBox2控件中显示的图片
                this.pictureBox3.Image = this.imageList3.Images[1]; //设置pictureBox3控件中显示的图片
            }
        }
    }
}