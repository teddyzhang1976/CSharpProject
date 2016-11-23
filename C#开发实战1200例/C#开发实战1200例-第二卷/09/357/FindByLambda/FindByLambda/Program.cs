using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FindByLambda
{
    class Program
    {
        static void Main(string[] args)
        {
            //声明一个数组并初始化
            string[] strLists = new string[] { "明日科技", "C#编程词典", "C#范例大全" };
            Console.WriteLine("源字符串数组：");
            //使用foreach语句遍历输出
            foreach (string str in strLists)
            {
                Console.Write(str + "  ");
            }
            Console.WriteLine("\n");
            //使用Lambda表达式查找数组中包含“C#”的字符串
            string[] strList = Array.FindAll(strLists, s => (s.IndexOf("C#") >= 0));
            Console.WriteLine("查找到的包含“C#”的字符串：");
            //使用foreach语句遍历输出
            foreach (string str in strList)
            {
                Console.Write(str + "  ");
            }
            Console.ReadLine();
        }
    }
}
