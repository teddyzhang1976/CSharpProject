using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SimulateOperateMouse
{
    public partial class Frm_Main : Form
    {
        [DllImport("user32.dll")]
        //引入API函数mouse_event
        private static extern int mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        const int MOUSEEVENTF_MOVE = 0x0001;//表示鼠标移动
        const int MOUSEEVENTF_LEFTDOWN = 0x0002;//表示鼠标左键按下
        const int MOUSEEVENTF_LEFTUP = 0x0004;//表示鼠标左键松开

        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mouse_event(MOUSEEVENTF_MOVE, -20, -20, 0, 0);//模拟移动鼠标　
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);//第一次鼠标左键按下
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);//第一次鼠标左键松开
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);//第二次鼠标左键按下
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);//第二次鼠标左键松开
        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("您的鼠标发生了自动上移，并双击了窗体一次！");
        }
    }
}
