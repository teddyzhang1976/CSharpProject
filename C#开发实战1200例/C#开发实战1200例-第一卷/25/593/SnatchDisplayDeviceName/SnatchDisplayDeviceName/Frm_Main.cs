using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;

namespace SnatchDisplayDeviceName
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void snatch_Click(object sender,EventArgs e)
        {
            ManagementObjectSearcher FlashDevice = new ManagementObjectSearcher("select * from win32_VideoController");//声明一个用于检索设备管理信息的对象
            foreach(ManagementObject FlashDeviceObject in FlashDevice.Get())//循环遍历WMI实例中的每一个对象
            {
                printName.Text = FlashDeviceObject["name"].ToString();//在文本框中显示显示设备的名称
                aristotle.Text = FlashDeviceObject["PNPDeviceID"].ToString();//在文本框中显示显示设备的PNPDeviceID
            }
        }
    }
}
