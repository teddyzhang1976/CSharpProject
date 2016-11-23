using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ExecCMD
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string P_str_IP = textBox1.Text;//记录接收人IP地址
            string P_str_Info = textBox2.Text;//记录要发送的消息
            System.Diagnostics.Process.Start("cmd.exe", "/c net send " + P_str_IP + " " + P_str_Info);//向指定IP地址发送信息
        }
    }
}