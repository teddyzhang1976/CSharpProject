using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowInfoByExpandFunc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("使用扩展方法显示员工信息\n");
            (new User() { Name = "刘老师", Age = 28, Pay = 3000 }).Display();//调用扩展方法显示信息
            (new pepole() { Name = "夏老师", Age = 30 }).Show();
        }
    }
    class User
    {
        public string Name { get; set; }//自动实现名称属性
        public int Age { get; set; }//自动实现年龄属性
        public double Pay { get; set; }//自动实现薪资属性
        public override string ToString()
        {
            return string.Format(
                "姓名：{0}  年龄：{1}  工资：{2}", Name, Age, Pay);//对信息进行格式化
        }
    }

    class pepole
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    static class ShwoInfo
    {
        public static void Display(this object o)//定义扩展方法
        {
            Console.WriteLine(o.ToString(), "提示！");//输出信息
            Console.ReadLine();
        }

        public static void Show(this pepole o)
        {
            Console.WriteLine(string.Format("姓名:{0}  年龄：{1}", o.Name, o.Age.ToString()));
            Console.ReadLine();
        }


    }
}
