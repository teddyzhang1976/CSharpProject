using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetMinCommonMultiple
{
    class Program
    {
        public float minGongBeiShu(int n1, int n2)
        {
            int temp = Math.Max(n1, n2);//求两个数的最大值
            n2 = Math.Min(n1, n2);//求两个数中的最小值
            n1 = temp;//记录临时值
            int product = n1 * n2;//求两个数的乘积
            while (n2 != 0)
            {
                n1 = n1 > n2 ? n1 : n2;//使n1中的数大于n2中的数
                int m = n1 % n2;//记录n1求余n2的结果
                n1 = n2;//交换两个数
                n2 = m;//记录求余结果
            }
            return (product / n1);//得到最小公倍数
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("请输入第一个数：");
                int n1 = Convert.ToInt32(Console.ReadLine());//记录第一个数
                Console.Write("请输入第二个数：");
                int n2 = Convert.ToInt32(Console.ReadLine());//记录第二个数
                if (n1 * n2 != 0)//判断两个数中的一个是否为0
                {
                    Program program = new Program();//创建Program对象
                    Console.WriteLine("{0}和{1}的最小公倍数为{2}", n1, n2, program.minGongBeiShu(n1, n2));//输出最小公倍数
                }
                else
                {
                    Console.WriteLine("这两个数不能为0。");
                }
            }
        }
    }
}
