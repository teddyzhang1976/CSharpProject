using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace DelProperty
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
            rgK.SetValue("NoPropertiesMyComputer", 1, RegistryValueKind.DWord);//删除“我的电脑”菜单中的“属性”菜单
            MessageBox.Show("删除“属性”功能成功！");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //定位注册表项
            RegistryKey rgK =Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");
            rgK.SetValue("NoPropertiesMyComputer", 0, RegistryValueKind.DWord);//恢复“我的电脑”菜单中的“属性”菜单
            MessageBox.Show(("恢复“属性”功能成功！"));
        }
    }
}