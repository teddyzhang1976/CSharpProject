using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Wrox.ProCSharp.Linq
{
  class Program
  {
    static void Main()
    {
      IntroParallel();
      // Cancellation();
    }

    static void Cancellation()
    {
      var data = SampleData();

      Console.WriteLine("filled array");
      var sum1 = (from x in data
                  where Math.Log(x) < 4
                  select x).Average();
      Console.WriteLine("sync result {0}", sum1);

      var cts = new CancellationTokenSource();
      
      Task.Factory.StartNew(() =>
        {
          try
          {
            var res = (from x in data.AsParallel().WithCancellation(cts.Token)
                       where Math.Log(x) < 4
                       select x).Average();
            Console.WriteLine("query finished, result: {0}", res);
          }
          catch (OperationCanceledException ex)
          {
            Console.WriteLine(ex.Message);
          }
        });

      Console.WriteLine("query started");
      Console.Write("cancel? ");
      string input = Console.ReadLine();
      if (input.ToLower().Equals("y"))
      {
        cts.Cancel();
        Console.WriteLine("sent a cancel");
      }

      Console.WriteLine("press return to exit");
      Console.ReadLine();
    }

    static IEnumerable<int> SampleData()
    {
      const int arraySize = 100000000;
      var r = new Random();
      return Enumerable.Range(0, arraySize).Select(x => r.Next(140)).ToList();
    }

    static void IntroParallel()
    {
      var data = SampleData();

      var watch = new Stopwatch();

      watch.Start();
      var q1 = (from x in data
                where Math.Log(x) < 4
                select x).Average();
      watch.Stop();
      Console.WriteLine("sync {0}, result: {1}", watch.ElapsedMilliseconds, q1);

      watch.Reset();
      watch.Start();
      var q2 = (from x in Partitioner.Create(data).AsParallel()
                where Math.Log(x) < 4
                select x).Average();
      watch.Stop();
      Console.WriteLine("async {0}, result: {1}", watch.ElapsedMilliseconds, q2);
    }
  }
}
