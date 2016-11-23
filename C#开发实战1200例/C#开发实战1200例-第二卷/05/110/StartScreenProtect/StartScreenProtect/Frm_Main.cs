using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace StartScreenProtect
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_SCREENSAVE = 0xf140;

        [DllImport("user32.dll")]//声明API函数SendMessage用于发送消息
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        private void button1_Click(object sender, EventArgs e)
        {
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_SCREENSAVE, 0);//发送消息启动屏幕保护程序
        }
    }
}