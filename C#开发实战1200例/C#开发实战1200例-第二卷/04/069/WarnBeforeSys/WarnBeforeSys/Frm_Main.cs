using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace WarnBeforeSys
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistryKey rkey = Registry.LocalMachine;//获取注册表中的LocalMachine节点
            RegistryKey rkeyInfo = rkey.CreateSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon");//创建注册表项
            rkeyInfo.SetValue("LegalNoticeCaption", textBox1.Text, RegistryValueKind.String);//设置键
            rkeyInfo.SetValue("LegalNoticeText", textBox2.Text, RegistryValueKind.String);//设置值
            MessageBox.Show("已完成设置，请重新启动计算机！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}