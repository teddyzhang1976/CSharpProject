using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ValidationDemo
{
  public abstract class NotifyDataErrorInfoBase : BindableObject, INotifyDataErrorInfo
  {
    public void SetError(string errorMessage, [CallerMemberName] string propertyName = null)
    {
      List<string> errorList;
      if (errors.TryGetValue(propertyName, out errorList))
      {
        errorList.Add(errorMessage);
      }
      else
      {
        errorList = new List<string> { errorMessage };
        errors.Add(propertyName, errorList);
      }
      HasErrors = true;
      OnErrorsChanged(propertyName);
    }

    public void ClearErrors([CallerMemberName] string propertyName = null)
    {
      if (hasErrors)
      {
        List<string> errorList;
        if (errors.TryGetValue(propertyName, out errorList))
        {
          errors.Remove(propertyName);
        }
        if (errors.Count == 0)
        {
          HasErrors = false;
        }
        OnErrorsChanged(propertyName);
      }
    }

    public void ClearAllErrors()
    {
      if (HasErrors)
      {
        errors.Clear();
        HasErrors = false;
        OnErrorsChanged(null);
      }
    }

    public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

    private Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();
    public IEnumerable GetErrors(string propertyName)
    {
      List<string> errorsForProperty;
      bool err = errors.TryGetValue(propertyName, out errorsForProperty);
      if (!err) return null;
      return errorsForProperty;
    }

    private bool hasErrors = false;
    public bool HasErrors
    {
      get { return hasErrors; }
      protected set { 
        if (SetProperty(ref hasErrors, value))
        {
          OnErrorsChanged(propertyName: null);
        }
      }
    }

    protected void OnErrorsChanged([CallerMemberName] string propertyName = null)
    {
      var errorsChanged = ErrorsChanged;
      if (errorsChanged != null)
      {
        errorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
      }
    }
  }
}
