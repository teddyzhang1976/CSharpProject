using System.Data.Linq;

namespace ConsoleApplication1
{
    public class MyNorthwindDataContext : DataContext
    {
        public Table<Customer> Customers;

        public MyNorthwindDataContext()
            : base(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\NORTHWND.MDF;Integrated Security=True;User Instance=True")
        {
        }
    }
}
