using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;

namespace CrossCursor
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        Image myImage;
        private void button1_Click(object sender, EventArgs e)
        {
            //设置文件的类型
            openFileDialog1.Filter = "*.jpg,*.jpeg,*.bmp,*.gif,*.ico,*.png,*.tif,*.wmf|*.jpg;*.jpeg;*.bmp;*.gif;*.ico;*.png;*.tif;*.wmf";
            openFileDialog1.ShowDialog(); 							//打开文件对话框
            myImage = System.Drawing.Image.FromFile(openFileDialog1.FileName); 	//根据文件的路径实例化Image类
            pictureBox1.Image = myImage; 							//显示打开的图片
            pictureBox1.Height = myImage.Height; 						//根据图片大小设置pictureBox1控件的高度
            pictureBox1.Width = myImage.Width; 						//根据图片大小设置pictureBox1控件的宽度
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Graphics myGraphics = pictureBox1.CreateGraphics();
            //通过调用Graphics对象的DrawLine方法实现鼠标十字定位功能
            myGraphics.DrawLine(new Pen(Color.Black, 1), new Point(e.X, 0), new Point(e.X, e.Y));
            myGraphics.DrawLine(new Pen(Color.Black, 1), new Point(e.X, e.Y), new Point(e.X, pictureBox1.Height - e.Y));
            myGraphics.DrawLine(new Pen(Color.Black, 1), new Point(0, e.Y), new Point(e.X, e.Y));
            myGraphics.DrawLine(new Pen(Color.Black, 1), new Point(e.X, e.Y), new Point(pictureBox1.Width - e.X, e.Y));
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox1.Image = myImage;						//显示原来的图片
            pictureBox1.Height = myImage.Height;					//设置控件的高度
            pictureBox1.Width = myImage.Width; 					//设置控件的宽度
        }
    }
}