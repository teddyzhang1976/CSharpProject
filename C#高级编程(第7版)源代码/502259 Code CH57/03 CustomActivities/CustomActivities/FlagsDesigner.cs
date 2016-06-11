using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Workflow.Activities;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Collections;
using System.Reflection;

namespace CustomActivities
{
    /// <summary>
    /// Custom designer for the FlagsActivity
    /// </summary>
    [ActivityDesignerTheme(typeof(FlagsTheme))]
    public class FlagsDesigner : ParallelActivityDesigner
    {
        /// <summary>
        /// Ensures that only activities of a certain type can be inserted into the FlagsActivity
        /// </summary>
        /// <param name="insertLocation">The hit test location for the drag & drop or paste operation</param>
        /// <param name="activitiesToInsert">A collection of activities</param>
        /// <returns>True if the activities can be inserted</returns>
        public override bool CanInsertActivities(HitTestInfo insertLocation, ReadOnlyCollection<Activity> activitiesToInsert)
        {
            bool canInsert = true;

            foreach (Activity a in activitiesToInsert)
            {
                if (a.GetType() != typeof(SequenceActivity))
                {
                    canInsert = false;
                    break;
                }
            }

            return canInsert ? base.CanInsertActivities(insertLocation, activitiesToInsert) : canInsert;
        }

        /// <summary>
        /// Filter the properties displayed on the UI so that I can add in the enum property
        /// </summary>
        /// <param name="properties"></param>
        protected override void PreFilterProperties(IDictionary properties)
        {
            base.PreFilterProperties(properties);
#if DEBUG
            Type actType = this.Activity.GetType();

            PropertyInfo pi = actType.GetProperty("EnumType");

            if (null != pi)
            {
                Type enumType = pi.GetValue(this.Activity, null) as Type;

                if (null != enumType)
                {
                    MethodInfo mi = actType.GetMethod("GetEnumTypePropertyDescriptor", BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[] { typeof(IDictionary) }, null);

                    if ( null != mi)
                        mi.Invoke(this.Activity, new object[] { properties });
                }
            }
#else
            FlagsActivity act = this.Activity as FlagsActivity;

            if ((null != act) && ( null != act.EnumType))
                act.GetEnumTypePropertyDescriptor(properties);
#endif
        }

        /// <summary>
        /// Update the properties of the activity as appropriate
        /// </summary>
        /// <param name="e"></param>
        protected override void OnActivityChanged(ActivityChangedEventArgs e)
        {
            base.OnActivityChanged(e);

            if (null != e.Member)
            {
                if ((e.Member.Name == "EnumType") && (base.Activity.Site != null))
                {
                    Type t = e.NewValue as Type;

                    // Ensure the selected enum type is valid
                    if (null != t)
                        new FlagsEnumFilterProvider(base.Activity.Site).CanFilterType(t, true);

                    TypeDescriptor.Refresh(e.Activity);
                }
            }
        }

        /// <summary>
        /// Create a new branch
        /// </summary>
        /// <returns></returns>
        protected override System.Workflow.ComponentModel.CompositeActivity OnCreateNewBranch()
        {
            return new SequenceActivity();
        }
    }
}
