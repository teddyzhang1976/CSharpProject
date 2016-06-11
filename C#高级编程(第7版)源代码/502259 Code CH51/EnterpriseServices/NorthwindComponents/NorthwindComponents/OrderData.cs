using System;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.Runtime.InteropServices;

namespace Wrox.ProCSharp.EnterpriseServices
{
    [ComVisible(true)]
    public interface IOrderUpdate
    {
        void Insert(Order order);
    }

    [Transaction(TransactionOption.Required)]
    [EventTrackingEnabled(true)]
    [ConstructionEnabled(true, Default = "server=(local);database=northwind;trusted_connection=true")]
    [ComVisible(true)]
    public class OrderData : ServicedComponent, IOrderUpdate
    {
        private string connectionString;

        protected override void Construct(string s)
        {
            connectionString = s;
        }

        [AutoComplete()]
        public void Insert(Order order)
        {
            var connection = new SqlConnection(connectionString);

            try
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Orders (CustomerId," +
                   "OrderDate, ShipAddress, ShipCity, ShipCountry)" +
                   "VALUES(@CustomerId, @OrderDate, @ShipAddress, @ShipCity, " +
                   "@ShipCountry)";
                command.Parameters.AddWithValue("@CustomerId", order.CustomerId);
                command.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                command.Parameters.AddWithValue("@ShipAddress", order.ShipAddress);
                command.Parameters.AddWithValue("@ShipCity", order.ShipCity);
                command.Parameters.AddWithValue("@ShipCountry", order.ShipCountry);

                connection.Open();

                command.ExecuteNonQuery();

                command.CommandText = "SELECT @@IDENTITY AS 'Identity'";
                object identity = command.ExecuteScalar();
                order.SetOrderId(Convert.ToInt32(identity));
                using (var updateOrderLine = new OrderLineData())
                {
                    foreach (var orderLine in order.OrderLines)
                    {
                        updateOrderLine.Insert(order.OrderId, orderLine);
                    }
                }

                System.Threading.Thread.Sleep(10000);   // only for monitoring
            }
            finally
            {
                connection.Close();
            }
        }
    }
}




