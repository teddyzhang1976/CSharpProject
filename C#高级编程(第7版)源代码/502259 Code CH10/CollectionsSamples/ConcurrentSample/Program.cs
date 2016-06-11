using System;
using System.Collections.Concurrent;
using System.Threading;

namespace ConcurrentSample
{
    class Program
    {
        static void Main()
        {
            // BlockingDemo();

            BlockingDemoSimple();


        }

        static void BlockingDemoSimple()
        {
            var sharedCollection = new BlockingCollection<int>();
            var events = new ManualResetEventSlim[2];
            var waits = new WaitHandle[2];
            for (int i = 0; i < 2; i++)
			{
			    events[i] = new ManualResetEventSlim(false);
                waits[i] = events[i].WaitHandle;
			}


            var producer = new Thread(obj =>
            {
                var state = (Tuple<BlockingCollection<int>, ManualResetEventSlim>)obj;
                var coll = state.Item1;
                var ev = state.Item2;
                var r = new Random();

                for (int i = 0; i < 300; i++)
                {
                    coll.Add(r.Next(3000));
                }
                ev.Set();
            });
            producer.Start(Tuple.Create<BlockingCollection<int>, ManualResetEventSlim>(sharedCollection, events[0]));

            var consumer = new Thread(obj =>
            {
                var state = (Tuple<BlockingCollection<int>, ManualResetEventSlim>)obj;
                var coll = state.Item1;
                var ev = state.Item2;

                for (int i = 0; i < 300; i++)
                {
                    int result = coll.Take();
                }
                ev.Set();
            });
            consumer.Start(Tuple.Create<BlockingCollection<int>, ManualResetEventSlim>(sharedCollection, events[1]));

            if (!WaitHandle.WaitAll(waits))
                Console.WriteLine("wait failed");
            else
                Console.WriteLine("reading/writing finished");

        }

        static void BlockingDemo()
        {
            const int threadCount = 10;
            ManualResetEventSlim[] events = new ManualResetEventSlim[threadCount];
            WaitHandle[] waits = new WaitHandle[threadCount];
            var consoleLock = new object();

            for (int thread = 0; thread < threadCount; thread++)
            {
                events[thread] = new ManualResetEventSlim(false);
                waits[thread] = events[thread].WaitHandle;
            }

            var sharedCollection = new BlockingCollection<int>();


            for (int thread = 0; thread < threadCount >> 1; thread++)
            {
                var producer = new Thread((state) =>
                {
                    var coll = ((Tuple<BlockingCollection<int>, ManualResetEventSlim>)state).Item1;
                    var wait = ((Tuple<BlockingCollection<int>, ManualResetEventSlim>)state).Item2;
                    var r = new Random();
                    for (int i = 0; i < 300; i++)
                    {
                        int data = r.Next(30000);
                        if (!coll.TryAdd(data))
                        {
                            Console.WriteLine("**** couldn't add");
                        }
                        else
                        {
                            lock (consoleLock)
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write(" {0} ", data);
                                Console.ResetColor();
                            }
                        }
                        Thread.Sleep(r.Next(40));
                    }
                    wait.Set();
                });
                producer.Start(Tuple.Create<BlockingCollection<int>, ManualResetEventSlim>(sharedCollection, events[thread]));
            }

            Thread.Sleep(500);  // give the producers a headstart

            for (int thread = threadCount >> 1; thread < threadCount; thread++)
            {
                var consumer = new Thread((state) =>
                {
                    var coll = ((Tuple<BlockingCollection<int>, ManualResetEventSlim>)state).Item1;
                    var wait = ((Tuple<BlockingCollection<int>, ManualResetEventSlim>)state).Item2;
                    var r = new Random();
                    for (int i = 0; i < 3000; i++)
                    {
                        int result;
                        if (!coll.TryTake(out result))
                        {
                            Console.WriteLine("couldn't take");
                        }
                        else
                        {
                            lock (consoleLock)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(" {0} ", result);
                                Console.ResetColor();
                            }
                        }

                        Thread.Sleep(r.Next(40));
                    }
                    wait.Set();
                });
                consumer.Start(Tuple.Create<BlockingCollection<int>, ManualResetEventSlim>(sharedCollection, events[thread]));
            }

            if (!WaitHandle.WaitAll(waits))
                Console.WriteLine("error waiting...");

        }
    }
}
