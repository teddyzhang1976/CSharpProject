using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CheckNetWork
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (SystemInformation.Network)//判断是否有网络连接
                label1.Text = "该计算机已经联网！";
            else
                label1.Text = "该计算机尚未联网！";
        }
    }
}