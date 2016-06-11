#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;

#endregion

namespace WorkflowPersistence
{
    class Program
    {
        static void Main(string[] args)
        {
            string conn = "Initial Catalog=WF;Data Source=.;Integrated Security=SSPI";

            using(WorkflowRuntime workflowRuntime = new WorkflowRuntime())
            {
                workflowRuntime.AddService(new SqlWorkflowPersistenceService(conn, true, new TimeSpan(1,0,0), new TimeSpan(0,10,0)));

                AutoResetEvent waitHandle = new AutoResetEvent(false);
                workflowRuntime.WorkflowCompleted += delegate(object sender, WorkflowCompletedEventArgs e) {waitHandle.Set();};
                workflowRuntime.WorkflowTerminated += delegate(object sender, WorkflowTerminatedEventArgs e)
                {
                    Console.WriteLine(e.Exception.Message);
                    waitHandle.Set();
                };

                workflowRuntime.WorkflowIdled += delegate(object sender, WorkflowEventArgs e)
                {
                    Console.WriteLine("Workflow idled: {0}", e.WorkflowInstance.InstanceId);
                };

                workflowRuntime.WorkflowPersisted += delegate(object sender, WorkflowEventArgs e)
                {
                    Console.WriteLine("Workflow persisted: {0}", e.WorkflowInstance.InstanceId);
                };

                workflowRuntime.WorkflowUnloaded += delegate(object sender, WorkflowEventArgs e)
                {
                    Console.WriteLine("Workflow unloaded: {0}", e.WorkflowInstance.InstanceId);
                };

                workflowRuntime.WorkflowLoaded += delegate(object sender, WorkflowEventArgs e)
                {
                    Console.WriteLine("Workflow loaded: {0}", e.WorkflowInstance.InstanceId);
                };

                WorkflowInstance instance = workflowRuntime.CreateWorkflow(typeof(WorkflowPersistence.Workflow1));
                instance.Start();

                waitHandle.WaitOne();
            }
        }
    }
}
