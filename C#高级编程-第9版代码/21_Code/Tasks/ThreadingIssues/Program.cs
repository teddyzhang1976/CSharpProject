using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Wrox.ProCSharp.Threading
{
  class Program
  {
    static void Main()
    {
      // RaceConditions();
      Deadlock();

      Console.ReadLine();

    }

    static void RaceConditions()
    {
      var state = new StateObject();
      for (int i = 0; i < 2; i++)
      {
        Task.Run(() => new SampleTask().RaceCondition(state));
      }
    }

    static void Deadlock()
    {
      var s1 = new StateObject();
      var s2 = new StateObject();
      Task.Run(() => new SampleTask(s1, s2).Deadlock1());
      Task.Run(() => new SampleTask(s1, s2).Deadlock2());

      Thread.Sleep(100000);
    }
  }
}
