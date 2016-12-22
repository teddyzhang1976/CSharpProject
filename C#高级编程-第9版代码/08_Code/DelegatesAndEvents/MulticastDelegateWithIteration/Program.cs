using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wrox.ProCSharp.Delegates
{
  class Program
  {
    static void One()
    {
      Console.WriteLine("One");
      throw new Exception("Error in one");
    }

    static void Two()
    {
      Console.WriteLine("Two");
    }


    static void Main()
    {
      //Action d1 = One;
      //d1 += Two;

      //try
      //{
      //    d1();
      //}
      //catch (Exception)
      //{
      //    Console.WriteLine("Exception caught");
      //}

      Action d1 = One;
      d1 += Two;

      Delegate[] delegates = d1.GetInvocationList();
      foreach (Action d in delegates)
      {
        try
        {
          d();
        }
        catch (Exception)
        {
          Console.WriteLine("Exception caught");
        }
      }


    }
  }
}
