using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TailorAnimation
{
    public partial class Frm_Main : Form
    {
        string strPath;
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            strPath = Application.StartupPath.Substring(0, Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf("\\")).LastIndexOf("\\"));			//截取图片所在的文件路径
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; 		//设置图片的显示类型
            pictureBox1.Image = Image.FromFile(strPath + @"\image\1.jpg");	//为pictureBox1设置显示的图片
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random r = new Random(); 								//声明一个随机类的对象
            pictureBox1.Image = Image.FromFile(strPath + @"\image\" + r.Next(1, 5) + ".jpg");	//为pictureBox1设置显示的图片
        }
    }
}