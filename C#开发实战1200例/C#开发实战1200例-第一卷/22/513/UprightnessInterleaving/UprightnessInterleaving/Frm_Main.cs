using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;

namespace UprightnessInterleaving
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
            openFileDialog1.Filter = "*.jpg,*.jpeg,*.bmp|*.jpg;*.jpeg;*.bmp";			//设置文件的类型
            openFileDialog1.ShowDialog(); 									//打开文件对话框
            Image myImage = System.Drawing.Image.FromFile(openFileDialog1.FileName); 	//根据文件的路径实例化Image类
            myBitmap = new Bitmap(myImage);	 							//实例化Bitmap类
            this.BackgroundImage = myBitmap; 								//显示打开的图片
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int intWidth = this.BackgroundImage.Width;						//获取背景片的宽度
                int intHeight = this.BackgroundImage.Height;					//获取背景片的高度
                Graphics myGraphics = this.CreateGraphics(); 					//创建窗体的Graphics类
                myGraphics.Clear(Color.WhiteSmoke); 							//以指定的颜色清除
                Bitmap bitmap = new Bitmap(intWidth, intHeight); 					//实例化Bitmap类
                int i = 0;
                //通过调用Bitmap对象的SetPixel方法实现垂直交错效果显示图像
                while (i <= intHeight / 2)
                {
                    for (int m = 0; m <= intWidth - 1; m++)
                    {
                        bitmap.SetPixel(m, i, myBitmap.GetPixel(m, i));				//设置当前象素的颜色值
                    }
                    for (int n = 0; n <= intWidth - 1; n++)
                    {
                        bitmap.SetPixel(n, intHeight - i - 1, myBitmap.GetPixel(n, intHeight - i - 1)); //设置当前象素的颜色值
                    }
                    i++;
                    this.Refresh();										//工作区无效
                    this.BackgroundImage = bitmap; 							//显示垂直交错的图片
                    System.Threading.Thread.Sleep(10);							//线程挂起
                }
            }
            catch { }
        }
    }
}