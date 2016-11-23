using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;

namespace GetCPUInfo
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            ManagementClass mc = new ManagementClass("win32_processor");//创建ManagementClass对象
            ManagementObjectCollection moc = mc.GetInstances();//获取CPU信息
            foreach (ManagementObject mo in moc)
            {
                textBox1.Text = mo["processorid"].ToString();//获取CUP编号
            }
            ManagementObjectSearcher driveID = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");//查询CPU信息
            foreach (ManagementObject MyXianKa in driveID.Get())
            {
                textBox2.Text = MyXianKa["Manufacturer"].ToString();//获取CUP制造商名称
                textBox3.Text = MyXianKa["Version"].ToString();//获取CPU版本号
                textBox4.Text = MyXianKa["Name"].ToString();//获取CUP产品名称
            }
        }
    }
}
