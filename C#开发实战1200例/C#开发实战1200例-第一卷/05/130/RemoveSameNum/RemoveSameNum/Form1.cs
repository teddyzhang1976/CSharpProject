using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RemoveSameNum
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string P_str_Arr = lab_Array.Text.Remove(0, 5);//记录初始字符串
            string[] P_str_Arrs = P_str_Arr.Split(',');//对字符串进行分割
            int[] P_int_Arrs = new int[P_str_Arrs.Length];//定义一个一维数组
            //为int类型的一维数组进行赋值
            for (int i = 0; i < P_str_Arrs.Length; i++)
                P_int_Arrs[i] = Convert.ToInt32(P_str_Arrs[i]);
            //定义两个int类型的变量，分别用来表示数组下标和存储新的数组元素
            int P_int_Index, P_int_Temp;
            for (int i = 0; i < P_int_Arrs.Length - 1; i++)//根据数组下标的值遍历数组元素
            {
                P_int_Index = i + 1;
            id://定义一个标识，以便从这里开始执行语句
                if (P_int_Arrs[i] > P_int_Arrs[P_int_Index])//判断前后两个数的大小
                {
                    P_int_Temp = P_int_Arrs[i];//将比较后大的元素赋值给定义的int变量
                    P_int_Arrs[i] = P_int_Arrs[P_int_Index];//将后一个元素的值赋值给前一个元素
                    P_int_Arrs[P_int_Index] = P_int_Temp;//将int变量中存储的元素值赋值给后一个元素
                    goto id;//返回标识，继续判断后面的元素
                }
                else
                    if (P_int_Index < P_int_Arrs.Length - 1)//判断是否执行到最后一个元素
                    {
                        P_int_Index++;//如果没有，则再往后判断
                        goto id;//返回标识，继续判断后面的元素
                    }
            }
            int[] P_int_newArrs = RemoveNum(P_int_Arrs);//去掉重复数字
            lab_NArray.Text = "去掉重复数字之后的数组：\n       ";
            foreach (int P_int_NIndex in P_int_newArrs)//循环遍历排序后的数组元素并输出
                lab_NArray.Text += P_int_NIndex + " ";
        }

        #region 去掉数组中的重复数字
        /// <summary>
        /// 去掉数组中的重复数字
        /// </summary>
        /// <param name="P_int_Data">要去除重复数字的int数组</param>
        /// <returns>取出重复数字之后的数组</returns>
        static int[] RemoveNum(int[] P_int_Data)
        {
            List<int> P_list_Arrs = new List<int>();//实例化泛型集合
            for (int i = 0; i < P_int_Data.Length - 1; i++)//循环访问源数组元素
            {
                if (P_int_Data[i] != P_int_Data[i + 1])//判断相邻的值是否相同
                {
                    P_list_Arrs.Add(P_int_Data[i]);//如果不同，将值添加到泛型集合中
                }
            }
            P_list_Arrs.Add(P_int_Data[P_int_Data.Length - 1]);//将数组的最后一个元素添加到泛型集合中
            return P_list_Arrs.ToArray();//将泛型集合转换为数组，并返回
        }
        #endregion
    }
}
