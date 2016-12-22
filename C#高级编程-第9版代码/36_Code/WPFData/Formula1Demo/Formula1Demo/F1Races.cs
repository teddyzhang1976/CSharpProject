using System.Collections.Generic;
using System.Linq;

namespace Formula1Demo
{
    public class F1Races
    {
        private int lastpageSearched = -1;
        private IEnumerable<object> cache = null;
        private Formula1Entities data = new Formula1Entities();

        public IEnumerable<object> GetRaces(int page, int pageSize)
        {
            if (lastpageSearched == page)
                return cache;
            lastpageSearched = page;

            var q = (from r in data.Races
                     from rr in r.RaceResults
                     orderby r.Date ascending
                     select new
                     {
                         Year = r.Date.Year,
                         Country = r.Circuit.Country,
                         Position = rr.Position,
                         Racer = rr.Racer.FirstName + " " + rr.Racer.LastName,
                         Car = rr.Team.Name,
                         Points = rr.Points
                     }).Skip(page * pageSize).Take(pageSize);
            cache = q.ToList();
            return cache;
        }
    }
}
