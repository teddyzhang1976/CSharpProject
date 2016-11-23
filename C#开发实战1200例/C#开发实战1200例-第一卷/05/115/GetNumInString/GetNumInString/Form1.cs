using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GetNumInString
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //查找数字方法
        public bool getNumeric(string str)
        {
            bool b = false;
            //将所有数字存储到一个字符串数组中
            string[] ArrayInt = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            foreach (string n in ArrayInt)//判断字符是否包含数组中指定的数字
            {
                if (n == str)//如果找到了数字
                {
                    b = true;
                    break;
                }
            }
            return b;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = "得到的数字：";
            string strs = textBox1.Text;//记录要从中查找数字的字符串
            for (int i = 0; i < strs.Length; i++)//循环遍历这个字符串
            {
                string str = strs.Substring(i, 1);//单一读取每一个字符
                bool b = getNumeric(str);//判断字符是否为数字
                if (b)
                {
                    label2.Text += str + "、";//如果是数字则显示
                }
            }
        }
    }
}
