using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    public class EventDemo
    {
        public event DemoDelegate DemoEvent;

        public void FireEvent()
        {
            if (DemoEvent != null)
                DemoEvent(44);
        }
    }

    public class Subscriber
    {
        public void Handler(int x)
        {
            Console.WriteLine("Handler {0}", x);
        }
    }
}
