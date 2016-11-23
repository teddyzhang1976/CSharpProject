using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ArrayRank
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private string[,] G_str_array;//定义数组类型变量

        private Random G_Random_Num = new Random();//生成随机数对象

        private void btn_GetArray_Click(object sender, EventArgs e)
        {
            txt_display.Clear();//清空控件中的字符串
            G_str_array = new string[//随机生成二维数组
                G_Random_Num.Next(2, 10),
                G_Random_Num.Next(2, 10)];
            lab_Message.Text = string.Format(
                "生成了 {0} 行 {1 }列 的数组",
                G_str_array.GetUpperBound(0) + 1,//获取数组的行数
                G_str_array.GetUpperBound(1) + 1);//获取数组的列数
            DisplayArray();//调用显示数组方法
        }

        private void DisplayArray()
        {
            //使用循环赋值
            for (int i = 0; i < G_str_array.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < G_str_array.GetUpperBound(1) + 1; j++)
                {
                    G_str_array[i, j] = i.ToString() + "," + j.ToString() + "  ";
                }
            }

            //使用循环输出
            for (int i = 0; i < G_str_array.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < G_str_array.GetUpperBound(1) + 1; j++)
                {
                    txt_display.Text += G_str_array[i, j];
                }
                txt_display.Text += Environment.NewLine;
            }
        }
    }
}
