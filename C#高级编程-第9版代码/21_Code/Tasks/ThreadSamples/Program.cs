using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Wrox.ProCSharp.Threading
{
    public class MyThread
    {
        private string data;

        public MyThread(string data)
        {
            this.data = data;
        }

        public void ThreadMain()
        {
            Console.WriteLine("Running in a thread, data: {0}", data);
        }
    }



    public struct Data
    {
        public string Message;
    }


    class Program
    {
        static void Main()
        {
            FirstThread();

            //var t1 = new Thread(Prio);
            //t1.Name = "First";

            //var t2 = new Thread(Prio);
            //t2.Name = "Second";
            //t1.Priority = ThreadPriority.Highest;
            //t2.Priority = ThreadPriority.Lowest;

            //t1.Start();
            //t2.Start();

            //var t1 = new Thread(ThreadMain);
            //t1.Name = "MyNewThread1";
            //t1.IsBackground = true;
            //t1.Start();
            //Console.WriteLine("Main thread ending now...");

            //var d = new Data { Message = "Info" };
            //var t2 = new Thread(ThreadMainWithParameters);
            //t2.Start(d);

            //var obj = new MyThread("info");
            //var t3 = new Thread(obj.ThreadMain);
            //t3.Start();
        }

        static void Prio()
        {
            for (int i = 0; i < 10000; i++)
            {
                Console.WriteLine("{0}, {1}", Thread.CurrentThread.Name, i);
            }
        }

        static void ThreadMain()
        {
            Console.WriteLine("Thread {0} started", Thread.CurrentThread.Name);
            Thread.Sleep(3000);
            // Console.WriteLine("Running in the thread {0}, id: {1}.", Thread.CurrentThread.Name, Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Thread {0} completed", Thread.CurrentThread.Name);
        }

        static void ThreadMainWithParameters(object o)
        {
            Data d = (Data)o;
            Console.WriteLine("Running in a thread, received {0}", d.Message);
        }

        static void FirstThread()
        {
            new Thread(() => Console.WriteLine("Running in a thread, id: {0}", Thread.CurrentThread.ManagedThreadId)).Start();

            Console.WriteLine("This is the main thread, id: {0}", Thread.CurrentThread.ManagedThreadId);
        }
    }
}
