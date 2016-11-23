using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ElectronAlbumShroudAegis
{
    public partial class Frm_Main : Form
    {
        int width=0, heigh=0;
        string strpath;
        public Frm_Main()
        {
            InitializeComponent();
           
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            strpath = Application.StartupPath + "\\Image";		//获取可执行文件的路径
            Cursor.Hide();			//隐藏当前鼠标指针
            this.timer1.Enabled = true; 	//启动timer1计时器
            width = this.Width;			//保存当前窗体的宽度
            heigh = this.Height;			//保存当前窗体的高度
            drowImage(); 			//绘制图片
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Interval = new Random().Next(500, 2000);	//设置Timer控件的Interval属性来控制图片更改的频率
            drowImage(); 								//绘制图片
        }

        private void drowImage()
        {
            Graphics myGraphics = this.CreateGraphics(); 			//实例化一个GDI+绘图图面类
            myGraphics.Clear(Color.Black);					//清空原有的绘图图面并以指定的背景色填充
            //实例化一个GDI+位图实例
            Bitmap myBitmap = new Bitmap(strpath + "\\" + new Random().Next(1, 5).ToString() + ".jpg");
            myGraphics.DrawImage(myBitmap, new Random().Next(0, width - myBitmap.Width), new Random().Next(0, heigh - myBitmap.Height));//绘制图片
        }

        private void Frm_Main_KeyDown(object sender, KeyEventArgs e)
        {
            ExitWindows();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            ExitWindows();
        }

        private void ExitWindows()
        {
            this.timer1.Enabled = false;
            Application.Exit();
        }
    }
}