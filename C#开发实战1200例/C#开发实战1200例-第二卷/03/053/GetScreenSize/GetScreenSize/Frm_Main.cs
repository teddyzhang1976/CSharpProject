using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GetScreenSize
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text="当前屏幕的分辨率为：" + SystemInformation.VirtualScreen.Width + "*" + SystemInformation.VirtualScreen.Height;//显示屏幕分辨率
        }
    }
}