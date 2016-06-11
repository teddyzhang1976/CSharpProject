using System;
using System.Collections.Generic;
using System.Workflow.ComponentModel.Design;
using System.Runtime.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.Activities;
using System.ComponentModel;

namespace CustomActivities
{
    /// <summary>
    /// Creates the toolbox item for the FlagsActivity
    /// </summary>
    [Serializable]
    public class FlagsToolboxItem : ActivityToolboxItem
    {
        /// <summary>
        /// Change the display name
        /// </summary>
        /// <param name="t"></param>
        public FlagsToolboxItem(Type t)
            : base(t)
        {
            this.DisplayName = "Flags";
        }

        /// <summary>
        /// Necessary for the Visual Studio design time environment
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        private FlagsToolboxItem(SerializationInfo info, StreamingContext context)
        {
            this.Deserialize(info, context);
        }

        /// <summary>
        /// Called when the activity is dragged onto the design surface
        /// </summary>
        /// <remarks>
        /// Here I construct two child activities as well as the FlagsActivity.
        /// </remarks>
        /// <param name="host"></param>
        /// <returns></returns>
        protected override System.ComponentModel.IComponent[] CreateComponentsCore(System.ComponentModel.Design.IDesignerHost host)
        {
            CompositeActivity parent = new FlagsActivity();
            parent.Activities.Add(new SequenceActivity());
            parent.Activities.Add(new SequenceActivity());

            return new IComponent[] { parent };
        }
    }
}
