using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.Win32;
namespace AmendIETitle
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //定位注册表项位置
            RegistryKey reg = Registry.CurrentUser.CreateSubKey(@"SoftWare\Microsoft\Internet Explorer\Main");
            reg.SetValue("Window Title", this.textBox1.Text, RegistryValueKind.String);//设置IE标题栏内容
            MessageBox.Show("修改成功");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //定位注册表项位置
            RegistryKey reg = Registry.CurrentUser.CreateSubKey(@"SoftWare\Microsoft\Internet Explorer\Main");
            reg.DeleteValue("Window Title", false);//恢复IE标题栏内容
            MessageBox.Show("恢复成功");
        }
    }
}