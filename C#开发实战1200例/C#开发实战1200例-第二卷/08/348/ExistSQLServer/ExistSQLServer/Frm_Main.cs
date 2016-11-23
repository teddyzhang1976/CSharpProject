using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceProcess;
namespace ExistSQLServer
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 判断是还存在SQL服务
        /// </summary>
        /// <returns></returns>
        public bool ExitSQL()
        {
            bool sqlFlag = false;//定义布尔类型变量
            ServiceController[] services =//得到系统服务集合
                ServiceController.GetServices();
            for (int i = 0; i < services.Length; i++)
            {
                if (services[i].DisplayName.ToString() == "MSSQLSERVER")
                    sqlFlag = true;//方法返回布尔值
            }
            return sqlFlag;//方法返回去布尔值
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ExitSQL())
            {
                label1.Text = "本地计算机中已经安装SQL软件";//显示字符串信息
            }
            else
            {
                label1.Text = "本地计算机中已经安装SQL软件";//显示字符串信息
            }
        }
    }
}
