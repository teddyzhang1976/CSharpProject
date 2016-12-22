using System;
using System.Linq;
using System.Activities;
using System.Activities.Statements;
using System.Threading;

namespace _03_PickDemo
{

    class Program
    {
        static void Main(string[] args)
        {
            WorkflowApplication app = new WorkflowApplication(new ExpenseClaims());
            ResumeWorkflowService resume = new ResumeWorkflowService(app);
            FormsPromptService promptService = new FormsPromptService(resume);

            app.Extensions.Add(promptService);

            ManualResetEvent finished = new ManualResetEvent(false);

            app.Idle = (idleArgs) =>
            {
                Console.WriteLine("Application has idled...");
            };

            app.Completed = (completedArgs) => { finished.Set(); };

            app.Run();

            finished.WaitOne();
        }
    }
}
