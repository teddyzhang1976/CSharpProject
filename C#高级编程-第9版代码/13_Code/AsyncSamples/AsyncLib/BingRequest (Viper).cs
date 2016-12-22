using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Wrox.ProCSharp.Async
{
  public class BingRequest : Wrox.ProCSharp.Async.IImageRequest
  {
    private const string BingAppId = "8AFBBB42DBABC943BF022DD6F0BF69D554E18AF3";

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
        return string.Format("http://api.bing.net/xml.aspx?AppId={0}&Query={1}&Sources=Image&Version=2.0&Market=en-us&Adult=Moderate&Image.Count={2}&Image.Offset={3}", BingAppId, SearchTerm, Count, Offset);
      }
    }

    public int Count { get; set; }
    public int Offset { get; set; }

    public IEnumerable<SearchItemResult> Parse(string xml)
    {
      XElement respXml = XElement.Parse(xml);
      XNamespace mms = XNamespace.Get("http://schemas.microsoft.com/LiveSearch/2008/04/XML/multimedia");

      return (from item in respXml.Descendants(mms + "ImageResult")
              select new SearchItemResult
              {
                Title = new string(item.Element(mms + "Title").Value.Take(50).ToArray()),
                Url = item.Element(mms + "MediaUrl").Value,
                ThumbnailUrl = item.Element(mms + "Thumbnail").Element(mms + "Url").Value,
                Source = "Bing"
              }).ToList();
    }

    //public IEnumerable<SearchItemResult> GetPictureData()
    //{
    //  var client = new WebClient();
    //  string resp = client.DownloadString(Url);

    //  XElement respXml = XElement.Parse(resp);
    //  XNamespace mms = XNamespace.Get("http://schemas.microsoft.com/LiveSearch/2008/04/XML/multimedia");

    //  return (from item in respXml.Descendants(mms + "ImageResult")
    //          select new SearchItemResult
    //          {
    //            Title = item.Element(mms + "Title").Value,
    //            Url = item.Element(mms + "MediaUrl").Value,
    //            ThumbnailUrl = item.Element(mms + "Thumbnail").Element(mms + "Url").Value
    //          }).ToList();
    //}
    //Func<IEnumerable<SearchItemResult>> getPictureData;
    //public IAsyncResult BeginGetPictureData(AsyncCallback callback, object asyncState)
    //{
    //  if (getPictureData != null)
    //    throw new InvalidOperationException("async operation already active");
    //  getPictureData = GetPictureData;
    //  return getPictureData.BeginInvoke(callback, asyncState);
    //}

    //public IEnumerable<SearchItemResult> EndGetPictureData(IAsyncResult ar)
    //{
    //  var result = getPictureData.EndInvoke(ar);
    //  getPictureData = null;
    //  return result;
    //}


  }
}
