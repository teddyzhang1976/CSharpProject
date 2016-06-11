using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    public enum Suit
    {
        Heart, Diamond, Club, Spade
    }

    class Program
    {
        static void Main(string[] args)
        {
            int x = 1;
            PassingParamters pp = new PassingParamters();
            pp.ChangeVal(ref x);

            int y;
            pp.GetVal(out y);

            long l4 = 3;
            int i4 = (int)l4;

            EventDemo evd = new EventDemo();
            Subscriber subscr = new Subscriber();
            evd.FireEvent();
            evd.DemoEvent += subscr.Handler;
            evd.FireEvent();

            Demo f = new Demo();
            // BarDelegate d1 = new BarDelegate(f.Bar);
            DemoDelegate d1 = f.Bar;
            d1(33);

            DemoDelegate d2 = Demo.Foo;
            DemoDelegate d3 = d1 + d2;

            int i = 0;
            while (i < 3)
            {
                Console.WriteLine(i++);
            }

            i = 0;
            do
            {
                Console.WriteLine(i++);
            } while (i < 3);

            int[] arr1 = { 1, 2, 3 };
            foreach (int i1 in arr1)
            {
                Console.WriteLine(i1);
            }

            short s = 2;
            long l = 3;
            uint i2 = 4;
            ushort s2 = 5;
            ulong l2 = 6;
            Console.WriteLine("{0} {1} {2} {3} {4} {5}",
                i, s, l, i2, s2, l2);

            SomeData d = Singleton.GetObject();

            int[] arr = new int[3] { 1, 2, 3 };
            int[] arr2 = { 1, 2, 3 };

            Color c = Color.Red;

            string col = GetColor(Suit.Diamond);

        }

        static string GetColor(Suit s)
        {
            string color;
            switch (s)
            {
                case Suit.Heart:
                case Suit.Diamond:
                    color = "Red";
                    break;
                case Suit.Spade:
                case Suit.Club:
                    color = "Black";
                    break;
                default:
                    color = "Unknown";
                    break;
            }
            return color;
        }
    }
}
