using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UsePredicateDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().PredicateDelegate();//调用自定义方法显示信息
        }
        public void PredicateDelegate()
        {
            List<User> P_List_user = new List<User>();//创建泛型集合
            //为泛型集合赋值
            P_List_user.Add(new User() { Name = "小刘", Age = 33, Pay = 5000 });
            P_List_user.Add(new User() { Name = "小王", Age = 30, Pay = 5000 });
            P_List_user.Add(new User() { Name = "小赵", Age = 32, Pay = 5000 });
            P_List_user.Add(new User() { Name = "小吕", Age = 30, Pay = 5000 });
            P_List_user.Add(new User() { Name = "小房", Age = 31, Pay = 5000 });
            string P_Str = string.Empty;//定义一个字符串变量，用来记录输出信息
            List<User> P_List_temp = P_List_user.FindAll(//在泛型集合中查找
                (pp) =>//定义匿名方法
                {
                    return pp.Age > 30;//指定查找条件
                });
            P_List_temp.ForEach(//遍历查询结果
                (pp) =>//定义匿名方法
                {
                    //记录查找到的信息
                    P_Str += "姓名：" + pp.Name + "   年龄：" +pp.Age.ToString() + Environment.NewLine;
                });
            Console.WriteLine(P_Str);//输出信息
            Console.ReadLine();
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
    }
}
