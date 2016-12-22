using System;

namespace AppSupport
{
  public class DateService
  {
    public string GetLongDateInfoString()
    {
      return string.Format("Today's date is {0:D}", DateTime.Today);
    }

    public string GetShortDateInfoString()
    {
      return string.Format("Today's date is {0:d}", DateTime.Today);
    }
  }

}
