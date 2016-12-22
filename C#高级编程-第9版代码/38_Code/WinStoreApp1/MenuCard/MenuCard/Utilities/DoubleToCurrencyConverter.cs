using System;
using System.Globalization;
using Windows.UI.Xaml.Data;

namespace Wrox.ProCSharp.Utilities
{
  public class DoubleToCurrencyConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, string language)
    {
      double d = (double)value;
      return string.Format("{0:C}", d);
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
      string s = value.ToString();
      return double.Parse(s, NumberStyles.Currency);
    }
  }
}
