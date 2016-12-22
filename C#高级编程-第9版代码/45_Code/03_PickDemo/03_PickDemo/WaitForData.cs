using System.Activities;

namespace _03_PickDemo
{
    /// <summary>
    /// This class waits for some data to arrive and then returns this to the caller
    /// </summary>
    public class WaitForData : NativeActivity<string>
    {
        [RequiredArgument]
        public InArgument<string> BookmarkName { get; set; }

        /// <summary>
        /// This activity can induce a wait, i.e. the workflow can go idle waiting for something to show up
        /// </summary>
        protected override bool CanInduceIdle
        {
            get { return true; }
        }

        /// <summary>
        /// Create a bookmark and wait for data to arrive on it
        /// </summary>
        /// <param name="context"></param>
        protected override void Execute(NativeActivityContext context)
        {
            context.CreateBookmark(BookmarkName.Get(context), new BookmarkCallback(OnDataArrived));
        }

        /// <summary>
        /// Process the data that has arrived
        /// </summary>
        /// <param name="context"></param>
        /// <param name="bm"></param>
        /// <param name="state"></param>
        private void OnDataArrived(NativeActivityContext context, Bookmark bm, object state)
        {
            context.SetValue(this.Result, (string)state);
        }
    }
}
