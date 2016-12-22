using System.Runtime.CompilerServices;
using Windows.Storage;

namespace AppSettingsSample.Utilities
{
  static class RoamingSettings
  {
    public static T GetValue<T>(T defaultValue = default(T), [CallerMemberName] string propertyName = null)
    {
      return (T)(ApplicationData.Current.RoamingSettings.Values[propertyName] ?? defaultValue);
    }

    public static void SetValue<T>(T value, [CallerMemberName] string propertyName = null)
    {
      ApplicationData.Current.RoamingSettings.Values[propertyName] = value;
    }
  }
}
