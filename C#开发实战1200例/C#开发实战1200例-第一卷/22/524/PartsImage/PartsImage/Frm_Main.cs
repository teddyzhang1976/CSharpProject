using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace PartsImage
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
            g.Clear(Color.White);//清空背景色
            int width = MyBitmap.Width;//获取图片的宽度
            int height = MyBitmap.Height;//获取图片的高度
            //定义将图片切分成四个部分的区域
            RectangleF[] block ={
					new RectangleF(0,0,width/2,height/2),
					new RectangleF(width/2,0,width/2,height/2),
					new RectangleF(0,height/2,width/2,height/2),
					new RectangleF(width/2,height/2,width/2,height/2)};
            //分别克隆图片的四个部分	
            Bitmap[] MyBitmapBlack ={
                MyBitmap.Clone(block[0],System.Drawing.Imaging.PixelFormat.DontCare),
                MyBitmap.Clone(block[1],System.Drawing.Imaging.PixelFormat.DontCare),
                MyBitmap.Clone(block[2],System.Drawing.Imaging.PixelFormat.DontCare),
                MyBitmap.Clone(block[3],System.Drawing.Imaging.PixelFormat.DontCare)};
            //绘制图片的四个部分，各部分绘制时间间隔为0.5秒					
            g.DrawImage(MyBitmapBlack[0], 0, 0);
            System.Threading.Thread.Sleep(500);
            g.DrawImage(MyBitmapBlack[1], width / 2, 0);
            System.Threading.Thread.Sleep(500);
            g.DrawImage(MyBitmapBlack[3], width / 2, height / 2);
            System.Threading.Thread.Sleep(500);
            g.DrawImage(MyBitmapBlack[2], 0, height / 2);
        }
    }
}