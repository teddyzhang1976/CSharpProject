using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace TaskSamples
{
  class Program
  {
    static void Main()
    {
      // ParallelDemo();

      // TasksUsingThreadPool();
      // RunSynchronousTask();
      // LongRunningTask();

      // ResultsFromTasks();
      // ContinuationTask();
      ParentAndChild();

      // HierarchyTasks("c:\\");

    
      Console.ReadLine();
    }

    private static void RunSynchronousTask()
    {
      TaskMethod("just the main thread");
      var t1 = new Task(TaskMethod, "run sync");
      t1.RunSynchronously();
    }

    private static void LongRunningTask()
    {
      var t1 = new Task(TaskMethod, "long running", TaskCreationOptions.LongRunning);
      t1.Start();
    }

    static void ResultsFromTasks()
    {
      var t1 = new Task<Tuple<int, int>>(TaskWithResult, Tuple.Create<int, int>(8, 3));
      t1.Start();
      Console.WriteLine(t1.Result);
      t1.Wait();
      Console.WriteLine("result from task: {0} {1}", t1.Result.Item1, t1.Result.Item2);
    }

    static Tuple<int, int> TaskWithResult(object division)
    {
      Tuple<int, int> div = (Tuple<int, int>)division;
      int result = div.Item1 / div.Item2;
      int reminder = div.Item1 % div.Item2;
      Console.WriteLine("task creates a result...");

      return Tuple.Create<int, int>(result, reminder);
    }

    static void TasksUsingThreadPool()
    {
      var tf = new TaskFactory();
      Task t1 = tf.StartNew(TaskMethod, "using a task factory");

      Task t2 = Task.Factory.StartNew(TaskMethod, "factory via a task");

      var t3 = new Task(TaskMethod, "using a task constructor and Start");
      t3.Start();

      Task t4 = Task.Run(() => TaskMethod("using the Run method"));

    }

    static void ContinuationTask()
    {
      Task t1 = new Task(DoOnFirst);
      Task t2 = t1.ContinueWith(DoOnSecond);
      Task t3 = t1.ContinueWith(DoOnSecond);
      Task t4 = t2.ContinueWith(DoOnSecond);
      Task t5 = t1.ContinueWith(DoOnError, TaskContinuationOptions.OnlyOnFaulted);
      t1.Start();


      Thread.Sleep(5000);

    }


    static void DoOnFirst()
    {
      Console.WriteLine("doing some task {0}", Task.CurrentId);
      Thread.Sleep(3000);
    }

    static void DoOnSecond(Task t)
    {
      Console.WriteLine("task {0} finished", t.Id);
      Console.WriteLine("this task id {0}", Task.CurrentId);
      Console.WriteLine("do some cleanup");
      Thread.Sleep(3000);
    }

    static void DoOnError(Task t)
    {
      Console.WriteLine("task {0} had an error!", t.Id);
      Console.WriteLine("my id {0}", Task.CurrentId);
      Console.WriteLine("do some cleanup");
    }

    static void ParentAndChild()
    {
      var parent = new Task(ParentTask);
      parent.Start();
      Thread.Sleep(2000);
      Console.WriteLine(parent.Status);
      Thread.Sleep(4000);
      Console.WriteLine(parent.Status);

    }
    static void ParentTask()
    {
      Console.WriteLine("task id {0}", Task.CurrentId);
      var child = new Task(ChildTask); // , TaskCreationOptions.DetachedFromParent);
      child.Start();
      Thread.Sleep(1000);
      Console.WriteLine("parent started child");
      // Thread.Sleep(3000);
    }
    static void ChildTask()
    {
      // Console.WriteLine("task id {0}, parent: {1}", Task.Current.Id, Task.Current.Parent.Id);
      Console.WriteLine("child");
      Thread.Sleep(5000);
      Console.WriteLine("child finished");
    }

    static object taskMethodLock = new object();
    static void TaskMethod(object title)
    {
      lock (taskMethodLock)
      {
        Console.WriteLine(title);
        Console.WriteLine("Task id: {0}, thread: {1}",
          Task.CurrentId == null ? "no task" : Task.CurrentId.ToString(),
          Thread.CurrentThread.ManagedThreadId);
        Console.WriteLine("is pooled thread: {0}", Thread.CurrentThread.IsThreadPoolThread);
        Console.WriteLine("is background thread: {0}", Thread.CurrentThread.IsBackground);
        Console.WriteLine();
      }
    }

    static void ParallelDemo()
    {
      // Parallel.For(0, 5, i => Console.WriteLine(i));
      Parallel.For<string>(0, 20, () => "abcd",
          (x, ls, str) =>
          {
            Console.WriteLine(x);
            return "defg";
          },
              (str) =>
              {
                Console.WriteLine("action {0}", str);
              });

      ParallelOptions po = new ParallelOptions();




    }



    //static void ParentAndChild()
    //{
    //    TaskFactory factory = new TaskFactory();
    //    var t1 = factory.StartNew(() =>
    //        {
    //            Console.WriteLine("parent task {0}", Task.CurrentId);

    //            factory.StartNew(() =>
    //                {
    //                    Console.WriteLine("child task {0}", Task.CurrentId);
    //                    Thread.Sleep(2000);
    //                    Console.WriteLine("finished child");
    //                }, TaskCreationOptions.AttachedToParent);

    //            Console.WriteLine("finished parent");
    //        });

    //    t1.Wait();

    //}


  }
}
