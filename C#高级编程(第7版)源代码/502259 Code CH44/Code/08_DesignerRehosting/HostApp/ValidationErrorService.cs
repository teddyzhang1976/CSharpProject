using System;
using System.Activities.Presentation.Validation;

namespace HostApp
{
    public class ValidationErrorService : IValidationErrorService
    {
        public void ShowValidationErrors(System.Collections.Generic.IList<ValidationErrorInfo> errors)
        {
            _errorCount = errors.Count;
        }

        public int ErrorCount
        {
            get { return _errorCount; }
        }

        private int _errorCount;
    }
}
