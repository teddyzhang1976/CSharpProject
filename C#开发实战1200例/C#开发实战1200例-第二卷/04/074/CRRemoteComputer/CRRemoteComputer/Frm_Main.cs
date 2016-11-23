using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Management;

namespace CRRemoteComputer
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CloseComputer("Shutdown");//远程关闭计算机
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CloseComputer("Reboot");//远程重启计算机
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && textBox1.Text != "")
                textBox2.Focus();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && textBox2.Text != "")
                button1.Focus();
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        #region 关闭或重启远程计算机
        /// <summary>
        /// 关闭或重启远程计算机
        /// </summary>
        /// <param name="doinfo">要执行的操作命令</param>
        private void CloseComputer(string doinfo)
        {
            ConnectionOptions op = new ConnectionOptions();//创建ConnectionOptions对象
            op.Username = textBox4.Text;//设置远程机器用户名
            op.Password = textBox3.Text;//设置远程机器登录密码
            //创建ManagementScope对象
            ManagementScope scope = new ManagementScope("\\\\" + textBox2.Text + "\\root\\cimv2:Win32_Service", op);
            try
            {
                scope.Connect();//连接远程对象
                ObjectQuery oq = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");//实例化ObjectQuery对象
                //创建ManagementObjectSearcher对象
                ManagementObjectSearcher query1 = new ManagementObjectSearcher(scope, oq);
                ManagementObjectCollection queryCollection1 = query1.Get();//得到WMI控制
                foreach (ManagementObject mobj in queryCollection1)
                {
                    string[] str = { "" };
                    mobj.InvokeMethod(doinfo, str);
                }
            }
            catch (Exception ey)
            {
                MessageBox.Show(ey.Message);
            }
        }
        #endregion
    }
}
