using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ClearIEURls
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegistryKey rkBase = Registry.CurrentUser;//定位到CurrentUser注册表项
            //打开指定的注册表项
            RegistryKey rkChild = rkBase.OpenSubKey(@"Software\Microsoft\Internet Explorer\TypedURLs",true);
            String[] strValueNames = rkChild.GetValueNames();//获取所有的历史网址
            foreach (string strItem in strValueNames)//遍历获取到的历史网址
            {
                rkChild.DeleteValue(strItem);//删除遍历到的历史网址
            }
        }
    }
}
