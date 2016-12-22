using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_PickDemo.SharedInterfaces
{
    public interface IPromptService
    {
        void Prompt(string caption, string accepted, string rejected);
        void CancelPrompt();
    }
}
