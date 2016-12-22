using System;
using System.Threading;
using System.Threading.Tasks;

namespace Wrox.ProCSharp.Threading
{

  class Program
  {
    static void Main()
    {
      for (int i = 0; i < 5; i++)
      {
        SyncSample();
      }

    }

    static void SyncSample()
    {
      object obj = new object();
      bool lockTaken = false;
      Monitor.TryEnter(obj, 500, ref lockTaken);
      if (lockTaken)
      {
        try
        {
          // acquired the lock
          // synchronized region for obj
        }
        finally
        {
          Monitor.Exit(obj);
        }

      }
      else
      {
        // didn't get the lock, do something else
      }

      int numTasks = 20;
      var state = new SharedState();
      var tasks = new Task[numTasks];

      for (int i = 0; i < numTasks; i++)
      {
        tasks[i] = Task.Run(() => new Job(state).DoTheJob());
      }

      for (int i = 0; i < numTasks; i++)
      {
        tasks[i].Wait();
      }

      Console.WriteLine("summarized {0}", state.State);
    }
  }
}
