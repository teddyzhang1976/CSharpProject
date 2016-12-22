using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace Formula1Demo
{
  //   [ValueConversion(typeof(int), typeof(double))]
    class Int32ToDouble : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ConvertStringIntDouble(value, targetType);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ConvertStringIntDouble(value, targetType);

        }

        private object ConvertStringIntDouble(object value, Type targetType)
        {
            try
            {
                if (targetType == typeof(string))
                    return System.Convert.ToInt32(value).ToString();
                else
                    return System.Convert.ToInt32(value);
            }
            catch (FormatException)
            {
                return 0;
            }
            catch (ArgumentException)
            {
                return 11;
            }
        }
    }
}
