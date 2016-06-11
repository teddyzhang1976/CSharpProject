using System;
using System.Collections.Generic;
using System.Workflow.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Workflow.Activities;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Design;
using System.Collections;
using System.Reflection;
using System.ComponentModel.Design.Serialization;
using System.CodeDom;

namespace CustomActivities
{
    /// <summary>
    /// Defines an activity that executes its streams based on a [Flags] enum
    /// </summary>
    [ToolboxBitmap(typeof(FlagsActivity), "Resources.Flags.png")]
    [ToolboxItem(typeof(FlagsToolboxItem))]
    [Designer(typeof(FlagsDesigner), typeof(IDesigner))]
    public class FlagsActivity : CompositeActivity, IActivityEventListener<ActivityExecutionStatusChangedEventArgs>, IDynamicPropertyTypeProvider
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public FlagsActivity()
        {
            base.SetValue(FlagsActivity.ParameterBindingsProperty, new WorkflowParameterBindingCollection(this));
        }

        /// <summary>
        /// Constructor using a name
        /// </summary>
        /// <param name="name">The name of the activity</param>
        public FlagsActivity(string name)
            : base(name)
        {
            base.SetValue(FlagsActivity.ParameterBindingsProperty, new WorkflowParameterBindingCollection(this));
        }

        /// <summary>
        /// Get/set the EnumType used by this activity
        /// </summary>
        [Description("Please select an enum marked with the [Flags] attribute")]
        [Category("Activity")]
        [RefreshProperties(RefreshProperties.All)]
        [TypeFilterProvider(typeof(FlagsEnumFilterProvider))]
        [Editor(typeof(TypeBrowserEditor), typeof(UITypeEditor))]
        public Type EnumType
        {
            get { return base.GetValue(FlagsActivity.EnumTypeProperty) as Type; }
            set { base.SetValue(FlagsActivity.EnumTypeProperty, value); }
        }

        /// <summary>
        /// Get/Set the IsExecuting flag
        /// </summary>
        private bool IsExecuting
        {
            get { return (bool)base.GetValue(FlagsActivity.IsExecutingProperty); }
            set { base.SetValue(FlagsActivity.IsExecutingProperty, value); }
        }

        /// <summary>
        /// Cancel the activity. Loop through all enabled activities, and for any that are currently
        /// executing ask them to cancel.
        /// </summary>
        /// <param name="executionContext"></param>
        /// <returns>The status of the activity</returns>
        protected override ActivityExecutionStatus Cancel(ActivityExecutionContext executionContext)
        {
            if (null == executionContext)
                throw new ArgumentNullException("executionContext");

            bool completed = true;

            for (int pos = 0; pos < base.EnabledActivities.Count; pos++)
            {
                Activity act = base.EnabledActivities[pos];
                if (act.ExecutionStatus == ActivityExecutionStatus.Executing)
                {
                    executionContext.CancelActivity(act);
                    completed = false;
                }
                else if ((act.ExecutionStatus == ActivityExecutionStatus.Canceling) || (act.ExecutionStatus == ActivityExecutionStatus.Faulting))
                    completed = false;
            }
            if (!completed)
                return ActivityExecutionStatus.Canceling;
            else
                return ActivityExecutionStatus.Closed;
        }

        /// <summary>
        /// Execute the activity
        /// </summary>
        /// <param name="executionContext"></param>
        /// <returns>Exedcuting if any children are running, otherwise Closed</returns>
        protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
        {
            if (null == executionContext)
                throw new ArgumentNullException("executionContext");

            this.IsExecuting = true;

            for (int pos = 0; pos < base.EnabledActivities.Count; pos++)
            {
                SequenceActivity act = base.EnabledActivities[pos] as SequenceActivity;

                if (null != act)
                {
/*                    foreach (Account account in Customer.Accounts)
                    {
                        if (account.GetType() == act.AccountType)
                        {
                            act.Account = account;
                            act.RegisterForStatusChange(Activity.ClosedEvent, this);
                            executionContext.ExecuteActivity(act);
                        }
                    }*/

                    act.RegisterForStatusChange(Activity.ClosedEvent, this);
                    executionContext.ExecuteActivity(act);
                }
            }

            if (base.EnabledActivities.Count != 0)
                return ActivityExecutionStatus.Executing;
            else
                return ActivityExecutionStatus.Closed;
        }

        /// <summary>
        /// An activity has been added - hookup to that activites Closed event
        /// </summary>
        /// <param name="executionContext"></param>
        /// <param name="addedActivity"></param>
        protected override void OnActivityChangeAdd(ActivityExecutionContext executionContext, Activity addedActivity)
        {
            if (null == executionContext)
                throw new ArgumentNullException("executionContext");
            if (null == addedActivity)
                throw new ArgumentNullException("addedActivity");

            FlagsActivity act = executionContext.Activity as FlagsActivity;

            if ((act.ExecutionStatus == ActivityExecutionStatus.Executing) && act.IsExecuting)
            {
                addedActivity.RegisterForStatusChange(Activity.ClosedEvent, this);
                executionContext.ExecuteActivity(addedActivity);
            }
        }

