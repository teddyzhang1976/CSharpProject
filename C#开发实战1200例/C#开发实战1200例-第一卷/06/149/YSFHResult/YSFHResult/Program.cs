using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YSFHResult
{
    class Program
    {
        #region 约瑟夫环问题算法
        /// <summary>
        /// 约瑟夫环问题算法
        /// </summary>
        /// <param name="total">总人数</param>
        /// <param name="start">开始报数的人</param>
        /// <param name="alter">要出列的人</param>
        /// <returns>返回一个int类型的一维数组</returns>
        static int[] Jose(int total, int start, int alter)
        {
            int j, k = 0;
            //intCounts数组存储按出列顺序的数据，以当结果返回 
            int[] intCounts = new int[total + 1];
            //intPers数组存储初始数据 
            int[] intPers = new int[total + 1];
            //对数组intPers赋初值,第一个人序号为0,第二人为1，依此下去
            for (int i = 0; i < total; i++)
            {
                intPers[i] = i;
            }
            //按出列次序依次存于数组intCounts中 
            for (int i = total; i >= 2; i--)
            {
                start = (start + alter - 1) % i;
                if (start == 0)
                    start = i;
                intCounts[k] = intPers[start];
                k++;
                for (j = start + 1; j <= i; j++)
                    intPers[j - 1] = intPers[j];
            }
            intCounts[k] = intPers[1];
            //结果返回 
            return intCounts;
        }
        #endregion

        static void Main(string[] args)
        {
            int[] intPers = Jose(12, 3, 4);         //调用自定义方法解决约瑟夫环问题
            Console.WriteLine("出列顺序：");
            for (int i = 0; i < intPers.Length; i++)
            {
                Console.Write(intPers[i]+" ");//输出出列顺序
            }
            Console.ReadLine();
        }
    }
}
