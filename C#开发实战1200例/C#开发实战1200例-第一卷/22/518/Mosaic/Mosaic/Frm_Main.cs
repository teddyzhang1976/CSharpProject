using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;

namespace Mosaic
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "*.jpg,*.jpeg,*.bmp|*.jpg;*.jpeg;*.bmp";
            openFileDialog1.ShowDialog();
            Image myImage = System.Drawing.Image.FromFile(openFileDialog1.FileName);
            this.BackgroundImage = myImage;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap myBitmap = new Bitmap(this.BackgroundImage);				//根据窗体的背景实例化Bitmap类
            int intWidth = myBitmap.Width / 50;								//获取图片的指定宽度
            int intHeight = myBitmap.Height / 50; 								//获取图片的指定高度
            Graphics myGraphics = this.CreateGraphics(); 							//创建窗体的Graphics类
            myGraphics.Clear(Color.WhiteSmoke); 								//以指定的颜色清除
            Point[] myPoint = new Point[2500];									//定义数组
            for (int i = 0; i < 50; i++)										//获取指定区域图片的位置
            {
                for (int j = 0; j < 50; j++)
                {
                    myPoint[i * 50 + j].X = i * intWidth;
                    myPoint[i * 50 + j].Y = j * intHeight;
                }
            }
            Bitmap bitmap = new Bitmap(myBitmap.Width, myBitmap.Height);			//实例化Bitmap类
            for (int i = 0; i < 10000; i++)
            {
                Random rand = new Random();								//实例化Random类
                int intPos = rand.Next(2500);									//获取一个随机数
                for (int m = 0; m < intWidth; m++)
                {
                    for (int n = 0; n < intHeight; n++)
                    {
                        bitmap.SetPixel(myPoint[intPos].X + m, myPoint[intPos].Y + n, myBitmap.GetPixel(myPoint[intPos].X + m,
        myPoint[intPos].Y + n)); 						//通过调用Bitmap对象的SetPixel方法为图像的各像素点重新着色
                    }
                }
                this.Refresh();//工作区无效
                this.BackgroundImage = bitmap;								//显示处理后的图片
                for (int k = 0; k < 2500; k++)
                {
                    for (int m = 0; m < intWidth; m++)
                    {
                        for (int n = 0; n < intHeight; n++)
                        {
                            bitmap.SetPixel(myPoint[k].X + m, myPoint[k].Y + n, myBitmap.GetPixel(myPoint[k].X + m,
        myPoint[k].Y + n)); 					//通过调用Bitmap对象的SetPixel方法为图像的各像素点重新着色
                        }
                    }
                    this.Refresh(); //工作区无效
                    this.BackgroundImage = bitmap;							//显示处理后的图片
                }
            }
        }
    }
}