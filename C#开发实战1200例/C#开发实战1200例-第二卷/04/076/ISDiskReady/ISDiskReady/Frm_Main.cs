using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;
using System.IO;

namespace ISDiskReady
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SelectQuery selectQuery = new SelectQuery("select * from win32_logicaldisk");//查询磁盘信息
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(selectQuery);//创建WMI查询对象
            foreach (ManagementObject disk in searcher.Get())//遍历所有磁盘
            {
                comboBox1.Items.Add(disk["Name"].ToString());//将磁盘名称添加到下拉列表中
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DriveInfo dinfo = new DriveInfo(comboBox1.Text);//创建DriveInfo对象
            if (dinfo.IsReady)//判断磁盘是否准备好
                label2.Text = "该磁盘已经准备好";//如果准备好则弹出提示
            else//否则
                label2.Text = "该磁盘未准备好";//通知磁盘未准备好
        }
    }
}