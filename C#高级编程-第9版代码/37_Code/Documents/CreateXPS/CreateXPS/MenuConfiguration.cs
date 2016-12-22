using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wrox.ProCSharp.Documents
{
  [Serializable]
  public class MenuConfigDay
  {
    public DayOfWeek DayOfWeek { get; set; }
    public decimal Price { get; set; }
  }

  [Serializable]
  public class MenuConfiguration
  {
    public MenuConfiguration()
    {
      MenuConfig = new List<MenuConfigDay>();
    }

    public List<MenuConfigDay> MenuConfig { get; set; }
  }


}
