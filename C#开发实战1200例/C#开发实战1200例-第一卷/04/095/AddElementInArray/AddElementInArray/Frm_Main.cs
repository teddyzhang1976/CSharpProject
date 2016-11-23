using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AddElementInArray
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        private int[] G_int_array = new int[8];//定义数组类型变量
        /// <summary>
        /// 增加单个数组元素
        /// </summary>
        /// <param name="ArrayBorn">要向其中添加元素的一维数组</param>
        /// <param name="Index">添加索引</param>
        /// <param name="Value">添加值</param>
        /// <returns></returns>
        static int[] AddArray(int[] ArrayBorn, int Index, int Value)
        {
            if (Index >= (ArrayBorn.Length))//判断添加索引是否大于数组的长度
                Index = ArrayBorn.Length - 1;//将添加索引设置为数组的最大索引
            int[] TemArray = new int[ArrayBorn.Length + 1];//声明一个新的数组
            for (int i = 0; i < TemArray.Length; i++)//遍历新数组的元素
            {
                if (Index >= 0)//判断添加索引是否大于等于0
                {
                    if (i < (Index + 1))//判断遍历到的索引是否小于添加索引加1
                        TemArray[i] = ArrayBorn[i];//交换元素值
                    else if (i == (Index + 1))//判断遍历到的索引是否等于添加索引加1
                        TemArray[i] = Value;//为遍历到的索引设置添加值
                    else
                        TemArray[i] = ArrayBorn[i - 1];//交换元素值
                }
                else
                {
                    if (i == 0)//判断遍历到的索引是否为0
                        TemArray[i] = Value;//为遍历到的索引设置添加值
                    else
                        TemArray[i] = ArrayBorn[i - 1];//交换元素值
                }
            }
            return TemArray;//返回插入元素后的新数组
        }

        private void btn_RArray_Click(object sender, EventArgs e)
        {
            txt_RArray.Clear();//清空文本框
            //使用循环赋值
            for (int i = 0; i < G_int_array.GetUpperBound(0) + 1; i++)
            {
                G_int_array[i] = i;
            }
            //使用循环输出
            for (int i = 0; i < G_int_array.GetUpperBound(0) + 1; i++)
            {
                txt_RArray.Text += G_int_array[i] + " ";
            }
        }

        private void btn_Sure_Click(object sender, EventArgs e)
        {
            rtbox_NArray.Clear();//清空文本框
            G_int_array = AddArray(G_int_array, 4, Convert.ToInt32(txt_Element.Text));//调用自定义方法向数组中插入单个元素
            //使用循环输出
            for (int i = 0; i < G_int_array.GetUpperBound(0) + 1; i++)
            {
                rtbox_NArray.Text += G_int_array[i] + " ";
            }
        }
    }
}
