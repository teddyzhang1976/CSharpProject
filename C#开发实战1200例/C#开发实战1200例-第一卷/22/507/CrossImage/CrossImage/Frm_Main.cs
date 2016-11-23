using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;

namespace CrossImage
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //设置文件的类型
            openFileDialog1.Filter = "*.jpg,*.jpeg,*.bmp,*.gif,*.ico,*.png,*.tif,*.wmf|*.jpg;*.jpeg;*.bmp;*.gif;*.ico;*.png;*.tif;*.wmf";
            openFileDialog1.ShowDialog();									//打开文件对话框
            Image myImage = System.Drawing.Image.FromFile(openFileDialog1.FileName);	//根据文件的路径实例化Image类
            pictureBox1.Image = myImage;									//显示打开的图片
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Image myImage = pictureBox1.Image;//实例化Image
            myImage.RotateFlip(RotateFlipType.Rotate180FlipX); 					//调用RotateFlip方法实现图形翻转
            pictureBox1.Image = myImage;									//显示旋转后的图片
        }
    }
}