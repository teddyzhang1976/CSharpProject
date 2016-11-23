using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;

namespace RevertRegedit
{
    public partial class Frm_Main : Form
    {

        public Frm_Main()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "reg文件(*.reg)|*.reg";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Process myProcess = new Process();//创建一个新进程
                myProcess.StartInfo.FileName = "cmd.exe";//设置要启动的应用程序，控制台应用程序
                myProcess.StartInfo.UseShellExecute = false;//设置直接从可执行文件创建进程
                myProcess.StartInfo.RedirectStandardInput = true;//设置应用程序的输入要从标准输入流中读取
                myProcess.StartInfo.RedirectStandardOutput = true;//设置将应用程序的输出写入标准输出流
                myProcess.StartInfo.RedirectStandardError = true;//设置将应用程序的错误写入错误输出流
                myProcess.StartInfo.CreateNoWindow = true;//设置启动该进程而不创建包含它的新窗口
                myProcess.Start();//启动该进程
                string pp = "regedit /s " + textBox1.Text;//设置还原注册表到指定目录的命令字符串
                myProcess.StandardInput.WriteLine(pp);//还原注册表
                MessageBox.Show("注册表还原成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
