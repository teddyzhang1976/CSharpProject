using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.ServiceProcess;

namespace StartWindowsService
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ServiceController service = new ServiceController();//创建服务控制对象
            service.ServiceName = "Messenger";//启动Windows信史服务
            //判断当前服务状态
            if (service.Status == ServiceControllerStatus.Stopped)
            {
                try
                {
                    service.Start();// 启动服务
                    service.WaitForStatus(ServiceControllerStatus.Running);
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("不能启动该服务！");
                }
            }
        }
    }
}