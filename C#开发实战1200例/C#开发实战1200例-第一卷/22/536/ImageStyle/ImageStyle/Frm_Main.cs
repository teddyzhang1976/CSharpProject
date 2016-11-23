using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;

namespace ImageStyle
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
            textBox1.Text = openFileDialog1.FileName.Substring(openFileDialog1.FileName.LastIndexOf(".") + 1,
        openFileDialog1.FileName.Length - openFileDialog1.FileName.LastIndexOf(".") - 1);	//获取当前图片的扩展名
        }
    }
}