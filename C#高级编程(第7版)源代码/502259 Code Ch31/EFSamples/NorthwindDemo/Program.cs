using System;

namespace Wrox.ProCSharp.EntityFramework
{
    class Program
    {
        static void Main()
        {
            using (var data = new NorthwindEntities())
            {
                data.ContextOptions.LazyLoadingEnabled = false;

                foreach (Customer customer in data.Customers)
                {
                    Console.WriteLine("{0}", customer.CompanyName);

                    foreach (Order order in customer.Orders)
                    {
                        Console.WriteLine("\t{0} {1:d}", order.OrderID, order.OrderDate);
                    }
                }
            }

        }
    }
}
