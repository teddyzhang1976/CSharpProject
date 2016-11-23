using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Reverse
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }


        private string[] G_str_array;//定义字符串数组字段

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            G_str_array = new string[] {"C#编程词典","C#编程宝典","C#开发实战宝典","视频学C#","C#范例大全"};//为字符串数组字段赋值
            foreach (string str in G_str_array)//遍历字符串数组集合
            {
                lab_str.Text += str + Environment.NewLine;//显示字符串数组
                    
            }
        }

        private void btn_Reverse_Click(object sender, EventArgs e)
        {
            lab_str2.Text = string.Empty;//清空信息
            foreach (string str in G_str_array.Reverse())//遍历反转后的字符串数组
            {
                lab_str2.Text += str + Environment.NewLine;//显示字符串数组
            }
        }
    }
}