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
namespace RelationFile
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        public void RefreshSystem()
        {
            Process[] mprocess;
            mprocess = Process.GetProcessesByName("explorer");//创建进程组件的数组，并将它们与共享“explorer”进程名称的所有进程资源关联。
            foreach (Process mp in mprocess)
            {
                mp.Kill();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string notepath = @"C:\WINDOWS\notepad.exe";//记事本应用程序路径
                string extName = ".ls";//要创建子项的名称
                string mtype = "我定义的类型";
                string mContent = "text/plain";
                RegistryKey mreg;
                mreg = Registry.ClassesRoot;//获取指定基项
                mreg = mreg.CreateSubKey(extName);//在指定基项下创建新子项“.ls”
                mreg.SetValue("", mtype);//设置.ls子项的“默认键”对应的值为“我定义的类型”
                mreg.SetValue("Content Type", mContent);//设置设置.ls子项的“Content Type键”对应的值为“text/plain”
                mreg = mreg.CreateSubKey("shell\\open\\command");//在.ls子项下创建新的子项“shell\\open\\command”
                mreg.SetValue("", notepath + " %1");//设置“shell\\open\\command”子项的“默认键”对应的值为“C:\WINDOWS\notepad.exe %1”
                mreg.Close();//关闭该项，如果该项的内容已修改，则将该项刷新到磁盘。
                if (MessageBox.Show("设置完毕") == DialogResult.OK)
                {
                    RefreshSystem();//刷新explorer进程
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegistryKey mreg;
            string extName = ".ls";//指定子项名
            mreg = Registry.ClassesRoot;//获取基项名
            mreg = mreg.CreateSubKey(extName+"\\shell\\open");//打开指定的子项,已进行读写
            mreg.DeleteSubKey("command");//删除指定子项
            mreg.Close();//关闭该项，如果该项的内容已修改，则将该项刷新到磁盘。
            if (MessageBox.Show("设置完毕") == DialogResult.OK)
            {
                RefreshSystem();//刷新explorer进程
            }
        }
    }
}
