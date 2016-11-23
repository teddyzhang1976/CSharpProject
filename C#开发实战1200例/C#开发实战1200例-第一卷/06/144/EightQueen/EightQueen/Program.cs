using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EightQueen
{
    class Program
    {
        #region 解决八皇后问题
        /// <summary>
        /// 解决八皇后问题
        /// </summary>
        /// <param name="size">皇后数量</param>
        static void QueenArithmetic(int size)
        {
            int[] Queen = new int[size];//每行皇后的位置
            int y, x, i, j, d, t = 0;
            y = 0;
            Queen[0] = -1;
            while (true)
            {
                for (x = Queen[y] + 1; x < size; x++)
                {
                    for (i = 0; i < y; i++)
                    {
                        j = Queen[i];
                        d = y - i;
                        //检查新皇后是否能与以前的皇后相互攻击
                        if ((j == x) || (j == x - d) || (j == x + d))
                            break;
                    }
                    if (i >= y)
                        break;//不攻击
                }
                if (x == size) //没有合适的位置
                {
                    if (0 == y)
                    {
                        //回溯到了第一行
                        Console.WriteLine("Over");
                        break; //结束
                    }
                    //回溯
                    Queen[y] = -1;
                    y--;
                }
                else
                {
                    Queen[y] = x;//确定皇后的位置
                    y++;//下一个皇后
                    if (y < size)
                        Queen[y] = -1;
                    else
                    {
                        //所有的皇后都排完了，输出
                        Console.WriteLine("\n" + ++t + ':');
                        for (i = 0; i < size; i++)
                        {
                            for (j = 0; j < size; j++)
                                Console.Write(Queen[i] == j ? 'Q' : '*');
                            Console.WriteLine();
                        }
                        y = size - 1;//回溯
                    }
                }
            }
            Console.ReadLine();
        }
        #endregion

        static void Main(string[] args)
        {
            int size = 8;//皇后数
            QueenArithmetic(size);
        }
    }
}
