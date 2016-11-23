using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IniArrayByLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            //初始化了一个长度为3的字符串数组，所有元素的值都是"lsj"
            string[] strA = Enumerable.Repeat<string>("lsj", 3).ToArray();
            Console.Write("字符串数组strA的元素：");
            foreach (string item in strA)			//遍历数组元素输出
            {
                Console.Write(item + ",");
            }
            //初始化了一个长度为3的整型数组，元素的值分别为0、1、2
            int[] intA = Enumerable.Range(0, 3).ToArray<int>();
            Console.Write("\n整型数数组intA的元素：");
            foreach (int item in intA)			//遍历数组元素输出
            {
                Console.Write(item + ",");
            }
            //初始化了一个长度为5的整型数组，元素的值分别为0、10、20、30、40
            int[] intB = Enumerable.Range(0, 5).Select(i => 10 * i).ToArray<int>();
            Console.Write("\n整型数数组intB的元素：");
            foreach (int item in intB)			//遍历数组元素输出
            {
                Console.Write(item + ",");
            }
            Console.Read();
        }
    }
}
