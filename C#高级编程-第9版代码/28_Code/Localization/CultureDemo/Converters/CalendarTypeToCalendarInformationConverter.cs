using System;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace CultureDemo.Converters
{
  public class CalendarTypeToCalendarInformationConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      Calendar c = value as Calendar;
      if (c == null) return null;
      StringBuilder calText = new StringBuilder(50);
      calText.Append(c.ToString());
      calText.Remove(0, 21); // remove the namespace
      calText.Replace("Calendar", "");

      GregorianCalendar gregCal = c as GregorianCalendar;
      if (gregCal != null)
      {
        calText.AppendFormat(" {0}", gregCal.CalendarType.ToString());
      }
      return calText.ToString();
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
