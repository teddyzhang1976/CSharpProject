using System;
using System.Threading;
using System.Threading.Tasks;

namespace Wrox.ProCSharp.Threading
{
    public class Calculator
    {
        private ManualResetEventSlim mEvent;
        private CountdownEvent cEvent;

        public int Result { get; private set; }

        public Calculator(ManualResetEventSlim ev)
        {
            this.mEvent = ev;
        }
        public Calculator(CountdownEvent ev)
        {
            this.cEvent = ev;
        }

        public void Calculation(object obj)
        {
            Tuple<int, int> data = (Tuple<int, int>)obj;
            Console.WriteLine("Task {0} starts calculation", Task.CurrentId);
            Thread.Sleep(new Random().Next(3000));
            Result = data.Item1 + data.Item2;

            // signal the event—completed!
            Console.WriteLine("Task {0} is ready", Task.CurrentId);
            mEvent.Set();
            // cEvent.Signal();
        }
    }

}
