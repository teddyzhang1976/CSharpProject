using System;
using System.Activities;
using System.Diagnostics;
using System.ComponentModel;
using System.Activities.Validation;

namespace Activities
{
    [Designer("Activities.Presentation.DebugWriteDesigner, Activities.Presentation")]
    public class DebugWrite : CodeActivity
    {
        [Description("The message output to the debug stream")]
        [RequiredArgument]
        public InArgument<string> Message { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            Debug.WriteLine(Message.Get(context));
        }
    }
}
