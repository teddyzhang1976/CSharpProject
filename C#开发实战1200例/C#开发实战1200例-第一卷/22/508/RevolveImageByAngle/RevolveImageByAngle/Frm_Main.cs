using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RevolveImageByAngle
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        private Bitmap SourceBitmap;
        private Bitmap MyBitmap;
        private void button2_Click(object sender, EventArgs e)
        {
            //打开图像文件
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "图像文件(JPeg, Gif, Bmp, etc.)|*.jpg;*.jpeg;*.gif;*.bmp;*.tif; *.tiff; *.png| JPeg 图像文件(*.jpg;*.jpeg)|*.jpg;*.jpeg |GIF 图像文件(*.gif)|*.gif |BMP图像文件(*.bmp)|*.bmp|Tiff图像文件(*.tif;*.tiff)|*.tif;*.tiff|Png图像文件(*.png)| *.png |所有文件(*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //得到原始大小的图像
                SourceBitmap = new Bitmap(openFileDialog.FileName);
                //得到缩放后的图像
                MyBitmap = new Bitmap(SourceBitmap, this.pictureBox1.Width, this.pictureBox1.Height);
                this.pictureBox1.Image = MyBitmap;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = this.panel1.CreateGraphics();//实例化绘图对象
            float MyAngle = 0;//旋转的角度
            while (MyAngle < 360)
            {
                TextureBrush MyBrush = new TextureBrush(MyBitmap);//实例化TextureBrush类
                this.panel1.Refresh();//使工作区无效
                MyBrush.RotateTransform(MyAngle);//以指定角度旋转图像
                g.FillRectangle(MyBrush, 0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height);//绘制旋转后的图像
                MyAngle += 0.5f;//增加旋转的角度
                System.Threading.Thread.Sleep(50);//使线程休眠50毫秒
            }
        }
    }
}