        /// <summary>
        /// Remove the IsExecuting property
        /// </summary>
        /// <param name="provider"></param>
        protected override void OnClosed(IServiceProvider provider)
        {
            base.RemoveProperty(FlagsActivity.IsExecutingProperty);
        }

        /// <summary>
        /// Called after changes have been made to the Activities collection
        /// </summary>
        /// <param name="rootContext"></param>
        protected override void OnWorkflowChangesCompleted(ActivityExecutionContext rootContext)
        {
            base.OnWorkflowChangesCompleted(rootContext);
            if (this.IsExecuting)
            {
                bool canClose = true;
                for (int pos = 0; pos < base.EnabledActivities.Count; pos++)
                {
                    Activity act = base.EnabledActivities[pos];
                    if (act.ExecutionStatus != ActivityExecutionStatus.Closed)
                    {
                        canClose = false;
                        break;
                    }
                }
                if (canClose)
                    rootContext.CloseActivity();
            }
        }

        /// <summary>
        /// Return a property descriptor for the Enum
        /// </summary>
        /// <param name="properties"></param>
        internal void GetEnumTypePropertyDescriptor(IDictionary properties)
        {
            if (null != this.Site)
            {
                ITypeProvider provider = this.Site.GetService(typeof(ITypeProvider)) as ITypeProvider;

                if (null == provider)
                    throw new InvalidOperationException("The ITypeProvider service is needed by this activity and does not seem to be available.");

                if (this.EnumType != null)
                    // Construct a property descriptor for the EnumValue property
                    properties["EnumValue"] = GetEnumValuePropertyDescriptor();
            }
        }

        /// <summary>
        /// Construct a property descriptor for the EnumType property
        /// </summary>
        /// <returns>A property descriptor</returns>
        private PropertyDescriptor GetEnumValuePropertyDescriptor()
        {
            return new EnumValuePropertyDescriptor(EnumType);
        }

        /// <summary>
        /// Setup the properties of this activity - add in the EnumValue property if appropriate
        /// </summary>
        protected override void InitializeProperties()
        {
            if (EnumType != null)
                this.ParameterBindings.Add(new WorkflowParameterBinding("EnumValue"));

            base.InitializeProperties();
        }

        /// <summary>
        /// Respond to status changes on child activities
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void IActivityEventListener<ActivityExecutionStatusChangedEventArgs>.OnEvent(object sender, ActivityExecutionStatusChangedEventArgs e)
        {
            if (null == sender)
                throw new ArgumentNullException("sender");
            if (null == e)
                throw new ArgumentNullException("e");

            ActivityExecutionContext context = sender as ActivityExecutionContext;
            if (null == context)
                throw new ArgumentException("No execution context is available");

            FlagsActivity act = context.Activity as FlagsActivity;
            e.Activity.UnregisterForStatusChange(Activity.ClosedEvent, this);
            bool canClose = true;
            for (int pos = 0; pos < act.EnabledActivities.Count; pos++)
            {
                Activity childAct = act.EnabledActivities[pos];
                if ((childAct.ExecutionStatus != ActivityExecutionStatus.Initialized) && (childAct.ExecutionStatus != ActivityExecutionStatus.Closed))
                {
                    canClose = false;
                    break;
                }
            }
            if (canClose)
                context.CloseActivity();
        }

        /// <summary>
        /// Define a dependency property for the activity which is used to indicate that the activity is executing
        /// </summary>
        private static DependencyProperty IsExecutingProperty = 
            DependencyProperty.Register("IsExecuting", typeof(bool), typeof(FlagsActivity), 
            new PropertyMetadata(false));

        /// <summary>
        /// Define the dependency property used for the Enum type
        /// </summary>
        public static DependencyProperty EnumTypeProperty = 
            DependencyProperty.Register("EnumType", typeof(Type), typeof(FlagsActivity), 
            new PropertyMetadata(null, DependencyPropertyOptions.Metadata, 
                                 new Attribute[] { new ValidationOptionAttribute(ValidationOption.Required)}));

