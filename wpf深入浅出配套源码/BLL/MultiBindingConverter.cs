using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace WpfApplication1.BLL
{
    public class MultiBindingConverter:IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if(!values.Cast<string>().Any(text=>string.IsNullOrEmpty(text))&&values[0].ToString()==values[1].ToString()&&values[3].ToString()==values[2].ToString())
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 该方法不会被调用
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetTypes"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
