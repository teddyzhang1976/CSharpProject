using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Goto
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        string[] G_str_array = new string[] //定义数组并初始化
        { 
        "C#范例宝典",
        "C#编程宝典",
        "C#视频学",
        "C#项目开发全程实录",
        "C#项目开发实例自学手册",
        "C#编程词典",
        "C#实战宝典",
        "C#经验技巧宝典",
        "C#入门模式",
        };

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            lbox_str.Items.AddRange(G_str_array);
        }

        private void btn_query_Click(object sender, EventArgs e)
        {
            int i = 0;//定义计数器
        label1://定义标签
            if (G_str_array[i].Contains(txt_query.Text))//判断是否找到图书
            {
                lbox_str.SelectedIndex = i;//选中查找到的结果
                MessageBox.Show(txt_query.Text + " 已经找到！", "提示！");//提示找到信息
                return;
            }
            i++;
            if (i < G_str_array.Length) goto label1;//条件满足则跳转到标签
            MessageBox.Show(txt_query.Text + " 没有找到！", "提示！");//提示未找到信息
        }

    }
}
