using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    public delegate void DemoDelegate(int x);

    class Demo
    {
        public static void Foo(int x)
        {
            Console.WriteLine("Foo {0}", x);
        }

        public void Bar(int x)
        {
            Console.WriteLine("Bar {0}", x);
        }
    }
}
