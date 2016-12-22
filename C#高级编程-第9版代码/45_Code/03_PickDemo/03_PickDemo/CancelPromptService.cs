using System.Activities;
using _03_PickDemo.SharedInterfaces;

namespace _03_PickDemo
{
    public class CancelPromptService : NativeActivity
    {
        protected override void Execute(NativeActivityContext context)
        {
            context.GetExtension<IPromptService>().CancelPrompt();
        }
    }
}
