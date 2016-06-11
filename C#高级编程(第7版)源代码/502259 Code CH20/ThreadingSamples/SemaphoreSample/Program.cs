using System;
using System.Diagnostics;
using System.Threading;

namespace Wrox.ProCSharp.Threading
{
    class Program
    {
        static void Main()
        {
            int threadCount = 6;
            int semaphoreCount = 4;
            var semaphore = new SemaphoreSlim(semaphoreCount, semaphoreCount);
            var threads = new Thread[threadCount];

            for (int i = 0; i < threadCount; i++)
            {
                threads[i] = new Thread(ThreadMain);
                threads[i].Start(semaphore);
            }

            for (int i = 0; i < threadCount; i++)
            {
                threads[i].Join();
            }
            Console.WriteLine("All threads finished");

        }


        static void ThreadMain(object o)
        {
            SemaphoreSlim semaphore = o as SemaphoreSlim;
            Trace.Assert(semaphore != null, "o must be a Semaphore type");
            bool isCompleted = false;
            while (!isCompleted)
            {
                if (semaphore.Wait(600))
                {
                    try
                    {
                        Console.WriteLine("Thread {0} locks the semaphore",
                              Thread.CurrentThread.ManagedThreadId);
                        Thread.Sleep(2000);
                    }
                    finally
                    {
                        semaphore.Release();
                        Console.WriteLine("Thread {0} releases the semaphore",
                           Thread.CurrentThread.ManagedThreadId);
                        isCompleted = true;
                    }
                }
                else
                {
                    Console.WriteLine("Timeout for thread {0}; wait again",
                       Thread.CurrentThread.ManagedThreadId);
                }
            }
        }
    }
}
