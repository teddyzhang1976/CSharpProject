using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace PostRunTask
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = string.Empty;//清空控件
            Process[] myProcesses = Process.GetProcesses();//获取当前进程数组
            foreach (Process myProcess in myProcesses)//遍历数组
            {
                if (myProcess.MainWindowTitle.Length > 0)//如果进程存在用户界面标题
                    //将界面标题添加到控件中
                    richTextBox1.Text += "任务名：" + myProcess.MainWindowTitle + "\n";
            }
        }
    }
}