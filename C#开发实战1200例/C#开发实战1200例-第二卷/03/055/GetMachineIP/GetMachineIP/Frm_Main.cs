using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GetMachineIP
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string s = "";//定义一个变量，用来记录IP地址
            System.Net.IPAddress[] addressList = System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName()).AddressList;//获取IP地址列表
            for (int i = 0; i < addressList.Length; i++)//遍历IP地址列表
            {
                s += addressList[i].ToString() + "\n";//获得遍历到的IP地址
            }
            textBox1.Text = s;//显示IP地址
        }
    }
}