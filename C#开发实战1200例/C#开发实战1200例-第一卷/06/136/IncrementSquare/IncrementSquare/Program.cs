using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IncrementSquare
{
    class Program
    {
        public string sum(int num)
        {
            string P_str_Expression = "";//定义一个字符串，用来记录表达式
            double sum = 0;//定义一个变量，用来记录结果 
            for (int i = 1; i <= num; i++)//遍历所有要计算的数
            {
                sum += Convert.ToDouble(Math.Pow(i, i));//计算结果并记录
                P_str_Expression += i + "的" + i + "次幂" + " + ";//记录表达式
            }
            return P_str_Expression.Remove(P_str_Expression.Length - 3) + " = " + sum;//返回表达式和结果
        }
        static void Main(string[] args)
        {
            while (true)//定义一个循环，以便循环输入数据
            {
                Console.Write("请输入一个整数:");
                int num = Convert.ToInt32(Console.ReadLine());//记录要计算的数
                Program program = new Program();//创建Program对象
                Console.WriteLine(program.sum(num));//输出结果
            }
        }
    }
}
