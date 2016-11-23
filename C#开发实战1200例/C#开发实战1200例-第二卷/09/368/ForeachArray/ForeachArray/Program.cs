using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForeachArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();//创建Program对象，用来调用类的方法
            string[] P_str_Name = { "C#编程全能词典", "C#编程词典个人版", "C#编程词典企业版" };	//定义字符串数组
            string[] P_str_Money = { "98元", "698元", "2998元" };//定义字符串数组
            Console.WriteLine("这两组数组的元素：");
            p.TestB(P_str_Name, P_str_Money);//调用方法输出两个数组中的所有元素
            Console.Read();
        }
        //该方法实现连接两个字符串，并输出所有的元素
        private void TestB(string[] str1s, string[] str2s)
        {
            foreach (string item in str1s.Concat<string>(str2s))//首先数组str1s与数组str2s连接，然后遍历
            {
                Console.Write(item + "  ");
            }
        }
    }
}
