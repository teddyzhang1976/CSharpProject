using System;
using System.Collections.ObjectModel;

namespace Wrox.ProCSharp.Collections
{
  class Program
  {
    static void Main()
    {
      var data = new ObservableCollection<string>();
      data.CollectionChanged += Data_CollectionChanged;
      data.Add("One");
      data.Add("Two");
      data.Insert(1, "Three");
      data.Remove("One");

    }

    static void Data_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
      Console.WriteLine("action: {0}", e.Action.ToString());

      if (e.OldItems != null)
      {
        Console.WriteLine("starting index for old item(s): {0}", e.OldStartingIndex);
        Console.WriteLine("old item(s):");
        foreach (var item in e.OldItems)
        {
          Console.WriteLine(item);
        }
      }
      if (e.NewItems != null)
      {
        Console.WriteLine("starting index for new item(s): {0}", e.NewStartingIndex);
        Console.WriteLine("new item(s): ");
        foreach (var item in e.NewItems)
        {
          Console.WriteLine(item);
        }
      }


      Console.WriteLine();

    }
  }
}
