using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _02_ParallelExecution
{
    public class WorkerClass
    {
        public void DoJob1()
        {
            Console.WriteLine("Do Job 1");
            Thread.Sleep(2000);
            Console.WriteLine("Do Job 1 done");
        }

        public void DoJob2()
        {
            Console.WriteLine("Do Job 2");
            Thread.Sleep(3000);
            Console.WriteLine("Do Job 2 done");
        }

        public static int DoMore(int howLong)
        {
            Console.WriteLine("Do More");
            Thread.Sleep(howLong);
            Console.WriteLine("Do More done");

            return 123;
        }
    }
}
