using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Management;

namespace ModifyDefaultPrinter
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            try
            {
                ManagementObjectSearcher query = new ManagementObjectSearcher("SELECT * FROM Win32_Printer");//查找打印设备
                ManagementObjectCollection queryCollection = query.Get();//获取查找到的打印设备
                foreach (ManagementObject mo in queryCollection)//遍历查找到的打印设备
                {
                    if (string.Compare(mo["Name"].ToString(), "PrinterName", true) == 0)//判断默认的打印设备是否为PrinterName
                    {
                        mo.InvokeMethod("SetDefaultPrinter", null);//设置默认打印设备
                        break;
                    }
                }
            }
            catch
            {
                MessageBox.Show("请首先启动本机的打印服务！");
            }
        }
    }
}