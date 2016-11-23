using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace MD5Arithmetic
{
    class Program
    {
        public string Encrypt(string strPwd)
        {
            MD5 md5 = new MD5CryptoServiceProvider();//创建MD5对象
            byte[] data = System.Text.Encoding.Default.GetBytes(strPwd);//将字符编码为一个字节序列
            byte[] md5data = md5.ComputeHash(data);//计算data字节数组的哈希值
            md5.Clear();//清空MD5对象
            string str = "";//定义一个变量，用来记录加密后的密码
            for (int i = 0; i < md5data.Length - 1; i++)//遍历字节数组
            {
                str += md5data[i].ToString("x").PadLeft(2, '0');//对遍历到的字节进行加密
            }
            return str;//返回得到的加密字符串
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("请输入密码：");
                string P_str_Code = Console.ReadLine();//记录要加密的密码
                Program program=new Program();//创建Program对象
                Console.WriteLine("使用MD5加密后的结果为：" + program.Encrypt(P_str_Code));//输出加密后的字符串
            }
        }
    }
}
