using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;

namespace MaxMinImage
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
            openFileDialog1.ShowDialog();								//打开文件对话框
            myImage = System.Drawing.Image.FromFile(openFileDialog1.FileName);	//实例化myImage类
            pictureBox1.Image = myImage;								//显示图片
            pictureBox1.Height = myImage.Height;							//设置pictureBox1的高度
            pictureBox1.Width = myImage.Width; 							//设置pictureBox1的宽度
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Height = Convert.ToInt32(myImage.Height * Convert.ToSingle(textBox1.Text.Trim()));//设置高度
                pictureBox1.Width = Convert.ToInt32(myImage.Width * Convert.ToSingle(textBox1.Text.Trim()));//设置宽度
            }
            catch { }
        }
    }
}