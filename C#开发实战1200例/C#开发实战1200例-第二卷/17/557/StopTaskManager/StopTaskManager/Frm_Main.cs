using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;

namespace StopTaskManager
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
            RegistryKey rkBase;//声明注册表基项
            RegistryKey rkChild;//声明注册表子项
            rkBase = Registry.CurrentUser;//定位到CurrentUser子项
            //创建注册表项
            rkChild = rkBase.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
            rkChild.SetValue("DisableTaskMgr", 1);//设置注册表键值，以便禁用任务管理器
            rkChild.Close();//关闭注册表对象
            MessageBox.Show("禁止任务管理器成功!");
            RefreshSystem();//刷新窗体进程
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegistryKey rkBase;//声明注册表基项
            RegistryKey rkChild;//声明注册表子项
            rkBase = Registry.CurrentUser;//定位到CurrentUser子项
            //创建注册表项
            rkChild = rkBase.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
            rkChild.SetValue("DisableTaskMgr", 0);//设置注册表键值，以便启用任务管理器
            rkChild.Close();//关闭注册表对象
            MessageBox.Show("启用任务管理器成功!");
            RefreshSystem();//刷新窗体进程
        }
    }
}
