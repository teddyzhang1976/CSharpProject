using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Linq;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace ExposeWFService
{
    public sealed partial class Workflow1 : SequentialWorkflowActivity
    {
        public Workflow1()
        {
            InitializeComponent();
        }

        public string returnValue = default(System.String);
        public string inputMessage = default(System.String);

        private void codeActivity1_ExecuteCode(object sender, EventArgs e)
        {
            this.returnValue = string.Format("You said {0}", inputMessage);
        }


    }
}
