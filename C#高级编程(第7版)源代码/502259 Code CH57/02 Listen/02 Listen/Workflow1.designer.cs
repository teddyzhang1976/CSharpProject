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

namespace _2_Listen
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
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding1 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            this.ReRoute = new System.Workflow.Activities.CodeActivity();
            this.HideDialog = new System.Workflow.Activities.CallExternalMethodActivity();
            this.Wait = new System.Workflow.Activities.DelayActivity();
            this.Panic = new System.Workflow.Activities.CodeActivity();
            this.Rejected = new System.Workflow.Activities.HandleExternalEventActivity();
            this.PayMe = new System.Workflow.Activities.CodeActivity();
            this.Approved = new System.Workflow.Activities.HandleExternalEventActivity();
            this.waitTimeout = new System.Workflow.Activities.EventDrivenActivity();
            this.waitRejection = new System.Workflow.Activities.EventDrivenActivity();
            this.waitApproval = new System.Workflow.Activities.EventDrivenActivity();
            this.listenActivity1 = new System.Workflow.Activities.ListenActivity();
            this.RequestApproval = new System.Workflow.Activities.CallExternalMethodActivity();
            // 
            // ReRoute
            // 
            this.ReRoute.Name = "ReRoute";
            this.ReRoute.ExecuteCode += new System.EventHandler(this.ReRoute_ExecuteCode);
            // 
            // HideDialog
            // 
            this.HideDialog.InterfaceType = typeof(_2_Listen.IExpenseApproval);
            this.HideDialog.MethodName = "CancelApproval";
            this.HideDialog.Name = "HideDialog";
            // 
            // Wait
            // 
            this.Wait.Name = "Wait";
            this.Wait.TimeoutDuration = System.TimeSpan.Parse("00:00:10");
            // 
            // Panic
            // 
            this.Panic.Name = "Panic";
            this.Panic.ExecuteCode += new System.EventHandler(this.Panic_ExecuteCode);
            // 
            // Rejected
            // 
            this.Rejected.EventName = "Rejected";
            this.Rejected.InterfaceType = typeof(_2_Listen.IExpenseApproval);
            this.Rejected.Name = "Rejected";
            // 
            // PayMe
            // 
            this.PayMe.Name = "PayMe";
            this.PayMe.ExecuteCode += new System.EventHandler(this.PayMe_ExecuteCode);
            // 
            // Approved
            // 
            this.Approved.EventName = "Approved";
            this.Approved.InterfaceType = typeof(_2_Listen.IExpenseApproval);
            this.Approved.Name = "Approved";
            // 
            // waitTimeout
            // 
            this.waitTimeout.Activities.Add(this.Wait);
            this.waitTimeout.Activities.Add(this.HideDialog);
            this.waitTimeout.Activities.Add(this.ReRoute);
            this.waitTimeout.Name = "waitTimeout";
            // 
            // waitRejection
            // 
            this.waitRejection.Activities.Add(this.Rejected);
            this.waitRejection.Activities.Add(this.Panic);
            this.waitRejection.Name = "waitRejection";
            // 
            // waitApproval
            // 
            this.waitApproval.Activities.Add(this.Approved);
            this.waitApproval.Activities.Add(this.PayMe);
            this.waitApproval.Name = "waitApproval";
            // 
            // listenActivity1
            // 
            this.listenActivity1.Activities.Add(this.waitApproval);
            this.listenActivity1.Activities.Add(this.waitRejection);
            this.listenActivity1.Activities.Add(this.waitTimeout);
            this.listenActivity1.Name = "listenActivity1";
            // 
            // RequestApproval
            // 
            this.RequestApproval.InterfaceType = typeof(_2_Listen.IExpenseApproval);
            this.RequestApproval.MethodName = "RequestApproval";
            this.RequestApproval.Name = "RequestApproval";
            workflowparameterbinding1.ParameterName = "expenseReportID";
            workflowparameterbinding1.Value = 333;
            this.RequestApproval.ParameterBindings.Add(workflowparameterbinding1);
            // 
            // Workflow1
            // 
            this.Activities.Add(this.RequestApproval);
            this.Activities.Add(this.listenActivity1);
            this.Name = "Workflow1";
            this.CanModifyActivities = false;

		}

		#endregion

        private DelayActivity Wait;
        private HandleExternalEventActivity Rejected;
        private HandleExternalEventActivity Approved;
        private EventDrivenActivity waitTimeout;
        private EventDrivenActivity waitRejection;
        private EventDrivenActivity waitApproval;
        private ListenActivity listenActivity1;
        private CodeActivity ReRoute;
        private CodeActivity Panic;
        private CodeActivity PayMe;
        private CallExternalMethodActivity HideDialog;
        private CallExternalMethodActivity RequestApproval;







    }
}
