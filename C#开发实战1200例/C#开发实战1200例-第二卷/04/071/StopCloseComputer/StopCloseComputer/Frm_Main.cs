using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StopCloseComputer
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        private int isClose = 0;//声明一个变量表示是否关机
        private const int WM_QUERYENDSESSION = 0x0011;//系统发送的关机命令
        protected override void WndProc(ref Message m)//此方法用于处理Windows消息
        {
            switch (m.Msg)//获取消息值
            {
                case WM_QUERYENDSESSION:
                    m.Result = (IntPtr)isClose;//为了响应消息处理，设置返回值
                    break;
                default://默认执行
                    base.WndProc(ref m);//重写此方法
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            isClose = 0;//使消息值等于0，实现禁止关机
            MessageBox.Show("禁止关闭计算机");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            isClose = 1;//使消息值等于1，实现允许关机
            MessageBox.Show("允许关闭计算机");
        }
    }
}
