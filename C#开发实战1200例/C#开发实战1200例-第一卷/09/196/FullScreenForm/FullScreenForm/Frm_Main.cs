using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FullScreenForm
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;//设置窗体为无边框样式
            this.WindowState = FormWindowState.Maximized;//最大化显示窗体
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.Sizable;//设置窗体为有边框样式
            this.WindowState = FormWindowState.Normal;//正常显示窗体
        }
    }
}