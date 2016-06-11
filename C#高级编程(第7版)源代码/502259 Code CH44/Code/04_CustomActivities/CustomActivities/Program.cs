using System;
using System.Linq;
using System.Activities;
using System.Activities.Statements;
using Activities;

namespace CustomActivities
{

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
//                WorkflowInvoker.Invoke(new TestRetry());
                WorkflowInvoker.Invoke(GetWorkflow());
            }
            catch (Exception ex)
            {
                int i = 0;
            }

            int j = 0;
        }

        private static Activity GetWorkflow()
        {
            return new Retry
            {
                NumberOfRetries = new InArgument<int> ( 3 ) ,
                Body = new FailSometimes ( ) 
            };
        }
    }
}
