using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperateElementByLinq
{
    class Program
    {
        public struct Product
        {
            //定义字段
            private int id;//产品id
            private float price;//单价
            //构造函数
            public Product(int id, float price)
            {
                this.id = id;
                this.price = price;
            }
            //定义属性
            public int p_id
            {
                get { return id; }
            }
            public float p_price
            {
                get { return price; }
            }
            //重写ToString()方法
            public override string ToString()
            {
                return "产品id：" + p_id.ToString() + "*********" + "单价：" + p_price;
            }
        }
        static void Main(string[] args)
        {
            Product[] pdt = new Product[]{
                new Product(001,130),
                new Product(002,510),
                new Product(003,299),
                new Product(004,1022),
                new Product(005,355)
            };
            var first = pdt.First(p => p.p_price > 500);//返回单价大于500的第一个元素
            Console.WriteLine("First操作符（" + first + "）");
            var last = pdt.Last(p => p.p_price < 500);//返回单价小于500的最后一个元素
            Console.WriteLine("Last操作符（" + last + "）");
            var single = pdt.Single(p => p.p_id == 1);//返回产品id为1的元素
            Console.WriteLine("Single操作符（" + single + "）");
            var elementat = pdt.ElementAt(3);//返回第4个元素
            Console.WriteLine("ElementAt操作符（" + elementat + ")");
            Console.Read();
        }
    }
}
