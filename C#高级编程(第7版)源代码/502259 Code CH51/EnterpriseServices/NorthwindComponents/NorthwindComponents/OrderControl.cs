using System;
using System.EnterpriseServices;
using System.Runtime.InteropServices;

namespace Wrox.ProCSharp.EnterpriseServices
{
    [ComVisible(true)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IOrderControl
    {
        void NewOrder(Order order);
    }

    [Transaction(TransactionOption.Supported)]
    [EventTrackingEnabled(true)]
    [ComVisible(true)]
    public class OrderControl : ServicedComponent, IOrderControl
    {
        [AutoComplete()]
        public void NewOrder(Order order)
        {
            using (OrderData data = new OrderData())
            {
                data.Insert(order);
            }
        }
    }
}
