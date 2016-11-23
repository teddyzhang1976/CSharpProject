using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ISNetWorkStatus
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (SystemInformation.PowerStatus.PowerLineStatus == PowerLineStatus.Offline)//如果是脱机状态
                label1.Text = "系统网络处于脱机状态！";
            else if (SystemInformation.PowerStatus.PowerLineStatus == PowerLineStatus.Online)//如果是联机状态
                label1.Text = "系统网络处于联机状态";
            else if (SystemInformation.PowerStatus.PowerLineStatus == PowerLineStatus.Unknown)//如果是未知状态
                label1.Text = "系统网络处于未知状态";
        }
    }
}