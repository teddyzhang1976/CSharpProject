using System;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using System.Data;
using System.Data.SqlClient;

namespace Wrox.ProCSharp.EnterpriseServices
{
    [ComVisible(true)]
    public interface IOrderLineUpdate
    {
        void Insert(int orderId, OrderLine orderDetail);
    }

    [Transaction(TransactionOption.Required)]
    [EventTrackingEnabled(true)]
    [ConstructionEnabled(true, Default = "server=(local);database=northwind;trusted_connection=true")]
    [ComVisible(true)]
    public class OrderLineData : ServicedComponent, IOrderLineUpdate
    {
        private string connectionString;

        protected override void Construct(string s)
        {
            connectionString = s;
        }
        public void Insert(int orderId, OrderLine orderDetail)
        {
            var connection = new SqlConnection(connectionString);
            try
            {
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO [Order Details] (OrderId, " +
                   "ProductId, UnitPrice, Quantity)" +
                   "VALUES(@OrderId, @ProductId, @UnitPrice, @Quantity)";
                command.Parameters.AddWithValue("@OrderId", orderId);
                command.Parameters.AddWithValue("@ProductId", orderDetail.ProductId);
                command.Parameters.AddWithValue("@UnitPrice", orderDetail.UnitPrice);
                command.Parameters.AddWithValue("@Quantity", orderDetail.Quantity);

                connection.Open();

                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                ContextUtil.SetAbort();
                throw;
            }
            finally
            {
                connection.Close();
            }
            ContextUtil.SetComplete();
        }
    }
}
