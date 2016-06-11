using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace _2_Listen
{
	public sealed partial class Workflow1: SequentialWorkflowActivity
	{
		public Workflow1()
		{
			InitializeComponent();
		}

        private void PayMe_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("Expense report approved");
        }

        private void Panic_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("Expense report rejected");
        }

        private void ReRoute_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("Approval timeout - ask someone else!");
        }
	}

}
