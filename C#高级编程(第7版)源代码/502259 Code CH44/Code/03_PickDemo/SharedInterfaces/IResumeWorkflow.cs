using System;

namespace SharedInterfaces
{
    public interface IResumeWorkflow
    {
        void Resume(string bookmarkName);
    }
}
