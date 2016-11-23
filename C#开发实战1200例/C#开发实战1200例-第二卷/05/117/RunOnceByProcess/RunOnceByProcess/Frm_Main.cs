using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace RunOnceByProcess
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            string moduleName = Process.GetCurrentProcess().MainModule.ModuleName; //获取当前活动进程的模块名称
            string processName = System.IO.Path.GetFileNameWithoutExtension(moduleName);//返回指定路径字符串的文件名
            Process[] processes = Process.GetProcessesByName(processName);//根据文件名创建进程资源数组
            if (processes.Length > 1)//如果该数组长度大于1，说明多次运行
            {
                MessageBox.Show("本程序一次只能运行一个实例！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);//弹出提示信息
                this.Close();//关闭当前窗体
            }
        }
    }
}