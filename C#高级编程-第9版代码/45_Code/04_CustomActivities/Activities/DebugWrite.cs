using System.Activities;
using System.ComponentModel;
using System.Diagnostics;

namespace Activities
{
    [Designer("Activities.Design.DebugWriteDesigner, Activities.Design")]
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
