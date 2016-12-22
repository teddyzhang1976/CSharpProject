using System;
using System.Collections.Concurrent;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Wrox.ProCSharp.Collections
{
  class Program
  {
    static void Main()
    {
      // BlockingDemo();

      //BlockingDemoSimple();

      PipelineSample();

      Console.ReadLine();

    }

    private static void ReadFileNames(string path, BlockingCollection<string> output)
    {
      foreach (string filename in Directory.EnumerateFiles(path, "*.cs"))
      {
        output.Add(filename);
      }
      output.CompleteAdding();
    }

    private static void AddOrIncrementValue(string key, ConcurrentDictionary<string, int> dict)
    {
      bool success = false;
      while (!success)
      {
        int value;
        if (dict.TryGetValue(key, out value))
        {
          if (dict.TryUpdate(key, value + 1, value))
          {
            success = true;
          }
        }
        else
        {
          if (dict.TryAdd(key, 1))
          {
            success = true;
          }
        }
      }
    }

    

    private static async void LoadContent(BlockingCollection<string> input, ConcurrentDictionary<string, int> output)
    {
      foreach (var filename in input.GetConsumingEnumerable())
      {
        using (FileStream stream = File.OpenRead(filename))
        {
          var reader = new StreamReader(stream);
          string line = await reader.ReadLineAsync();
          string[] words = line.Split(' ', ';', '\t');
          foreach (var word in words)
          {
            AddOrIncrementValue(word, output);
          }
        }
      }
    }

    private static void TransferContent(ConcurrentDictionary<string, int> input, BlockingCollection<Info> output)
    {
      foreach (var word in input.Keys)
	    {
        int value;
        if (input.TryGetValue(word, out value))
        {
		      output.Add(new Info { Word = word, Count = value });
        }
	    }
    }
    private static void ShowContent(BlockingCollection<Info> input)
    {
      foreach (var item in input.GetConsumingEnumerable())
      {
        Console.WriteLine(item);
      }
    }

    private static async void PipelineSample()
    {
      BlockingCollection<string> coll1 = new BlockingCollection<string>();
      ConcurrentDictionary<string, int> coll2 = new ConcurrentDictionary<string,int>();
      BlockingCollection<Info> coll3 = new BlockingCollection<Info>();
      Task t1 = Task.Factory.StartNew(() => ReadFileNames(@"C:\temp\MvcApplication1\MvcApplication1\Controllers", coll1), TaskCreationOptions.LongRunning);
      Console.WriteLine("started stage 1");
      Task t2 = Task.Factory.StartNew(() => LoadContent(coll1, coll2), TaskCreationOptions.LongRunning);
      Console.WriteLine("started stage 2");
      await Task.WhenAll(t1, t2);
      Console.WriteLine("stage 1 and 2 completed");
      Task t3 = Task.Factory.StartNew(() => TransferContent(coll2, coll3), TaskCreationOptions.LongRunning);
      Task t4 = Task.Factory.StartNew(() => ShowContent(coll3), TaskCreationOptions.LongRunning);
      Console.WriteLine("stages 3 and 4 started");
      await Task.WhenAll(t3, t4);
      Console.WriteLine("all finished");


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

    static async void BlockingDemo()
    {
      const int taskCount = 10;
      ManualResetEventSlim[] events = new ManualResetEventSlim[taskCount];
      WaitHandle[] waits = new WaitHandle[taskCount];
      var consoleLock = new object();

      for (int task = 0; task < taskCount; task++)
      {
        events[task] = new ManualResetEventSlim(false);
        waits[task] = events[task].WaitHandle;
      }

      var sharedCollection = new BlockingCollection<int>();


      for (int task = 0; task < taskCount >> 1; task++)
      {

        var producer = new Task((state) =>
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
        }, Tuple.Create<BlockingCollection<int>, ManualResetEventSlim>(sharedCollection, events[task]));

        producer.Start();
//        producer.Start(Tuple.Create<BlockingCollection<int>, ManualResetEventSlim>(sharedCollection, events[task]));
      }

      await Task.Delay(500); // give the producers a headstart
  

      for (int task = taskCount >> 1; task < taskCount; task++)
      {
        var consumer = new Task((state) =>
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
        }, Tuple.Create<BlockingCollection<int>, ManualResetEventSlim>(sharedCollection, events[task]));
        consumer.Start();
      }

      if (!WaitHandle.WaitAll(waits))
        Console.WriteLine("error waiting...");

    }
  }
}
