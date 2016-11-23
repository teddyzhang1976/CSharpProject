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

namespace ModifyDiskFormat
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
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
            DriveInfo DInfo = new DriveInfo(comboBox1.Text);//创建驱动器对象
            textBox1.Text = DInfo.DriveFormat;//显示磁盘格式
            if (textBox1.Text == "NTFS")//判断是否为NTFS格式
                button2.Enabled = false;//设置转换按钮不可用
            else if (textBox1.Text == "FAT32")//判断是否为FAT32格式
                button2.Enabled = true;//设置转换按钮可用
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();//创建进程对象
            process.StartInfo.FileName = "cmd.exe";//启动cmd命令
            process.StartInfo.Arguments = "/c convert " + textBox1.Text + " /fs:ntfs";//设置转换命令
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;//隐藏窗口
            process.StartInfo.UseShellExecute = false;//是否使用系统外壳程序启动进程
            process.StartInfo.RedirectStandardInput = true;//是否从流中读取
            process.StartInfo.RedirectStandardOutput = true;//是否写入流
            process.StartInfo.RedirectStandardError = true;//是否将错误信息写入流
            process.StartInfo.CreateNoWindow = true;//是否在新窗口中启动进程
            process.Start();//启动进程            
            process.WaitForExit();//执行完退出
        }
    }
}
