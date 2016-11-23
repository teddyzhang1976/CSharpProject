using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ArrayInfo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class Finder
        {
            // 定义一个泛型方法，用来查找指定值在数组中的索引
            public static int Find<T>(T[] items, T item)
            {
                for (int i = 0; i < items.Length; i++)//遍历泛型数组
                {
                    if (items[i].Equals(item))//判断是否找到了指定值
                    {
                        return i;//返回指定值在数组中的索引
                    }
                }
                return -1;//如果没有找到，返回-1
            }
        } 

        private void button1_Click(object sender, EventArgs e)
        {
            string[] Str = new string[] { "一", "二", "三", "四", "五", "六", "七", "八", "九" };//声明一个字符串类型的数组
            MessageBox.Show(Finder.Find<string>(Str, "三").ToString());//查找字符串“三”在数组中的索引
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int[] IntArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };//声明一个整数类型的数组
            MessageBox.Show(Finder.Find<int>(IntArray, 5).ToString());//查找数字5在数组中的索引
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool[] IntArray = new bool[] { true, false};//声明一个布尔类型的数组
            MessageBox.Show(Finder.Find<bool>(IntArray, false).ToString());//查找false在数组中的索引
        }
    }
}
