using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Conversion
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();//创建Program对象
            p.ConvertSequence();//转换序列
            p.ConvertCollectionB();//转换集合
            Console.Read();
        }
        /// <summary>
        /// 转换序列
        /// </summary>
        public void ConvertSequence()
        {
            string[] strs = { "Mary", "Rose", "Jack", "Peter" };//定义字符串数组
            IEnumerable<string> strIESource = strs.Select(i => i.Substring(0, 3));//获取字符串序列
            IEnumerable<object> objIEResult = strIESource.Cast<object>();//把字符串序列转为IEnumerable<object>
            Console.WriteLine("把IEnumerable<string>转换为IEnumerable<object>的运行结果：");
            foreach (object item in objIEResult)//遍历输出IEnumerable<object>序列
            {
                Console.WriteLine(item.ToString());
            }
        }
        /// <summary>
        /// 转换集合方式A
        /// </summary>
        public void ConvertCollectionA()
        {
            string[] strs = { "Mary", "Rose", "Jack", "Peter" };//定义字符串数组
            IEnumerable<string> strIESource = strs.Select(i => i);//获取字符串序列
            List<string> strListSource = new List<string>(strIESource);//实例化List<string>
            List<object> objListResult = new List<object>(strListSource.Cast<object>());//把List<string>转换为List<object>
            Console.WriteLine("把List<string>转换为List<object>的运行结果：");
            foreach (object item in objListResult)//遍历输出List<object>集合
            {
                Console.WriteLine(item.ToString());
            }
        }

        /// <summary>
        /// 转换集合
        /// 把List<string>转换为List<object>
        /// </summary>
        public void ConvertCollectionB()
        {
            string[] strs = { "Mary", "Rose", "Jack", "Peter" };//定义字符串数组
            IEnumerable<string> strIESource = strs.Select(i => i); //获取字符串序列
            List<string> strListSource = new List<string>(strIESource); //实例化List<string>
            List<object> objListResult = strListSource.Cast<object>().ToList();	//把List<string>转换为List<object>
            Console.WriteLine("把List<string>转换为List<object>的运行结果：");
            foreach (object item in objListResult) //遍历输出List<object>集合
            {
                Console.WriteLine(item.ToString()); //输出列表中元素
            }
        }
    }
}
