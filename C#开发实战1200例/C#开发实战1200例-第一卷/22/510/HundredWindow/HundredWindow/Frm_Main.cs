using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace HundredWindow
{
    public partial class Frm_Main : Form
    {
        Image myImage;
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "*.jpg,*.jpeg,*.bmp|*.jpg;*.jpeg;*.bmp";		//设置文件的类型
            openFileDialog1.ShowDialog();								//打开文件对话框
            myImage = System.Drawing.Image.FromFile(openFileDialog1.FileName);	//根据文件的路径实例化Image类
            this.BackgroundImage = myImage;								//显示打开的图片
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap myBitmap = (Bitmap)this.BackgroundImage.Clone();		//用窗体背景的复本实例化Bitmap类
                int intWidth = myBitmap.Width;							//记录图片的宽度
                int intHeight = myBitmap.Height / 20;						//记录图片的指定高度
                Graphics myGraphics = this.CreateGraphics();				//创建窗体的Graphics类
                myGraphics.Clear(Color.WhiteSmoke);						//用指定的颜色清除窗体背景
                Point[] myPoint = new Point[30];							//定义数组
                for (int i = 0; i < 30; i++)									//记录百叶窗各节点的位置
                {
                    myPoint[i].X = 0;
                    myPoint[i].Y = i * intHeight;
                }
                Bitmap bitmap = new Bitmap(myBitmap.Width, myBitmap.Height);	//实例化Bitmap类
                //通过调用Bitmap对象的SetPixel方法重新设置图像的像素点颜色，从而实现百叶窗效果
                for (int m = 0; m < intHeight; m++)
                {
                    for (int n = 0; n < 20; n++)
                    {
                        for (int j = 0; j < intWidth; j++)
                        {
                            bitmap.SetPixel(myPoint[n].X + j, myPoint[n].Y + m, myBitmap.GetPixel(myPoint[n].X + j,myPoint[n].Y + m));//获取当前象素颜色值
                        }
                    }
                    this.Refresh();									//绘制无效
                    this.BackgroundImage = bitmap;						//显示百叶窗体的效果
                    System.Threading.Thread.Sleep(100);						//线程挂起
                }
            }
            catch { }
        }
    }
}