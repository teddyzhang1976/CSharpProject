using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NavigationForm
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.Clear();//清空listView1中的原有内容
            listView1.LargeImageList = imageList1;//设置当前项以大图标的形式显示时用到的图像
            listView1.Items.Add("设置上下班时间", "设置上下班时间", 0);//向listView1中添加项“设置上下班时间”
            listView1.Items.Add("是否启用短信提醒", "是否启用短信提醒", 1);//向listView1中添加项“是否启用短信提醒”
            listView1.Items.Add("设置密码", "设置密码", 2);//向listView1中添加项“设置密码”
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            listView1.Dock = DockStyle.None;//设置listView1的绑定属性为未绑定
            button1.Dock = DockStyle.Top;//设置button1的绑定属性为上端绑定
            button2.Dock = DockStyle.Bottom;//设置button2的绑定属性为底端绑定
            button3.SendToBack();//将button3发送到Z顺序的后面
            button3.Dock = DockStyle.Bottom;//设置button3的绑定属性为底端绑定
            listView1.BringToFront();//将listView1带到Z顺序的前面
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                          | System.Windows.Forms.AnchorStyles.Left)
                          | System.Windows.Forms.AnchorStyles.Right)));
            listView1.Dock = DockStyle.Bottom;//设置listView1的绑定属性为底端绑定
            listView1.Clear();//清空listView1中的原有内容
            listView1.Items.Add("设置上下班时间", "设置上下班时间", 0);//向listView1中添加“设置上下班时间”
            listView1.Items.Add("是否启用短信提醒", "是否启用短信提醒", 1);//向listView1中添加“是否启用短信提醒”
            listView1.Items.Add("设置密码", "设置密码", 2);//向listView1中添加“设置密码”
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            listView1.Dock = DockStyle.None;//设置listView1的绑定属性为未绑定
            button2.Dock = DockStyle.Top;//设置button2的绑定属性为上端绑定
            button1.SendToBack();//将控件button1发送到Z顺序的后面
            button1.Dock = DockStyle.Top;//设置button1的绑定属性为上端绑定
            button3.Dock = DockStyle.Bottom;//设置button3的绑定属性为底端绑定
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                         | System.Windows.Forms.AnchorStyles.Left)
                         | System.Windows.Forms.AnchorStyles.Right)));
            listView1.Dock = DockStyle.Bottom;//设置listView1的绑定属性为底端绑定
            listView1.Clear();//清空listView1中的原有内容
            listView1.Items.Add("近期工作记录", "近期工作记录", 3);//向listView1中添加“近期工作记录”
            listView1.Items.Add("近期工作计划", "近期工作计划", 4);//向listView1中添加“近期工作计划”
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            listView1.Dock = DockStyle.None;//设置listView1的绑定属性为未绑定
            button3.SendToBack();//将button3发送到Z顺序的后面
            button3.Dock = DockStyle.Top;//设置button3的绑定属性为上端绑定
            button2.SendToBack();//将button2发送到Z顺序的后面
            button2.Dock = DockStyle.Top;//设置button2的绑定属性为上端绑定
            button1.SendToBack();//将button1发送到Z顺序的后面
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                         | System.Windows.Forms.AnchorStyles.Left)
                         | System.Windows.Forms.AnchorStyles.Right)));
            button1.Dock = DockStyle.Top;//设置button1的绑定属性为上端绑定
            listView1.Dock = DockStyle.Bottom;//设置listView1的绑定属性为底端绑定
            listView1.Clear();//清空listView1中的原有内容
            listView1.Items.Add("编辑工作进度报告", "编辑工作进度报告", 5);//向listView1中添加“编辑工作进度报告”
            listView1.Items.Add("编辑项目设计图", "编辑项目设计图", 6);//向listView1中添加“编辑项目设计图”
        }
    }
}