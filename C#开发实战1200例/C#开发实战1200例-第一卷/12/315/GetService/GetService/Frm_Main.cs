using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.ServiceProcess;
namespace GetService
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //下面的示例使用 ServiceController 类检查IIS服务是否已停止。如果该服务已停止，此示例将启动该服务并等待服务状态设置为 Running。
            //此示例使用 ServiceController 组件在本地计算机上继续 IIS 管理服务
            //serviceController1.MachineName = ".";
            //serviceController1.ServiceName = "IISAdmin";//IIS 服务
        }
        //开启IIS服务的状态
        private void button1_Click(object sender, EventArgs e)
        {
            serviceController1.MachineName = ".";//设置此服务所在的计算机名称
            serviceController1.ServiceName = "IISAdmin";//设置服务名称
             if (serviceController1.Status == //判断服务状态
                 ServiceControllerStatus.Running)
            {
                MessageBox.Show(//弹出消息对话框
                    serviceController1.DisplayName + "  服务正在运行");
                Application.Exit();//退出应用程序
            }
            else
            {
                serviceController1.Start();//启动服务
                MessageBox.Show(//弹出消息对话框
                    serviceController1.DisplayName + "  服务已开启");
                Application.Exit();//退出应用程序
            }

        }
        //判断IIS服务的状态
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                serviceController1.MachineName = ".";//设置此服务所在的计算机名称
                serviceController1.ServiceName = "IISAdmin";//设置服务名称
                if (serviceController1.Status == //判断服务状态
                    ServiceControllerStatus.Running)
                {
                    MessageBox.Show(//弹出消息对话框
                        serviceController1.DisplayName + "  服务已开启");
                    btn_Stop.Enabled = true;//启用停止服务按钮
                    btn_Status.Enabled = false;//停用状态按钮
             
                }
                else
                {
                    MessageBox.Show(//弹出消息对话框
                        serviceController1.DisplayName + "服务已停止");
                    btn_Status.Enabled = false;//停用状态按钮
                    btn_Start.Enabled = true;//启用开始服务按钮
                 
                }
            }
            catch (Exception ee)//捕获异常
            { MessageBox.Show(ee.Message); }//弹出消息对话框

        }
  
        //停止IIS服务的状态
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                serviceController1.MachineName = ".";//设置此服务所在的计算机名称
                serviceController1.ServiceName = "IISAdmin";//设置服务名称
                if (serviceController1.CanStop)//判断是否可以停止服务
                {
                    serviceController1.Stop();//停止服务
                    MessageBox.Show(//弹出消息对话框
                        serviceController1.DisplayName + "服务已停止");
                    Application.Exit();//退出应用程序
                 }
                else
                {
                    MessageBox.Show(//弹出消息对话框
                        serviceController1.DisplayName + "不可以停止");
                    Application.Exit();//退出应用程序
                }
            }
            catch (Exception ee)//捕获异常
                { MessageBox.Show(ee.Message); }//弹出消息对话框
        }
    }
}