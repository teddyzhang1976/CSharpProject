using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FilterByLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建并初始化泛型集合
            List<string> color = new List<string>() { "red", "yellow", "green", "black", "blue" };
            //使用where子句
            var result = from c in color
                         where c.Length > 4
                         select c;
            //使用Where操作符
            var result2 = color.Where(u => u.IndexOf("ll") > -1);
            Console.WriteLine("查询长度大于4的字符串：");
            foreach (var item in result)//遍历第一个查询结果
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("查询包含子串ll的字符串：");
            foreach (var item in result2)//遍历第二个查询结果
            {
                Console.WriteLine(item);
            }
            Console.Read();
        }
    }
}
