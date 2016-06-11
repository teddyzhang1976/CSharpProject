using System;

namespace Wrox.ProCSharp.EntityFramework
{
    class Program
    {
        static void Main()
        {
            using (var data = new PaymentsEntities())
            {
                foreach (var p in data.Payments)
                {
                    Console.WriteLine("{0}, {1} - {2:C}", p.GetType().Name, p.Name, p.Amount);
                }
            }

        }
    }
}
