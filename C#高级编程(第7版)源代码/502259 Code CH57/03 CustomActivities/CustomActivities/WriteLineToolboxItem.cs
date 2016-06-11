using System;
using System.Runtime.Serialization;
using System.Workflow.ComponentModel.Design;

namespace CustomActivities
{
    /// <summary>
    /// This class is the toolbox item for the WriteLineActivity
    /// </summary>
    [Serializable]
    public class WriteLineToolboxItem : ActivityToolboxItem
    {
        /// <summary>
        /// Set the display name to WriteLine - i.e. trim off the 'Activity' string
        /// </summary>
        /// <param name="t"></param>
        public WriteLineToolboxItem(Type t)
            : base(t)
        {
            base.DisplayName = "WriteLine";
        }

        /// <summary>
        /// Necessary for the Visual Studio design time environment
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        private WriteLineToolboxItem(SerializationInfo info, StreamingContext context)
        {
            this.Deserialize(info, context);
        }
    }
}
