using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wrox.ProCSharp.Threading
{
    public class SharedState
    {
        private int state = 0;

        public int State { get; set; }


        public int IncrementState()
        {
            //  lock (this)
            {
                return ++state;
            }
            // return Interlocked.Increment(ref state);
        }

    }
}
