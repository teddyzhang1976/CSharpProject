using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;

namespace SnatchVoiceDeviceName
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void snatch_Click(object sender,EventArgs e)
        {
            ManagementObjectSearcher VoiceDeviceSearcher = new ManagementObjectSearcher("select * from Win32_SoundDevice");//声明一个用于检索设备管理信息的对象
            foreach(ManagementObject VoiceDeviceObject in VoiceDeviceSearcher.Get())//循环遍历WMI实例中的每一个对象
            {
                VoiceDeviceName.Text = VoiceDeviceObject["ProductName"].ToString(); //在当前文本框中显示声音设备的名称
                aristotle.Text = VoiceDeviceObject["PNPDeviceID"].ToString();//在当前文本框中显示声音设备的PNPDeviceID
            }
            snatch.Enabled = false;//设置“获取”按钮为不可用状态
        }
    }
}
