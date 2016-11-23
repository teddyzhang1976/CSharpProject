using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;

namespace GetHardDiskID
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            //创建ManagementObjectSearcher对象
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");
            String strHardDiskID = null;//存储磁盘序列号
            //调用ManagementObjectSearcher类的Get方法取得硬盘序列号
            foreach (ManagementObject mo in searcher.Get())
            {
                strHardDiskID = mo["SerialNumber"].ToString().Trim();//记录获得的磁盘序列号
                break;
            }
            label1.Text = "硬盘序列号: "+strHardDiskID;//显示硬盘序列号
        }
    }
}
