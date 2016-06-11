using System;
using System.Threading;
using System.Threading.Tasks;

namespace Wrox.ProCSharp.Threading
{
    class Program
    {
        static void Main(string[] args)
        {
            const int taskCount = 4;

            var mEvents = new ManualResetEventSlim[taskCount];
            // var cEvent = new CountdownEvent(taskCount);

            var waitHandles = new WaitHandle[taskCount];
            var calcs = new Calculator[taskCount];

            TaskFactory taskFactory = new TaskFactory();
            for (int i = 0; i < taskCount; i++)
            {
                mEvents[i] = new ManualResetEventSlim(false);
                waitHandles[i] = mEvents[i].WaitHandle;
                calcs[i] = new Calculator(mEvents[i]);
                //calcs[i] = new Calculator(cEvent);

                taskFactory.StartNew(calcs[i].Calculation, Tuple.Create(i + 1, i + 3));

            }

            //cEvent.Wait();
            //Console.WriteLine("all finished");
            //for (int i = 0; i < taskCount; i++)
            //{
            //    Console.WriteLine("task for {0}, result: {1}", i, calcs[i].Result);
            //}

            for (int i = 0; i < taskCount; i++)
            {
                int index = WaitHandle.WaitAny(waitHandles);
                if (index == WaitHandle.WaitTimeout)
                {
                    Console.WriteLine("Timeout!!");
                }
                else
                {
                    mEvents[index].Reset();
                    Console.WriteLine("finished task for {0}, result: {1}",
                                      index, calcs[index].Result);
                }
            }

        }
    }
}
