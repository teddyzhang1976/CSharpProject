using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TenFactiorial
{
    class Program
    {
        public double factorial(int num)//计算指定数的阶乘
        {
            switch (num)//判断输入的数
            {
                case 1://如果是1
                    return 1;//返回1
                default:
                    return num * factorial(num - 1);//计算阶乘结果
            }
        }
        static void Main(string[] args)
        {
            while (true)//定义一个循环，以便循环输入数据
            {
                Console.WriteLine("输入一个整数：");
                int num = Convert.ToInt32(Console.ReadLine());//记录输入的数字
                Program program = new Program();//创建Program对象
                Console.WriteLine("{0}!的值为{1}", num, program.factorial(num));//输出阶乘结果
            }
        }
    }
}
