using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BubbleUpSort
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
                //定义两个int类型的变量，分别用来表示数组下标和存储新的数组元素
                int j, temp;
                for (int i = 0; i < G_int_value.Length - 1; i++)//根据数组下标的值遍历数组元素
                {
                    j = i + 1;
                id://定义一个标识，以便从这里开始执行语句
                    if (G_int_value[i] > G_int_value[j])//判断前后两个数的大小
                    {
                        temp = G_int_value[i];//将比较后大的元素赋值给定义的int变量
                        G_int_value[i] = G_int_value[j];//将后一个元素的值赋值给前一个元素
                        G_int_value[j] = temp;//将int变量中存储的元素值赋值给后一个元素
                        goto id;//返回标识，继续判断后面的元素
                    }
                    else
                        if (j < G_int_value.Length - 1)//判断是否执行到最后一个元素
                        {
                            j++;//如果没有，则再往后判断
                            goto id;//返回标识，继续判断后面的元素
                        }
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
                txt_str.Text += i.ToString() + ", ";//向控件内添加字符串

            }
        }
    }
}
