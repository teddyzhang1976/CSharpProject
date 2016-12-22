using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using _03_PickDemo.SharedInterfaces;

namespace _03_PickDemo
{
    public class FormsPromptService : IPromptService
    {
        public FormsPromptService(IResumeWorkflow resume)
        {
            _resume = resume;
        }

        public void Prompt(string caption, string accepted, string rejected)
        {
            _caption = caption;
            _acceptedBookmark = accepted;
            _rejectedBookmark = rejected;

            Thread t = new Thread(new ThreadStart(PromptThread));
            t.SetApartmentState(ApartmentState.STA);
            t.Name = "Prompt";
            t.Start();
        }

        public void CancelPrompt()
        {
            if (null != _dialog)
                _dialog.Close();
        }

        private void PromptThread()
        {
            _dialog = new PromptDialog();
            _dialog.promptText.Text = _caption;
            string bookmarkName = string.Empty;

            switch (_dialog.ShowDialog())
            {
                case DialogResult.OK:
                    {
                        bookmarkName = _acceptedBookmark;
                        break;
                    }
                case DialogResult.Cancel:
                    {
                        bookmarkName = _rejectedBookmark;
                        break;
                    }
            }

            if (!string.IsNullOrEmpty(bookmarkName))
                _resume.Resume(bookmarkName);
        }

        private IResumeWorkflow _resume;
        private PromptDialog _dialog;
        private string _caption;
        private string _acceptedBookmark;
        private string _rejectedBookmark;
    }
}
