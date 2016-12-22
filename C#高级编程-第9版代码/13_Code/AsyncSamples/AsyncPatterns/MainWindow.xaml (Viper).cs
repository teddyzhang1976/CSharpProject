using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Wrox.ProCSharp.Async
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private SearchInfo searchInfo;
    private object lockList = new object();
    private CancellationTokenSource cts = new CancellationTokenSource();

    public MainWindow()
    {
      InitializeComponent();
      searchInfo = new SearchInfo();
      this.DataContext = searchInfo;

      BindingOperations.EnableCollectionSynchronization(searchInfo.List, lockList);
    }

    private IEnumerable<IImageRequest> GetSearchRequests()
    {
      return new List<IImageRequest>
      {
        new BingRequest { SearchTerm = searchInfo.SearchTerm },
        new FlickrRequest { SearchTerm = searchInfo.SearchTerm}
      };
    }


    private void OnSearchSync(object sender, RoutedEventArgs e)
    {
      foreach (var req in GetSearchRequests())
      {
        WebClient client = new WebClient();
        string resp = client.DownloadString(req.Url);
        var images = req.Parse(resp);
        foreach (var image in images)
        {
          searchInfo.List.Add(image);
        }

      }
      //var pictures = req1.GetPictureData();
      //foreach (var item in pictures)
      //{
      //  searchInfo.List.Add(item);
      //}
      //foreach (var item in pictures)
      //{
      //  BitmapImage thumbnailImage = new BitmapImage(new Uri(item.ThumbnailUrl), new RequestCachePolicy(RequestCacheLevel.Reload));
      //  BitmapImage image = new BitmapImage(new Uri(item.Url), new RequestCachePolicy(RequestCacheLevel.Reload));
      //  image.DownloadCompleted += (sender1, e1) =>
      //    {
      //      item.ThumbnailImage = thumbnailImage;
      //      item.Image = image;
      //      searchInfo.List.Add(item);
      //    };
      //  // searchInfo.List.Add(item);
      //}
      //var req = new FlickrRequest { SearchTerm = searchInfo.SearchTerm };
      //var client = new WebClient();
      //string resp = client.DownloadString(req.Url);
      //XElement respXml = XElement.Parse(resp);

      //var req = new BingRequest { SearchTerm = searchInfo.SearchTerm };
      //var client = new WebClient();
      //string resp = client.DownloadString(req.Url);

      //XElement respXml = XElement.Parse(resp);
      //XNamespace mms = XNamespace.Get("http://schemas.microsoft.com/LiveSearch/2008/04/XML/multimedia");

      //var q = from item in respXml.Descendants(mms + "ImageResult")
      //        select new SearchItemResult
      //        {
      //          Title = item.Element(mms + "Title").Value,
      //          Url = item.Element(mms + "MediaUrl").Value,
      //          ThumbnailUrl = item.Element(mms + "Thumbnail").Element(mms + "Url").Value
      //        };

      //foreach (var item in q)
      //{
      //  searchInfo.List.Add(item);
      //}
    }

    private void OnSeachAsyncPattern(object sender, RoutedEventArgs e)
    {
      Func<string, string> downloadString = address =>
        {
          var client = new WebClient();
          return client.DownloadString(address);
        };

      Action<SearchItemResult> addItem = item => searchInfo.List.Add(item);

      foreach (var req in GetSearchRequests())
      {
        downloadString.BeginInvoke(req.Url, ar =>
          {
            string resp = downloadString.EndInvoke(ar);
            var images = req.Parse(resp);
            foreach (var image in images)
            {
              this.Dispatcher.Invoke(addItem, image);
            }
          }, null);
      }
    }

    private void OnAsyncEventPattern(object sender, RoutedEventArgs e)
    {
      foreach (var req in GetSearchRequests())
      {
        var client = new WebClient();
        client.DownloadStringCompleted += (sender1, e1) =>
          {
            string resp = e1.Result;
            var images = req.Parse(resp);
            foreach (var image in images)
            {
              searchInfo.List.Add(image);
            }
          };
        client.DownloadStringAsync(new Uri(req.Url));
      }
    }

    private async void OnTaskBasedAsyncPattern(object sender, RoutedEventArgs e)
    {
      try
      {
        foreach (var req in GetSearchRequests())
        {
          var client = new HttpClient();
          var response = await client.GetAsync(req.Url, cts.Token);
          string resp = await response.Content.ReadAsStringAsync();

          await Task.Run(() =>
          {
            var images = req.Parse(resp);
            foreach (var image in images)
            {
              cts.Token.ThrowIfCancellationRequested();
              searchInfo.List.Add(image);
            }
          }, cts.Token);
        }
      }
      catch (OperationCanceledException ex)
      {
        MessageBox.Show(ex.Message);
      }
    }

    private async void OnTaskBasedAsyncPattern1(object sender, RoutedEventArgs e)
    {
      foreach (var req in GetSearchRequests())
      {
        var client = new WebClient();
        string resp = await client.DownloadStringTaskAsync(req.Url);

        var images = req.Parse(resp);
        foreach (var image in images)
        {
          searchInfo.List.Add(image);
        }
      }
    }

    private void OnCancel(object sender, RoutedEventArgs e)
    {
      cts.Cancel();
    }

    private void OnClear(object sender, RoutedEventArgs e)
    {
      searchInfo.List.Clear();
      cts = new CancellationTokenSource();
    }






  }
}
