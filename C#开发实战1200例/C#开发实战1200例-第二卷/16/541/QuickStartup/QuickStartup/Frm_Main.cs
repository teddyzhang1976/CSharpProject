using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace QuickStartup
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
                RegistryKey rgK = Registry.CurrentUser.CreateSubKey(@"Control Panel\Desktop");//定位注册表位置
                rgK.SetValue("HungAppTimeout", 400);//设置开机速度
                rgK.SetValue("WaitToKillAppTimeout", 1000);//设置关机速度
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control", "HungAppTimeout", 400);//设置开机速度
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control", "WaitToKillServiceTimeout", 1000);//设置关机速度
                MessageBox.Show("修改成功--请重新启动计算机");
            }
            catch (Exception ey)
            {
                MessageBox.Show("该程序可以不适合您的操作系统");
            }
        }
    }
}
