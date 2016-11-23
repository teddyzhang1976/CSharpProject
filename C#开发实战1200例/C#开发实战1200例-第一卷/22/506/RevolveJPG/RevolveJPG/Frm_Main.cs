using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;

namespace RevolveJPG
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "*.jpg|*.jpg";								//设置图片的类型
            openFileDialog1.ShowDialog();									//打开文件对话框
            Image myImage = System.Drawing.Image.FromFile(openFileDialog1.FileName);	//实例化Image类
            pictureBox1.Image = myImage;									//显示打开的图片
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Image myImage = pictureBox1.Image;								//实例化Image类
            myImage.RotateFlip(RotateFlipType.Rotate90FlipXY); 		//调用RotateFlip方法将JPG格式图像进行旋转
            pictureBox1.Image = myImage;									//显示旋转后的图片
        }
    }
}