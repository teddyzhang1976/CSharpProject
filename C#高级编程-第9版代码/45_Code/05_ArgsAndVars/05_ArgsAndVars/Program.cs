using System;
using System.Linq;
using System.Activities;
using System.Activities.Statements;
using System.Collections.Generic;

namespace _05_ArgsAndVars
{

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("PolicyId", 123);

            WorkflowInvoker.Invoke(new PolicyFlow(), parms);
        }
    }
}
