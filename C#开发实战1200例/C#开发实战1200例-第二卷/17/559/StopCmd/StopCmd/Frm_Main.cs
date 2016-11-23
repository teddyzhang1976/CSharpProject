using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace StopCmd
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistryKey rkBase = Registry.CurrentUser;//定位到CurrentUser子项
            //创建注册表项
            RegistryKey rkChild = rkBase.CreateSubKey(@"Software\Policies\Microsoft\Windows\System");
            rkChild.SetValue("DisableCMD", 1);//禁用命令提示符
            rkChild.Close();//关闭注册表对象
            MessageBox.Show("禁止成功！");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegistryKey rkBase = Registry.CurrentUser;//定位到CurrentUser子项
            //创建注册表项
            RegistryKey rkChild = rkBase.CreateSubKey(@"Software\Policies\Microsoft\Windows\System");
            rkChild.SetValue("DisableCMD", 0);//启用命令提示符
            rkChild.Close();//关闭注册表对象
            MessageBox.Show("启用成功！");
        }
    }
}
