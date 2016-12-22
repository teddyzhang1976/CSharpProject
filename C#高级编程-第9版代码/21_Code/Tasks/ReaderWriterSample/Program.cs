using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Wrox.ProCSharp.Threading
{
    class Program
    {
        private static List<int> items = new List<int>() { 0, 1, 2, 3, 4, 5 };
        private static ReaderWriterLockSlim rwl = new
              ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);

        static void ReaderMethod(object reader)
        {
            try
            {
                rwl.EnterReadLock();

                for (int i = 0; i < items.Count; i++)
                {
                    Console.WriteLine("reader {0}, loop: {1}, item: {2}",
                          reader, i, items[i]);
                    Thread.Sleep(40);
                }
            }
            finally
            {
                rwl.ExitReadLock();
            }
        }

        static void WriterMethod(object writer)
        {
            try
            {
                while (!rwl.TryEnterWriteLock(50))
                {
                    Console.WriteLine("Writer {0} waiting for the write lock",
                          writer);
                    Console.WriteLine("current reader count: {0}",
                          rwl.CurrentReadCount);
                }
                Console.WriteLine("Writer {0} acquired the lock", writer);
                for (int i = 0; i < items.Count; i++)
                {
                    items[i]++;
                    Thread.Sleep(50);
                }
                Console.WriteLine("Writer {0} finished", writer);
            }
            finally
            {
                rwl.ExitWriteLock();
            }
        }

        static void Main()
        {
            var taskFactory = new TaskFactory(TaskCreationOptions.LongRunning, TaskContinuationOptions.None);
            var tasks = new Task[6];
            tasks[0] = taskFactory.StartNew(WriterMethod, 1);
            tasks[1] = taskFactory.StartNew(ReaderMethod, 1);
            tasks[2] = taskFactory.StartNew(ReaderMethod, 2);
            tasks[3] = taskFactory.StartNew(WriterMethod, 2);
            tasks[4] = taskFactory.StartNew(ReaderMethod, 3);
            tasks[5] = taskFactory.StartNew(ReaderMethod, 4);

            for (int i = 0; i < 6; i++)
            {
                tasks[i].Wait();
            }
        }
    }

}
