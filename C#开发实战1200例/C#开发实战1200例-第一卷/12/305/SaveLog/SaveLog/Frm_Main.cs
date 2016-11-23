using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace SaveLog
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            if (System.Diagnostics.EventLog.SourceExists("ErrEventLog"))//判断是否存在事件源
            {
                System.Diagnostics.EventLog.DeleteEventSource("ErrEventLog");//删除事件源注册
            }
            System.Diagnostics.EventLog.//创建日志信息
                CreateEventSource("ErrEventLog", "Application");
            eventLog2.Log = "Application";//设置日志名称
            eventLog2.Source = "ErrEventLog";//事件源名称
            this.eventLog1.MachineName = ".";//表示本机
        }
        private void btn_Find_Click(object sender, EventArgs e)
        {
            if (eventLog1.Entries.Count > 0)//判断是否存在系统日志
            {
                foreach (System.Diagnostics.EventLogEntry//遍历日志信息
                    entry in eventLog1.Entries)
                {
                    if (entry.EntryType ==//判断是否为错误日志
                        System.Diagnostics.EventLogEntryType.Error)
                    {
                        listBox1.Items.Add(entry.Message);//向控件中添加数据项
                        eventLog2.WriteEntry(entry.Message,//写入日志信息
                            System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("系统没有错误日志.");//弹出消息对话框
            }
        }
    }
}