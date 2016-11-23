using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_0_Click(object sender, EventArgs e)
        {
            if (txt_value.Text.Length < 9)//判断数值是符合规定
            {
                if (G_bl_add)//判断是否刚刚按下+号键
                {
                    txt_value.Clear();//清空数字
                    G_bl_add = false;//刚刚按下数字键
                }
                txt_value.Text += "0";//输入数字0
                G_bl_key = false;//打开+号键开关
            }
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            if (txt_value.Text.Length < 9)//判断数值是符合规定
            {
                if (G_bl_add)//判断是否刚刚按下+号键
                {
                    txt_value.Clear();//清空数字
                    G_bl_add = false;//刚刚按下数字键
                }
                txt_value.Text += "1";//输入数字0
                G_bl_key = false;//打开+号键开关
            }
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            if (txt_value.Text.Length < 9)//判断数值是符合规定
            {
                if (G_bl_add)//判断是否刚刚按下+号键
                {
                    txt_value.Clear();//清空数字
                    G_bl_add = false;//刚刚按下数字键
                }
                txt_value.Text += "2";//输入数字0
                G_bl_key = false;//打开+号键开关
            }
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            if (txt_value.Text.Length < 9)//判断数值是符合规定
            {
                if (G_bl_add)//判断是否刚刚按下+号键
                {
                    txt_value.Clear();//清空数字
                    G_bl_add = false;//刚刚按下数字键
                }
                txt_value.Text += "3";//输入数字0
                G_bl_key = false;//打开+号键开关
            }
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            if (txt_value.Text.Length < 9)//判断数值是符合规定
            {
                if (G_bl_add)//判断是否刚刚按下+号键
                {
                    txt_value.Clear();//清空数字
                    G_bl_add = false;//刚刚按下数字键
                }
                txt_value.Text += "4";//输入数字0
                G_bl_key = false;//打开+号键开关
            }
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            if (txt_value.Text.Length < 9)//判断数值是符合规定
            {
                if (G_bl_add)//判断是否刚刚按下+号键
                {
                    txt_value.Clear();//清空数字
                    G_bl_add = false;//刚刚按下数字键
                }
                txt_value.Text += "5";//输入数字0
                G_bl_key = false;//打开+号键开关
            }
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            if (txt_value.Text.Length < 9)//判断数值是符合规定
            {
                if (G_bl_add)//判断是否刚刚按下+号键
                {
                    txt_value.Clear();//清空数字
                    G_bl_add = false;//刚刚按下数字键
                }
                txt_value.Text += "6";//输入数字0
                G_bl_key = false;//打开+号键开关
            }
        }

        private void btn_7_Click(object sender, EventArgs e)
        {
            if (txt_value.Text.Length < 9)//判断数值是符合规定
            {
                if (G_bl_add)//判断是否刚刚按下+号键
                {
                    txt_value.Clear();//清空数字
                    G_bl_add = false;//刚刚按下数字键
                }
                txt_value.Text += "7";//输入数字0
                G_bl_key = false;//打开+号键开关
            }
        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            if (txt_value.Text.Length < 9)//判断数值是符合规定
            {
                if (G_bl_add)//判断是否刚刚按下+号键
                {
                    txt_value.Clear();//清空数字
                    G_bl_add = false;//刚刚按下数字键
                }
                txt_value.Text += "8";//输入数字0
                G_bl_key = false;//打开+号键开关
            }
        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            if (txt_value.Text.Length < 9)//判断数值是符合规定
            {
                if (G_bl_add)//判断是否刚刚按下+号键
                {
                    txt_value.Clear();//清空数字
                    G_bl_add = false;//刚刚按下数字键
                }
                txt_value.Text += "9";//输入数字0
                G_bl_key = false;//打开+号键开关
            }
        }

        private List<double> G_list_value = //记录累加数值
            new List<double>();

        private bool G_bl_add = false;//判断是否刚刚按下+号

        private bool G_bl_value = false;//判断是否刚刚按下=号

        private bool G_bl_key = false;//防止连续按+号

        private void btn_clear_Click(object sender, EventArgs e)
        {
            G_list_value.Clear();//清空集合中数值
            lb_express.Text = GetString();//清空计算表达式
            txt_value.Clear();//清空累加结果
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (G_bl_value)//判断是否刚刚按下=号
            {
                G_bl_value = false;//设置刚刚按下的不是=号
                G_bl_key = true;//设置刚刚按下的是加号
            }
            else
            {
                if (!G_bl_key)//判断是否连续按+号
                {
                    G_list_value.Add(//向集合中添加累加的数值
                        double.Parse(txt_value.Text));
                    GetValue();//计算累加数值并输出
                    lb_express.Text = GetString();//得到数值的字符串表示
                    G_bl_add = true;//设置已经按下+号
                    G_bl_key = true;//防止多次按下+号
                }
            }
        }

        private void btn_num_Click(object sender, EventArgs e)
        {
            if (!G_bl_key)//判断是否连续按下+号
            {
                if (!G_bl_value)//判断是否刚刚按下=号
                {
                    G_list_value.Add(//向集合中添加累加的数值
                        double.Parse(txt_value.Text));
                    GetValue();//计算累加数值并输出
                    lb_express.Text = GetString();//得到数值的字符串表示
                    G_bl_add = true;//设置已经按下+号
                    G_bl_value = true;//设置已经按下=号
                }
            }
        }

        /// <summary>
        /// 方法用于计算累加数值并输出
        /// </summary>
        void GetValue()
        {
            double P_dbl_temp = 0;//定义局部变量
            foreach (double d in G_list_value)//遍历集合
            {
                P_dbl_temp += d;//计算累加结果
            }
            txt_value.Text = P_dbl_temp.ToString();//显示累加结果
        }

        /// <summary>
        /// 方法用于得到数值的字符串表示
        /// </summary>
        /// <returns>返回字符串数值</returns>
        string GetString()
        {
            string P_str_temp = string.Empty;//定义局部变量
            for (int i = 0; i < G_list_value.Count; i++)//遍历集合
            {
                if (i != 0)//判断是否是第一个数值
                {
                    P_str_temp += //产生字符串
                        "+" + G_list_value[i].ToString();
                }
                else
                {
                    P_str_temp = //产生字符串
                        G_list_value[i].ToString();
                }
            }
            return P_str_temp;//返回字符串
        }
    }
}
