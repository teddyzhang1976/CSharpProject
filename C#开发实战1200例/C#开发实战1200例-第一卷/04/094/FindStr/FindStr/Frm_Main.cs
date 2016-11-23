using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FindStr
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
            G_str_array = new string[] {//为字符串数组字段赋值
            "明日科技","C#编程词典","C#范例大全","C#范例宝典"};
            for (int i = 0; i < G_str_array.Length; i++)//循环输出字符串
            {
                lab_Message.Text += G_str_array[i] + "\n";
            }
        }

        private void txt_find_TextChanged(object sender, EventArgs e)
        {
            if (txt_find.Text != string.Empty)//判断查找字符串是否为空
            {
                string[] P_str_temp = Array.FindAll//使用FindAll方法查找相应字符串
                    (G_str_array, (s) => s.Contains(txt_find.Text));
                if (P_str_temp.Length > 0)//判断是否查找到相应字符串
                {
                    txt_display.Clear();//清空控件中的字符串
                    foreach (string s in P_str_temp)//向控件中添加字符串
                    {
                        txt_display.Text += s + Environment.NewLine;
                    }
                }
                else
                {
                    txt_display.Clear();//清空控件中的字符串
                    txt_display.Text = "没有找到记录";//提示没有找到记录
                }
            }
            else
            {
                txt_display.Clear();//清空控件中的字符串
            }
        }
    }
}
