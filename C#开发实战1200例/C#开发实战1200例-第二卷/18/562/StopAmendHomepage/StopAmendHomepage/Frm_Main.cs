using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace StopAmendHomepage
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //创建注册表项
            RegistryKey reg = Registry.CurrentUser.CreateSubKey(@"SoftWare\Policies\Microsoft\Internet Explorer\Control Panel");
            reg.SetValue("HomePage", 1, RegistryValueKind.DWord);//设置HomePage键值为1，以便禁止修改IE主页
            MessageBox.Show("禁止修改IE主页设置成功");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //创建注册表项
            RegistryKey reg = Registry.CurrentUser.CreateSubKey(@"SoftWare\Policies\Microsoft\Internet Explorer\Control Panel");
            reg.SetValue("HomePage", 0, RegistryValueKind.DWord);//设置HomePage键值为0，以便允许修改IE主页
            MessageBox.Show("启用IE主页设置成功");
        }
    }
}
