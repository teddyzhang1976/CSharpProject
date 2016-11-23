using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace MP3Player
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        //***********************
        private Point mouseOffset;//记录鼠标坐标
        private bool isMouseDown=false;//是否按下鼠标
        bool flag = false;//判断是播放还是打开选择窗口
        static bool MM = true;//记录是否静音
        //***********************
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        #region 移动无边框窗体
        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            int xOffset;
            int yOffset;
            if (e.Button == MouseButtons.Left)
            {
                xOffset = -e.X;
                yOffset = -e.Y;
                mouseOffset = new Point(xOffset, yOffset);
                isMouseDown = true;
            }
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseOffset.X, mouseOffset.Y);
                Location = mousePos;
            }
        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
            }
        }
        #endregion

        private void pictureBox4_Click(object sender, EventArgs e)//打开播放
        {
            if (!flag)
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    axWindowsMediaPlayer1.URL = openFileDialog1.FileName;
                    m = 1;
                    lblSongTitle.Text= " 歌曲名称：" + axWindowsMediaPlayer1.currentMedia.getItemInfo("Title");
                }
            }
            else
            {
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)//暂停
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
            flag = true;
        }

        private void pictureBox6_Click(object sender, EventArgs e)//停止
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            flag = false;
        }



        private void pictureBox7_Click(object sender, EventArgs e)//静音
        {
            if (MM)
            {
                pictureBox7.Image = (Image)Properties.Resources.音量按钮变色;
                axWindowsMediaPlayer1.settings.mute = true;
                MM = false;
            }
            else
            {
                pictureBox7.Image = (Image)Properties.Resources.音量按钮;
                axWindowsMediaPlayer1.settings.mute = false;
                MM = true;
            }
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.Image = (Image)Properties.Resources.播放按钮变;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Image = (Image)Properties.Resources.播放按钮;
        }

        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            pictureBox5.Image = (Image)Properties.Resources.暂停按钮变;
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.Image = (Image)Properties.Resources.暂停按钮;
        }

        private void pictureBox6_MouseEnter(object sender, EventArgs e)
        {
            pictureBox6.Image = (Image)Properties.Resources.停止按钮变;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.Image = (Image)Properties.Resources.停止按钮;
        }
        int m = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            int i =(int) axWindowsMediaPlayer1.playState;
            switch(i)
            {
                case 1: lblStauts.Text = "状态：停止"; break;
                case 2: lblStauts.Text = "状态：暂停"; break;
                case 3: lblStauts.Text = "状态：播放"; break;
                case 6: lblStauts.Text = "状态：正在缓冲"; break;
                case 9: lblStauts.Text = "状态：正在连接"; break;
                case 10: lblStauts.Text = "状态：准备就绪"; break;
            }
            lbljindu.Text = axWindowsMediaPlayer1.Ctlcontrols.currentPositionString;
            if (m == 1)
            {
                hScrollBar1.Maximum = (int)axWindowsMediaPlayer1.currentMedia.duration;
                hScrollBar1.Minimum = 0;
                hScrollBar1.Value = (int)axWindowsMediaPlayer1.Ctlcontrols.currentPosition;
                hScrollBar2.Value=axWindowsMediaPlayer1.settings.volume;
            }
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.currentPosition = e.NewValue;
        }

        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            axWindowsMediaPlayer1.settings.volume = e.NewValue;
        }
    }
}
