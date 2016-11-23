using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreateStringByLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();//创建Program对象
            p.CreateSString();//调用自定义方法
            p.CreateTString();//调用自定义方法
            Console.Read();
        }
        private void CreateSString()
        {
            //生成包含6个连续字符的字符串
            string str = new string(Enumerable.Range(0, 6).Select<int, char>(i => (char)(i + 65)).ToArray());
            Console.WriteLine("包含6个连续字符的字符串：" + str);
        }
        private void CreateTString()
        {
            //生成包含3个重复字符串的字符串
            string str = string.Join(string.Empty, Enumerable.Repeat<string>("MR", 3).ToArray());
            Console.WriteLine("包含3个重复字符串的字符串：" + str);
        }
    }
}
