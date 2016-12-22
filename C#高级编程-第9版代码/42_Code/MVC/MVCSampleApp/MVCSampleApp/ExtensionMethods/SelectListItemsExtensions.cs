using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSampleApp
{
  public static class SelectListItemsExtensions
  {
    public static IEnumerable<SelectListItem> ToSelectListItems(
        this IDictionary<int, string> dict, int selectedId)
    {
      return dict.Select(item =>
        new SelectListItem
        {
          Selected = item.Key == selectedId,
          Text = item.Value,
          Value = item.Key.ToString()
        });
    }
  }

}