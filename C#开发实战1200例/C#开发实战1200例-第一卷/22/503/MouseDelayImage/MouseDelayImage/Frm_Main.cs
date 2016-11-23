using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;

namespace MouseDelayImage
{
    public partial class Frm_Main : Form
    {
        bool flag = false;//定义变量，用来标识鼠标是否移动
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            flag = false;
            pictureBox1.Location = new System.Drawing.Point(14, 8);
            openFileDialog1.Filter = "*.jpg,*.jpeg,*.bmp,*.gif,*.ico,*.png,*.tif,*.wmf|*.jpg;*.jpeg;*.bmp;*.gif;*.ico;*.png;*.tif;*.wmf";
            openFileDialog1.ShowDialog();
            Image myImage = System.Drawing.Image.FromFile(openFileDialog1.FileName);
            pictureBox1.Image = myImage;
        }

        private void Frm_Main_MouseMove(object sender, MouseEventArgs e)
        {
            if (flag)													//如果鼠标在窗体中移动
                pictureBox1.Location = new System.Drawing.Point(e.X, e.Y);			//定义PictureBox控件的坐标位置
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            flag = true;//将标识设置为true
        }
    }
}