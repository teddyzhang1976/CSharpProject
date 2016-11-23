using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace LCRComputer
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll", EntryPoint = "ExitWindowsEx", CharSet = CharSet.Ansi)]
        private static extern int ExitWindowsEx(int uFlags, int dwReserved);

        private void button1_Click(object sender, EventArgs e)
        {
            ExitWindowsEx(0, 0);//注销计算机
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process myProcess = new System.Diagnostics.Process();
            myProcess.StartInfo.FileName = "cmd.exe";//启动cmd命令
            myProcess.StartInfo.UseShellExecute = false;//是否使用系统外壳程序启动进程
            myProcess.StartInfo.RedirectStandardInput = true;//是否从流中读取
            myProcess.StartInfo.RedirectStandardOutput = true;//是否写入流
            myProcess.StartInfo.RedirectStandardError = true;//是否将错误信息写入流
            myProcess.StartInfo.CreateNoWindow = true;//是否在新窗口中启动进程
            myProcess.Start();//启动进程
            myProcess.StandardInput.WriteLine("shutdown -s -t 0");//执行关机命令
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process myProcess = new System.Diagnostics.Process();
            myProcess.StartInfo.FileName = "cmd.exe";//启动cmd命令
            myProcess.StartInfo.UseShellExecute = false;//是否使用系统外壳程序启动进程
            myProcess.StartInfo.RedirectStandardInput = true;//是否从流中读取
            myProcess.StartInfo.RedirectStandardOutput = true;//是否写入流
            myProcess.StartInfo.RedirectStandardError = true;//是否将错误信息写入流
            myProcess.StartInfo.CreateNoWindow = true;//是否在新窗口中启动进程
            myProcess.Start();//启动进程
            myProcess.StandardInput.WriteLine("shutdown -r -t 0");//执行重启计算机命令
        }
    }
}