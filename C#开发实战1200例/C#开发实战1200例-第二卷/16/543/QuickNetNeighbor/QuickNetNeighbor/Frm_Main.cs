using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace QuickNetNeighbor
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
                RegistryKey rkChild = rkMain.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\RemoteComputer\NameSpace");//定义网上邻居位置
                rkChild.DeleteSubKeyTree("{2227A280-3AEA-1069-A2DE-08002B30309D}");//删除子项
                rkChild.DeleteSubKeyTree("{D6277990-4C6A-11CF-8D87-00AA0060F5BF}");//删除子项
                MessageBox.Show("优化网上邻居显示成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
