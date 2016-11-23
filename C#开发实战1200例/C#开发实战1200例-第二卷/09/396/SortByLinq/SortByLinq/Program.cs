using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortByLinq
{
    class Program
    {
        public class Person
        {
            //定义字段
            private string Name;
            private int Age;
            private string Dept;
            //构造函数
            public Person(string Name, int Age, string Dept)
            {
                this.Name = Name;
                this.Age = Age;
                this.Dept = Dept;
            }
            //定义属性
            public string P_name
            {
                get { return Name; }
            }
            public int P_age
            {
                get { return Age; }
            }
            public string P_dept
            {
                get { return Dept; }
            }
        }
        static void Main(string[] args)
        {
             Person[] arr = new Person[] {
                new Person("小刘",30,"软件开发"),
                new Person("小王",26,"软件开发"),
                new Person("小赵",27,"软件测试"),
                new Person("小吕",29,"软件开发"),
            };
            //orderby子句排序，按年龄降序
            var result = from p in arr
                         where p.P_dept == "软件开发"
                         orderby p.P_age descending
                         select new { p.P_name, p.P_age };
            Console.WriteLine("使用orderby子句降序排序：");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            //OrderBy操作符
            var result2 = arr.Where(p => p.P_dept == "软件开发").OrderBy(p => p.P_age).Select(p => new { p.P_name, p.P_age });
            Console.WriteLine("使用OrderBy升序排序：");
            foreach (var item in result2)
            {
                Console.WriteLine(item);
            }
            //OrderByDescending操作符
            var result3 = arr.Where(p => p.P_dept == "软件开发").OrderByDescending(p => p.P_age).Select(p => new { p.P_name, p.P_age });
            Console.WriteLine("使用OrderByDescending降序排序：");
            foreach (var item in result3)
            {
                Console.WriteLine(item);
            }
            //ThenBy操作符
            var result4 = arr.Where(p => p.P_dept == "软件开发").OrderByDescending(p => p.P_age).ThenBy(p => p.P_name).Select(p => new { p.P_name, p.P_age });
            Console.WriteLine("使用ThenBy关键字升序排序：");
            foreach (var item in result4)
            {
                Console.WriteLine(item);
            }
            //ThenByDescending操作符
            var result5 = arr.Where(p => p.P_dept == "软件开发").OrderBy(p => p.P_age).ThenByDescending(p => p.P_name).Select(p => new { p.P_name, p.P_age });
            Console.WriteLine("使用ThenByDescending关键字降序排序：");
            foreach (var item in result5)
            {
                Console.WriteLine(item);
            }
            //Reverse操作符
            var result6 = arr.Select(p => new { p.P_name, p.P_age }).Reverse();
            Console.WriteLine("使用Reverse操作符反转数据顺序：");
            foreach (var item in result6)
            {
                Console.WriteLine(item);
            }
            Console.Read();
        }
    }
}
