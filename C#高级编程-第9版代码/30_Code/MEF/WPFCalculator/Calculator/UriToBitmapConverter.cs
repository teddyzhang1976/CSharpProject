using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Wrox.ProCSharp.MEF
{
  public class UriToBitmapConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      BitmapImage image = null;
      string uri = value.ToString();
      if (uri != null)
      {
        var stream = File.OpenRead(Path.Combine(Properties.Settings.Default.AddInDirectory, uri));
        image = new BitmapImage();
        image.BeginInit();
        image.StreamSource = stream;
        image.EndInit();
        return image;
      }
      else
      {
        return null;
      }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
