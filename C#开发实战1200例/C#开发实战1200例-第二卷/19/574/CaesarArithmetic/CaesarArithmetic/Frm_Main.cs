using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CaesarArithmetic
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        //获取字符的ASCII码
        public int AscII(string str)
        {
            byte[] array = new byte[1];//创建字节数组
            array = System.Text.Encoding.ASCII.GetBytes(str);//为字节数组赋值
            int asciicode = (short)(array[0]);//获取字节数组的第一项
            return asciicode;//返回字节数组的第一项
        }
        public string Caesar(string str)//凯撒加密算法的实现
        {
            char[] c = str.ToCharArray();//创建字符数组
            string strCaesar = "";//定义一个变量，用来存储加密后的字符串
            for (int i = 0; i < str.Length; i++)//遍历字符串中的每一个字符串
            {
                string ins = c[i].ToString();//记录遍历到的字符
                string outs = "";//定义一个变量，用来记录加密后的字符串
                bool isChar = "0123456789abcdefghijklmnopqrstuvwxyz".Contains(ins.ToLower());//判断指定的字符串中是否包含遍历到的字符
                bool isToUpperChar = isChar && (ins.ToUpper() == ins);//判断遍历到的字符是否是大写
                ins = ins.ToLower();//将遍历到的字符转换为小写
                if (isChar)//判断指定的字符串中是否包含遍历到的字符
                {
                    int offset = (AscII(ins) + 5 - AscII("a")) % (AscII("z") - AscII("a") + 1);//获取字符的ASCII码
                    outs = Convert.ToChar(offset + AscII("a")).ToString();//转换为字符并记录
                    if (isToUpperChar)//判断是否大写
                    {
                        outs = outs.ToUpper();//全部转换为大写
                    }
                }
                else
                {
                    outs = ins;//记录遍历的字符
                }
                strCaesar += outs;//添加到加密字符串中
            }
            return strCaesar;//返回加密后的字符串
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string P_str_Code = textBox1.Text;//记录要加密的密码
            textBox2.Text = Caesar(P_str_Code);//显示加密后的字符串
        }
    }
}
