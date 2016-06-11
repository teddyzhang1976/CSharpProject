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

            SimpleTask();
            // ContinuationTask();
            // ParentAndChild();
            // ResultsFromTasks();

            Thread.Sleep(5000);

            //ParentAndChild();

            // HierarchyTasks("c:\\");

            //Parallel.f
            //Task t1 = new Task(() => Console.WriteLine("running in a task"));
            //Task t2 = new Task(() => Console.WriteLine("running in a task"));

            //for (int i = 0; i < 10; i++)
            //{
            //    Task t1 = new Task(o =>
            //    {
            //        Console.WriteLine("running in a task {0}", Thread.CurrentThread.ManagedThreadId);
            //        Thread.Sleep(500);
            //        Console.WriteLine("still running {0}", Thread.CurrentThread.ManagedThreadId);
            //    }, "data", TaskCreationOptions.None);
            //    // t1.RunSynchronously();
            //    t1.Start();



            //}



            //Console.WriteLine("start sleep main");
            //Thread.Sleep(3000);
            //Console.WriteLine("main thread");
        }

        static void ResultsFromTasks()
        {
            var t1 = new Task<Tuple<int,int>>(TaskWithResult, Tuple.Create<int, int>(8, 3));
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

        static void SimpleTask()
        {
            // using task factory
            TaskFactory tf = new TaskFactory();
            Task t1 = tf.StartNew(TaskMethod);

            // using the task factory via a task
            Task t2 = Task.Factory.StartNew(TaskMethod);

            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);

            // using Task constructor
            Task t3 = new Task(TaskMethod);
            // t3.Start();
            t3.RunSynchronously();

            Task t4 = new Task(TaskMethod, TaskCreationOptions.PreferFairness);
            t4.Start();
           

               
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
            Task parent = new Task(ParentTask);
            parent.Start();
            Thread.Sleep(2000);
            Console.WriteLine(parent.Status);
            Thread.Sleep(4000);
            Console.WriteLine(parent.Status);

        }
        static void ParentTask()
        {
            Console.WriteLine("task id {0}", Task.CurrentId);
            Task child = new Task(ChildTask); // , TaskCreationOptions.DetachedFromParent);
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

        static void TaskMethod()
        {
            Console.WriteLine("running in a task");
            Console.WriteLine("Task id: {0} {1}", Task.CurrentId, Thread.CurrentThread.ManagedThreadId);
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
