using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FileMonitor
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = Environment.SystemDirectory + "\\config";
            textBox1.Enabled = false;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fileSystemWatcher1.Path = textBox1.Text;
            //提示对于此示例，您可以使用本地计算机上所希望的任何目录。
            this.fileSystemWatcher1.Filter = "*.Evt";//此属获取或设置筛选字符串，用于确定在目录中监视哪些文件。
            this.fileSystemWatcher1.EndInit();
            button1.Enabled = false;
        }
        //创建文件是发生
        private void fileSystemWatcher1_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            listBox1.Items.Add("日志文件:" + e.FullPath+"被创建");
        }
        private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            listBox1.Items.Add("日志文件:" + e.FullPath + "被更改");
        }
        private void fileSystemWatcher1_Deleted(object sender, System.IO.FileSystemEventArgs e)
        {
            listBox1.Items.Add("日志文件:" + e.FullPath + "被册除");
        }
    }
}