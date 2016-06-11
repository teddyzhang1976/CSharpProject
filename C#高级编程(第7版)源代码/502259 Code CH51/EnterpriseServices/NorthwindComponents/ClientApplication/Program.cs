using System;

namespace Wrox.ProCSharp.EnterpriseServices
{
    class Program
    {
        static void Main()
        {
            var order = Order.Create("PICCO", DateTime.Today, "Georg Pipps",
                           "Salzburg", "Austria");
            order.AddOrderLine(OrderLine.Create(16, 17.45F, 2));
            order.AddOrderLine(OrderLine.Create(67, 14, 1));

            using (var orderControl = new OrderControl())
            {
                orderControl.NewOrder(order);
            }

        }
    }
}
