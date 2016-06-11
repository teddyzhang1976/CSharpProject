using System;
  
namespace Wrox
{
   public class ScopeTest2
   {
      static int j = 20;
      public static void Main()
      {
         int j = 30;
          Console.WriteLine(j);
          return;
       }
   }
}

