using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Wrox.ProCSharp.MEF
{
  public class BindableBase : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;

    protected void SetProperty<T>(ref T item, T value, [CallerMemberName]string propertyName = "")
    {
      if (!EqualityComparer<T>.Default.Equals(item, value))
      {
        item = value;
        OnPropertyChanged(propertyName);
      }
    }

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
