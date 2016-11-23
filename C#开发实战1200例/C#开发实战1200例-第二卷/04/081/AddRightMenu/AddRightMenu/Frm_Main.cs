using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace AddRightMenu
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\Software\\Classes\\Directory\\Shell\\New Window", "", "在新窗口中打开");//添加右键菜单
            Registry.SetValue("HKEY_LOCAL_MACHINE\\Software\\Classes\\Directory\\Shell\\New Window\\Command", "", "exlorer.exe %1");//设置打开命令
            MessageBox.Show("右键菜单添加成功");
        }
    }
}
