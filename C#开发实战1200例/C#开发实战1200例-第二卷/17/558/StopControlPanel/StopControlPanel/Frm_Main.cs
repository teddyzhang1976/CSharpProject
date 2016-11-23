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

namespace StopControlPanel
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
            RegistryKey rkMain = Registry.CurrentUser;//定位到CurrentUser子项
            //创建注册表项
            RegistryKey rkChild = rkMain.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Uninstall");
            rkChild.SetValue("NoRemovePage", 1);//禁用添加删除程序
            rkChild.Close();//关闭注册表对象
            MessageBox.Show("禁止使用添加删除程序成功！");
            RefreshSystem();//刷新窗体进程
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegistryKey rkMain = Registry.CurrentUser;//定位到CurrentUser子项
            //创建注册表项
            RegistryKey rkChild = rkMain.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Uninstall");
            rkChild.SetValue("NoRemovePage", 0);//启用添加删除程序
            rkChild.Close();//关闭注册表对象
            MessageBox.Show("启用添加删除程序成功！");
            RefreshSystem();//刷新窗体进程
        }
    }
}
