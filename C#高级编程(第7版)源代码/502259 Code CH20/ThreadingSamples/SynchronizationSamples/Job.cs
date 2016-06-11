using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wrox.ProCSharp.Threading
{
    public class Job
    {
        SharedState sharedState;
        public Job(SharedState sharedState)
        {
            this.sharedState = sharedState;
        }
        public void DoTheJob()
        {
            for (int i = 0; i < 50000; i++)
            {
                // lock (sharedState)
                {
                    sharedState.State += 1;
                    //   sharedState.IncrementState();
                }
            }

        }
    }
}
