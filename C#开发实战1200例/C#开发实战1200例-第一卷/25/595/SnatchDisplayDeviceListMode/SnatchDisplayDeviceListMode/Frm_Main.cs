using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;

namespace SnatchDisplayDeviceListMode
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void snatch_Click(object sender,EventArgs e)
        {
            ManagementObjectSearcher ListModeSearcher = new ManagementObjectSearcher("select * from Win32_VideoController");//声明一个用于检索设备管理信息的对象
            foreach(ManagementObject ListModeObject in ListModeSearcher.Get()) //循环遍历WMI实例中的每一个对象
            {
                unhideMode.Text = ListModeObject["VideoModeDescription"].ToString(); //显示设备的当前显示模式
            }
            snatch.Enabled = false;//设定“获取”按钮为不可用状态
        }
    }
}
