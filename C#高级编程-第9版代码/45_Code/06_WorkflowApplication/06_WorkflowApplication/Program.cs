using System;
using System.Linq;
using System.Activities;
using System.Activities.Statements;
using System.Threading;
using System.Runtime.DurableInstancing;
using System.Activities.DurableInstancing;
using System.Configuration;
using SharedInterfaces;

namespace _06_WorkflowApplication
{

    class Program
    {
        static void Main(string[] args)
        {
            // Event set when the workflow completes
            ManualResetEvent finished = new ManualResetEvent(false);

            // Event set when a task is ready to process
            AutoResetEvent taskReady = new AutoResetEvent(false);

            // Name of the task to process
            string taskName = string.Empty;

            // Create the workflow app & get the unique ID
            WorkflowApplication app = BuildApplication(finished);
            Guid id = app.Id;

            // Then add the ITaskExtension
            app.Extensions.Add(new TaskExtension
            {
                Execute = (task) =>
                {
                    taskName = task;
                    taskReady.Set();
                }
            });

            // Run the workflow & wait for the taskReady event to be set
            app.Run();
            taskReady.WaitOne();

            // Now process that task and get the outcome
            bool satisfied = ProcessTask(taskName);

            // Now reload the workflow
            app = BuildApplication(finished);

            try
            {
                app.Load(id);

                // And resume the bookmark
                app.ResumeBookmark(taskName, satisfied);

                // Wait for the workflow to complete
                finished.WaitOne();

                Console.WriteLine("Finished processing, press [Enter] to terminate");
                Console.ReadLine();
            }
            catch (InstancePersistenceCommandException ex)
            {
                Console.WriteLine("\r\n********\r\nError when trying to load the workflow - have you setup the database?\r\n********\r\n");
                Console.WriteLine(ex.InnerException.ToString());
            }

        }

        /// <summary>
        /// Construct a workflow application and return to the caller
        /// </summary>
        /// <param name="finished"></param>
        /// <returns></returns>
        private static WorkflowApplication BuildApplication(EventWaitHandle finished)
        {
            // Construct the instance store
            SqlWorkflowInstanceStore store = new SqlWorkflowInstanceStore(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
            store.InstanceCompletionAction = InstanceCompletionAction.DeleteAll;

            // Now create a workflow app
            WorkflowApplication app = new WorkflowApplication(BuildWorkflow());

            app.Completed = (e) => { finished.Set(); };
            app.PersistableIdle = (e) => { return PersistableIdleAction.Unload; };
            app.InstanceStore = store;

            return app;
        }

        /// <summary>
        /// Process the nasmed task - in this case just prompt the user
        /// </summary>
        /// <param name="taskName"></param>
        /// <returns></returns>
        private static bool ProcessTask(string taskName)
        {
            // Now I know a task has shown up, I can prompt the user
            Console.WriteLine("The task '{0}' has shown up.\r\nPlease type 'Y' or 'N' and press [Enter]...", taskName);
            string response = Console.ReadLine();

            bool satisfied = response.IndexOf("Y", StringComparison.CurrentCultureIgnoreCase) > -1;

            return satisfied;
        }

        /// <summary>
        /// Create the workflow used by this example
        /// </summary>
        /// <returns></returns>
        private static Activity BuildWorkflow()
        {
            // What we're building is...
            //
            // If ( Task ( "AskCustomerIfTheyWantACatalogue" ) )
            // Then WriteLine ( "The customer wants a catalogue" )
            //

            Variable<bool> taskSucceeded = new Variable<bool>();

            return new Sequence
            {
                Variables = { taskSucceeded },
                Activities = 
                {
                    new CustomActivities.Task
                    { 
                        TaskName = "AskCustomerIfTheyWantACatalogue",
                        Result = new OutArgument<bool> ( taskSucceeded )
                    },
                    new If 
                    {
                        Condition = new InArgument<bool> ( taskSucceeded ),
                        Then = new WriteLine { Text = "The customer wants a catalogue" }
                    }
                }
            };
        }
    }

    public class TaskExtension : ITaskExtension
    {
        public void ExecuteTask(string taskName)
        {
            Execute(taskName);
        }

        public Action<string> Execute { get; set; }
    }
}
