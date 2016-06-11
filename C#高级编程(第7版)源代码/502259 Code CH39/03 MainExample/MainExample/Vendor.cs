using System;
using System.Collections.Generic;

namespace MainExample
{
    /// <summary>
    /// An example class used when displaying list data
    /// </summary>
    public class Vendor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static List<Vendor> GetVendors()
        {
            List<Vendor> vendors = new List<Vendor>();
            vendors.Add(new Vendor { Name = "Sams Seaside Emporium", Id = 1 });
            vendors.Add(new Vendor { Name = "Jacks Guitar World", Id = 2 });
            vendors.Add(new Vendor { Name = "Thomas's Geek-O-Rama", Id = 3 });

            return vendors;
        }
    }
}
