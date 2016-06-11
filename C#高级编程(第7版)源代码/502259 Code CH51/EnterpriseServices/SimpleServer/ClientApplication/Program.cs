using System;


namespace Wrox.ProCSharp.EnterpriseServices
{
    class Program
    {
        static void Main()
        {
            using (SimpleComponent obj = new SimpleComponent())
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(obj.Welcome("Stephanie"));
                }
            }

        }
    }
}
