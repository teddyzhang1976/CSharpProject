using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace BassoRelievo
{
    public partial class Frm_Main : Form
    {
        Bitmap myBitmap;
        Image myImage;
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "*.jpg,*.jpeg,*.bmp|*.jpg;*.jpeg;*.bmp"; 		//设置文件的类型
            openFileDialog1.ShowDialog(); //打开文件对话框
            myImage = System.Drawing.Image.FromFile(openFileDialog1.FileName); 	//根据文件的路径实例化Image类
            myBitmap = new Bitmap(myImage);							//实例化Bitmap类
            this.BackgroundImage = myBitmap;	 							//显示打开的图片
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                myBitmap = new Bitmap(myImage); 						//实例化Bitmap类
                //遍历图片中的所有象素
                for (int i = 0; i < myBitmap.Width - 1; i++)
                {
                    for (int j = 0; j < myBitmap.Height - 1; j++)
                    {
                        Color Color1 = myBitmap.GetPixel(i, j);				//获取当前象素的颜色值
                        Color Color2 = myBitmap.GetPixel(i + 1, j + 1);			//获取斜点下象素的颜色值
                        int red = Math.Abs(Color1.R - Color2.R + 128);				//设置R色值
                        int green = Math.Abs(Color1.G - Color2.G + 128); 			//设置G色值
                        int blue = Math.Abs(Color1.B - Color2.B + 128); 			//设置B色值
                        //颜色处理
                        if (red > 255) red = 255;							//如果R色值大于255，将R色值设为255
                        if (red < 0) red = 0; 								//如果R色值小于0，将R色值设为0
                        if (green > 255) green = 255; 						//如果G色值大于255，将R色值设为255
                        if (green < 0) green = 0; 							//如果G色值小于0，将R色值设为0
                        if (blue > 255) blue = 255; 							//如果B色值大于255，将R色值设为255
                        if (blue < 0) blue = 0; 							//如果B色值小于0，将R色值设为0
                        //通过调用Bitmap对象的SetPixel方法为图像的像素点重新着色
                        myBitmap.SetPixel(i, j, Color.FromArgb(red, green, blue));
                    }
                }
                this.BackgroundImage = myBitmap;							//显示处理后的图片
            }
            catch { }
        }
    }
}