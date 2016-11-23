using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace ImageBlowUp
{
    public partial class Frm_Main : Form
    {
        Cursor myCursor = new Cursor(@"C:\WINDOWS\Cursors\cross_r.cur"); //自定义鼠标 
        Image myImage; 
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //设置文件的类型
            openFileDialog1.Filter = "*.jpg,*.jpeg,*.bmp,*.gif,*.ico,*.png,*.tif,*.wmf|*.jpg;*.jpeg;*.bmp;*.gif;*.ico;*.png;*.tif;*.wmf";
            openFileDialog1.ShowDialog();								//打开文件对话框
            myImage = System.Drawing.Image.FromFile(openFileDialog1.FileName);	//根据文件的路径和名称实例化Image类
            pictureBox1.Image = myImage;								//显示图片
            pictureBox1.Height = myImage.Height;							//设置控件的高度
            pictureBox1.Width = myImage.Width;							//设置控件的宽度
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                Cursor.Current = myCursor;								//定义鼠标
                Graphics graphics = pictureBox1.CreateGraphics();				//实例化pictureBox1控件的Graphics类
                //声明两个Rectangle对象，分别用来指定要放大的区域和放大后的区域
                Rectangle sourceRectangle = new Rectangle(e.X - 10, e.Y - 10, 20, 20);	//要放大的区域 
                Rectangle destRectangle = new Rectangle(e.X - 20, e.Y - 20, 40, 40);
                //调用DrawImage方法对选定区域进行重新绘制，以放大该部分
                graphics.DrawImage(myImage, destRectangle, sourceRectangle, GraphicsUnit.Pixel);
            }
            catch { }
        }
    }
}