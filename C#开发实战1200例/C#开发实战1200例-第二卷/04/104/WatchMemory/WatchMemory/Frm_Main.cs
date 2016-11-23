using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;

namespace WatchMemory
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Computer myComputer = new Computer();
            //获取系统的物理内存总量
            textBox1.Text = Convert.ToString(myComputer.Info.TotalPhysicalMemory / 1024 / 1024);
            //获取系统的可用物理内存
            textBox2.Text = Convert.ToString(myComputer.Info.AvailablePhysicalMemory / 1024 / 1024);
            //获取系统的虚拟内存总量
            textBox3.Text = Convert.ToString(myComputer.Info.TotalVirtualMemory / 1024 / 1024);
            //获取系统的可用虚拟内存
            textBox4.Text = Convert.ToString(myComputer.Info.AvailableVirtualMemory / 1024 / 1024);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();//启动计时器
        }
    }
}