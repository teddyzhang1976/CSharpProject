using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WatchClipBoard
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;//设置计时器间隔为1000毫秒
            timer1.Start();//启动计时器
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())//判断剪贴板中是否存在文本数据
                richTextBox1.Text = Clipboard.GetText();//将剪贴板中的内容显示在richTextBox1控件中
        }
    }
}
