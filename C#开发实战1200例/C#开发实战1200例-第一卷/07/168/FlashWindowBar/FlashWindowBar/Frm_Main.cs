using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace FlashWindowBar
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        //重写API函数，用来实现窗体标题栏闪烁功能
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool FlashWindow(IntPtr handle, bool bInvert);

        private void timer1_Tick(object sender, EventArgs e)
        {
            FlashWindow(this.Handle,true);//启用窗体闪烁函数
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;//启动计时器
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;//关闭计时器
        }
    }
}