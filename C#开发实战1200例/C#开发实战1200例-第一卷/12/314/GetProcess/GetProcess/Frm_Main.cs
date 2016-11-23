using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace GetProcess
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            process1.StartInfo.FileName = "notepad.exe";//设置将要启动的应用程序
        }

        private void button1_Click(object sender, EventArgs e)
        {
            process1.Start();//启动应用程序
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process[] myProcesses;//创建进程集合变量
            myProcesses = System.Diagnostics.Process.GetProcessesByName("Notepad");//得到进程集合
            foreach (System.Diagnostics.Process instance in myProcesses)//遍历进程集合
            {
                instance.CloseMainWindow();//向进程主窗体发送关闭消息
                instance.WaitForExit(3000);//在指定时间内等待进程退出
                instance.Close();//释放与此进程关联的所有资源
            }
        }
    }
}