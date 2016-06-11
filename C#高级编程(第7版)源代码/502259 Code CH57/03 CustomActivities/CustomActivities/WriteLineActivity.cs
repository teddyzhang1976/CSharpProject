using System;
using System.ComponentModel;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Compiler;
using System.Drawing;

namespace CustomActivities
{
    /// <summary>
    /// A simple activity that displays a message to the console when it executes
    /// </summary>
    [ActivityValidator(typeof(WriteLineValidator))]
    [Designer(typeof(WriteLineDesigner))]
    [ToolboxBitmap(typeof(WriteLineActivity),"Resources.WriteLine.png")]
    [ToolboxItem(typeof(WriteLineToolboxItem))]
	public class WriteLineActivity : Activity
	{
        /// <summary>
        /// Execute the activity - display the message on screen
        /// </summary>
        /// <param name="executionContext"></param>
        /// <returns></returns>
        protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
        {
            Console.WriteLine(Message);

            return ActivityExecutionStatus.Closed;
        }

        /// <summary>
        /// Get/Set the message displayed to the user
        /// </summary>
        [Description("The message to display")]
        [Category("Parameters")]
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        /// <summary>
        /// Store the message displayed to the user
        /// </summary>
        private string _message;
    }

}
