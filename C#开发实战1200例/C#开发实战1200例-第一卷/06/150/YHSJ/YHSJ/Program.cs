using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YHSJ
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] Array_int = new int[10][];//定义一个10行的二维数组
            //向数组中记录杨辉三角形的值
            for (int i = 0; i < Array_int.Length; i++)//遍历行数
            {
                Array_int[i] = new int[i + 1];//定义二维数组的列数
                for (int j = 0; j < Array_int[i].Length; j++)//遍历二维数组的列数
                {
                    if (i <= 1)//如果是数组的前两行
                    {
                        Array_int[i][j] = 1;//将其设置为1
                        continue;
                    }
                    else
                    {
                        if (j == 0 || j == Array_int[i].Length - 1)//如果是行首或行尾
                            Array_int[i][j] = 1;//将其设置为1
                        else
                            Array_int[i][j] = Array_int[i - 1][j - 1] + Array_int[i - 1][j];//根据杨辉算法进行计算
                    }
                }
            }
            for (int i = 0; i < Array_int.Length; i++)//输出杨辉三角形
            {
                for (int j = 0; j < Array_int[i].Length; j++)
                    Console.Write("{0}\t", Array_int[i][j]);
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
