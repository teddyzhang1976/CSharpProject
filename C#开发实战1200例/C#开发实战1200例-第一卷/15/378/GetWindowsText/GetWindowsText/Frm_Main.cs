using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace GetWindowsText
{
    public partial class Frm_Main : Form
    {
        const int GW_HWNDNEXT = 2;//API参数：获取下一个同级窗口句柄
        public Frm_Main()
        {
            InitializeComponent();
        }

        private  void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();									//清空richTextBox1控件
            StringBuilder text = new StringBuilder(2560);					//实例化StringBuilder类
            IntPtr currentHandle;									//定义变量
            currentHandle = GetWindow(this.Handle, GW_HWNDNEXT);		//获得窗体句柄
            int v = GetWindowText(currentHandle, text, 2560);			//获得窗体文字
            richTextBox1.Text = text.ToString();						//显示窗体文字
        }
        [DllImportAttribute("user32.dll")]
        private static extern int GetWindowText(IntPtr handle, StringBuilder Text, int MaxCount);
        [DllImportAttribute("user32.dll")]
        private static extern IntPtr GetWindow(IntPtr handle,int ucmd);

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}