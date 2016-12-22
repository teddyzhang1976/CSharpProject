using AppSettingsSample.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Settings Flyout item template is documented at http://go.microsoft.com/fwlink/?LinkId=273769

namespace AppSettingsSample
{
  public sealed partial class SettingsFlyout1 : SettingsFlyout
  {
    public SettingsFlyout1()
    {
      this.InitializeComponent();
      this.DataContext = this;
      
    }


    public string Text1
    {
      get { return RoamingSettings.GetValue(String.Empty); }
      set { RoamingSettings.SetValue(value); }
    }

    
  }
}
