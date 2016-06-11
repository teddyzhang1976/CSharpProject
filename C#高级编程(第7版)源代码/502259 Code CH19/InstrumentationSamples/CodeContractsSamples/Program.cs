using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Diagnostics;



namespace Wrox.ProCSharp.Instrumentation
{
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


            //int x = 7;
            //Invariant(ref x);
            //Postcondition();

            //int[] data = { 3, 5, 7, 11 };
            //ArrayTest(data);

            // MinMax(7, 2);
            //Preconditions(null);
            //PrecondtionsWithLegacyCode(null);

           
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


        static void Invariant(ref int x)
        {
            Contract.Invariant(x > 5);
            x = 3;
            Console.WriteLine("invariant value: {0}", x);
            x = 9;    
        }

        static void ArrayTest(int[] data)
        {
            Contract.Requires(Contract.ForAll(data, i => i < 12));
            

            // Contract.Requires(Contract.Exists(data, i => i < 5));
            Console.WriteLine("ArrayTest contract succeeded");
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

        static void PrecondtionsWithLegacyCode(object o)
        {
            if (o == null) throw new ArgumentNullException("o");
            Contract.EndContractBlock();
        }

    }
}
