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
            const int numberTasks = 2;
            const int partitionSize = 1000000;
            var data = new List<string>(FillData(partitionSize * numberTasks));

            var barrier = new Barrier(numberTasks + 1);

            var tasks = new Task<int[]>[numberTasks];
            for (int i = 0; i < numberTasks; i++)
            {
                //tasks[i] = taskFactory.StartNew<int[]>(CalculationInTask,
                //    Tuple.Create(i, partitionSize, barrier, data));
                int jobNumber = i;
                tasks[i] = Task.Run(() => CalculationInTask(jobNumber, partitionSize, barrier, data));
            }

            barrier.SignalAndWait();
            var resultCollection = tasks[0].Result.Zip(tasks[1].Result, (c1, c2) =>
                {
                    return c1 + c2;
                });

            char ch = 'a';
            int sum = 0;
            foreach (var x in resultCollection)
            {
                Console.WriteLine("{0}, count: {1}", ch++, x);
                sum += x;
            }

            Console.WriteLine("main finished {0}", sum);
            Console.WriteLine("remaining {0}, phase {1}", barrier.ParticipantsRemaining, barrier.CurrentPhaseNumber);

        }

//        static int[] CalculationInTask(object p)
        static int[] CalculationInTask(int jobNumber, int partitionSize, Barrier barrier, IList<string> coll)
        {
            var data = new List<string>(coll);
            int start = jobNumber * partitionSize;
            int end = start + partitionSize;
            Console.WriteLine("Task {0}: partition from {1} to {2}", Task.CurrentId, start, end);
            int[] charCount = new int[26];
            for (int j = start; j < end; j++)
            {
                char c = data[j][0];
                charCount[c - 97]++;
            }
            Console.WriteLine("Calculation completed from task {0}. {1} times a, {2} times z", Task.CurrentId, charCount[0], charCount[25]);

            barrier.RemoveParticipant();
            Console.WriteLine("Task {0} removed from barrier, remaining participants {1}", Task.CurrentId, barrier.ParticipantsRemaining);
            return charCount;
        }

        public static IEnumerable<string> FillData(int size)
        {
            var data = new List<string>(size);
            var r = new Random();
            for (int i = 0; i < size; i++)
            {
                data.Add(GetString(r));
            }
            return data;
        }
        private static string GetString(Random r)
        {
            var sb = new StringBuilder(6);
            for (int i = 0; i < 6; i++)
            {
                sb.Append((char)(r.Next(26) + 97));
            }
            return sb.ToString();
        }
    }
}
