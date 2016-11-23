using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace AsynchronismLoadPlayVoice
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 本实例需引用命名空间using System.Media
        /// </summary>
        private void unfold_Click(object sender,EventArgs e)
        {
            OpenFileDialog VoiceDialog = new OpenFileDialog();//声明一个提示用户打开文件的对象
            VoiceDialog.ShowDialog(); //用默认的所有者运行通用对话框。 （继承自 CommonDialog。）
            path.Text = VoiceDialog.FileName; //将文件的路径保存在文本框中
        }

        private void play_Click(object sender,EventArgs e)
        {
            try
            {
                SoundPlayer player = new SoundPlayer(); //声明一个控制WAV文件的声音播放文件对象
                player.SoundLocation = path.Text; //指定声音文件的路径
                player.LoadAsync();  //设置播放的方法
                player.Play(); //播放声音文件
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void path_TextChanged(object sender,EventArgs e)
        {
            if(path.Text != null && path.Text != "")//当文本框中的内容为空或不存在时
            {
                play.Enabled = true;//设置“播放”按钮为可用状态
            }
            else                                   //当文本框中的内容为空或不存在时
            {
                play.Enabled = false;//设置“播放”按钮为不可用状态
            }
        }
    }
}
