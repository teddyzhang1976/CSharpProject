using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClockingPlayImplement
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //当当前的时间与文本框中的内容一致时
            if (DateTime.Now.ToShortTimeString() == this.textBox2.Text.Trim().ToString())
            {
                this.axWindowsMediaPlayer1.URL = this.textBox1.Text; 		//设置音乐文件的播放路径
                this.axWindowsMediaPlayer1.Ctlcontrols.play(); 			//播放多媒体文件
                this.timer1.Enabled = false; 		//关闭timer1计时器
                this.timer2.Enabled = true; 		//启动timer2计时器
                this.timer2.Interval = 1000; 		//设置timer2计时器的Tick事件间隔为1s
                this.Show(); 				//显示该窗体
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.timer1.Enabled = true;
            this.Hide();
            this.ShowInTaskbar = false;//不在任务栏显现
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.textBox1.Text = this.openFileDialog1.FileName;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (this.axWindowsMediaPlayer1.status != "正在播放")			//当多媒体处于正在播放的状态时
            {
                this.timer2.Enabled = false; 		//关闭timer2计时器
                MessageBox.Show("本次播放已完成，谢谢使用！！！");		//弹出信息提示
            }
        }
    }
}