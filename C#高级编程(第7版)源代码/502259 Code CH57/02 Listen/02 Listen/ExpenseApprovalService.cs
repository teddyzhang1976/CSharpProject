using System;
using System.Collections.Generic;
using System.Text;
using System.Workflow.Runtime;
using System.Threading;
using System.Windows.Forms;

namespace _2_Listen
{
    /// <summary>
    /// This class provides the service that asks the manager for approval
    /// </summary>
	public class ExpenseApprovalService : IExpenseApproval
	{
        /// <summary>
        /// This method is called from the workflow to ask for approval of the expense report
        /// </summary>
        /// <param name="expenseReportID">The ID of the expense report</param>
        public void RequestApproval(int expenseReportID)
        {
            _instanceID = WorkflowEnvironment.WorkflowInstanceId;

            Thread t = new Thread(new ParameterizedThreadStart(ShowUI));
            t.Start(expenseReportID);
        }

        /// <summary>
        /// Display the UI to the user
        /// </summary>
        /// <param name="o"></param>
        private void ShowUI(object o)
        {
            _dialog = new AskApproval();
            _dialog.expenseID.Text = o.ToString();

            DialogResult dr = _dialog.ShowDialog();

            switch (dr)
            {
                case DialogResult.Yes:
                    {
                        OnApproved(_instanceID, _dialog.reason.Text);
                        break;
                    }
                case DialogResult.No:
                    {
                        OnRejected(_instanceID, _dialog.reason.Text);
                        break;
                    }
            }
        }

        /// <summary>
        /// Delegate called to ensure we close the window on the appropriate thread
        /// </summary>
        private delegate void CancelDelegate();

        /// <summary>
        /// Called to cancel the approval/rejection request
        /// </summary>
        public void CancelApproval()
        {
            if (null != _dialog)
            {
                if (_dialog.InvokeRequired)
                    _dialog.Invoke(new CancelDelegate(CancelApproval));
                else
                    _dialog.Close();
                _dialog = null;
            }
        }

        /// <summary>
        /// Raised the Approved event
        /// </summary>
        /// <param name="instanceID">The workflow instance</param>
        /// <param name="reason">The approval reason</param>
        public void OnApproved(Guid instanceID, string reason)
        {
            if (null != Approved)
                Approved(null, new ExpenseEventArgs(instanceID, reason));
        }

        /// <summary>
        /// Raise the Rejected event
        /// </summary>
        /// <param name="instanceID">The workflow instance</param>
        /// <param name="reason">The rejection reason</param>
        public void OnRejected(Guid instanceID, string reason)
        {
            if (null != Rejected)
                Rejected(null, new ExpenseEventArgs(instanceID, reason));
        }

        /// <summary>
        /// Event raised when the expense report is approved
        /// </summary>
        public event EventHandler<ExpenseEventArgs> Approved;

        /// <summary>
        /// Event raised if the expense report is rejected
        /// </summary>
        public event EventHandler<ExpenseEventArgs> Rejected;

        /// <summary>
        /// Store the dialog displayed to the user
        /// </summary>
        private AskApproval _dialog;

        /// <summary>
        /// Store the workflow instance we're working on
        /// </summary>
        private Guid _instanceID;
    }
}
