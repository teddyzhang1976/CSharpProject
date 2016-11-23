using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDBHArith
{
    class Program
    {
        #region  判断一个数是否是素数
        /// <summary>
        /// 判断一个数是否是素数
        /// </summary>
        /// <param name="intNum">要判断的数</param>
        /// <returns>如果是，返回true,否则，返回false</returns>
        static bool IsPrimeNumber(int intNum)
        {
            bool blFlag = true;                 //标识是否是素数
            if (intNum == 1 || intNum == 2)     //判断输入的数字是否是1或者2
                blFlag = true;                  //为bool类型变量赋值
            else
            {
                int sqr = Convert.ToInt32(Math.Sqrt(intNum));   //对要判断的数字进行开方运算
                for (int i = sqr; i >= 2; i--)  //从开方后的数进行循环
                {
                    if (intNum % i == 0)        //对要判断的数字和指定数字进行求余运算
                    {
                        blFlag = false;         //如果余数为0，说明不是素数
                    }
                }
            }
            return blFlag;                      //返回bool型变量
        }
        #endregion

        #region 判断一个数是否符合哥德巴赫猜想
        /// <summary>
        /// 判断一个数是否符合哥德巴赫猜想
        /// </summary>
        /// <param name="intNum">要判断的数</param>
        /// <returns>如果符合，返回true，否则，返回false</returns>
        static bool ISGDBHArith(int intNum)
        {
            bool blFlag = false;                //标识是否符合哥德巴赫猜想
            if (intNum % 2 == 0 && intNum > 6)  //对要判断的数字进行判断
            {
                for (int i = 1; i <= intNum / 2; i++)
                {
                    bool bl1 = IsPrimeNumber(i);             //判断i是否为素数
                    bool bl2 = IsPrimeNumber(intNum - i);    //判断intNum-i是否为素数
                    if (bl1 & bl2)
                    {
                        //输出等式
                        Console.WriteLine("{0}={1}+{2}", intNum, i, intNum - i);
                        blFlag = true;          //符合哥德巴赫猜想
                    }
                }
            }
            return blFlag;                      //返回bool型变量
        }
        #endregion

        static void Main(string[] args)
        {
            Console.WriteLine("输入一个大于6的偶数:");          //提示输入信息
            int intNum = Convert.ToInt32(Console.ReadLine());   //记录输入的数字
            bool blFlag = ISGDBHArith(intNum);                  //判断是否符合哥德巴赫猜想
            if (blFlag)                                         //如果为true，说明符合，并输出信息
            {
                Console.WriteLine("{0}能写成两个素数的和,所以其符合哥德巴赫猜想。", intNum);
            }
            else
            {
                Console.WriteLine("猜想错误。");
            }
            Console.ReadLine();
        }
    }
}
