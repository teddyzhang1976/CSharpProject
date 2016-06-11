using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace Wrox.ProCSharp.Threading
{
    class Program
    {
        static int TakesAWhile(int data, int ms)
        {
            Console.WriteLine("TakesAWhile started");
            Thread.Sleep(ms);
            Console.WriteLine("TakesAWhile completed");
            return ++data;
        }

        public delegate int TakesAWhileDelegate(int data, int ms);

        static void Main()
        {
            // synchronous
            // TakesAWhile(1, 3000);
            TakesAWhileDelegate d1 = TakesAWhile;

            // polling
            //IAsyncResult ar = d1.BeginInvoke(1, 3000, null, null);
            //while (!ar.IsCompleted)
            //{ 
            //   // doing something else
            //   Console.Write("."); 
            //   Thread.Sleep(50);
            //}
            //int result = d1.EndInvoke(ar);
            //Console.WriteLine("result: {0}", result);

            // wait handle
            //IAsyncResult ar = d1.BeginInvoke(1, 3000, null, null);
            //while (true)
            //{
            //   Console.Write(".");
            //   if (ar.AsyncWaitHandle.WaitOne(50, false))
            //   {
            //      Console.WriteLine("Can get the result now");
            //      break;
            //   }
            //}
            //int result = d1.EndInvoke(ar);
            //Console.WriteLine("result: {0}", result);

            // async callback
            //d1.BeginInvoke(1, 3000, TakesAWhileCompleted, d1);
            //for (int i = 0; i < 100; i++)
            //{
            //   Console.Write(".");
            //   Thread.Sleep(50);
            //}

            d1.BeginInvoke(1, 3000,
               ar =>
               {
                   int result = d1.EndInvoke(ar);
                   Console.WriteLine("result: {0}", result);
               },
               null);
            for (int i = 0; i < 100; i++)
            {
                Console.Write(".");
                Thread.Sleep(50);
            }

        }

        static void TakesAWhileCompleted(IAsyncResult ar)
        {
            if (ar == null) throw new ArgumentNullException("ar");

            TakesAWhileDelegate d1 = ar.AsyncState as TakesAWhileDelegate;
            Trace.Assert(d1 != null, "Invalid object type");

            int result = d1.EndInvoke(ar);
            Console.WriteLine("result: {0}", result);
        }
    }
}
