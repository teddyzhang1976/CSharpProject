using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AddHyperLink
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            rtbox_HyperLink.AppendText(//向控件中添加文本信息
                @"明日科技：http://www.mingrisoft.com/
谷歌：http://www.google.cn/
网易：http://www.163.com/
百度：http://www.baidu.com/
CSDN：http://www.csdn.net/
腾讯：http://www.qq.com/
QQ书签：http://shuqian.qq.com/
QQ空间：http://qzone.qq.com/
校内网：http://www.xiaonei.com/");
        }

        private void rtbox_HyperLink_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(//使用IE打开指定网址
                "iexplore.exe", e.LinkText);
        }
    }
}
