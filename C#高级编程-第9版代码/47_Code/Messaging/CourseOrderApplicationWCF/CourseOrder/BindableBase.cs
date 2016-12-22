using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Wrox.ProCSharp.Messaging
{
  [DataContract]
  public abstract class BindableBase : INotifyPropertyChanged
  {
    protected void SetProperty<T>(ref T prop, T value, [CallerMemberName] string callerName = "")
    {
      if (!EqualityComparer<T>.Default.Equals(prop, value))
      {
        prop = value;
        OnPropertyChanged(callerName);
      }
    }
    
    protected virtual void OnPropertyChanged(string propertyName)
    {
      PropertyChangedEventHandler propertyChanged = PropertyChanged;
      if (propertyChanged != null)
      {
        propertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;
  }
}
