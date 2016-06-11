using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Transactions;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {
            NorthwindDataContext dc = new NorthwindDataContext();

            var query = dc.Products;

            foreach (Product item in query)
            {
                Console.WriteLine("{0} | {1} | {2}",
                   item.ProductID, item.ProductName, item.UnitsInStock);
            }

            Console.ReadLine();

            // using ExecuteQuery

            //DataContext dc = new DataContext(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\NORTHWND.MDF;Integrated Security=True;User Instance=True");

            //IEnumerable<Product> myProducts =
            //   dc.ExecuteQuery<Product>("SELECT * FROM PRODUCTS", "");

            //foreach (Product item in myProducts)
            //{
            //    Console.WriteLine(item.ProductID + " | " + item.ProductName);
            //}

            //Console.ReadLine();

            // USING TRANSACTION

            //NorthwindDataContext dc = new NorthwindDataContext();

            //using (TransactionScope myScope = new TransactionScope())
            //{
            //    Product p1 = new Product() { ProductName = "Bill's Product" };
            //    dc.Products.InsertOnSubmit(p1);

            //    Product p2 = new Product() { ProductName = "Another Product" };
            //    dc.Products.InsertOnSubmit(p2);

            //    try
            //    {
            //        dc.SubmitChanges();

            //        Console.WriteLine(p1.ProductID);
            //        Console.WriteLine(p2.ProductID);
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.ToString());
            //    }

            //    myScope.Complete();
            //}

            //Console.ReadLine();

            // PERFORMING JOINS

            //NorthwindDataContext dc = new NorthwindDataContext();
            //dc.Log = Console.Out;

            //var query = from c in dc.Customers
            //            join o in dc.Orders on c.CustomerID equals o.CustomerID
            //            orderby c.CustomerID
            //            select new
            //            {
            //                c.CustomerID,
            //                c.CompanyName,
            //                c.Country,
            //                o.OrderID,
            //                o.OrderDate
            //            };

            //foreach (var item in query)
            //{
            //    Console.WriteLine(item.CustomerID + " | " + item.CompanyName
            //         + " | " + item.Country + " | " + item.OrderID
            //          + " | " + item.OrderDate);
            //}

            //Console.ReadLine();

            // GROUPING ITEMS

            //NorthwindDataContext dc = new NorthwindDataContext();

            //var query = from p in dc.Products
            //            orderby p.Category.CategoryName ascending
            //            group p by p.Category.CategoryName into g
            //            select new { Category = g.Key, Products = g };

            //foreach (var item in query)
            //{
            //    Console.WriteLine(item.Category);

            //    foreach (var innerItem in item.Products)
            //    {
            //        Console.WriteLine("      " + innerItem.ProductName);
            //    }

            //    Console.WriteLine();
            //}

            //Console.ReadLine();



        }
    }
}
