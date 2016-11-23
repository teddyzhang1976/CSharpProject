using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace StopOpenAutoRun
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //定位注册表项
            RegistryKey rgK =Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");
            rgK.SetValue("NoRun", 1);//禁用“运行”功能
            MessageBox.Show("禁用“运行”成功");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //定位注册表项
            RegistryKey rgK =Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");
            rgK.SetValue("NoRun", 0);//启用“运行”功能
            MessageBox.Show("启用“运行”成功，请重新启动机器");
        }
    }
}
