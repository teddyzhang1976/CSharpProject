using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Net;
namespace DynamicTaskStock
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        private Thread td;//创建一个线程
        private TcpListener tcpListener;//实例化侦听对象
        string message = "";//记录传输的内容
        private void StartListen()
        {
            tcpListener = new TcpListener(888);//创建TcpListener实例
            tcpListener.Start();//开始监听
            while (true)
            {
                TcpClient tclient = tcpListener.AcceptTcpClient();//接受连接请求
                NetworkStream nstream = tclient.GetStream();//获取数据流
                byte[] mbyte = new byte[1024];//建立缓存
                int i = nstream.Read(mbyte, 0, mbyte.Length);//将数据流写入缓存
                message = Encoding.Default.GetString(mbyte, 0, i);//获取传输的内容
            }
        }
        private void Frm_Main_Load(object sender, EventArgs e)
        {
            td = new Thread(new ThreadStart(this.StartListen));//通过线程调用StartListen方法
            td.Start();//开始运行线程
        }

        private void Frm_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.tcpListener != null)
            {
                tcpListener.Stop();//停止侦听对象
            }
            if (td != null)
            {
                if (td.ThreadState == ThreadState.Running)//判断线程是否运行
                {
                    td.Abort();//终止线程
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                IPAddress[] ip = Dns.GetHostAddresses(Dns.GetHostName());//获取本机地址
                string message = "你好兄弟";//传输的内容
                TcpClient client = new TcpClient(txtAdd.Text, 888);//创建TcpClient实例
                NetworkStream netstream = client.GetStream();//创建NetworkStream实例
                StreamWriter wstream = new StreamWriter(netstream, Encoding.Default);//创建StreamWriter实例
                wstream.Write(message);//将信息写入流
                wstream.Flush();
                wstream.Close();//关闭流
                client.Close();//关闭TcpClient对象
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        bool k = true;//一个标记，用于控制图标闪动
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (message.Length > 0)//如果网络中传输了数据
            {
                if (k)//k为true时
                {
                    notifyIcon1.Icon = Properties.Resources._1;//托盘图标为1
                    k = false;//设k为false
                }
                else//k为false时
                {
                    notifyIcon1.Icon = Properties.Resources._2;//图盘图标为2，透明的图标
                    k = true;//k为true
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            message = "";//清空传输内容
            notifyIcon1.Icon = Properties.Resources._3;//初始化显示的图标
        }
    }
}
