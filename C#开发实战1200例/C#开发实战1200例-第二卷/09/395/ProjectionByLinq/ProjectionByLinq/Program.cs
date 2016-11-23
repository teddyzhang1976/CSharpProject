using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectionByLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            //定义Person类型数组
            Person[] arr = new Person[] {
                new Person("小刘",28,"软件开发"),
                new Person("小王",26,"软件开发"),
                new Person("小赵",27,"软件测试")
            };
            //投影操作，插入了索引值
            var result = arr.Select((p, index) => new { index, p.P_name, p.P_dept });
            foreach (var item in result)
            {

                Console.WriteLine(item);
            }
            Console.Read();
        }
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
    }
}
