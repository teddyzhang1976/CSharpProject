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

namespace DoorsWorkflow
{
	partial class SeqDoor
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
            this.callExternalMethodActivity2 = new System.Workflow.Activities.CallExternalMethodActivity();
            this.delayActivity1 = new System.Workflow.Activities.DelayActivity();
            this.callExternalMethodActivity3 = new System.Workflow.Activities.CallExternalMethodActivity();
            this.delayActivity2 = new System.Workflow.Activities.DelayActivity();
            this.callExternalMethodActivity1 = new System.Workflow.Activities.CallExternalMethodActivity();
            this.handleExternalEventActivity1 = new System.Workflow.Activities.HandleExternalEventActivity();
            this.eventDrivenActivity2 = new System.Workflow.Activities.EventDrivenActivity();
            this.eventDrivenActivity1 = new System.Workflow.Activities.EventDrivenActivity();
            this.listenActivity1 = new System.Workflow.Activities.ListenActivity();
            // 
            // callExternalMethodActivity2
            // 
            this.callExternalMethodActivity2.InterfaceType = typeof(DoorsWorkflow.IDoorService);
            this.callExternalMethodActivity2.MethodName = "LockDoor";
            this.callExternalMethodActivity2.Name = "callExternalMethodActivity2";
            // 
            // delayActivity1
            // 
            this.delayActivity1.Name = "delayActivity1";
            this.delayActivity1.TimeoutDuration = System.TimeSpan.Parse("00:00:30");
            // 
            // callExternalMethodActivity3
            // 
            this.callExternalMethodActivity3.InterfaceType = typeof(DoorsWorkflow.IDoorService);
            this.callExternalMethodActivity3.MethodName = "LockDoor";
            this.callExternalMethodActivity3.Name = "callExternalMethodActivity3";
            // 
            // delayActivity2
            // 
            this.delayActivity2.Name = "delayActivity2";
            this.delayActivity2.TimeoutDuration = System.TimeSpan.Parse("00:00:10");
            // 
            // callExternalMethodActivity1
            // 
            this.callExternalMethodActivity1.InterfaceType = typeof(DoorsWorkflow.IDoorService);
            this.callExternalMethodActivity1.MethodName = "UnlockDoor";
            this.callExternalMethodActivity1.Name = "callExternalMethodActivity1";
            // 
            // handleExternalEventActivity1
            // 
            this.handleExternalEventActivity1.EventName = "RequestEntry";
            this.handleExternalEventActivity1.InterfaceType = typeof(DoorsWorkflow.IDoorService);
            this.handleExternalEventActivity1.Name = "handleExternalEventActivity1";
            // 
            // eventDrivenActivity2
            // 
            this.eventDrivenActivity2.Activities.Add(this.delayActivity1);
            this.eventDrivenActivity2.Activities.Add(this.callExternalMethodActivity2);
            this.eventDrivenActivity2.Name = "eventDrivenActivity2";
            // 
            // eventDrivenActivity1
            // 
            this.eventDrivenActivity1.Activities.Add(this.handleExternalEventActivity1);
            this.eventDrivenActivity1.Activities.Add(this.callExternalMethodActivity1);
            this.eventDrivenActivity1.Activities.Add(this.delayActivity2);
            this.eventDrivenActivity1.Activities.Add(this.callExternalMethodActivity3);
            this.eventDrivenActivity1.Name = "eventDrivenActivity1";
            // 
            // listenActivity1
            // 
            this.listenActivity1.Activities.Add(this.eventDrivenActivity1);
            this.listenActivity1.Activities.Add(this.eventDrivenActivity2);
            this.listenActivity1.Name = "listenActivity1";
            // 
            // SeqDoor
            // 
            this.Activities.Add(this.listenActivity1);
            this.Name = "SeqDoor";
            this.CanModifyActivities = false;

		}

		#endregion

        private CallExternalMethodActivity callExternalMethodActivity2;
        private DelayActivity delayActivity1;
        private CallExternalMethodActivity callExternalMethodActivity3;
        private DelayActivity delayActivity2;
        private CallExternalMethodActivity callExternalMethodActivity1;
        private HandleExternalEventActivity handleExternalEventActivity1;
        private EventDrivenActivity eventDrivenActivity2;
        private EventDrivenActivity eventDrivenActivity1;
        private ListenActivity listenActivity1;
	}
}
