using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SnatchPlayTime
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void unfold_Click(object sender,EventArgs e)
        {
            OpenFileDialog MP3Dialog = new OpenFileDialog();//声明一个提示用户打开文件的对象
            MP3Dialog.Filter = "MP3文件(*.MP3)|*.MP3"; //获取或设置当前文件名筛选器字符串
            if(MP3Dialog.ShowDialog() == DialogResult.OK) //当选定文件之后单击“打开”按钮时
            {
                filePath.Text = MP3Dialog.FileName;//在文本框中显示打开文件的文件路径
                axWindowsMediaPlayer1.URL = MP3Dialog.FileName;//为WindowsMediaPlayer组件指定媒体
            }
        }

        private void snatch_Click(object sender,EventArgs e)
        {
            playTime.Text = GetFileTime(Convert.ToInt32(axWindowsMediaPlayer1.currentMedia.duration)*1000);//在文本框中显示歌曲的播放时间
        }

        #region  获取文件的播放时间，并按指定格式进行显示
        /// <summary>
        /// 获取文件的播放时间，并按指定格式进行显示
        /// </summary>
        /// <param Millisecond="int">毫秒数</param>
        public string GetFileTime(int Millisecond)
        {
            string Tem_Time = ""; //用来保存歌曲的播放时间
            double Tem_min = 0;  //用来保存歌曲播放的分钟部分
            double Tem_sec = 0;  //用来保存歌曲播放时间的秒
            double Tem_millisec = 0; //用来保存歌曲播放时间的毫秒
            Tem_min = Millisecond / 1000;//将当前时间转化为以秒为单位的数据类型
            Tem_min = Tem_min / 60.0; //将当前时间转化为以分为单位的数据类型
            Tem_sec = Tem_min - (int)Tem_min; //保存歌曲播放时间的小数部分（当以分为单位时）
            Tem_min = (int)Tem_min; //将double型变量Tem_min转化为int型变量
            Tem_sec = (60 * Tem_sec) / 100.0; //将获得的小数转化为以秒为单位的数据
            Tem_sec = (int)(Tem_sec * 100);//将数据类型转化为int型
            Tem_millisec = (int)((Millisecond - Tem_min * 60 * 1000 - Tem_sec * 1000) / 1000 * 100);//将歌曲播放的时间转换为以秒为单位存储
            if(Tem_min >= 100)//当Tem_min的值大于等于100时
            {
                Tem_Time = Tem_min.ToString("000") + ":" + Tem_sec.ToString("00");//设置时间的显示格式
            }
            else//当Tem_min的值小于100时
                Tem_Time = Tem_min.ToString("00") + ":" + Tem_sec.ToString("00"); //设置事件的显示格式
            return Tem_Time;//返回变量Tem_Time
        }
        #endregion

        private void filePath_TextChanged(object sender,EventArgs e)
        {
            if(filePath.Text != "" && filePath.Text != null)//当文本框中内容不为空且存在时
            {
                snatch.Enabled = true;//设置“获取”按钮为可用状态
            }
            else//当文本框中内容为空或这不存在时
            {
                snatch.Enabled = false;//设置“获取”按钮为不可用状态
            }
        }
    }
}
