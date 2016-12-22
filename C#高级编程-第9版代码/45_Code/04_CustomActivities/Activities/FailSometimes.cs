using System;
using System.Activities;

namespace Activities
{
    public class FailSometimes : CodeActivity
    {
        protected override void Execute(CodeActivityContext context)
        {
            _loopCount -= 1;

            if (_loopCount > 0)
                throw new Exception("Oh no bad things");
        }

        private static int _loopCount = 6;
    }
}
