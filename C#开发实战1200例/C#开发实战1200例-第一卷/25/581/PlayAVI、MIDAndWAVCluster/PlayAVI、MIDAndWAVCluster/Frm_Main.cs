using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PlayAVIMIDAndWAVCluster
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
      
        private void 选取文件_Click(object sender, EventArgs e)
        {
            this.optFile.ShowDialog();//打开“打开”对话框
            this.axWindowsMediaPlayer1.newMedia(this.optFile.FileName);//加载选择的文件
        }

        private void 播放文件_Click(object sender, EventArgs e)
        {
            this.axWindowsMediaPlayer1.URL = this.optFile.FileName;//播放文件
        }

        private void 停止_Click(object sender, EventArgs e)
        {
            this.axWindowsMediaPlayer1.close();//停止播放
        }

        private void 退出_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}