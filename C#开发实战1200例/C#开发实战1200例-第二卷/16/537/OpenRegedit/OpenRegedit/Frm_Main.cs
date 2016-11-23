using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OpenRegedit
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string regeditstr = Environment.GetEnvironmentVariable("WinDir");//WinDir系统环境变量的名称
            System.Diagnostics.Process.Start(regeditstr + "\\regedit.exe");//打开注册表
        }
    }
}
