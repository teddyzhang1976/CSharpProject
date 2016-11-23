using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SuavityImage
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //打图像文件
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "图像文件(JPeg, Gif, Bmp, etc.)|*.jpg;*.jpeg;*.gif;*.bmp;*.tif; *.tiff; *.png| JPeg 图像文件(*.jpg;*.jpeg)|*.jpg;*.jpeg |GIF 图像文件(*.gif)|*.gif |BMP图像文件(*.bmp)|*.bmp|Tiff图像文件(*.tif;*.tiff)|*.tif;*.tiff|Png图像文件(*.png)| *.png |所有文件(*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap MyBitmap = new Bitmap(openFileDialog.FileName);
                this.pictureBox1.Image = MyBitmap;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int Height = this.pictureBox1.Image.Height;//获取图像高度
                int Width = this.pictureBox1.Image.Width;//获取图像宽度
                Bitmap bitmap = new Bitmap(Width, Height);//实例化新的位图对象
                Bitmap MyBitmap = (Bitmap)this.pictureBox1.Image;//记录原图
                Color pixel;//定义一个Color结构
                int[] Gauss ={ 1, 2, 1, 2, 4, 2, 1, 2, 1 };//定义高斯模板值
                //遍历原图的每个位置
                for (int x = 1; x < Width - 1; x++)
                    for (int y = 1; y < Height - 1; y++)
                    {
                        int r = 0, g = 0, b = 0;//声明3个变量，用来记录R/G/B值
                        int Index = 0;//声明一个变量，用来记录位置
                        for (int col = -1; col <= 1; col++)
                            for (int row = -1; row <= 1; row++)
                            {
                                pixel = MyBitmap.GetPixel(x + row, y + col);//获取指定点的像素
                                r += pixel.R * Gauss[Index];//记录R值
                                g += pixel.G * Gauss[Index];//记录G值
                                b += pixel.B * Gauss[Index];//记录B值
                                Index++;
                            }
                        r /= 16;//为R重新赋值
                        g /= 16;//为G重新赋值
                        b /= 16;//为B重新赋值
                        //处理颜色值溢出
                        r = r > 255 ? 255 : r;
                        r = r < 0 ? 0 : r;
                        g = g > 255 ? 255 : g;
                        g = g < 0 ? 0 : g;
                        b = b > 255 ? 255 : b;
                        b = b < 0 ? 0 : b;
                        bitmap.SetPixel(x - 1, y - 1, Color.FromArgb(r, g, b));//重新为指定点赋颜色值
                    }
                this.pictureBox1.Image = bitmap;//显示柔化效果的图像
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "信息提示");
            }
        }
    }
}