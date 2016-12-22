using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Wrox.ProCSharp.Model;

namespace Wrox.ProCSharp.Extensions
{
  static class MenuCardExtension
  {
    public static string ToHtml(this MenuCard card)
    {
      return
        new XElement("table",
          new XElement("thead",
            new XElement("td", "Text"),
            new XElement("td", "Price"),
            card.MenuItems.Select(mi =>
              new XElement("tr",
              new XElement("td", mi.Text),
              new XElement("td", mi.Price.ToString("C")))))).ToString();
    }

    public static string ToText(this MenuCard card)
    {
      var sb = new StringBuilder();
      sb.AppendLine(card.Title);
      sb.AppendLine();
      sb.AppendLine(card.Description);
      sb.AppendLine();
      foreach (var menuItem in card.MenuItems)
      {
        sb.AppendFormat("{0}\t\t{1}", menuItem.Text, menuItem.Price);
        sb.AppendLine();
      }
      return sb.ToString();
    }
  }
}
