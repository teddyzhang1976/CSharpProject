using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml.Linq;

namespace Wrox.ProCSharp.Async
{
  public class FlickrRequest : IImageRequest
  {
    private const string AppId = "enter your Flickr app-id here";

    public FlickrRequest()
    {
      Count = 50;
      Page = 1;
    }
    private string searchTerm;

    public string SearchTerm
    {
      get { return searchTerm; }
      set { searchTerm = value; }
    }

    public string Url
    {
      get
      {
        return string.Format("http://api.flickr.com/services/rest?api_key={0}&method=flickr.photos.search&content_type=1&text={1}&per_page={2}&page={3}", AppId, SearchTerm, Count, Page);
      }
    }

    public int Count { get; set; }
    public int Page { get; set; }

    public IEnumerable<SearchItemResult> Parse(string xml)
    {
      XElement respXml = XElement.Parse(xml);
      return (from item in respXml.Descendants("photo")
              select new SearchItemResult
              {
                Title = new string(item.Attribute("title").Value.Take(50).ToArray()),
                Url = string.Format("http://farm{0}.staticflickr.com/{1}/{2}_{3}_z.jpg",
                  item.Attribute("farm").Value, item.Attribute("server").Value, item.Attribute("id").Value, item.Attribute("secret").Value),
                ThumbnailUrl = string.Format("http://farm{0}.staticflickr.com/{1}/{2}_{3}_t.jpg",
                  item.Attribute("farm").Value, item.Attribute("server").Value, item.Attribute("id").Value, item.Attribute("secret").Value),
                Source = "Flickr"
              }).ToList();
    }

    public ICredentials Credentials
    {
      get { return null; }
    }
  }
}
