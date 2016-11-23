using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SelectMonkeyKing
{
    class Program
    {
        public int King(int M, int N)//总人数 M ，数到第 N 个排除
        {
            int k = 0;//定义一个变量，用来存储号码
            for (int i = 2; i <= M; i++)//遍历猴子个数
                k = (k + N) % i;//计算号码值
            return ++k;//返回猴子号码
        }
        static void Main(string[] args)
        {
            Program program = new Program();//创建Program对象
            Console.WriteLine("第" + program.King(10, 3) + "号猴子被选为大王。");//输入被选为大王的号码
            Console.ReadLine();
        }
    }
}
