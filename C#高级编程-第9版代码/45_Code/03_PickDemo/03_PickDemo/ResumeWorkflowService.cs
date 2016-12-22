using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _03_PickDemo.SharedInterfaces;

namespace _03_PickDemo
{
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
