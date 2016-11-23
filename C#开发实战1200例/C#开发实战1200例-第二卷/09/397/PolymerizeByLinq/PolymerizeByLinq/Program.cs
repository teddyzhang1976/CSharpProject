using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PolymerizeByLinq
{
    class Program
    {
        public class User
        {
            //定义字段
            private string Name;
            private int id;//用户id
            //构造函数
            public User(string Name, int id)
            {
                this.Name = Name;
                this.id = id;
            }
            //定义属性
            public string U_name
            {
                get { return Name; }
            }
            public int U_id
            {
                get { return id; }
            }
        }
        public class Order
        {
            //定义字段
            private int id;//用户id
            private float Money;//消费金额
            //构造函数
            public Order(int id, float Money)
            {
                this.id = id;
                this.Money = Money;
            }
            //定义属性
            public int o_id
            {
                get { return id; }
            }
            public float o_money
            {
                get { return Money; }
            }
        }
        static void Main(string[] args)
        {
            User[] us = new User[]{
                new User("王某",001),
                new User("蔡某",002),
                new User("刘某",003)
            };
            Order[] od = new Order[]{
                new Order(001,130),
                new Order(002,510),
                new Order(003,299),
                new Order(001,1022),
                new Order(003,355)
            };
            //Count操作符
            int result = od.Count(u => u.o_money > 300);
            Console.WriteLine("符合条件的记录个数：" + result.ToString());
            //Sum操作符简单应用
            var user = from o in od
                       where o.o_id == 001
                       select new { o.o_id, o.o_money };
            float result2 = user.Sum(o => o.o_money);
            Console.WriteLine("单用户消费总额：" + result2.ToString());
            //Sum操作符
            var u_sum = from u in us
                        join o in od
                        on u.U_id equals o.o_id
                        into userorder
                        select new { u.U_name, Total = userorder.Sum(o => o.o_money) };
            Console.WriteLine("用户消费情况：");
            foreach (var item in u_sum)
            {
                Console.WriteLine(item);
            }
            //Max操作符
            var ma =
                (from o in od
                 where o.o_id == 003
                 select new { o.o_id, o.o_money }
                ).Max(o => o.o_money);
            Console.WriteLine("单用户消费最多金额：" + ma.ToString());
            //Min操作符       
            var u_min = from u in us
                        join o in od
                        on u.U_id equals o.o_id
                        into userorder
                        select new { u.U_name, Mi = userorder.Min(o => o.o_money) };
            Console.WriteLine("用户消费最少金额：");
            foreach (var item in u_min)
            {
                Console.WriteLine(item);
            }
            //Average操作符        
            var u_avg = from u in us
                        join o in od
                        on u.U_id equals o.o_id
                        into userorder
                        select new { u.U_name, Mi = userorder.Average(o => o.o_money) };
            Console.WriteLine("用户平均消费金额：");
            foreach (var item in u_avg)
            {
                Console.WriteLine(item);
            }
            Console.Read();
        }
    }
}
