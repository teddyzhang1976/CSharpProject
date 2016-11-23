using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FastSort
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private int[] G_int_value;//定义数组字段

        private Random G_Random = new Random();//创建随机数对象

        //交换数据
        private void swap(ref int l, ref int r)
        {
            int temp;//临时值
            temp = l;//记录前一个值
            l = r;//记录后一个值
            r = temp;//前后交换数据
        }

        private void Sort(int[] list, int low, int high)
        {
            int pivot;//临时变量，用来存储最大值
            int l, r;//分别用来记录遍历到的索引和最大索引
            int mid;//中间索引
            if (high <= low)//判断输入的值是否合法
                return;
            else if (high == low + 1)//判断两个索引是否相邻
            {
                if (list[low] > list[high])//判断前面的值是否大于后面的值
                    swap(ref list[low], ref list[high]);//交换前后索引的值
                return;
            }
            mid = (low + high) >> 1;//记录数组的中间索引
            pivot = list[mid];//初始化临时变量的值
            swap(ref list[low], ref list[mid]);//交换第一个值和中间值的索引顺序
            l = low + 1;//记录遍历到的索引值
            r = high;//记录最大索引
            try
            {
                //使用do...while循环遍历数组，并比较前后值的大小
                do
                {

                    while (l <= r && list[l] < pivot)//判断遍历到的索引是否小于最大索引
                        l++;//索引值加1
                    while (list[r] >= pivot)//判断最大值是否大于等于记录的分支点
                        r--;//做大索引值减1
                    if (l < r)//如果当前遍历到的值小于最大值
                        swap(ref list[l], ref list[r]);//交换顺序

                } while (l < r);
                list[low] = list[r];//在最小索引处记录最小值
                list[r] = pivot;//在最大索引处记录最大值
                if (low + 1 < r)//判断最小索引是否小于最大索引
                    Sort(list, low, r - 1);//调用自身进行快速排序
                if (r + 1 < high)//判断最大索引是否小于数组长度
                    Sort(list, r + 1, high);//调用自身进行快速排序
            }
            catch { }
        }

        private void btn_sort_Click(object sender, EventArgs e)
        {
            if (G_int_value != null)
            {
                Sort(G_int_value, 0, G_int_value.Length-1);//使用快速排序法对数组进行排序
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
