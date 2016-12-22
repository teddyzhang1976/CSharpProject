using System;

namespace TuplesSample
{
  class Program
  {
    static void Main()
    {
      Tuple<string, string> name = new Tuple<string, string>("Jochen", "Rindt");
      Console.WriteLine(name.ToString());

      var result = Divide(5, 2);
      Console.WriteLine("result of division: {0}, reminder: {1}", result.Item1, result.Item2);

      AnyElementNumber();
    }

    static void AnyElementNumber()
    {
      var tuple = Tuple.Create<string, string, string, int, int, int, double, Tuple<int, int>>(
          "Stephanie", "Alina", "Nagel", 2009, 6, 2, 1.37, Tuple.Create<int, int>(52, 3490));
      Console.WriteLine(tuple.Item1);
    }

    public static Tuple<int, int> Divide(int dividend, int divisor)
    {
      int result = dividend / divisor;
      int reminder = dividend % divisor;

      return Tuple.Create<int, int>(result, reminder);
    }
  }
}
