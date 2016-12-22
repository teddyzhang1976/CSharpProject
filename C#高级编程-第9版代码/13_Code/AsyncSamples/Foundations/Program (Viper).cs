using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foundations
{
  class Program
  {
    static void Main(string[] args)
    {
      // CallerWithAsync();
      CallerWithContinuationTask();
      Console.ReadLine();

    }

    private static void CallerWithContinuationTask()
    {
      Console.WriteLine("started CallerWithContinuationTask in thread {0} and task {1}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);

      Task<string> t1 = GreetingAsync("Stephanie");
      t1.ContinueWith(t =>
        {
          string result = t.Result;
          Console.WriteLine(result);
          Console.WriteLine("finished CallerWithContinuationTask in thread {0} and task {1}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);
        });

    }

    private async static void CallerWithAsync()
    {
      Console.WriteLine("started CallerWithAsync in thread {0} and task {1}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);
      string result = await GreetingAsync("Stephanie");
      Console.WriteLine(result);
      Console.WriteLine("finished GreetingAsync in thread {0} and task {1}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);
    }

    static Task<string> GreetingAsync(string name)
    {
      return Task.Run<string>(() =>
        {
          Console.WriteLine("running greetingasync in thread {0} and task {1}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);
          return Greeting(name);
        });
    }

    static string Greeting(string name)
    {
      Console.WriteLine("running greeting in thread {0} and task {1}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);

      Thread.Sleep(3000);
      return string.Format("Hello, {0}", name);
    }
  }
}
