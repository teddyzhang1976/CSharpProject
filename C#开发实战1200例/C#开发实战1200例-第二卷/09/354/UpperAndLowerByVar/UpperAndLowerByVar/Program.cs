using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpperAndLowerByVar
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strWords = { "MingRi", "XiaoKe", "MRBccd" };//定义字符串数组
            //定义隐型查询表达式
            var ChangeWord =
                 from word in strWords
                 select new { Upper = word.ToUpper(), Lower = word.ToLower() };
            //循环访问隐型查询表达式
            foreach (var vWord in ChangeWord)
            {
                Console.WriteLine("大写: {0}, 小写: {1}", vWord.Upper, vWord.Lower);//输出转换后的单词
            }
            Console.ReadLine();
        }
    }
}
