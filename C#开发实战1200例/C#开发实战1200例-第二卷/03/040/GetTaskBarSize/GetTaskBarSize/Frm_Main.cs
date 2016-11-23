using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace GetTaskBarSize
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        public static extern int FindWindow(string lpClassName, string lpWindowName);//声明API函数FindWindow

        [DllImport("user32.dll")]
        public static extern int GetWindowRect(int hwnd, ref Rectangle lpRect);//声明API函数GetWindowRect

        Rectangle myrect;

        private void button1_Click(object sender, EventArgs e)
        {
            if (GetWindowRect(FindWindow("Shell_TrayWnd", null), ref myrect) == 0)//获取任务栏尺寸
                return;
            else
            {
                textBox1.Text = Convert.ToString(myrect.Left);//左边界
                textBox2.Text = Convert.ToString(myrect.Top);//上边界
                textBox3.Text = Convert.ToString(myrect.Right);//右边界
                textBox4.Text = Convert.ToString(myrect.Bottom);//下边界
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}