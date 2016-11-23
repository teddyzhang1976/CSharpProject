using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace StopRemoteAmendReg
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistryKey reg = Registry.LocalMachine;//获取HKEY_LOCAL_MACHINE基项
            reg = reg.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\SecurePipeServers\\winreg");//打开winreg子项
            reg.SetValue("RemoteRegAccess", 1, RegistryValueKind.DWord);//设置禁止远程修改
            reg.Close();//关闭该项
            MessageBox.Show("设置禁止成功！");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegistryKey reg = Registry.LocalMachine;//获取HKEY_LOCAL_MACHINE基项
            reg = reg.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\SecurePipeServers\\winreg");//打开winreg子项
            reg.SetValue("RemoteRegAccess", 0, RegistryValueKind.DWord);//设置允许远程修改
            reg.Close();//关闭该项
            MessageBox.Show("设置启用成功！");
        }
    }
}
