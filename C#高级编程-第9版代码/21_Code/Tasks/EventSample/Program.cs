using System;
using System.Threading;
using System.Threading.Tasks;

namespace Wrox.ProCSharp.Threading
{
  class Program
  {
    static void Main()
    {
      const int taskCount = 4;

      var mEvents = new ManualResetEventSlim[taskCount];
      // var cEvent = new CountdownEvent(taskCount);

      var waitHandles = new WaitHandle[taskCount];
      var calcs = new Calculator[taskCount];

      for (int i = 0; i < taskCount; i++)
      {
        int i1 = i;
        mEvents[i] = new ManualResetEventSlim(false);
        waitHandles[i] = mEvents[i].WaitHandle;
        calcs[i] = new Calculator(mEvents[i]);
        //calcs[i] = new Calculator(cEvent);

        Task.Run(() => calcs[i1].Calculation(i1 + 1, i1 + 3));

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
