using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ValidationDemo
{
  public abstract class BindableObject : INotifyPropertyChanged
  {
    protected bool SetProperty<T>(ref T item, T value, [CallerMemberName] string propertyName = null)
    {
      if (!EqualityComparer<T>.Default.Equals(item, value))
      {
        item = value;
        OnPropertyChanged(propertyName);
        return true;
      }
      return false;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
      var propertyChanged = PropertyChanged;
      if (propertyChanged != null)
      {
        propertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
    }
  }
}
