namespace Wrox.ProCSharp.Async
{
  public class SearchItemResult : BindableBase
  {
    private string title;

    public string Title
    {
      get { return title; }
      set { SetProperty(ref title, value); }
    }

    private string url;
    public string Url
    {
      get { return url; }
      set { SetProperty(ref url, value); }
    }

    private string thumbnailUrl;
    public string ThumbnailUrl
    {
      get { return thumbnailUrl; }
      set { SetProperty(ref thumbnailUrl, value); }
    }

    private string source;
    public string Source
    {
      get { return source; }
      set { SetProperty(ref source, value); }
    }

    //private BitmapImage thumbnailImage;
    //public BitmapImage ThumbnailImage
    //{
    //  get
    //  {
    //    return thumbnailImage;
    //  }
    //  set
    //  {
    //    SetProperty(ref thumbnailImage, value);
    //  }
    //}

    //private BitmapImage image;
    //public BitmapImage Image
    //{
    //  get
    //  {
    //    return image;
    //  }
    //  set
    //  {
    //    SetProperty(ref image, value);
    //  }
    //}

  }
}
