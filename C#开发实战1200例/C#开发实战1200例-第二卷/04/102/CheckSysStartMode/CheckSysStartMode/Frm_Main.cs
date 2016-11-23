using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CheckSysStartMode
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mode = SystemInformation.BootMode.ToString();//获取系统的启动模式
            string str = "当前系统的启动模式是：";//设置提示信息
            switch (mode)//switch语句判断启动模式
            {
                case "FailSafe"://如果获取的值为FailSafe
                    MessageBox.Show(str + "不带网络支持的安全模式");//说明是不带网络支持的安全模式
                    break;
                case "FailSafeWithNetwork"://如果获取的值为FailSafeWithNetwork
                    MessageBox.Show(str + "具有网络支持的安全模式");//说明是具有网络支持的安全模式
                    break;
                case "Normal"://如果获取的值为Normal
                    MessageBox.Show(str + "标准模式");//说明是标准模式
                    break;
            }
        }
    }
}