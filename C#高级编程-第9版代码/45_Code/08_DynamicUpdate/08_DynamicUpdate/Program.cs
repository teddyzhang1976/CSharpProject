using System;
using System.Activities;
using System.Activities.DurableInstancing;
using System.Activities.DynamicUpdate;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _08_DynamicUpdate
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a workflow instance from the original definition and persist to SQL
            Guid id = CreateAndUnloadInitialWorkflow();

            // Now create the update map that converts from the original workflow to the updated workflow
            DynamicUpdateMap map = CreateUpdateMap();

            // Now upgrade the existing workflow to the new workflow definition
            UpgradeExistingWorkflow(id, map);

            // Now run the existing workflow, which is now using the new workflow definition
            LoadAndRunWorkflow(id);

        }

        private static Activity GetOriginalWorkflow()
        {
            return new Sequence
            {
                Activities =
                {
                    new WriteLine { Text = "Existing WriteLine" }
                }
            };
        }

        private static Activity GetUpdatedWorkflow()
        {
            return new Sequence
            {
                Activities =
                {
                    new WriteLine { Text = "Existing WriteLine" },
                    new WriteLine { Text = "Second version of workflow" }
                }
            };
        }

        private static Guid CreateAndUnloadInitialWorkflow()
        {
            SqlWorkflowInstanceStore store = new SqlWorkflowInstanceStore(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
            WorkflowApplication app = new WorkflowApplication(GetOriginalWorkflow());
            app.InstanceStore = store;
            app.Unload();

            return app.Id;
        }

        private static DynamicUpdateMap CreateUpdateMap()
        {
            Activity workflowDefinition = GetOriginalWorkflow();
            DynamicUpdateServices.PrepareForUpdate(workflowDefinition);

            // Now update the workflow - add in a new activity
            Sequence seq = workflowDefinition as Sequence;
            seq.Activities.Add(new WriteLine { Text = "Second version of workflow" });

            // And then after all the changes, create the map
            return DynamicUpdateServices.CreateUpdateMap(workflowDefinition);
        }

        private static void UpgradeExistingWorkflow(Guid id, DynamicUpdateMap map)
        {
            SqlWorkflowInstanceStore store = new SqlWorkflowInstanceStore(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
            WorkflowApplicationInstance instance = WorkflowApplication.GetInstance(id, store);
            WorkflowApplication app = new WorkflowApplication(GetUpdatedWorkflow());
            app.Load(instance, map);
            app.Unload();
        }

        private static void LoadAndRunWorkflow(Guid id)
        {
            SqlWorkflowInstanceStore store = new SqlWorkflowInstanceStore(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
            WorkflowApplicationInstance instance = WorkflowApplication.GetInstance(id, store);
            WorkflowApplication app = new WorkflowApplication(GetUpdatedWorkflow());
            ManualResetEvent wait = new ManualResetEvent(false);
            app.Completed = args => wait.Set();
            app.Run();
            wait.WaitOne();
        }
    }
}
