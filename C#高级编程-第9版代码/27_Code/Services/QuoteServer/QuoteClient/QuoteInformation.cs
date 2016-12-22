using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Wrox.ProCSharp.WinServices
{
  public class QuoteInformation : INotifyPropertyChanged
  {
    public QuoteInformation()
    {
      EnableRequest = true;
    }
    private string quote;
    public string Quote
    {
      get
      {
        return quote;
      }
      internal set
      {
        SetProperty(ref quote, value);
      }
    }

    private bool enableRequest;
    public bool EnableRequest
    {
      get
      {
        return enableRequest;
      }
      internal set
      {
        SetProperty(ref enableRequest, value);
      }
    }

    private void SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
    {
      if (!EqualityComparer<T>.Default.Equals(field, value))
      {
        field = value;
        var handler = PropertyChanged;
        if (handler != null)
        {
          handler(this, new PropertyChangedEventArgs(propertyName));
        }
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;
  }
}
