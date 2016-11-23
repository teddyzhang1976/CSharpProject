using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace LevelInterleaving
{
    public partial class Frm_Main : Form
    {
        Bitmap myBitmap;
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "*.jpg,*.jpeg,*.bmp|*.jpg;*.jpeg;*.bmp"; 			//设置文件的类型
            openFileDialog1.ShowDialog(); 									//打开文件对话框
            Image myImage = System.Drawing.Image.FromFile(openFileDialog1.FileName);	//根据文件的路径实例化Image类
            myBitmap = new Bitmap(myImage);								//实例化Bitmap类
            this.BackgroundImage = myBitmap; 								//显示打开的图片
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int intWidth = this.BackgroundImage.Width;						//获取背景图片的宽度
                int intHeight = this.BackgroundImage.Height; 					//获取背景图片的高度
                Graphics myGraphics = this.CreateGraphics(); 					//创建窗体的Graphics类
                myGraphics.Clear(Color.WhiteSmoke); 							//以指定的颜色清除
                Bitmap bitmap = new Bitmap(intWidth, intHeight); 					//实例化Bitmap类
                int i = 0;
                //通过调用Bitmap对象的SetPixel方法实现水平交错效果显示图像
                while (i <= intWidth / 2)
                {
                    for (int m = 0; m <= intHeight - 1; m++)
                    {
                        bitmap.SetPixel(i, m, myBitmap.GetPixel(i, m));				//设置当前象素的颜色值
                    }
                    for (int n = 0; n <= intHeight - 1; n++)
                    {
                        bitmap.SetPixel(intWidth - i - 1, n, myBitmap.GetPixel(intWidth - i - 1, n));//设置当前象素的颜色值
                    }
                    i++;
                    this.Refresh();										//工作区无效
                    this.BackgroundImage = bitmap;							//显示水平交错的图片
                    System.Threading.Thread.Sleep(10);							//线程挂起
                }
            }
            catch { }
        }
    }
}