using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace HSStartButton
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private const int SW_HIDE = 0;
        private const int SW_SHOW = 5;

        [DllImport("user32.dll")]//寻找窗口列表中第一个符合指定条件的顶级窗口
        public static extern int FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]//在窗口列表中寻找与指定条件相符的第一个子窗口
        public static extern int FindWindowEx(int hWnd1, int hWnd2, string lpsz1, string lpsz2);

        [DllImport("user32.dll")]//控制窗口的可见性
        public static extern int ShowWindow(int hwnd, int nCmdShow);

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                ShowWindow(FindWindowEx(FindWindow("Shell_TrayWnd", null), 0, "Button", null), SW_HIDE);//隐藏开始按钮
            else if (radioButton2.Checked)
                ShowWindow(FindWindowEx(FindWindow("Shell_TrayWnd", null), 0, "Button", null), SW_SHOW);//显示开始按钮
        }
    }
}