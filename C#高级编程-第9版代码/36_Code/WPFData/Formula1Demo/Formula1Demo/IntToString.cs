using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Diagnostics.Contracts;

namespace Formula1Demo
{
  [ValueConversion(typeof(int), typeof(string))]
  public class IntToString : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {


      try
      {
        if (value.GetType() != typeof(int))
          return "0";
        return value.ToString();
      }
      catch (Exception ex)
      {
        Trace.WriteLine("------------------------------");
        Trace.WriteLine("bah {0}", ex.Message);
        return 0;
      }
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      if (value.GetType() != typeof(string))
        return 0;
      try
      {
        return int.Parse(value as string);
      }
      catch (Exception ex)
      {
        Trace.WriteLine("------------------------------");
        Trace.WriteLine("bah {0}", ex.Message);
        return 0;
      }

    }
  }
}
