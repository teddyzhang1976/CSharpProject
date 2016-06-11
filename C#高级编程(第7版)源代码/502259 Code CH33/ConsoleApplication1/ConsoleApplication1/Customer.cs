using System.Data.Linq.Mapping;

namespace ConsoleApplication1
{
    [Table(Name = "Customers")]
    public class Customer
    {
        [Column(IsPrimaryKey = true, Name = "CustomerID")]
        public string MyCustomerID { get; set; }
        [Column]
        public string CompanyName { get; set; }
        //[Column]
        //public string ContactName { get; set; }
        //[Column]
        //public string ContactTitle { get; set; }
        //[Column]
        //public string Address { get; set; }
        //[Column]
        //public string City { get; set; }
        //[Column]
        //public string Region { get; set; }
        //[Column]
        //public string PostalCode { get; set; }
        [Column]
        public string Country { get; set; }
        //[Column]
        //public string Phone { get; set; }
        //[Column]
        //public string Fax { get; set; }
    }
}
