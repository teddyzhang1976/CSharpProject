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


namespace StopScreenEgis
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
            RegistryKey mreg;//声明注册表对象
            mreg = Registry.CurrentUser;//定位到CurrentUser子项
            //创建注册表项
            mreg = mreg.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
            mreg.SetValue("NoDispScrSavPage", 1);//禁用“屏幕保护”选项卡
            mreg.Close();//关闭注册表对象
            if (MessageBox.Show("设置完毕") == DialogResult.OK)
            {
                RefreshSystem();//刷新窗体进程
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegistryKey mreg;//声明注册表对象
            mreg = Registry.CurrentUser;//定位到CurrentUser子项
            //创建注册表项
            mreg = mreg.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
            mreg.SetValue("NoDispScrSavPage", 0);//启用“屏幕保护”选项卡
            mreg.Close();//关闭注册表对象
            if (MessageBox.Show("设置完毕") == DialogResult.OK)
            {
                RefreshSystem();//刷新窗体进程
            }
        }

    }
}
