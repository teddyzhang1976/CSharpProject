using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace LocalSoftWare
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                RegistryKey rkMain = Registry.LocalMachine;//定义注册表位置
                RegistryKey rkChild = rkMain.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");//打开注册表项
                string[] strSubKeyNames = rkChild.GetSubKeyNames();//获取所有子项
                foreach (string strItem in strSubKeyNames)//遍历所有子项
                {
                    if (strItem.Substring(0,1) != "{")//去掉系统自动生成的信息
                    {
                        listBox1.Items.Add(strItem);//将子项添加到ListBox控件中
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
