using System;

namespace Wrox.ProCSharp.Collections
{
  public class ConsoleHelper
  {
    private static object syncOutput = new object();

    public static void WriteLine(string message)
    {
      lock (syncOutput)
      {
        Console.WriteLine(message);
      }
    }

    public static void WriteLine(string message, string color)
    {
      lock (syncOutput)
      {
        Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color);
        Console.WriteLine(message);
        Console.ResetColor();
      }
    }
  }
}
