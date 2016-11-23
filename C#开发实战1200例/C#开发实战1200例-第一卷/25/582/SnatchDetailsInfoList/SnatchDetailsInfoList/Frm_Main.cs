using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace SnatchDetailsInfoList
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private WMPLib.WindowsMediaPlayerClass c;	//初始化一个媒体对象
        private WMPLib.IWMPMedia m;        	//建立媒体播放列表对象

        private void ButOpen_Click(object sender, EventArgs e)
        {
            this.optFile.ShowDialog();
        }
        //加载多媒体文件
        private void ButPlay_Click(object sender, EventArgs e)
        {
            this.axWindowsMediaPlayer1.URL = this.optFile.FileName;	//播放指定路径下的多媒体文件
        }
        private void ButStop_Click(object sender, EventArgs e)
        {
            this.axWindowsMediaPlayer1.Ctlcontrols.stop(); 			//停止多媒体文件的播放
        }
        private void ButPause_Click(object sender, EventArgs e)
        {
            if (this.ButPause.Text == "暂停(&A)") 					//当单击“暂停（&A）”键时
            {
                this.axWindowsMediaPlayer1.Ctlcontrols.pause(); 		//暂停多媒体文件的播放
                this.ButPause.Text = "继续(&A)"; 					//使Button按钮上的文本变为“继续（&A）”
            }
            else											//当单击的是“继续（&A）”按钮时
            {
                this.axWindowsMediaPlayer1.Ctlcontrols.play(); 		//播放多媒体文件
                this.ButPause.Text = "暂停(&A)"; 					//设置Button按钮上的文本变为“暂停（&A）”
            }
        }
        private void ButInfo_Click(object sender, EventArgs e)
        {
            if (this.optFile.FileName != "optFile")	//当打开文件的文件名不为“optFile”
            {
                c = new WMPLib.WindowsMediaPlayerClass(); 		//实例化WindowsMediaPlayerClass类的对象
                m = c.newMedia(this.optFile.FileName); 				//为IWMPMedia对象赋值
                //获取媒体详细信息
                MessageBox.Show("歌手名:" + m.getItemInfo("Author") + "\r\n" + "歌  名:" + m.getItemInfo("Title"));
            }
        }
    }
}