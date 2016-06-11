using System;
  
namespace Wrox
{
   class ArgsExample
   {
      public static int Main(string[] args)
      {	
         for (int i = 0; i < args.Length; i++)
         {
            Console.WriteLine(args[i]);
         }
         return 0;
      }
   }
}
