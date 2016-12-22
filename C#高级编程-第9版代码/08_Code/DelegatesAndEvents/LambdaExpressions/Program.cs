using System;

namespace Wrox.ProCSharp.Delegates
{
  class Program
  {
    static void Main()
    {
      // SimpleDemos();

      int someVal = 5;
      Func<int, int> f = x => x + someVal;

      someVal = 7;

      Console.WriteLine(f(3));
    }


    static void SimpleDemos()
    {
      Func<string, string> oneParam = s => String.Format("change uppercase {0}", s.ToUpper());
      Console.WriteLine(oneParam("test"));

      Func<double, double, double> twoParams = (x, y) => x * y;
      Console.WriteLine(twoParams(3, 2));

      Func<double, double, double> twoParamsWithTypes = (double x, double y) => x * y;
      Console.WriteLine(twoParamsWithTypes(4, 2));

      Func<double, double> operations = x => x * 2;
      operations += x => x * x;

      ProcessAndDisplayNumber(operations, 2.0);
      ProcessAndDisplayNumber(operations, 7.94);
      ProcessAndDisplayNumber(operations, 1.414);
      Console.WriteLine();
    }

    static void ProcessAndDisplayNumber(Func<double, double> action, double value)
    {
      double result = action(value);
      Console.WriteLine(
         "Value is {0}, result of operation is {1}", value, result);

    }

  }
}
