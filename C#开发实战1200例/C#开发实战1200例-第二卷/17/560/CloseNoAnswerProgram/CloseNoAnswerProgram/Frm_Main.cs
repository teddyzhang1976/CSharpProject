using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace CloseNoAnswerProgram
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistryKey rkBase = Registry.CurrentUser;//定位到CurrentUser子项
            RegistryKey rkChild = rkBase.CreateSubKey(@"Control Panel\Desktop");//创建注册表项
            rkChild.SetValue("AutoEndTasks", 1);//设置自动关闭停止响应的程序
            rkChild.Close();//关闭注册表对象
            MessageBox.Show("自动关闭成功！");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegistryKey rkBase = Registry.CurrentUser;//定位到CurrentUser子项
            RegistryKey rkChild = rkBase.CreateSubKey(@"Control Panel\Desktop");//创建注册表项
            rkChild.SetValue("AutoEndTasks", 0);//取消自动关闭停止响应的程序
            rkChild.Close();//关闭注册表对象
            MessageBox.Show("取消自动关闭成功！");
        }
    }
}
