using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.ComponentModel;
using System.Data;

namespace Wrox.ProCSharp.EntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            // AllRacers()
            // UseObjectQuery();
            // ObjectQueryFilter();
            // EntitySQL();
            // QueryBuilderMethods();
            // TrackingDemo();
            // ChangeInformation();
            // DetachDemo();
            // LinqQuery1();
            LinqQuery2();
        }

        private static void LinqQuery2()
        {
            using (var data = new Formula1Entities())
            {
                var query = from r in data.Racers
                            from rr in r.RaceResults
                            where rr.Position <= 3 && rr.Position >= 1 && r.Country == "Switzerland"
                            group r by r.Id into g
                            let podium = g.Count()
                            orderby podium descending
                            select new
                            {
                                Racer = g.FirstOrDefault(),
                                Podiums = podium
                            };
                foreach (var r in query)
                {
                    Console.WriteLine("{0} {1} {2}", r.Racer.Firstname, r.Racer.Lastname, r.Podiums);
                }
            }

        }

        private static void LinqQuery1()
        {
            using (var data = new Formula1Entities())
            {
                var racers = from r in data.Racers
                             where r.Wins > 40
                             orderby r.Wins descending
                             select r;
                foreach (Racer r in racers)
                {
                    Console.WriteLine("{0} {1}", r.Firstname, r.Lastname);
                }
            }

        }

        private static void DetachDemo()
        {
            using (var data = new Formula1Entities())
            {
                data.ObjectStateManager.ObjectStateManagerChanged +=
                      ObjectStateManager_ObjectStateManagerChanged;
                ObjectQuery<Racer> racers = data.Racers.Where("it.Lastname='Alonso'");
                Racer fernando = racers.First();
                EntityKey key = fernando.EntityKey;
                data.Racers.Detach(fernando);
                // Racer is now detached and can be changed independent of the object context
                fernando.Starts++;
                Racer originalObject = data.GetObjectByKey(key) as Racer;
                data.Racers.ApplyCurrentValues(fernando);

                
            }

        }

        private static void ChangeInformation()
        {
            using (var data = new Formula1Entities())
            {
                var jaime = new Racer
                {
                    Firstname = "Jaime",
                    Lastname = "Alguersuari",
                    Country = "Spain",
                    Starts = 0
                };
                data.Racers.AddObject(jaime);
                Racer fernando = data.Racers.Where("it.Lastname='Alonso'").First();
                fernando.Starts++;
                DisplayState(EntityState.Added.ToString(),
                    data.ObjectStateManager.GetObjectStateEntries(EntityState.Added));
                DisplayState(EntityState.Modified.ToString(),
                      data.ObjectStateManager.GetObjectStateEntries(EntityState.Modified));
                ObjectStateEntry stateOfFernando =
                      data.ObjectStateManager.GetObjectStateEntry(fernando.EntityKey);
                Console.WriteLine("state of Fernando: {0}",
                      stateOfFernando.State.ToString());
                foreach (string modifiedProp in stateOfFernando.GetModifiedProperties())
                {
                    Console.WriteLine("modified: {0}", modifiedProp);
                    Console.WriteLine("original: {0}", stateOfFernando.OriginalValues[modifiedProp]);
                    Console.WriteLine("current: {0}", stateOfFernando.CurrentValues[modifiedProp]);
                }
                int changes = 0;
                try
                {
                    changes += data.SaveChanges();
                }
                catch (OptimisticConcurrencyException ex)
                {
                    data.Refresh(RefreshMode.ClientWins, ex.StateEntries);
                    changes += data.SaveChanges();
                }
                Console.WriteLine("{0} entities changed", changes);

            }
        }
        static void DisplayState(string state, IEnumerable<ObjectStateEntry> entries)
        {
            foreach (var entry in entries)
            {
                var r = entry.Entity as Racer;
                if (r != null)
                {
                    Console.WriteLine("{0}: {1}", state, r.Lastname);
                }
            }
        }


        private static void TrackingDemo()
        {
            using (var data = new Formula1Entities())
            {
                data.ObjectStateManager.ObjectStateManagerChanged += ObjectStateManager_ObjectStateManagerChanged;
                Racer niki1 = data.Racers.Where("it.Country='Austria' && it.Lastname='Lauda'").First();
                Racer niki2 = data.Racers.Where("it.Country='Austria'").
                      OrderBy("it.Wins DESC").First();
                if (Object.ReferenceEquals(niki1, niki2))
                {
                    Console.WriteLine("the same object");
                }
            }

        }

        static void ObjectStateManager_ObjectStateManagerChanged(object sender,
              CollectionChangeEventArgs e)
        {
            Console.WriteLine("Object State change—action: {0}", e.Action);
            Racer r = e.Element as Racer;
            if (r != null)
                Console.WriteLine("Racer {0}", r.Lastname);
        }


        private static void QueryBuilderMethods()
        {
            using (var data = new Formula1Entities())
            {
                string country = "USA";
                ObjectQuery<Racer> racers = data.Racers.Where("it.Country = @Country",
                   new ObjectParameter("Country", country))
                   .OrderBy("it.Wins DESC, it.Starts DESC")
                   .Top("3");
                foreach (var racer in racers)
                {
                    Console.WriteLine("{0} {1}, wins: {2}, starts: {3}",
                          racer.Firstname, racer.Lastname, racer.Wins, racer.Starts);
                }
            }

        }

        private static void EntitySQL()
        {
            using (var data = new Formula1Entities())
            {
                string country = "Brazil";
                ObjectQuery<Racer> racers = data.CreateQuery<Racer>(
                   "SELECT VALUE it FROM ([Formula1Entities].[Racers]) AS it WHERE it.Country = @Country",
                   new ObjectParameter("Country", country));

                foreach (var r in racers)
                {
                    Console.WriteLine("{0} {1}", r.Firstname, r.Lastname);
                }
            }

        }

        private static void ObjectQueryFilter()
        {
            using (var data = new Formula1Entities())
            {
                string country = "Brazil";
                ObjectQuery<Racer> racers = data.Racers.Where("it.Country = @Country", new ObjectParameter("Country", country));
                Console.WriteLine(racers.CommandText);
                Console.WriteLine(racers.ToTraceString());
            }
        }

        private static void UseObjectQuery()
        {
            using (var data = new Formula1Entities())
            {
                ObjectQuery<Racer> racers = data.CreateQuery<Racer>("[Formula1Entities].[Racers]");
                Console.WriteLine(racers.CommandText);
                Console.WriteLine(racers.ToTraceString());
            }
        }

        private static void AllRacers()
        {
            using (var data = new Formula1Entities())
            {
                ObjectSet<Racer> racers = data.Racers;
                Console.WriteLine(racers.CommandText);
                Console.WriteLine(racers.ToTraceString());
            }
        }
    }
}
