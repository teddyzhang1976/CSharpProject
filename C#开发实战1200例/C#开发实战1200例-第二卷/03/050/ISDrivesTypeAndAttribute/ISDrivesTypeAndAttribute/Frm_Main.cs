using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ISDrivesTypeAndAttribute
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        string P_str_Info = "";//声明一个变量，用来记录驱动器信息
        private void Frm_Main_Load(object sender, EventArgs e)
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();//获取所有驱动器信息
            foreach (DriveInfo dir in allDrives)//遍历所有驱动器信息
            {
                P_str_Info += Environment.NewLine + "驱动器名称：" + dir.Name;//获取名称
                P_str_Info += Environment.NewLine + " 类型：" + dir.DriveType;//获取类型
                if (dir.IsReady == true)//判断是否准备好
                {
                    P_str_Info += Environment.NewLine + " 卷标：" + dir.VolumeLabel;//获取卷标
                    P_str_Info += Environment.NewLine + " 文件格式：" + dir.DriveFormat;//获取文件格式
                    P_str_Info += Environment.NewLine + " 可用空间总量：" + dir.TotalFreeSpace / 1024 / 1024 / 1024 + "G";//获取可用空间
                    P_str_Info += Environment.NewLine + " 驱动器空间大小：" + dir.TotalSize / 1024 / 1024 / 1024 + "G\n";//获取总空间
                }
            }
            label1.Text = P_str_Info;//将驱动器信息显示在Label控件中
        }
    }
}