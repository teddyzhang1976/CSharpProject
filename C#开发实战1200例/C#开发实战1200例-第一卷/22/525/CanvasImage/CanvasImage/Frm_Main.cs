using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace CanvasImage
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
            //以油画效果显示图像
            Graphics g = this.panel1.CreateGraphics();
            //取得图片尺寸
            int width = MyBitmap.Width;
            int height = MyBitmap.Height;
            RectangleF rect = new RectangleF(0, 0, width, height);
            Bitmap img = MyBitmap.Clone(rect, System.Drawing.Imaging.PixelFormat.DontCare);
            //产生随机数序列
            Random rnd = new Random();
            //取不同的值决定油画效果的不同程度
            int iModel = 2;
            int i = width - iModel;
            while (i > 1)
            {
                int j = height - iModel;
                while (j > 1)
                {
                    int iPos = rnd.Next(100000) % iModel;
                    //将该点的RGB值设置成附近iModel点之内的任一点
                    Color color = img.GetPixel(i + iPos, j + iPos);
                    img.SetPixel(i, j, color);
                    j = j - 1;
                }
                i = i - 1;
            }
            //重新绘制图像
            g.Clear(Color.White);
            g.DrawImage(img, new Rectangle(0, 0, width, height)); 
        }
    }
}