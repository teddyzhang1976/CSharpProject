using Windows.UI.Xaml.Media;
using Wrox.ProCSharp.Extensions;

namespace Wrox.ProCSharp.Model
{

  public class AddMenuCardInfo : BindableBase
  {
    private string title;
    public string Title
    {
      get { return title; }
      set { SetProperty(ref title, value); }
    }

    private string description;
    public string Description
    {
      get { return description; }
      set { SetProperty(ref description, value); }
    }

    private ImageSource image;
    public ImageSource Image
    {
      get { return image; }
      set
      {
        SetProperty(ref image, value);
      }
    }

    private string imageFileName;
    public string ImageFileName
    {
      get { return imageFileName; }
      set
      {
        SetProperty(ref imageFileName, value);
      }
    }
  }
}
