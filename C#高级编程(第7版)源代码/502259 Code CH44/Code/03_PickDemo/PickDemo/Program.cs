using System;
using System.Linq;
using System.Activities;
using System.Activities.Statements;
using System.Threading;
using SharedInterfaces;

namespace PickDemo
{

    class Program
    {
        static void Main(string[] args)
        {
            WorkflowApplication app = new WorkflowApplication(new ExpenseClaims());
            ResumeWorkflowService resume = new ResumeWorkflowService(app);
            PromptService.FormsPromptService promptService = new PromptService.FormsPromptService(resume);

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

    public class ResumeWorkflowService : IResumeWorkflow
    {
        public ResumeWorkflowService(WorkflowApplication app)
        {
            _app = app;
        }

        public void Resume(string bookmarkName)
        {
            _app.ResumeBookmark(bookmarkName, null);
        }

        private WorkflowApplication _app;
    }
}
