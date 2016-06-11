using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Wrox.ProCSharp.Threading
{

    class Program
    {
        static void Main()
        {
            // CancelParallelLoop();
            CancelTask();
            Console.ReadLine();
        }

        static void CancelParallelLoop()
        {
            var cancellationSource = new CancellationTokenSource();
            cancellationSource.Token.ThrowIfCancellationRequested();
            cancellationSource.Token.Register(() => Console.WriteLine("** token cancelled"));

            // start a task that sends a cancel after 500 ms       
            new Task(() =>
               {
                   Thread.Sleep(500);
                   cancellationSource.Cancel(false);
               }).Start();

            try
            {
                ParallelLoopResult result =
                   Parallel.For(0, 100,
                       new ParallelOptions()
                       {
                           CancellationToken = cancellationSource.Token
                       },
                       x =>
                       {
                           Console.WriteLine("loop {0} started", x);
                           int sum = 0;
                           for (int i = 0; i < 100; i++)
                           {
                               Thread.Sleep(2);
                               sum += i;
                           }
                           Console.WriteLine("loop {0} finished", x);
                       });
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void CancelTask()
        {
            var cts = new CancellationTokenSource();
            cts.Token.Register(() => Console.WriteLine("*** task cancelled"));


            // start a task that sends a cancel to the cancellationSource after 500 ms   
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(500);
                cts.Cancel();
            });

            var factory = new TaskFactory(cts.Token);
            Task t1 = factory.StartNew(new Action<object>(f =>
                {
                    Console.WriteLine("in task");
                    for (int i = 0; i < 20; i++)
                    {
                        Thread.Sleep(100);
                        CancellationToken ct = (f as TaskFactory).CancellationToken;
                        if (ct.IsCancellationRequested)
                        {
                            Console.WriteLine("cancelling was requested, cancelling from within the task");
                            ct.ThrowIfCancellationRequested();
                            break;
                        }
                        Console.WriteLine("in loop");
                    }
                    Console.WriteLine("task finished without cancellation");
                }), factory, cts.Token);

            try
            {
                t1.Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine("exception: {0}, {1}", ex.GetType().Name, ex.Message);
                if (ex.InnerException != null)
                    Console.WriteLine("inner excepion: {0}, {1}", ex.InnerException.GetType().Name, ex.InnerException.Message);
            }
            Console.WriteLine("status of the task: {0}", t1.Status);
        }
    }
}
