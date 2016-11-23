using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace SearchEdit
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistryKey rkMain = Registry.LocalMachine.OpenSubKey("SOFTWARE", true);//打开HKEY_LOCAL_MACHINE\SOFTWARE子项
            SeachRegedit(rkMain, textBox1.Text);//搜索键值对
        }

        private void SeachRegedit(RegistryKey rkMain, string strChildItemName)
        {
            string[] subKeyNames;//表示被搜索项的所有子项名称的数组
            string[] subValueNames;//表示的所有值名称的数组
            RegistryKey rk = rkMain.OpenSubKey(strChildItemName, true);//检索指定的子项
            if (rk != null)
            {
                subValueNames = rk.GetValueNames();//获取被检索项包含的所有“键/值对”的键名
                foreach (string strValueName in subValueNames)//遍历数组
                {
                    this.listBox1.Items.Add(strValueName);//把每一个“键/值对”的键名添加到列表框中
                }
                subKeyNames = rk.GetSubKeyNames();//获取被搜索项的所有子项的名称
                foreach (string strSubKeyName in subKeyNames)//遍历子项
                {
                    SeachRegedit(rk, strSubKeyName);//递归调用SeachRegedit方法
                }
            }
        }
    }
}
