using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SongPlayShroudAegis
{
    public partial class Frm_Main : Form
    {
        int width = 0, heigh = 0;
        string strpath;
        public Frm_Main()
        {
            InitializeComponent();
            strpath = Application.StartupPath + "\\music";
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            this.timer1.Enabled = true;
            width = this.Width;
            heigh = this.Height;
          
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            ExitWindows();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                drowInfo(); 										//绘制屏保信息
                this.timer1.Interval = new Random().Next(800, 1600); 		//设置timer1的时间间隔
                string strname = new Random().Next(1, 4).ToString(); 		//记录随机数
                //当播放器处于空或者已停止时
                if (this.axWindowsMediaPlayer1.status == "" || this.axWindowsMediaPlayer1.status == "已停止")
                {
                    string strUrl = strpath + "\\" + strname + ".mp3";	//获取多媒体文件所处的路径
                    this.axWindowsMediaPlayer1.URL = strUrl; 	//设置播放文件的URL
                }
            }
            catch (Exception ex) 							//捕获异常
            {
                timer1.Enabled = false; 						//关闭计时器timer1
                MessageBox.Show(ex.Message); 				//弹出异常信息提示
            }
        }

        private void drowInfo()
        {
            Graphics myGraphics = this.CreateGraphics(); 			//实例化一个GDI+绘图图面类
            myGraphics.Clear(Color.Black);					//清空原有绘图面并以指定的背景色填充
            string strinfo = "歌曲播放屏幕保护";				//保存显示信息
            int x = new Random().Next(0, width - 250); 			//设置显示地点的X坐标
            int y = new Random().Next(50, heigh - 20); 			//设置显示地点的Y坐标
            myGraphics.DrawString(strinfo, new Font("华文形楷", 72, FontStyle.Bold), new SolidBrush(Color.FromArgb(new Random().Next(50, 255), new Random().Next(70, 255), new Random().Next(36, 255))), x, y); 	//绘制内容
        }

        private void ExitWindows()
        {
            this.timer1.Enabled = false;
            Application.Exit();
        }

    }
}