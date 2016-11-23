using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Diagnostics;

namespace StartSQLServer
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process pro = new Process();//创建进程对象
            pro.StartInfo.FileName = "cmd.exe";//设置应用程序名称
            pro.StartInfo.UseShellExecute = false;//是否使用系统外壳程序启动进程
            pro.StartInfo.RedirectStandardInput = true;//指示应用程序输入是否从流中读取
            pro.StartInfo.RedirectStandardOutput = true;//是否将应用程序输出写入流
            pro.StartInfo.RedirectStandardError = true;//是否将应用程序错误输入写入流
            pro.StartInfo.CreateNoWindow = true;//是否在新窗体中启动该进程的值
            pro.Start();//启动进程
            pro.StandardInput.WriteLine("net start mssqlserver");//将字符串写入文本流
            MessageBox.Show("已成功开启服务");//弹出消息对话框
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();//关闭窗体
        }
    }
}