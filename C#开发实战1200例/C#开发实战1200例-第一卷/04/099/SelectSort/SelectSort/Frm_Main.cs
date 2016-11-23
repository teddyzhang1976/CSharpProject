using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SelectSort
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private int[] G_int_value;//定义数组字段

        private Random G_Random = new Random();//创建随机数对象

        private void btn_sort_Click(object sender, EventArgs e)
        {
            if (G_int_value != null)
            {
                int min;//定义一个int变量，用来存储数组下标
                for (int i = 0; i < G_int_value.Length - 1; i++)//循环访问数组中的元素值（除最后一个）
                {
                    min = i;//为定义的数组下标赋值
                    for (int j = i + 1; j < G_int_value.Length; j++)//循环访问数组中的元素值（除第一个）
                    {
                        if (G_int_value[j] < G_int_value[min])//判断相邻两个元素值的大小
                            min = j;
                    }
                    int t = G_int_value[min];//定义一个int变量，用来存储比较大的数组元素值
                    G_int_value[min] = G_int_value[i];//将小的数组元素值移动到前一位
                    G_int_value[i] = t;//将int变量中存储的较大的数组元素值向后移
                }
                txt_str2.Clear();//清空控件内字符串
                foreach (int i in G_int_value)//遍历字符串集合
                {
                    txt_str2.Text += i.ToString() + ", ";//向控件内添加字符串
                }
            }
            else
            {
                MessageBox.Show("首先应当生成数组，然后再进行排序。", "提示！");
            }
        }

        private void btn_Generate_Click(object sender, EventArgs e)
        {
            G_int_value = new int[G_Random.Next(10, 20)];//生成随机长度数组
            for (int i = 0; i < G_int_value.Length; i++)//遍历数组
            {
                G_int_value[i] = G_Random.Next(0, 100);//为数组赋随机数值
            }
            txt_str.Clear();//清空控件内字符串
            foreach (int i in G_int_value)//遍历字符串集合
            {
                txt_str.Text +=i.ToString() + ", ";//向控件内添加字符串
            }
        }
    }
}
