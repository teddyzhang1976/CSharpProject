using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace AmendIEAutoComplete
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //创建或者打开指定的注册表项
            RegistryKey rgK =Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\AutoComplete");
            rgK.SetValue("AutoSuggest", "yes", RegistryValueKind.String);//设置IE地址栏的自动完成功能
            MessageBox.Show("设置成功！");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //创建或者打开指定的注册表项
            RegistryKey rgK =Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\AutoComplete");
            rgK.SetValue("AutoSuggest", "no", RegistryValueKind.String);//取消IE地址栏的自动完成功能
            MessageBox.Show("取消成功！");
        }
    }
}