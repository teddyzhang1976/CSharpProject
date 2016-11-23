using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace CreateNewLog
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!EventLog.SourceExists(textBox1.Text))//判断是否已经存在相同的日志
            {
                EventLog.CreateEventSource(textBox3.Text, textBox1.Text);//创建日志
            }
            EventLog log = new EventLog();//创建日志对象
            log.Source = textBox3.Text;//指定日志来源
            log.WriteEntry(textBox2.Text);//写入日志信息
        }
    }
}