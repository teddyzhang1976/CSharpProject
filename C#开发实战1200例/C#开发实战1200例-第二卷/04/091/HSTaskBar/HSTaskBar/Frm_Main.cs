using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace HSTaskBar
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private const int SW_HIDE = 0;
        private const int SW_RESTORE = 9;

        [DllImport("user32.dll")]//寻找窗口列表中第一个符合指定条件的顶级窗口
        public static extern int FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]//控制窗口的可见性
        public static extern int ShowWindow(int hwnd, int nCmdShow);

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                ShowWindow(FindWindow("Shell_TrayWnd", null), SW_HIDE);//隐藏任务栏
            else if (radioButton2.Checked)
                ShowWindow(FindWindow("Shell_TrayWnd", null), SW_RESTORE);//显示任务栏
        }
    }
}