using System.Collections.Concurrent;

namespace Wrox.ProCSharp.Collections
{
  public static class ConcurrentDictionaryExtension
  {
    public static void AddOrIncrementValue(this ConcurrentDictionary<string, int> dict, string key)
    {
      bool success = false;
      while (!success)
      {
        int value;
        if (dict.TryGetValue(key, out value))
        {
          if (dict.TryUpdate(key, value + 1, value))
          {
            success = true;
          }
        }
        else
        {
          if (dict.TryAdd(key, 1))
          {
            success = true;
          }
        }
      }
    }
  }
}
