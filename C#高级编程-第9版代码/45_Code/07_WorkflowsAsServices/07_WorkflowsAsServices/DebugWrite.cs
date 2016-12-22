using System;
using System.Activities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace _07_WorkflowsAsServices
{
    [Designer(typeof(DebugDesigner))]
    public class DebugWrite : CodeActivity
    {
        [RequiredArgument]
        public InArgument<string> Message { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            Debug.WriteLine(Message.Get(context));
        }
    }
}