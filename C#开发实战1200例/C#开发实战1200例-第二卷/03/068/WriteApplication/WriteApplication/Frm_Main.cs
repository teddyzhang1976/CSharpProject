using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace WriteApplication
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EventLog log = new EventLog();//创建日志对象
            log.Source = "Application";//指定日志来源为应用程序日志
            log.WriteEntry(textBox2.Text);//向应用程序日志中写入信息
        }
    }
}