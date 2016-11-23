using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoAttribute
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("使用自动实现属性记录用户信息\n");
            User P_user = new User();//创建test对象P_Test
            P_user.Name = "刘老师";//为属性赋值
            P_user.Age = 28;//为属性赋值
            Console.Write("用户名：" + P_user.Name + "   年龄：" + P_user.Age);//输出信息
            Console.ReadLine();
        }
    }
    class User
    {
        public string Name { get; set; }//自动实现属性
        public int Age { get; set; }//自动实现属性
    }
}
