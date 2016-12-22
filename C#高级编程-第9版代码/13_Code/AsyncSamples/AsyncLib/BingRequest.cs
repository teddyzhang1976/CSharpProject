using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml.Linq;

namespace Wrox.ProCSharp.Async
{
  public class BingRequest : IImageRequest
  {
    private const string AppId = "enter your BING app-id here";

    public BingRequest()
    {
      Count = 50;
      Offset = 0;
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
        return string.Format("https://api.datamarket.azure.com/Data.ashx/Bing/Search/v1/Image?Query=%27{0}%27&$top={1}&$skip={2}&$format=Atom", SearchTerm, Count, Offset);
      }
    }



    public int Count { get; set; }
    public int Offset { get; set; }

    public IEnumerable<SearchItemResult> Parse(string xml)
    {
      XElement respXml = XElement.Parse(xml);
      // XNamespace atom = XNamespace.Get("http://www.w3.org/2005/Atom");
      XNamespace d = XNamespace.Get("http://schemas.microsoft.com/ado/2007/08/dataservices");
      XNamespace m = XNamespace.Get("http://schemas.microsoft.com/ado/2007/08/dataservices/metadata");

      return (from item in respXml.Descendants(m + "properties")
              select new SearchItemResult
              {
                Title = new string(item.Element(d + "Title").Value.Take(50).ToArray()),
                Url = item.Element(d + "MediaUrl").Value,
                ThumbnailUrl = item.Element(d + "Thumbnail").Element(d + "MediaUrl").Value,
                Source = "Bing"
              }).ToList();
    }


    public ICredentials Credentials
    {
      get
      {
        return new NetworkCredential(AppId, AppId);
      }
    }
  }
}
