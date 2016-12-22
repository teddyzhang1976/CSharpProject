using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StateSample
{
  [Serializable]
  public class ShoppingCart
  {
    private List<Item> items = new List<Item>();

    public IList<Item> Items
    {
      get
      {
        return items;
      }
    }

    public decimal TotalCost
    {
      get
      {
        return items.Sum(item => item.Cost);
      }
    }
  }

  [Serializable]
  public class Item
  {
    public string Description { get; set; }
    public decimal Cost { get; set; }
  }
}