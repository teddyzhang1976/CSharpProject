using System;
using System.Activities;
using System.Activities.Core.Presentation;
using System.Activities.Presentation;
using System.Activities.Presentation.Services;
using System.Activities.Presentation.Toolbox;
using System.Activities.Presentation.Validation;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using _09_CustomActivities;
using Microsoft.Win32;

namespace _09_DesignerRehosting
{
    /// <summary>
    /// Exposes the view model to the main application window
    /// </summary>
    public class ViewModel : BaseViewModel, IValidationErrorService
    {
        public ViewModel()
        {
            // Ensure all designers are registered for inbuilt activities
            new DesignerMetadata().Register();
        }

        /// <summary>
        /// Change the view model to display a different root activity
        /// </summary>
        /// <param name="root">The new root actiivty</param>
        public void InitializeViewModel(Activity root)
        {
            InitializeViewModel((designer) => designer.Load(root));
        }

        /// <summary>
        /// Change the view model to load up a workflow from a file
        /// </summary>
        /// <param name="filename">The file that the workflow will be loaded from</param>
        public void InitializeViewModel(string filename)
        {
            InitializeViewModel((designer) => designer.Load(filename));
        }

        /// <summary>
        /// Private method as code is very similar other than the call to load the activity or file into the designer
        /// </summary>
        /// <param name="action"></param>
        private void InitializeViewModel(Action<WorkflowDesigner> action)
        {
            _designer = new WorkflowDesigner();

            // This ensures that all validation errors in the workflow are passed back to me
            // Using this I can disable menu options such as Run that are not valid if
            // the workflow has errors.
            _designer.Context.Services.Publish(typeof(IValidationErrorService), this);

            action(_designer);

            this.OnPropertyChanged("DesignerView");
            this.OnPropertyChanged("PropertyInspectorView");
        }

        /// <summary>
        /// Return the main designer view
        /// </summary>
        public UIElement DesignerView
        {
            get { return _designer.View; }
        }

        /// <summary>
        /// Return the property grid
        /// </summary>
        public UIElement PropertyInspectorView
        {
            get { return _designer.PropertyInspectorView; }
        }

        /// <summary>
        /// Return the toolbox
        /// </summary>
        public UIElement Toolbox
        {
            get
            {
                if (null == _toolbox)
                {
                    _toolbox = new ToolboxControl();

                    ToolboxCategory cat = new ToolboxCategory("Standard Activities");
                    cat.Add(new ToolboxItemWrapper(typeof(Sequence), "Sequence"));
                    cat.Add(new ToolboxItemWrapper(typeof(Assign), "Assign"));
                    _toolbox.Categories.Add(cat);

                    ToolboxCategory custom = new ToolboxCategory("Custom Activities");
                    custom.Add(new ToolboxItemWrapper(typeof(Message), "MessageBox"));
                    _toolbox.Categories.Add(custom);
                }

                return _toolbox;
            }
        }

        /// <summary>
        /// Respond to the New command on the menu
        /// </summary>
        public ICommand New
        {
            get
            {
                return new DelegateCommand(unused => 
                {
                    InitializeViewModel(new Sequence());
                });
            }
        }

        /// <summary>
        /// Open an existing workflow
        /// </summary>
        public ICommand Open
        {
            get
            {
                return new DelegateCommand(unused =>
                {
                    OpenFileDialog ofn = new OpenFileDialog();
                    ofn.Title = "Open Workflow";
                    ofn.Filter = "Workflows (*.xaml)|*.xaml";
                    ofn.CheckFileExists = true;
                    ofn.CheckPathExists = true;

                    if (true == ofn.ShowDialog())
                        InitializeViewModel(ofn.FileName);
                });
            }
        }

        /// <summary>
        /// Save a workflow
        /// </summary>
        public ICommand Save
        {
            get
            {
                return new DelegateCommand(
                    unused =>
                    {
                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.Title = "Save Workflow";
                        sfd.Filter = "Workflows (*.xaml)|*.xaml";
                        if (sfd.ShowDialog() == true)
                            _designer.Save(sfd.FileName);
                    },
                    unused => { return (null != _designer); }
                );
            }
        }

        /// <summary>
        /// Exit from the app
        /// </summary>
        public ICommand Exit
        {
            get
            {
                return new DelegateCommand(unused =>
                {
                    App.Current.MainWindow.Close();
                });
            }
        }

        /// <summary>
        /// Run the current workflow
        /// </summary>
        public ICommand Run
        {
            get
            {
                return new DelegateCommand(unused =>
                {
                    Activity root = _designer.Context.Services.GetService<ModelService>().Root.GetCurrentValue() as Activity;
                    WorkflowInvoker.Invoke(root);
                },
                unused => { return !HasErrors; }
                );
            }
        }

        /// <summary>
        /// Flag indicating whether the workflow has erorrs or not
        /// </summary>
        public bool HasErrors
        {
            get { return (0 != _errorCount); }
        }

        public void ShowValidationErrors(IList<ValidationErrorInfo> errors)
        {
            _errorCount = errors.Count;
            OnPropertyChanged("HasErrors");
        }

        private int _errorCount;
        private WorkflowDesigner _designer;
        private ToolboxControl _toolbox;
    }
}
