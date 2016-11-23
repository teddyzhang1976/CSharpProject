using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DrawPeachBlossom
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        int flag = 0;//定义一个标记，用来标记画桃花的哪个部分
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            flag = 0;//标记绘制花骨朵
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            flag = 1;//标记绘制花蕾
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            flag = 2;//标记绘制开花效果
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Point myPT = new Point(e.X, e.Y);//获取鼠标单击位置
            PictureBox pbox = new PictureBox();//实例化PictureBox控件
            pbox.Location = myPT;//指定PictureBox控件的位置
            pbox.BackColor = Color.Transparent;//设置PictureBox控件的背景色
            pbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;//设置PictureBox控件的图片显示方式
            switch (flag)//判断标记
            {
                case 0:
                    pbox.Size = new System.Drawing.Size(20, 18);//设置PictureBox控件大小
                    pbox.Image = Properties.Resources._2;//设置PictureBox控件要显示的图像
                    break;
                case 1:
                    pbox.Size = new System.Drawing.Size(30, 31);//设置PictureBox控件大小
                    pbox.Image = Properties.Resources._3;//设置PictureBox控件要显示的图像
                    break;
                case 2:
                    pbox.Size = new System.Drawing.Size(34, 30);//设置PictureBox控件大小
                    pbox.Image = Properties.Resources._1;//设置PictureBox控件要显示的图像
                    break;
            }
            if (e.Button == MouseButtons.Left)//判断是否单击了鼠标左键
            {
                pictureBox1.Controls.Add(pbox);//将把图片控件添加到桃树上
            }
        }
    }
}
