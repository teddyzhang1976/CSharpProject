using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace StopTopic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //定位注册表项
            RegistryKey rgK =Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");
            rgK.SetValue("NoThemesTab", 1, RegistryValueKind.DWord);//禁用“主题”选项卡
            MessageBox.Show("禁用成功！");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //定位注册表项
            RegistryKey rgK =Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");
            rgK.SetValue("NoThemesTab", 0, RegistryValueKind.DWord);//启用“主题”选项卡
            MessageBox.Show("启用成功！");
        }
    }
}