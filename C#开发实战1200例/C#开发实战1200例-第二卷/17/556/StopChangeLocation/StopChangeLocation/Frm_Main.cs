using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;

namespace StopChangeLocation
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }



        public void RefreshSystem()
        {
            Process[] mprocess;
            mprocess = Process.GetProcessesByName("explorer");
            foreach (Process mp in mprocess)
            {
                mp.Kill();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //定位注册表项
            RegistryKey rgK =Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");
            rgK.SetValue("LockTaskbar", 1);//禁止改变任务栏位置
            MessageBox.Show("设置成功！");
            RefreshSystem();//刷新窗体进程
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //定位注册表项
            RegistryKey rgK =Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");
            rgK.SetValue("LockTaskbar", 0);//允许改变任务栏位置
            MessageBox.Show("设置成功！");
            RefreshSystem();//刷新窗体进程
        }
    }
}