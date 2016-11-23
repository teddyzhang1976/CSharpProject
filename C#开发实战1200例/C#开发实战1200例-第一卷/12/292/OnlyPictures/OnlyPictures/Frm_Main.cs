using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace OnlyPictures
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "*.jpg|*.jpg|*.bmp|*.bmp";//设置筛选字符串
            if (openFileDialog1.ShowDialog() == DialogResult.OK)//弹出打开文件对话框
            {
                pictureBox1.Image = //显示图像
                    Image.FromFile(openFileDialog1.FileName);
            }
        }
    }
}