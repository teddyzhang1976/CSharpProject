using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;

namespace GetYSDrivesPath
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();//清空列表
            SelectQuery selectQuery = new SelectQuery("select * from win32_logicaldisk");//从WMI中查询信息
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(selectQuery);//创建WMI管理对象
            foreach (ManagementObject disk in searcher.Get())//遍历查询到的信息
            {
                string DriveType;//定义一个变量，用来存储驱动器类型
                DriveType = disk["DriveType"].ToString();//获取驱动器类型
                if (DriveType == "4")//判断驱动器类型
                    listBox1.Items.Add(disk["Name"].ToString());//将驱动器添加到列表中
            }
        }
    }
}