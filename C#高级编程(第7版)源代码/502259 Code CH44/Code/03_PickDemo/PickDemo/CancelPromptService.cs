using System;
using System.Activities;
using SharedInterfaces;

namespace PickDemo
{
    public class CancelPromptService : NativeActivity
    {
        protected override void Execute(NativeActivityContext context)
        {
            context.GetExtension<IPromptService>().CancelPrompt();
        }
    }
}
