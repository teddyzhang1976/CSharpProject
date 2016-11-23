using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;

namespace MouseMove
{
    public partial class Frm_Main : Form
    {
        bool flag = false;
        int x, y;
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //设置文件的类型
            openFileDialog1.Filter = "*.jpg,*.jpeg,*.bmp,*.gif,*.ico,*.png,*.tif,*.wmf|*.jpg;*.jpeg;*.bmp;*.gif;*.ico;*.png;*.tif;*.wmf";
            openFileDialog1.ShowDialog(); 									//打开文件对话框
            Image myImage = System.Drawing.Image.FromFile(openFileDialog1.FileName); 	//根据文件的路径实例化Image类
            pictureBox1.Image = myImage; 									//显示打开的图片
            pictureBox1.Height = myImage.Height;		//根据图片大小设置pictureBox1控件的高度
            pictureBox1.Width = myImage.Width; 		//根据图片大小设置pictureBox1控件的高度
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            flag = true;													//标识，鼠标按下
            x = e.X;													//记录鼠标的X坐标
            y = e.Y; 													//记录鼠标的Y坐标
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (flag)
            {
                //设置pictureBox1控件的位置
                pictureBox1.Left = pictureBox1.Left + (e.X - x);
                pictureBox1.Top = pictureBox1.Top + (e.Y - y);
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            flag = false;
        }
    }
}