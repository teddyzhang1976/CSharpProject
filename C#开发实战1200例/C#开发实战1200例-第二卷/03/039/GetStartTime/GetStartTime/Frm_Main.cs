using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GetStartTime
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox1.Text = (Environment.TickCount / 1000).ToString() + "秒";//获取启动后经过的时间
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = (Environment.TickCount / 1000).ToString() + "秒";//获取启动后经过的时间
        }
    }
}
