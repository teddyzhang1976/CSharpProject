using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCPReceive
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Thread thread = new Thread(new ThreadStart(Listen));
            thread.Start();
        }

        public void Listen()
        {
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");
            Int32 port = 2112;
            TcpListener tcpListener = new TcpListener(localAddr, port);
            tcpListener.Start();

            TcpClient tcpClient = tcpListener.AcceptTcpClient();

            NetworkStream ns = tcpClient.GetStream();
            StreamReader sr = new StreamReader(ns);
            string result = sr.ReadToEnd();
            Invoke(new UpdateDisplayDelegate(UpdateDisplay), new object[] { result });
            tcpClient.Close();
            tcpListener.Stop();
        }

        public void UpdateDisplay(string text)
        {
            textBox1.Text = text;
        }

        protected delegate void UpdateDisplayDelegate(string text);

    }
}
