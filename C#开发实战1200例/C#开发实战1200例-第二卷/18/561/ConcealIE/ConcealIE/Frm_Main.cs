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

namespace ConcealIE
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }


        public void RefreshSystem()
        {
            Process[] mprocess;//声明进程数组
            mprocess = Process.GetProcessesByName("explorer");//遍历所有正在运行的进程
            foreach (Process mp in mprocess)//遍历所有进程
            {
                mp.Kill();//杀死进程
            }
        }

        //获取操作系统版本
        private string GetOSProductVersion()
        {
            RegistryKey rkLocalMachine = Registry.LocalMachine;//定位LocalMachine注册表项
            //打开指定的注册表子项
            RegistryKey rkCurrentVersion = rkLocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");
            return rkCurrentVersion.GetValue("ProductName").ToString();//获得操作系统版本
        }

        //隐藏或显示IE
        private void ConcealOrShowIE(string strProductVersion,int intTag)
        {
            try
            {
                RegistryKey rkBase = Registry.CurrentUser;//定位到CurrentUser注册表项
                RegistryKey rkChild = null;//初始化一个注册表对象
                if (strProductVersion == "Microsoft Windows Server 2003")//如果操作系统是2003
                {
                     //创建新的注册表子项
                     rkChild = rkBase.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\HideDesktopIcons\ClassicStartMenu");
                }
                else if (strProductVersion == "Microsoft Windows XP")//如果操作系统是XP
                {
                    //创建新的注册表子项
                    rkChild = rkBase.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\HideDesktopIcons\NewStartPanel");
                }
                rkChild.SetValue("{871C5380-42A0-1069-A2EA-08002B30309D}", intTag, RegistryValueKind.DWord);//设置注册表值
                rkChild.Close();//关闭注册表对象
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string strProductVersion = GetOSProductVersion();//获取操作系统版本
            ConcealOrShowIE(strProductVersion, 1);//隐藏IE浏览器图标
            MessageBox.Show("隐藏IE浏览器图标成功！");
            RefreshSystem();//刷新窗体进程
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string strProductVersion = GetOSProductVersion();//获取操作系统版本
            ConcealOrShowIE(strProductVersion, 0);//显示IE浏览器图标
            MessageBox.Show("显示IE浏览器图标成功！");
            RefreshSystem();//刷新窗体进程
        }
    }
}
