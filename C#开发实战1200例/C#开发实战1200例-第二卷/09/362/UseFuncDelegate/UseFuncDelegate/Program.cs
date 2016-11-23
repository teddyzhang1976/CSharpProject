using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UseFuncDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("使用Func委托实现计算所有员工工资总和\n");
            new Program().FuncDelegate();//调用自定义方法显示汇总信息
        }
        public void FuncDelegate()
        {
            List<User> P_List_user = new List<User>();//创建泛型集合
            //为泛型集合赋值
            P_List_user.Add(new User() { Name = "小刘", Age = 33, Pay = 5000 });
            P_List_user.Add(new User() { Name = "小王", Age = 30, Pay = 5000 });
            P_List_user.Add(new User() { Name = "小赵", Age = 32, Pay = 5000 });
            P_List_user.Add(new User() { Name = "小吕", Age = 30, Pay = 5000 });
            P_List_user.Add(new User() { Name = "小房", Age = 31, Pay = 5000 });
            double Pay = P_List_user.Sum(//调用汇总方法进行汇总
                (pp) =>//定义匿名方法
                {
                    return pp.Pay;//返回汇总数据
                });
            Console.WriteLine("员工工资总和为：" + Pay.ToString());//输出信息
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
