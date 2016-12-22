using System.Activities;
using _03_PickDemo.SharedInterfaces;

namespace _03_PickDemo
{
    public class CallPromptService : NativeActivity
    {
        [RequiredArgument]
        public InArgument<string> AcceptedBookmarkName { get; set; }

        [RequiredArgument]
        public InArgument<string> RejectedBookmarkName { get; set; }

        [RequiredArgument]
        public InArgument<string> Prompt { get; set; }

        protected override void Execute(NativeActivityContext context)
        {
            context.GetExtension<IPromptService>().Prompt(Prompt.Get(context), AcceptedBookmarkName.Get(context), RejectedBookmarkName.Get(context));
        }
    }
}
