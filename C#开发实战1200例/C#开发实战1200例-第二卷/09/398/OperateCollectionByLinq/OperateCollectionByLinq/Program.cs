using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperateCollectionByLinq
{
    class Program
    {
        public class Order
        {
            //定义字段
            private int orderid;//订单id
            private string name;//用户姓名
            //构造函数
            public Order(int orderid, string name)
            {
                this.orderid = orderid;
                this.name = name;
            }
            //定义属性
            public int o_id
            {
                get { return orderid; }
            }
            public string Name
            {
                get { return name; }
            }
            //重写ToString()方法
            public override string ToString()
            {
                return "订单号：" + o_id.ToString() + "*********" + "用户姓名：" + Name;
            }
        }
        public struct College
        {
            //定义字段
            public int id;//学院编号
            public string name;//学院名称
            //构造函数
            public College(int id, string name)
            {
                this.id = id;
                this.name = name;
            }
            //定义属性
            public int c_id
            {
                get { return id; }
            }
            public string c_name
            {
                get { return name; }
            }
            //重写ToString()方法
            public override string ToString()
            {
                return "编号：" + c_id.ToString() + "*********" + "学院：" + c_name;
            }
        }
        static void Main(string[] args)
        {
            Order[] od = new Order[]{
                new Order(001,"王一"),
                new Order(002,"赵三"),
                new Order(003,"王一"),
                new Order(004,"张甲"),
                new Order(005,"赵三")
            };
            Order[] od2 = new Order[]{
                new Order(006,"刘亦"),
                new Order(007,"钱一") 
            };
            College[] cg = new College[]{
                new College(01,"电子"),
                new College(02,"计算机"),
                new College(03,"经管"),
                new College(04,"外语") 
            };
            College[] cg2 = new College[]{
                new College(01,"电子"),
                new College(02,"计算机"),
                new College(03,"工管"),
                new College(04,"外语"), 
                new College(05,"艺术"),
            };
            //Distinct避免重复操作
            var distinct =
                (from o in od
                 select new { o.Name }
                ).Distinct();
            Console.WriteLine("去除重复项操作结果：");
            foreach (var item in distinct)
            {
                Console.WriteLine(item);
            }
            //Union合并操作
            var union = od.Union(od2);
            Console.WriteLine("合并操作结果：");
            foreach (var item in union)
            {
                Console.WriteLine(item);
            }
            //Intersect交集操作
            var intersect = cg2.Intersect(cg);
            Console.WriteLine("交集操作结果：");
            foreach (var item in intersect)
            {
                Console.WriteLine(item);
            }
            //Except差集操作
            var except = cg2.Except(cg);
            Console.WriteLine("差集操作结果：");
            foreach (var item in except)
            {
                Console.WriteLine(item);
            }
            Console.Read();
        }
    }
}