        public static DependencyProperty ParameterBindingsProperty =
            DependencyProperty.Register("ParameterBindings", typeof(WorkflowParameterBindingCollection),
                                        typeof(FlagsActivity), new PropertyMetadata(new Attribute[] { new BrowsableAttribute(false), new DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Content)}));

        /// <summary>
        /// Get the parameter bindings collection
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Browsable(false)]
        public WorkflowParameterBindingCollection ParameterBindings
        {
            get { return base.GetValue(FlagsActivity.ParameterBindingsProperty) as WorkflowParameterBindingCollection; }
        }

        /// <summary>
        /// Defines a property descriptor that exposes the _enumValue field as a property
        /// </summary>
        protected class EnumValuePropertyDescriptor : PropertyDescriptor
        {
            /// <summary>
            /// Construct the property descriptor
            /// </summary>
            /// <param name="t"></param>
            public EnumValuePropertyDescriptor(Type t)
                : base("EnumValue", new Attribute[] { new DescriptionAttribute("Please bind this property to a field in the workflow or another activity"), new CategoryAttribute("Parameters")})
            {
                _type = t;
            }

            /// <summary>
            /// Return the type of the field
            /// </summary>
            public override Type ComponentType
            {
                get { return typeof(FlagsActivity); }
            }

            /// <summary>
            /// Return true if the value can be reset
            /// </summary>
            /// <param name="component"></param>
            /// <returns></returns>
            public override bool CanResetValue(object component)
            {
                bool canReset = false;

                FlagsActivity act = component as FlagsActivity;

                if ( null != act )
                    canReset = null != act.BoundData.Data;

                return canReset;
            }

            /// <summary>
            /// Get the value of the property
            /// </summary>
            /// <param name="component"></param>
            /// <returns></returns>
            public override object GetValue(object component)
            {
                object value = null;

                FlagsActivity act = component as FlagsActivity;

                if (null != act)
                    value = act.BoundData.Data;

                return value;
            }

            /// <summary>
            /// Reset the value to the default
            /// </summary>
            /// <param name="component"></param>
            public override void ResetValue(object component)
            {
                FlagsActivity act = component as FlagsActivity;

                if (null != act)
                    act.BoundData.Data = null;
            }

            /// <summary>
            /// Set the value of the property
            /// </summary>
            /// <param name="component"></param>
            /// <param name="value"></param>
            public override void SetValue(object component, object value)
            {
                FlagsActivity act = component as FlagsActivity;

                if (null != act)
                    act.BoundData.Data = value as ActivityBind;
            }

            /// <summary>
            /// Return true if the value should be serialized
            /// </summary>
            /// <param name="component"></param>
            /// <returns></returns>
            public override bool ShouldSerializeValue(object component)
            {
                bool shouldSerialize = false;

                FlagsActivity act = component as FlagsActivity;

                if (null != act)
                    shouldSerialize = null != act.BoundData.Data;

                return shouldSerialize;
            }

            /// <summary>
            /// Return the binding editor
            /// </summary>
            /// <param name="editorBaseType"></param>
            /// <returns></returns>
            public override object GetEditor(Type editorBaseType)
            {
                return TypeDescriptor.GetEditor(this.PropertyType, editorBaseType);
            }

            /// <summary>
            /// Check if the property is read only
            /// </summary>
            public override bool IsReadOnly
            {
                get { return false; }
            }

            /// <summary>
            /// Return the type of the property
            /// </summary>
            public override Type PropertyType
            {
                get { return typeof(ActivityBind); }
            }

            /// <summary>
            /// Defines the type of property
            /// </summary>
            private Type _type;
        }

        private FlagsActivityBoundData _boundData = new FlagsActivityBoundData();

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public FlagsActivityBoundData BoundData
        {
            get { return _boundData; }
            set { _boundData = value; }
        }

        AccessTypes IDynamicPropertyTypeProvider.GetAccessType(IServiceProvider serviceProvider, string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
                throw new ArgumentNullException("propertyName");
            return AccessTypes.Read | AccessTypes.Write;
        }

        Type IDynamicPropertyTypeProvider.GetPropertyType(IServiceProvider serviceProvider, string propertyName)
        {
            Type t = null;

            if (propertyName == "EnumValue")
                t = this.EnumType;

            return t;
        }
    }

    public class FlagsActivityBoundDataSerializer : CodeDomSerializer
    {
        public override object Deserialize(IDesignerSerializationManager manager, object codeObject)
        {
            return null;
        }

        public override object Serialize(IDesignerSerializationManager manager, object value)
        {
            CodeStatementCollection coll = base.Serialize(manager, value) as CodeStatementCollection;
            FlagsActivityBoundData fabd = value as FlagsActivityBoundData;

            if ( null != fabd)
            {

                return coll;
            }
            else
                return base.Serialize(manager, value);
        }
    }

    [DesignerSerializer(typeof(FlagsActivityBoundDataSerializer), typeof(CodeDomSerializer))]
    public class FlagsActivityBoundData
    {
        public ActivityBind Data
        {
            get { return _data; }
            set { _data = value; }
        }

        private ActivityBind _data;
    }
}
