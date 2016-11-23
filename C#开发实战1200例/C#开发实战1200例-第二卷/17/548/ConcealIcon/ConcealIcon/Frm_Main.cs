using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;

namespace ConcealIcon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void RefreshSystem()//刷新窗体进程
        {
            Process[] mprocess;//创建进程数组对象
            mprocess = Process.GetProcessesByName("explorer");//获取正在运行的所有进程
            foreach (Process mp in mprocess)//遍历获取到的进程
            {
                mp.Kill();//关闭进程
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            RegistryKey mreg;//声明注册表对象
            mreg = Registry.ClassesRoot;//定位到ClassesRoot注册表项
            mreg = mreg.CreateSubKey("piffile");//为注册表创建子项
            mreg.DeleteValue("IsShortcut");//删除注册表中的指定值
            mreg.Close();//关闭注册表对象
            RegistryKey mreg1;//声明注册表对象
            mreg1 = Registry.ClassesRoot;//定位到ClassesRoot注册表项
            mreg1 = mreg1.CreateSubKey("lnkfile");//为注册表创建子项
            mreg1.DeleteValue("IsShortcut");//删除注册表中的指定值
            mreg1.Close();//关闭注册表对象
            if (MessageBox.Show("设置完毕") == DialogResult.OK)
            {
                RefreshSystem();
            }
        }
    }
}
