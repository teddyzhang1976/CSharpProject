using System;
using System.Windows.Input;

namespace _09_DesignerRehosting
{
    /// <summary>
    /// Implements ICommand in a delegate friendly way
    /// </summary>
    public class DelegateCommand : ICommand
    {
        /// <summary>
        /// Create a command that can always be executed
        /// </summary>
        /// <param name="executeMethod">The method to execute when the command is called</param>
        public DelegateCommand(Action<object> executeMethod) : this(executeMethod, null) { }

        /// <summary>
        /// Create a delegate command which executes the canExecuteMethod before executing the executeMethod
        /// </summary>
        /// <param name="executeMethod"></param>
        /// <param name="canExecuteMethod"></param>
        public DelegateCommand(Action<object> executeMethod, Predicate<object> canExecuteMethod)
        {
            if (null == executeMethod)
                throw new ArgumentNullException("executeMethod");

            this._executeMethod = executeMethod;
            this._canExecuteMethod = canExecuteMethod;
        }

        public bool CanExecute(object parameter)
        {
            return (null == _canExecuteMethod) ? true : _canExecuteMethod(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _executeMethod(parameter);
        }

        private Predicate<object> _canExecuteMethod;
        private Action<object> _executeMethod;
    }
}
