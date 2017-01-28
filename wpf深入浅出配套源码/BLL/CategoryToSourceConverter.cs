using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace WpfApplication1.BLL
{
    public class CategoryToSourceConverter:IValueConverter
    {

        public object Convert(object value, Type targetType, object parameters, System.Globalization.CultureInfo culture)
        {
            Category category = (Category)value;
            switch (category)
            {
                case Category.Bomber:
                    return @"ICONS/Bomber.png";
                   
                case Category.Fighter:
                    return @"ICONS/Fighter.png";
                   
                default:
                    return null;
                    
            }
        }

        public object ConvertBack(object value, Type targetType, object parameters, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
