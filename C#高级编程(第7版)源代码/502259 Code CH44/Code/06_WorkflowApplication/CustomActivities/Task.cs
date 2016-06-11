using System;
using System.Activities;
using SharedInterfaces;

namespace CustomActivities
{
    public class Task : NativeActivity<Boolean>
    {
        [RequiredArgument]
        public InArgument<string> TaskName { get; set; }

        protected override bool CanInduceIdle
        {
            get { return true; }
        }

        protected override void Execute(NativeActivityContext context)
        {
            context.CreateBookmark(TaskName.Get(context), new BookmarkCallback(OnTaskComplete));
            context.GetExtension<ITaskExtension>().ExecuteTask(TaskName.Get(context));
        }

        private void OnTaskComplete(NativeActivityContext context, Bookmark bookmark, object state)
        {
            bool taskOK = Convert.ToBoolean(state);

            this.Result.Set(context, taskOK);
        }
    }
}
