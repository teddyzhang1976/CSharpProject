using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Wrox.ProCSharp.Linq
{
    class Program
    {
        static void Main()
        {
            // IntroParallel();
            Cancellation();
        }

        static void Cancellation()
        {
            const int arraySize = 100000000;
            var data = new int[arraySize];
            var r = new Random();
            for (int i = 0; i < arraySize; i++)
            {
                data[i] = r.Next(40);
            }

            var cts = new CancellationTokenSource();

            new Thread(() =>
                {
                    try
                    {
                        var sum = (from x in data.AsParallel().WithCancellation(cts.Token)
                                   where x < 80
                                   select x).Sum();
                        Console.WriteLine("query finished, sum: {0}", sum);
                    }
                    catch (OperationCanceledException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }).Start();


            Console.WriteLine("query started");
            Console.Write("cancel? ");
            int input = Console.Read();
            if (input == 'Y' || input == 'y')
            {
                // cancel!
                cts.Cancel();
            }
        }

        static void IntroParallel()
        {
            const int arraySize = 100000000;
            var data = new int[arraySize];
            var r = new Random();
            for (int i = 0; i < arraySize; i++)
			{
			    data[i] = r.Next(40);
			}
            Stopwatch watch = new Stopwatch();
            watch.Start();
            
            var q1 = (from x in Partitioner.Create(data).AsParallel()
                      where x < 80
                     select x).Sum();
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);
        }
    }
}
