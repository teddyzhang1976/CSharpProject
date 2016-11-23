using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JoinByLinq
{
    class Program
    {
        public struct Users
        {
            //定义字段
            private string Name;
            private int id;//用户id
            //构造函数
            public Users(string Name, int id)
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
        public struct Order
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
            Users[] us = new Users[]{
                new Users("王某",001),
                new Users("蔡某",002),
                new Users("刘某",003)
            };
            Order[] od = new Order[]{
                new Order(001,130),
                new Order(002,510),
                new Order(003,299),
                new Order(001,1022),
                new Order(003,355)
            };
            //Join联接操作
            var join = us.Join(od,
                               u => u.U_id,
                               o => o.o_id,
                               (u, o) => new { u.U_id, u.U_name, o.o_money });
            Console.WriteLine("使用Join方法联接结果如下：");
            foreach (var item in join)
            {
                Console.WriteLine(item);
            }
            //join into子句
            var join_into = from u in us
                            join o in od
                            on u.U_id equals o.o_id
                            into userorder
                            select new { u.U_name, Num = userorder.Count() };
            Console.WriteLine("使用join into子句联接结果如下：");
            foreach (var item in join_into)
            {
                Console.WriteLine(item);
            }
            Console.Read();
        }
    }
}
