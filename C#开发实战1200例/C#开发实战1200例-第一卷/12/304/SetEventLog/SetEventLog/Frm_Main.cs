using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SetEventLog
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (eventLog1.Entries.Count > 0)
            {
                foreach (System.Diagnostics.EventLogEntry entry
                   in eventLog1.Entries)
                {
                    listBox1.Items.Add(entry.Message);
                }
            }
            else
            {
                MessageBox.Show("日志中没有记录.");
            }
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            if (System.Diagnostics.EventLog.SourceExists("ZhyScoure"))//判断是否存在事件源
            {
                System.Diagnostics.EventLog.DeleteEventSource("ZhyScoure");//删除事件源注册
            }
            System.Diagnostics.EventLog.//创建日志信息
                CreateEventSource("ZhyScoure", "NewLog1");
            eventLog1.Log = "NewLog1";//设置日志名称
            eventLog1.Source = "ZhyScoure";//事件源名称
            this.eventLog1.MachineName = ".";//表示本机
        }

        private void btn_Write_Click(object sender, EventArgs e)
        {
            if (System.Diagnostics.EventLog.Exists("NewLog1"))//判断日志是否存在
            {
                if (textBox1.Text != "")//如果文本框为空
                {
                    eventLog1.WriteEntry(textBox1.Text.ToString());//写入日志
                    MessageBox.Show("日志写成功");//弹出消息对话框
                    textBox1.Text = "";//清空文本框信息
                }
                else
                {
                    MessageBox.Show("日志内容不能为空");//弹出消息对话框
                }
            }
            else
            {
                MessageBox.Show("日志不存在");//弹出消息对话框
            }
        }
    }
}