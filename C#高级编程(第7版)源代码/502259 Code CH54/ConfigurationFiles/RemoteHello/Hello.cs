using System;

namespace Wrox.ProCSharp.Remoting
{

    public class Hello : System.MarshalByRefObject
    {
        public Hello()
        {
            Console.WriteLine("Constructor called");
        }

        public string Greeting(string name)
        {
            Console.WriteLine("Greeting called");
            return "Hello, " + name;
        }
    }
}

