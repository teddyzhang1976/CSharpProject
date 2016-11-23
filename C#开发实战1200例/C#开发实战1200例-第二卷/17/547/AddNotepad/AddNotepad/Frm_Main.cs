using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace AddNotepad
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
            RegistryKey rk = Registry.LocalMachine.CreateSubKey(@"software\Classes\*\shell\notepad");
            rk.SetValue("", "用记事本打开(&J)", RegistryValueKind.String);//添加“用记事本打开”注册表项
            //创建注册表项
            RegistryKey rkValue =Registry.LocalMachine.CreateSubKey(@"software\Classes\*\shell\notepad\command");
            rkValue.SetValue("", "notepad.exe %1", RegistryValueKind.String);//设置“用记事本打开”命令
            MessageBox.Show("设置成功！");
        }
    }
}
