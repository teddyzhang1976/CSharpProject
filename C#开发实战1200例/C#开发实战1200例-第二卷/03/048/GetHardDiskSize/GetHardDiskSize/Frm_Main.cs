using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GetHardDiskSize
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            System.IO.DriveInfo[] drive = System.IO.DriveInfo.GetDrives();//获取所有驱动器
            for (int i = 0; i < drive.Length; i++)//遍历驱动器
            {
                comboBox1.Items.Add(drive[i].Name);//将驱动器添加到下拉列表中
            }
            comboBox1.SelectedIndex = 0;//设置下拉列表默认选择第一项
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                System.IO.DriveInfo[] drive = System.IO.DriveInfo.GetDrives();//获取所有驱动器
                for (int i = 0; i < drive.Length; i++)//遍历驱动器
                {
                    if (comboBox1.SelectedItem.ToString() == drive[i].Name)//判断遍历到的项是否与下拉列表中的项相同
                    {
                        label1.Text = "总空间：" + drive[i].TotalSize / 1024 / 1024 / 1024 + "G";//显示总空间
                        label2.Text = "剩余空间：" + drive[i].TotalFreeSpace / 1024 / 1024 / 1024 + "G";//显示剩余空间
                        label3.Text = "已用空间：" + (drive[i].TotalSize - drive[i].TotalFreeSpace) / 1024 / 1024 / 1024 + "G";//显示已用空间
                    }
                }
            }
            catch { }
        }
    }
}
