using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace HSDesktopIcon
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
            RegistryKey RKey=Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\HideDesktopIcons\\NewStartPanel");
            if (checkBox1.Checked)
                RKey.SetValue("{20D04FE0-3AEA-1069-A2D8-08002B30309D}", 1);//隐藏我的电脑
            if (checkBox2.Checked)
                RKey.SetValue("{59031a47-3f72-44a7-89c5-5595fe6b30ee}", 1);//隐藏我的文档
            if (checkBox3.Checked)
                RKey.SetValue("{F02C1A0D-BE21-4350-88B0-7367FC96EF3C}", 1);//隐藏网上邻居
            if (checkBox4.Checked)
                RKey.SetValue("{645FF040-5081-101B-9F08-00AA002F954E}", 1);//隐藏回收站
            if (checkBox5.Checked)
                RKey.SetValue("{5399E694-6CE5-4D6C-8FCE-1D8870FDCBA0}", 1);//隐藏控制面板
            MessageBox.Show("修改成功——请刷新桌面！");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //定位注册表项
            RegistryKey RKey = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\HideDesktopIcons\\NewStartPanel");
            if (checkBox1.Checked)
                RKey.SetValue("{20D04FE0-3AEA-1069-A2D8-08002B30309D}", 0);//显示我的电脑
            if (checkBox2.Checked)
                RKey.SetValue("{59031a47-3f72-44a7-89c5-5595fe6b30ee}", 0);//显示我的文档
            if (checkBox3.Checked)
                RKey.SetValue("{F02C1A0D-BE21-4350-88B0-7367FC96EF3C}", 0);//显示网上邻居
            if (checkBox4.Checked)
                RKey.SetValue("{645FF040-5081-101B-9F08-00AA002F954E}", 0);//显示回收站
            if (checkBox5.Checked)
                RKey.SetValue("{5399E694-6CE5-4D6C-8FCE-1D8870FDCBA0}", 0);//显示控制面板
            MessageBox.Show("修改成功——请刷新桌面！");
        }
    }
}
