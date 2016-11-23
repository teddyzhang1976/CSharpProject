using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DelArrayYesLength
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        private int[] G_int_array = new int[8];//定义数组类型变量
        /// <summary>
        /// 删除数组中的元素，并改变数组的长度
        /// </summary>
        /// <param name="ArrayBorn">要从中删除元素的数组</param>
        /// <param name="Index">删除索引</param>
        /// <param name="Len">删除的长度</param>
        /// <returns>得到的新数组</returns>
        static int[] DeleteArray(int[] ArrayBorn, int Index, int Len)
        {
            if (Len <= 0)//判断删除长度是否小于等于0
                return ArrayBorn;//返回源数组
            if (Index == 0 && Len >= ArrayBorn.Length)//判断删除长度是否超出了数组范围
                Len = ArrayBorn.Length;//将删除长度设置为数组的长度
            else if ((Index + Len) >= ArrayBorn.Length)//判断删除索引和长度的和是否超出了数组范围
                Len = ArrayBorn.Length - Index - 1;//设置删除的长度
            int[] temArray = new int[ArrayBorn.Length - Len];//声明一个新的数组
            for (int i = 0; i < temArray.Length; i++)//遍历新数组
            {
                if (i >= Index)//判断遍历索引是否大于等于删除索引
                    temArray[i] = ArrayBorn[i + Len];//为遍历到的索引元素赋值
                else
                    temArray[i] = ArrayBorn[i];//为遍历到的索引元素赋值
            }
            return temArray;//返回得到的新数组
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
            G_int_array = DeleteArray(G_int_array, Convert.ToInt32(txt_Index.Text), Convert.ToInt32(txt_Num.Text));//删除数组中的元素
            //使用循环输出删除元素的数组
            for (int i = 0; i < G_int_array.GetUpperBound(0) + 1; i++)
            {
                rtbox_NArray.Text += G_int_array[i] + " ";
            }
        }
    }
}
