using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace FontForm
{
    public partial class Frm_Main : Form
    {
        Bitmap bit;//声明位图对象
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bit = new Bitmap("font.bmp");//从指定的图像初始化Bitmap类对象
            bit.MakeTransparent(Color.Blue);//使用默认的透明颜色对Bitmap位图透明
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawImage((Image)bit, new Point(0, 0));//在指定位置按指定大小绘制图片的指定部分
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();//关闭当前窗体
        }
    }
}