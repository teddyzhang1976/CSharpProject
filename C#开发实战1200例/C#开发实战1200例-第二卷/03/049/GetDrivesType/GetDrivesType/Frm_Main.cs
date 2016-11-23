using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GetDrivesType
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.IO.DriveInfo[] drive = System.IO.DriveInfo.GetDrives();//获取所有磁盘分区
            for (int i = 0; i < drive.Length; i++)//遍历所有磁盘分区
            {
                comboBox1.Items.Add(drive[i].Name);//将磁盘分区添加到下拉列表中
            }
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            System.IO.DriveInfo[] drive = System.IO.DriveInfo.GetDrives();//获取所有磁盘分区
            for (int i = 0; i < drive.Length; i++)//遍历所有磁盘分区
            {
                if (comboBox1.SelectedItem.ToString() == drive[i].Name)//判断遍历到的磁盘分区与下拉列表中的选择项相同
                {
                    if (drive[i].IsReady)//判断磁盘是否准备好
                        textBox1.Text = drive[i].DriveFormat;//获取磁盘的文件系统类型
                }
            }
        }
    }
}