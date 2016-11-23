using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OpenControlPanelProgram
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("main.cpl");//打开鼠标设置窗口
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("desk.cpl");//打开桌面设置窗口
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("ncpa.cpl");//打开网络连接窗口
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("mmsys.cpl");//打开声音设置窗口
        }
    }
}