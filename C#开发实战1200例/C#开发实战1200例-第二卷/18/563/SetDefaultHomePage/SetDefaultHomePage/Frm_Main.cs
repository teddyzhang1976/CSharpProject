using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.Win32;
namespace SetDefaultHomePage
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //定位注册表项位置
            RegistryKey reg = Registry.CurrentUser.CreateSubKey(@"SoftWare\Microsoft\Internet Explorer\Main");
            object strInfo = reg.GetValue("Start Page", "没有值");//获取当前IE主页
            this.textBox1.Text = (string)strInfo;//显示主页
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //定位注册表项位置
            RegistryKey reg = Registry.CurrentUser.CreateSubKey(@"SoftWare\Microsoft\Internet Explorer\Main");
            reg.SetValue("Start Page", this.textBox2.Text, RegistryValueKind.String);//设置新主页
            MessageBox.Show("IE 当前的默认页为\r\n" + this.textBox2.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //定位注册表项位置
            RegistryKey reg = Registry.CurrentUser.CreateSubKey(@"SoftWare\Microsoft\Internet Explorer\Main");
            reg.SetValue("Start Page", "about:blank", RegistryValueKind.String);//设置空白页
            MessageBox.Show("IE 当前的默认页为\r\n" + "空白页");
        }
    }
}