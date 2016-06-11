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
          RaceConditions();
          // Deadlock();

      }

      static void RaceConditions()
      {
          var state = new StateObject();
          for (int i = 0; i < 2; i++)
          {
              new Task(new SampleTask().RaceCondition, state).Start();
          }
      }

      static void Deadlock()
      {
          var s1 = new StateObject();
          var s2 = new StateObject();
          new Task(new SampleTask(s1, s2).Deadlock1).Start();
          new Task(new SampleTask(s1, s2).Deadlock2).Start();

          Thread.Sleep(100000);
      }
   }
}
