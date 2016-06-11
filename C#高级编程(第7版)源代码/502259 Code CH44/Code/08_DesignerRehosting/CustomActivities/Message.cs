using System;
using System.Activities;
using System.Windows;

namespace CustomActivities
{
    public class Message : CodeActivity
    {
        [RequiredArgument]
        public InArgument<string> Text { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            MessageBox.Show(Text.Get(context));
        }
    }
}
