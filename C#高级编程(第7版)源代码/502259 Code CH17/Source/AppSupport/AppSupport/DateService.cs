using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppSupport
{
    public class DateService
    {
        public string GetLongDateInfoString()
        {
            return string.Concat("Today's date is ", DateTime.Now.ToLongDateString());
        }

        public string GetShortDateInfoString()
        {
            return string.Concat("Today's date is ", DateTime.Now.ToShortDateString());
        }
    }
}
