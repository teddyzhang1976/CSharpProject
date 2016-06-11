using System;
using System.Threading;

namespace Wrox.ProCSharp.Threading
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Main thread: {0}", Thread.CurrentThread.ManagedThreadId);

            AsyncComponent comp = new AsyncComponent();
            comp.LongTaskCompleted += Comp_LongTaskCompleted;

            comp.LongTaskAsync("input", 33);

            Console.ReadLine();
        }

        static void Comp_LongTaskCompleted(object sender, LongTaskCompletedEventArgs e)
        {
            Console.WriteLine("completed result: {0}, thread: {1}", e.Output, Thread.CurrentThread.ManagedThreadId);
        }
    }
}
