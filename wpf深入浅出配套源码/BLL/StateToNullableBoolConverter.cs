using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace WpfApplication1.BLL
{
    public class StateToNullableBoolConverter:IValueConverter
    {

        public object Convert(object value, Type targetType, object parameters, System.Globalization.CultureInfo culture)
        {
            State state = (State)value;
            switch (state)
            {
                case State.Available:
                    return true;
                    
                case State.Locked:
                    return false;
                case State.Unknown:
                    
                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameters, System.Globalization.CultureInfo culture)
        {
            bool? nb = (bool?)value;
            switch (nb)
            {
                case true:
                    return State.Available;
                case false:
                    return State.Locked;
                case null:
                default:
                    return State.Unknown;
                    
            }
        }
    }
}
