using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Wrox.ProCSharp.WPF
{
  public class BindableObject : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
      var propertyChanged = PropertyChanged;
      if (propertyChanged != null)
      {
        propertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
    }

    protected virtual void SetProperty<T>(ref T item, T value, [CallerMemberName] string propertyName = null)
    {
      if (!EqualityComparer<T>.ReferenceEquals(item, value))
      {
        item = value;
        OnPropertyChanged(propertyName);
      }
    }
  }
}
