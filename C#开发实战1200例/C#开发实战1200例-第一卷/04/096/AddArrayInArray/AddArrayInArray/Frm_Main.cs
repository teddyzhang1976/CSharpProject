using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AddArrayInArray
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        private int[] G_int_array = new int[8];//定义数组类型变量
        private int[] G_int_Narray = new int[4];//定义数组类型变量
        /// <summary>
        /// 向一维数组中添加一个数组
        /// </summary>
        /// <param name="ArrayBorn">源数组</param>
        /// <param name="ArrayAdd">要添加的数组</param>
        /// <param name="Index">添加索引</param>
        /// <returns>新得到的数组</returns>
        static int[] AddArray(int[] ArrayBorn, int[] ArrayAdd, int Index)
        {
            if (Index >= (ArrayBorn.Length))//判断添加索引是否大于数组的长度
                Index = ArrayBorn.Length - 1;//将添加索引设置为数组的最大索引
            int[] TemArray = new int[ArrayBorn.Length + ArrayAdd.Length];//声明一个新的数组
            for (int i = 0; i < TemArray.Length; i++)//遍历新数组的元素
            {
                if (Index >= 0)//判断添加索引是否大于等于0
                {
                    if (i < (Index + 1))//判断遍历到的索引是否小于添加索引加1
                        TemArray[i] = ArrayBorn[i];//交换元素值
                    else if (i == (Index + 1))//判断遍历到的索引是否等于添加索引加1
                    {
                        for (int j = 0; j < ArrayAdd.Length; j++)//遍历要添加的数组
                            TemArray[i + j] = ArrayAdd[j];//为遍历到的索引设置添加值
                        i = i + ArrayAdd.Length - 1;//将遍历索引设置为要添加数组的索引最大值
                    }
                    else
                        TemArray[i] = ArrayBorn[i - ArrayAdd.Length];//交换元素值
                }
                else
                {
                    if (i == 0)//判断遍历到的索引是否为0
                    {
                        for (int j = 0; j < ArrayAdd.Length; j++)//遍历要添加的数组
                            TemArray[i + j] = ArrayAdd[j];//为遍历到的索引设置添加值
                        i = i + ArrayAdd.Length - 1;//将遍历索引设置为要添加数组的索引最大值
                    }
                    else
                        TemArray[i] = ArrayBorn[i - ArrayAdd.Length];//交换元素值
                }
            }
            return TemArray;//返回添加数组后的新数组
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


        private void btn_NArray_Click(object sender, EventArgs e)
        {
            txt_NArray.Clear();//清空文本框
            //使用循环赋值
            for (int i = 0; i < G_int_Narray.GetUpperBound(0) + 1; i++)
            {
                G_int_Narray[i] = i;
            }
            //使用循环输出
            for (int i = 0; i < G_int_Narray.GetUpperBound(0) + 1; i++)
            {
                txt_NArray.Text += G_int_Narray[i] + " ";
            }
        }

        private void btn_Sure_Click(object sender, EventArgs e)
        {
            rtbox_NArray.Clear();//清空文本框
            G_int_array = AddArray(G_int_array, G_int_Narray,5);//调用自定义方法向数组中插入数组
            //使用循环输出
            for (int i = 0; i < G_int_array.GetUpperBound(0) + 1; i++)
            {
                rtbox_NArray.Text += G_int_array[i] + " ";
            }
        }
    }
}
