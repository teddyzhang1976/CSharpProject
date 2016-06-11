using System;

namespace SharedInterfaces
{
    public interface IPromptService
    {
        void Prompt(string caption, string accepted, string rejected);
        void CancelPrompt();
    }
}
