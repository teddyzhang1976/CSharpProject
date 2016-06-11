using System;

namespace Wrox
{
   class MainEntryPoint
   {
      static void Main()
      {
         // Try calling some static functions
         Console.WriteLine("Pi is " + MathTest.GetPi());
         int x = MathTest.GetSquareOf(5);
         Console.WriteLine("Square of 5 is " + x);

         // Instantiate at MathTest object
         MathTest math = new MathTest();   // this is C#'s way of
                                           // instantiating a reference type
         
         // Call non-static methods
         math.Value = 30;
         Console.WriteLine(
            "Value field of math variable contains " + math.Value);
         Console.WriteLine("Square of 30 is " + math.GetSquare());
      }
   }

   // Define a class named MathTest on which we will call a method
   class MathTest
   {
      public int Value;

      public int GetSquare()
      {
         return Value*Value;
      }

      public static int GetSquareOf(int x)
      {
         return x*x;
      }

      public static double GetPi()
      {
         return 3.14159;
      }
   }
}
