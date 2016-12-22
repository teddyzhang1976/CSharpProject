using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ValidationDemo
{
  public class SomeDataWithNotifications : NotifyDataErrorInfoBase
  {
    private int val1;

    public int Val1
    {
      get { return val1; }
      set
      {
        SetProperty(ref val1, value);
        CheckVal1(val1, value);
      }
    }

    private async void CheckVal1(int oldValue, int newValue, [CallerMemberName] string propertyName = null)
    {
      ClearErrors(propertyName);

      string result = await ValidationSimulator.Validate(newValue, propertyName);
      if (result != null)
      {
        SetError(result, propertyName);
      }
    }
  }

  public static class ValidationSimulator
  {
    public static Task<string> Validate(int val, [CallerMemberName] string propertyName = null)
    {
      return Task<string>.Run(async () =>
        {
          await Task.Delay(3000);
          if (val > 50) return "bad value";
          else return null;
        });
    }
  }
}
