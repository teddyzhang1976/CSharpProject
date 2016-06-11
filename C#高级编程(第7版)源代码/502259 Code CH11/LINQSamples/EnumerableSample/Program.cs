using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wrox.ProCSharp.LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            // Filtering();
            // IndexFiltering();
            // TypeFiltering();K
            // CompoundFrom();
            // Grouping();
            // GroupingWithNestedObjects();
            // Join();
            SetOperations();
            // ZipOperation();
            // Partitioning();
            // Aggregate();
            // Aggregate2();
            Untyped();
        }

        static void Untyped()
        {
            var list = new System.Collections.ArrayList(Formula1.GetChampions() as System.Collections.ICollection);

            var query = from r in list.Cast<Racer>()
                        where r.Country == "USA"
                        orderby r.Wins descending
                        select r;
            foreach (var racer in query)
            {
                Console.WriteLine("{0:A}", racer);
            }

        }

        static void ZipOperation()
        {
            var racerNames = from r in Formula1.GetChampions()
                             where r.Country == "Italy"
                             orderby r.Wins descending
                             select new
                             {
                                 Name = r.FirstName + " " + r.LastName
                             };

            var racerNamesAndStarts = from r in Formula1.GetChampions()
                                   where r.Country == "Italy"
                                   orderby r.Wins descending
                                   select new 
                                   {
                                       LastName = r.LastName,
                                       Starts = r.Starts
                                   };


            //var racers = racerNames.Zip(racerNamesAndStarts, (first, second) => first.Name + ", starts: " + second.Starts);
            //foreach (var r in racers)
            //{
            //    Console.WriteLine(r);
            //}

        }

        static void Aggregate2()
        {
            var countries = (from c in
                                 from r in Formula1.GetChampions()
                                 group r by r.Country into c
                                 select new
                                 {
                                     Country = c.Key,
                                     Wins = (from r1 in c
                                             select r1.Wins).Sum()
                                 }
                             orderby c.Wins descending, c.Country
                             select c).Take(5);

            foreach (var country in countries)
            {
                Console.WriteLine("{0} {1}", country.Country, country.Wins);
            }

        }

        static void Aggregate()
        {
            var query = from r in Formula1.GetChampions()
                        where r.Years.Count() > 3
                        orderby r.Years.Count() descending
                        select new
                        {
                            Name = r.FirstName + " " + r.LastName,
                            TimesChampion = r.Years.Count()
                        };

            foreach (var r in query)
            {
                Console.WriteLine("{0} {1}", r.Name, r.TimesChampion);
            }
        }

        static void Partitioning()
        {
            int pageSize = 5;

            int numberPages = (int)Math.Ceiling(Formula1.GetChampions().Count() /
                  (double)pageSize);

            for (int page = 0; page < numberPages; page++)
            {
                Console.WriteLine("Page {0}", page);

                var racers =
                   (from r in Formula1.GetChampions()
                    orderby r.LastName
                    select r.FirstName + " " + r.LastName).
                   Skip(page * pageSize).Take(pageSize);

                foreach (var name in racers)
                {
                    Console.WriteLine(name);
                }
                Console.WriteLine();
            }

        }

        static void SetOperations()
        {
            Func<string, IEnumerable<Racer>> racersByCar =
                car => from r in Formula1.GetChampions()
                       from c in r.Cars
                       where c == car
                       orderby r.LastName
                       select r;

            Console.WriteLine("World champion with Ferrari and McLaren");
            foreach (var racer in racersByCar("Ferrari").Intersect(racersByCar("McLaren")))
            {
                Console.WriteLine(racer);
            }
        }

        static void Join()
        {
            var racers = from r in Formula1.GetChampions()
                         from y in r.Years
                         where y > 2003
                         select new
                         {
                             Year = y,
                             Name = r.FirstName + " " + r.LastName
                         };

            var teams = from t in
                            Formula1.GetContructorChampions()
                        from y in t.Years
                        where y > 2003
                        select new
                        {
                            Year = y,
                            Name = t.Name
                        };

            var racersAndTeams =
                  from r in racers
                  join t in teams on r.Year equals t.Year
                  select new
                  {
                      Year = r.Year,
                      Racer = r.Name,
                      Team = t.Name
                  };

            Console.WriteLine("Year  Champion " + "Constructor Title");
            foreach (var item in racersAndTeams)
            {
                Console.WriteLine("{0}: {1,-20} {2}",
                   item.Year, item.Racer, item.Team);
            }

        }


        static void GroupingWithNestedObjects()
        {
            var countries = from r in Formula1.GetChampions()
                            group r by r.Country into g
                            orderby g.Count() descending, g.Key
                            where g.Count() >= 2
                            select new
                            {
                                Country = g.Key,
                                Count = g.Count(),
                                Racers = from r1 in g
                                         orderby r1.LastName
                                         select r1.FirstName + " " + r1.LastName
                            };
            foreach (var item in countries)
            {
                Console.WriteLine("{0, -10} {1}", item.Country, item.Count);
                foreach (var name in item.Racers)
                {
                    Console.Write("{0}; ", name);
                }
                Console.WriteLine();
            }

        }

        static void Grouping()
        {
            var countries = from r in Formula1.GetChampions()
                            group r by r.Country into g
                            orderby g.Count() descending, g.Key
                            where g.Count() >= 2
                            select new
                            {
                                Country = g.Key,
                                Count = g.Count()
                            };

            foreach (var item in countries)
            {
                Console.WriteLine("{0, -10} {1}", item.Country, item.Count);
            }

        }

        static void CompoundFrom()
        {
            var ferrariDrivers = from r in Formula1.GetChampions()
                                 from c in r.Cars
                                 where c == "Ferrari"
                                 orderby r.LastName
                                 select r.FirstName + " " + r.LastName;

            foreach (var racer in ferrariDrivers)
            {
                Console.WriteLine(racer);
            }

        }

        static void TypeFiltering()
        {
            object[] data = { "one", 2, 3, "four", "five", 6 };
            var query = data.OfType<string>();
            foreach (var s in query)
            {
                Console.WriteLine(s);
            }

        }

        static void IndexFiltering()
        {
            var racers = Formula1.GetChampions().
                    Where((r, index) => r.LastName.StartsWith("A") && index % 2 != 0);
            foreach (var r in racers)
            {
                Console.WriteLine("{0:A}", r);
            }

        }


        static void Filtering()
        {
            var racers = from r in Formula1.GetChampions()
                         where r.Wins > 15 && (r.Country == "Brazil" || r.Country == "Austria")
                         select r;

            foreach (var r in racers)
            {
                Console.WriteLine("{0:A}", r);
            }

        }
    }
}
