using System;
using System.Workflow.ComponentModel.Compiler;

namespace CustomActivities
{
    /// <summary>
    /// This class validates the WriteLineActivity
    /// </summary>
    public class WriteLineValidator : ActivityValidator
    {
        /// <summary>
        /// Check that the Message property is set
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override ValidationErrorCollection Validate(ValidationManager manager, object obj)
        {
            if (null == manager)
                throw new ArgumentNullException("manager");
            if (null == obj)
                throw new ArgumentNullException("obj");

            ValidationErrorCollection errors = base.Validate(manager, obj);

            // Coerce to a WriteLineActivity
            WriteLineActivity act = obj as WriteLineActivity;

            if (null != act)
            {
                if (null != act.Parent)
                {
                    // Check the Message property
                    if (string.IsNullOrEmpty(act.Message))
                        errors.Add(ValidationError.GetNotSetValidationError("Message"));
                }
            }

            return errors;
        }
	}
}
