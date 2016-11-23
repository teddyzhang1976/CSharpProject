using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace WriteSystemLog
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
            log.Source = "System";//指定日志来源为系统日志
            log.WriteEntry(textBox2.Text);//向系统日志中写入信息
        }
    }
}