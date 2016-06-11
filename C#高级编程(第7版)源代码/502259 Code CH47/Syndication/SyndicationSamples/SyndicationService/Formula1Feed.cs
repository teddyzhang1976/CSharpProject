using System;
using System.Linq;
using System.ServiceModel.Syndication;
using System.ServiceModel.Web;
using System.Xml.Linq;

namespace Wrox.ProCSharp.Syndication
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Feed1" in both code and config file together.
    public class Formula1Feed : IFormula1Feed
    {
        public SyndicationFeedFormatter CreateFeed()
        {
            DateTime fromDate = DateTime.Today - TimeSpan.FromDays(365);
            DateTime toDate = DateTime.Today;
            string from = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters["from"];
            string to = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters["to"];

            if (from != null && to != null)
            {
                try
                {
                    fromDate = DateTime.Parse(from);
                    toDate = DateTime.Parse(to);
                }
                catch (FormatException)
                {
                    // keep the default dates
                }
            }

            // Create a new Syndication Feed.
            var feed = new SyndicationFeed();
            feed.Generator = "";
            feed.Generator = "Pro C# 4.0 Sample Feed Generator";
            feed.Language = "en-us";
            feed.LastUpdatedTime = new DateTimeOffset(DateTime.Now);
            feed.Title = SyndicationContent.CreatePlaintextContent("Formula1 results");
            feed.Categories.Add(new SyndicationCategory("Formula1"));
            feed.Authors.Add(new SyndicationPerson("web@christiannagel.com",
                  "Christian Nagel", "http://www.christiannagel.com"));
            feed.Description = SyndicationContent.CreatePlaintextContent(
                  "Sample Formula 1");


            using (var data = new Formula1Entities())
            {
                var races = (from racer in data.Racers
                             from raceResult in racer.RaceResults
                             where raceResult.Race.Date > fromDate &&
                                raceResult.Race.Date < toDate &&
                                raceResult.Position == 1
                             orderby raceResult.Race.Date
                             select new
                             {
                                 Country = raceResult.Race.Circuit.Country,
                                 Date = raceResult.Race.Date,
                                 Winner = racer.Firstname + " " + racer.Lastname
                             }).ToArray();


                feed.Items = races.Select(race =>
                    {
                        return new SyndicationItem
                        {
                            Title = SyndicationContent.CreatePlaintextContent(
                                String.Format("G.P. {0}", race.Country)),
                            Content = SyndicationContent.CreateXhtmlContent(
                                new XElement("p",
                                    new XElement("h3", String.Format("{0}, {1}",
                                        race.Country, race.Date.ToShortDateString())),
                                    new XElement("b", String.Format("Winner: {0}", race.Winner))).ToString())
                        };
                    });
             


                // Return ATOM or RSS based on query string
                // rss -> http://localhost:8732/Design_Time_Addresses/SyndicationService/Feed1/
                // atom -> http://localhost:8732/Design_Time_Addresses/SyndicationService/Feed1/?format=atom
                string query = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters["format"];
                SyndicationFeedFormatter formatter = null;
                if (query == "atom")
                {
                    formatter = new Atom10FeedFormatter(feed);
                }
                else
                {
                    formatter = new Rss20FeedFormatter(feed);
                }


                return formatter;
            }
        }
    }
}
