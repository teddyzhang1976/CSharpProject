using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
namespace AddLog
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            if (eventLog1.Entries.Count > 0)
            {
                foreach (System.Diagnostics.EventLogEntry//遍历所有日志
                    entry in eventLog1.Entries)
                {
                    if (comboBox1.Items.Count == 0)//判断是否为第一个日志
                    {
                        comboBox1.Items.Add(//添加日志信息
                            entry.Source.ToString());
                    }
                    else
                    {
                        if (!comboBox1.Items.Contains(//判断产生日志信息的应用程序是否重复
                            entry.Source.ToString()))
                        {
                            comboBox1.Items.Add(//添加日志信息
                                entry.Source.ToString());
                        }
                    }
                }
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)//如果没有选择应用程序
            {
                MessageBox.Show("请选择日志名称");//弹出消息对话框
                return;
            }
            if (textBox1.Text == "")//如果没有添写日志内容
            {
                MessageBox.Show("请填写日志内容");//弹出消息对话框
                textBox1.Focus();//控件得到焦点
                return;//退出方法
            }
            eventLog1.Log = "System";//设置读写日志的名称
            eventLog1.Source = comboBox1.//设置日志源名称
                SelectedItem.ToString();
            eventLog1.MachineName = ".";//设置写入日志的计算机名称
            eventLog1.WriteEntry(textBox1.Text);
            MessageBox.Show("添加成功");//弹出提示信息
            if (eventLog1.Entries.Count > 0)//如果日志中有内容
            {
                foreach (System.Diagnostics.EventLogEntry//遍历日志内容
                    entry in eventLog1.Entries)
                {
                    listView1.Items.Add(entry.Message);//在控件中显示日志内容
                }
            }
        }
    }
}
