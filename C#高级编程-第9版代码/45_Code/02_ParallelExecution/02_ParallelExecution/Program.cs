using System;
using System.Linq;
using System.Activities;
using System.Activities.Statements;

namespace _02_ParallelExecution
{

    class Program
    {
        static void Main(string[] args)
        {
            // Create and cache the workflow definition
            Activity workflow1 = new Workflow1();
            WorkflowInvoker.Invoke(workflow1);
        }
    }
}
