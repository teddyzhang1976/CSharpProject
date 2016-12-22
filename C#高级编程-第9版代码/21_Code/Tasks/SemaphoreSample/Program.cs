using System;
using System.Threading;
using System.Threading.Tasks;

namespace Wrox.ProCSharp.Threading
{
  class Program
  {
    static void Main()
    {
      int taskCount = 6;
      int semaphoreCount = 3;
      var semaphore = new SemaphoreSlim(semaphoreCount, semaphoreCount);
      var tasks = new Task[taskCount];

      for (int i = 0; i < taskCount; i++)
      {
        tasks[i] = Task.Run(() => TaskMain(semaphore));
      }

      Task.WaitAll(tasks);

      Console.WriteLine("All tasks finished");
    }


    static void TaskMain(SemaphoreSlim semaphore)
    {
      bool isCompleted = false;
      while (!isCompleted)
      {
        if (semaphore.Wait(600))
        {
          try
          {
            Console.WriteLine("Task {0} locks the semaphore", Task.CurrentId);
            Thread.Sleep(2000);
          }
          finally
          {
            Console.WriteLine("Task {0} releases the semaphore", Task.CurrentId);
            semaphore.Release();
            isCompleted = true;
          }
        }
        else
        {
          Console.WriteLine("Timeout for task {0}; wait again",
             Task.CurrentId);
        }
      }
    }
  }
}
