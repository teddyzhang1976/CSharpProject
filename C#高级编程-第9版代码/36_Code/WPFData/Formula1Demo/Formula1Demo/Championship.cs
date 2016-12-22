using System;
using System.Collections.Generic;
using System.Linq;

namespace Formula1Demo
{
    public static class F1DataContext
    {
        public static Formula1Entities Data { get; set; }
    }

    public class Championship
    {
        public int Year { get; set; }
        public Lazy<IEnumerable<F1Race>> Races
        {
            get
            {
                return new Lazy<IEnumerable<F1Race>>(() =>
                {
                  return (from r in F1DataContext.Data.Races
                          where r.Date.Year == Year
                          orderby r.Date
                          select new F1Race
                          {
                            Date = r.Date,
                            Country = r.Circuit.Country
                          }).ToList();
                });
            }
        }
    }

    public class F1Race
    {
        public string Country { get; set; }
        public DateTime Date { get; set; }
        public Lazy<IEnumerable<F1RaceResult>> Results
        {
            get
            {
                return new Lazy<IEnumerable<F1RaceResult>>(() =>
                {
                  return (from rr in F1DataContext.Data.RaceResults
                          where rr.Race.Date == this.Date
                          select new F1RaceResult
                          {
                            Position = rr.Position,
                            Racer = rr.Racer.FirstName + " " + rr.Racer.LastName,
                            Car = rr.Team.Name
                          }).ToList();
                });
            }
        }

    }

    public class F1RaceResult
    {
        public int Position { get; set; }
        public string Racer { get; set; }
        public string Car { get; set; }
    }
}
