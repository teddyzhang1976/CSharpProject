using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Reflection;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace WorkflowPersistence
{
	partial class Workflow1
	{
		#region Designer generated code
		
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
		private void InitializeComponent()
		{
            this.CanModifyActivities = true;
            this.wait = new System.Workflow.Activities.DelayActivity();
            // 
            // wait
            // 
            this.wait.Name = "wait";
            this.wait.TimeoutDuration = System.TimeSpan.Parse("00:00:20");
            // 
            // Workflow1
            // 
            this.Activities.Add(this.wait);
            this.Name = "Workflow1";
            this.CanModifyActivities = false;

		}

		#endregion

        private DelayActivity wait;


    }
}
