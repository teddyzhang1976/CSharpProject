using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace StopClose
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
            rgK.SetValue("NoClose", 1);//屏蔽关机功能
            MessageBox.Show("屏蔽关机功能成功！");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //定位注册表项
            RegistryKey rgK =Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");
            rgK.SetValue("NoClose", 0);//开启关机功能
            MessageBox.Show("开启关机成功，请重新启动机器！");
        }
    }
}