using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Diagnostics;



namespace Wrox.ProCSharp.Diagnostics
{
  [ContractOption(category: "runtime", setting: "checking", enabled: true)]
  class Program
  {
    static void Main()
    {
      Contract.ContractFailed += (sender, e) =>
      {
        Console.WriteLine(e.Message);
        // e.SetHandled();
      };

      // var p = new Person { FirstName = "Tom", LastName = null }; // contract error
      //var p = new Person { FirstName = "Tom", LastName = "Turbo" };
      //p.Age = 133; // contract error

      Program prog = new Program();
      //prog.SomeData = "init value";
      //prog.Invariant();
      //int x = 7;
      //Invariant(ref x);
      //Postcondition();
      
      int[] data = { 3, 5, 7, 11, 20 };
      // ArrayTest(data);
      // prog.ArrayTestWithPureMethod(data);

      // MinMax(7, 2);
      //Preconditions(null);


      Abbrevations(data);


    }

    private static void Abbrevations(int[] data)
    {
      CheckCollectionContract(data);
    }

    [ContractAbbreviator]
    private static void CheckCollectionContract(int[] data)
    {
      Contract.Requires<ArgumentNullException>(data != null);
      Contract.Requires(Contract.ForAll(data, x => x < 12));
    }

    static int ReturnValue()
    {
      Contract.Ensures(Contract.Result<int>() < 6);
      return 3;
    }

    static int ReturnLargerThanInput(int x)
    {
      Contract.Ensures(Contract.Result<int>() > Contract.OldValue<int>(x));
      return x + 3;
    }

    private static int sharedState = 5;
    static void Postcondition()
    {
      Contract.Ensures(sharedState < 6);
      sharedState = 9;
      Console.WriteLine("change sharedState invariant {0}", sharedState);
      sharedState = 3;
      Console.WriteLine("before returning change it to a valid value {0}", sharedState);
    }

    private int x = 10;

    [ContractInvariantMethod]
    private void ObjectInvariant()
    {
      Contract.Invariant(x > 5);
    }

    public void Invariant()
    {
      // x = 3;
      Console.WriteLine("invariant value: {0}", x);

      // contract failure at the end of the method
    }

    [Pure]
    public void PureMethod()
    {
      SomeData = "New Value";
      Console.WriteLine(SomeData);
    }
    public string SomeData { get; set; }

    static void ArrayTest(int[] data)
    {
      Contract.Requires(Contract.ForAll(data, i => i < 12));


      // Contract.Requires(Contract.Exists(data, i => i < 5));
      Console.WriteLine("ArrayTest contract succeeded");
    }
    
    public void ArrayTestWithPureMethod(int[] data)
    {
      Contract.Requires(Contract.ForAll(data, MyDataCheck));

      Console.WriteLine("ArrayWithPureMethod succeeded");
    }

    public int MaxVal { get; set; }
    public bool MyDataCheck(int x)
    {
      return x <= MaxVal;
    }

    static void OutParameters(out int x, out int y)
    {
      Contract.Ensures(Contract.ValueAtReturn<int>(out x) > 5 && Contract.ValueAtReturn<int>(out x) < 20);
      Contract.Ensures(Contract.ValueAtReturn<int>(out y) % 5 == 0);
      x = 8;
      y = 10;
    }

    static void MinMax(int min, int max)
    {
      Contract.Requires(min <= max);
      Contract.Requires<ArgumentException>(min <= max);
    }

    static void Preconditions(object o)
    {
      Contract.Requires<ArgumentNullException>(o != null, "Preconditions, o may not be null");
      Console.WriteLine(o.GetType().Name);
    }

    static void Foo(object o)
    {
      Contract.Requires(o != null, "o is null!");
      Contract.Ensures(o != null);

      Console.WriteLine("Foo");
    }



  }
}
