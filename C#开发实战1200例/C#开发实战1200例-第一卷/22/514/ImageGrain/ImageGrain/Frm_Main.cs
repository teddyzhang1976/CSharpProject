using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace ImageGrain
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
            myBitmap = new Bitmap(myImage);								//实例化Bitmap类
            this.BackgroundImage = myBitmap; 								//显示打开的图片
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Image myImage = System.Drawing.Image.FromFile(openFileDialog1.FileName);//实例化Image类
                myBitmap = new Bitmap(myImage); 							//实例化Bitmap类
                Rectangle rect = new Rectangle(0, 0, myBitmap.Width, myBitmap.Height);	//实例化Rectangle类
                System.Drawing.Imaging.BitmapData bmpData = myBitmap.LockBits(rect,
        System.Drawing.Imaging.ImageLockMode.ReadWrite, myBitmap.PixelFormat); 		//将指定图像锁定到内存中
                IntPtr ptr = bmpData.Scan0; 								//获得图像中第一个像素数据的地址
                int bytes = myBitmap.Width * myBitmap.Height * 3;			//设置大小
                byte[] rgbValues = new byte[bytes];//实例化byte数组
                System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes); //使用RGB值为声明的rgbValues数组赋值
                for (int counter = 0; counter < rgbValues.Length; counter += 3)		//初始化大小
                    rgbValues[counter] = 255;
                System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes); //使用RGB值为图像的像素点着色
                myBitmap.UnlockBits(bmpData); 							//从内存中解锁图像
                this.BackgroundImage = myBitmap;							//显示设置后的图片
            }
            catch { }
        }
    }
}