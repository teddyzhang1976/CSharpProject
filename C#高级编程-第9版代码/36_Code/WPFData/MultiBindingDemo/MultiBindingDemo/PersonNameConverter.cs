using System;
using System.Globalization;
using System.Windows.Data;

namespace Wrox.ProCSharp.WPF
{

  public class PersonNameConverter : IMultiValueConverter
  {
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
      switch (parameter as string)
      {
        case "FirstLast":
          return values[0] + " " + values[1];
        case "LastFirst":
          return values[1] + ", " + values[0];
        default:
          throw new ArgumentException(String.Format("invalid argument {0}", parameter));
      }
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
      throw new NotSupportedException();
    }

  }
}
