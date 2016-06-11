using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    public class SomeData
    {
    }

    public class Singleton
    {
        private static SomeData d = null;
        public static SomeData GetObject()
        {
            if (d == null)
            {
                d = new SomeData();
            }
            return d;
        }
    }
}
