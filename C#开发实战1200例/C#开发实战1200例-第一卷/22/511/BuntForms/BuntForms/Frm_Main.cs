using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace BuntForms
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
                Graphics myGraphics = this.CreateGraphics();				//创建窗体的Graphics类
                Bitmap myBitmap = new Bitmap(myImage);					//实例化Bitmap类
                myGraphics.Clear(this.BackColor);							//以指定的颜色清除
                for (int i = 0; i < this.Height; i++)							//从上到下遍历图片
                {
                    Rectangle rectangle1 = new Rectangle(0, 0, this.Width, i);		//获取图片指定行的象素
                    Rectangle rectangle2 = new Rectangle(0, this.Height - i, this.Width, i + 1);	//获取图片当行区域的以下区域
                    //通过调用Bitmap对象的Clone方法和DrawImage方法实现图像的推拉效果
                    Bitmap cloneBitmap = myBitmap.Clone(rectangle2, PixelFormat.DontCare);
                    myGraphics.DrawImage(cloneBitmap, rectangle1);			//绘制指定大小的图片
                    this.Show();
                }
            }
            catch { }
        }
    }
}