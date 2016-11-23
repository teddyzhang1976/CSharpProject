using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XESort
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
                int inc;//定义一个int变量，用来确定每个有序序列的个数
                for (inc = 1; inc <= G_int_value.Length / 9; inc = 3 * inc + 1) ;//为有序序列赋值
                for (; inc > 0; inc /= 3)
                {
                    for (int i = inc + 1; i <= G_int_value.Length; i += inc)
                    {
                        int t = G_int_value[i - 1];//记录当前值
                        int j = i;//定义下一个索引
                        while ((j > inc) && (G_int_value[j - inc - 1] > t))
                        {
                            G_int_value[j - 1] = G_int_value[j - inc - 1];//交换数据
                            j -= inc;
                        }
                        G_int_value[j - 1] = t;//将下一个元素值设置为当前值
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
