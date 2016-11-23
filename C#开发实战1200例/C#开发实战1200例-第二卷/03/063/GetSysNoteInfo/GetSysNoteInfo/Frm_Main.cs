using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace GetSysNoteInfo
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.eventLog1.Log = "System";//设置获取系统日志
            EventLogEntryCollection collection = eventLog1.Entries;//创建日志实体对象
            int Count = collection.Count;//获取所有的日志条数
            string info = "显示系统日志" + Count.ToString() + "个事件。";//显示日志数
            foreach (EventLogEntry entry in collection)//遍历获取到的日志
            {
                info += "\n\n类型：" + entry.EntryType.ToString();//显示日志类型
                info += "\n\n日期：" + entry.TimeGenerated.ToLongDateString();//显示日志日期
                info += "\n\n时间：" + entry.TimeGenerated.ToLongTimeString();//显示日志时间
                info += "\n\n来源：" + entry.Source;//显示日志来源
                info += "\n\n事件：" + entry.EventID.ToString();//显示日志事件
                info += "\n\n用户：" + entry.UserName;//显示日志用户
                info += "\n\n计算机：" + entry.MachineName;//显示日志计算机
            }
            this.richTextBox1.Text = info;//显示日志信息
        }
    }
}