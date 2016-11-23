using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;

namespace RGBValue
{
    public partial class Frm_Main : Form
    {
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
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Bitmap bmp = (Bitmap)pictureBox1.Image;//实例化Bitmap类
            try
            {
                Color pointColor = bmp.GetPixel(e.X, e.Y);						//获取当前象素的颜色值
                //分别通过调用Color对象的R、G、B属性获得指定点的R、G、B值
                textBox1.Text = pointColor.R.ToString();
                textBox2.Text = pointColor.G.ToString();
                textBox3.Text = pointColor.B.ToString();
            }
            catch { }
        }
    }
}