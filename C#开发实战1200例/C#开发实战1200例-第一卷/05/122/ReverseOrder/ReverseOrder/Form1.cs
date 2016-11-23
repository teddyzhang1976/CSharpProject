using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReverseOrder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 通过迭代器实现字符串的倒序
        /// </summary>
        /// <param string="n">进行倒序的字符串</param>
        /// <returns>以对象的方式倒序返回单个字符</returns>
        public static IEnumerable<object> Transpose(string n)
        {
            if (n.Length >0)//如果泛型不为空
            {
                for (int i = n.Length-1; i >= 0; i--)//从末尾开始遍历字符串
                    yield return (object)n[i];//返回数据集合
            }
        }

        /// <summary>
        /// 获取倒序后的字符串
        /// </summary>
        /// <param string="Str">进行倒序的字符串</param>
        /// <returns>返回倒序后的字符串</returns>
        public string GetValue(string Str)
        {
            if (Str.Length == 0)//判断字符串长度是否为0
                return "";//返回空
            string Tem_Str = "";//记录倒序之后的字符串
            foreach (object i in Transpose(Str))//遍历迭代器
                Tem_Str += i.ToString();//获取迭代器中的每个字符
            return Tem_Str;//返回倒序之后的字符串
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox2.Text = GetValue(textBox1.Text);
        }
    }
}
