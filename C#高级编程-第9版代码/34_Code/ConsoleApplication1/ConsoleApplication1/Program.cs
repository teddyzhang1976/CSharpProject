using System;
using System.Data.Linq;
using System.Xml.Linq;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {

            //XDocument xdoc = XDocument.Load(@"C:\hamlet.xml"); /// put hamlet.xml in the correct path

            //var query = from people in xdoc.Descendants("PERSONA")
            //            select people.Value;

            //Console.WriteLine("{0} Players Found", query.Count());
            //Console.WriteLine();

            //foreach (var item in query)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.ReadLine();

            XElement xe = new XElement("Company",
            new XElement("CompanyName", "Lipper"),
            new XElement("CompanyAddress",
            new XElement("Address", "123 Main Street"),
            new XElement("City", "St. Louis"),
            new XElement("State", "MO"),
            new XElement("Country", "USA")));

                Console.WriteLine(xe.ToString());
                Console.ReadLine();

            // dealing with RSS

                //XDocument xdoc =
                //    XDocument.Load(@"http://geekswithblogs.net/evjen/Rss.aspx");

                //var query = from rssFeed in xdoc.Descendants("channel")
                //            select new
                //            {
                //                Title = rssFeed.Element("title").Value,
                //                Description = rssFeed.Element("description").Value,
                //                Link = rssFeed.Element("link").Value,
                //            };

                //foreach (var item in query)
                //{
                //    Console.WriteLine("TITLE: " + item.Title);
                //    Console.WriteLine("DESCRIPTION: " + item.Description);
                //    Console.WriteLine("LINK: " + item.Link);
                //}

                //Console.WriteLine();

                //var queryPosts = from myPosts in xdoc.Descendants("item")
                //                 select new
                //                 {
                //                     Title = myPosts.Element("title").Value,
                //                     Published =
                //                        DateTime.Parse(
                //                          myPosts.Element("pubDate").Value),
                //                     Description =
                //                        myPosts.Element("description").Value,
                //                     Url = myPosts.Element("link").Value,
                //                     Comments = myPosts.Element("comments").Value
                //                 };

                //foreach (var item in queryPosts)
                //{
                //    Console.WriteLine(item.Title);
                //}

                //Console.ReadLine();


            // writing to the xml document

                //XDocument xdoc = XDocument.Load(@"C:\hamlet.xml");

                //xdoc.Element("PLAY").Element("PERSONAE").
                //   Element("PERSONA").SetValue("Bill Evjen, king of Denmark");

                //Console.WriteLine(xdoc.Element("PLAY").
                //   Element("PERSONAE").Element("PERSONA").Value);

                //Console.ReadLine();

            // outputting xml

                //NorthwindDataContext dc = new NorthwindDataContext();

                //XElement xe = new XElement("Customer",
                //    from c in dc.Customers
                //    select new XElement("Customer",
                //        new XElement("CustomerId", c.CustomerID),
                //        new XElement("CompanyName", c.CompanyName),
                //        new XElement("Country", c.Country),
                //        new XElement("OrderNum", c.Orders.Count)));

                //xe.Save(@"C:\myCustomers.xml");
                //Console.WriteLine("File created");
                //Console.ReadLine();


        }
    }
}
