using System;
using System.Collections.Generic;
using System.Text;
using System.Workflow.Activities;

namespace _2_Listen
{
    /// <summary>
    /// This class is used to provide event args to the Approved/Rejected events
    /// </summary>
    /// <remarks>
    /// This class has to be marked with the [Serializable] attribute as it may be serialized by
    /// the workflow runtime before being delivered to the object handling the event
    /// </remarks>
    [Serializable]
    public class ExpenseEventArgs : ExternalDataEventArgs
    {
        /// <summary>
        /// Construct the event args from the passed values
        /// </summary>
        /// <param name="instanceID">The workflow ID that this data is sent to</param>
        /// <param name="reason">The reason for approval/rejection</param>
        public ExpenseEventArgs(Guid instanceID, string reason)
            : base(instanceID)
        {
            _reason = reason;
        }

        /// <summary>
        /// Get the reason for approval/rejection
        /// </summary>
        public string Reason
        {
            get { return _reason; }
        }

        /// <summary>
        /// Store the reason for approval/rejection
        /// </summary>
        private string _reason;
    }

    /// <summary>
    /// This interface is used by the workflow to request approval for an expense report, and 
    /// it also exposes an event that is raised when that approval is provided.
    /// </summary>
    [ExternalDataExchange]
	public interface IExpenseApproval
	{
        /// <summary>
        /// This method is called from the workflow to ask for approval of the expense report
        /// </summary>
        /// <param name="expenseReportID">The ID of the expense report</param>
        void RequestApproval(int expenseReportID);

        /// <summary>
        /// Called to cancel the approval/rejection request
        /// </summary>
        void CancelApproval();

        /// <summary>
        /// Event raised when the expense report is approved
        /// </summary>
        event EventHandler<ExpenseEventArgs> Approved;

        /// <summary>
        /// Event raised if the expense report is rejected
        /// </summary>
        event EventHandler<ExpenseEventArgs> Rejected;
	}
}
