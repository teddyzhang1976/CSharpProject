using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Wrox.ProCSharp.Collections
{
  public static class PipelineStages
  {
    public static Task ReadFilenamesAsync(string path, BlockingCollection<string> output)
    {
      return Task.Run(() =>
        {
          foreach (string filename in Directory.EnumerateFiles(path, "*.cs", SearchOption.AllDirectories))
          {
            output.Add(filename);
            ConsoleHelper.WriteLine(string.Format("stage 1: added {0}", filename));
          }
          output.CompleteAdding();
        });
    }

    public static async Task LoadContentAsync(BlockingCollection<string> input, BlockingCollection<string> output)
    {
      foreach (var filename in input.GetConsumingEnumerable())
      {
        using (FileStream stream = File.OpenRead(filename))
        {
          var reader = new StreamReader(stream);
          string line = null;
          while ((line = await reader.ReadLineAsync()) != null)
          {
            output.Add(line);
            ConsoleHelper.WriteLine(string.Format("stage 2: added {0}", line));
          }
        }
      }
      output.CompleteAdding();
    }

    public static Task ProcessContentAsync(BlockingCollection<string> input, ConcurrentDictionary<string, int> output)
    {
      return Task.Run(() =>
        {
          foreach (var line in input.GetConsumingEnumerable())
          {
            string[] words = line.Split(' ', ';', '\t', '{', '}', '(', ')', ':', ',', '"');
            foreach (var word in words.Where(w => !string.IsNullOrEmpty(w)))
            {
              output.AddOrIncrementValue(word);
              ConsoleHelper.WriteLine(string.Format("stage 3: added {0}", word));
            }
          }
        });
    }

    public static Task TransferContentAsync(ConcurrentDictionary<string, int> input, BlockingCollection<Info> output)
    {
      return Task.Run(() =>
        {
          foreach (var word in input.Keys)
          {
            int value;
            if (input.TryGetValue(word, out value))
            {
              var info = new Info { Word = word, Count = value };
              output.Add(info);
              ConsoleHelper.WriteLine(string.Format("stage 4: added {0}", info));
            }
          }
          output.CompleteAdding();
        });
    }

    public static Task AddColorAsync(BlockingCollection<Info> input, BlockingCollection<Info> output)
    {
      return Task.Run(() =>
        {
          foreach (var item in input.GetConsumingEnumerable())
          {
            if (item.Count > 40)
            {
              item.Color = "Red";
            }
            else if (item.Count > 20)
            {
              item.Color = "Yellow";
            }
            else
            {
              item.Color = "Green";
            }
            output.Add(item);
            ConsoleHelper.WriteLine(string.Format("stage 5: added color {1} to {0}", item, item.Color));
          }
          output.CompleteAdding();
        });
    }

    public static Task ShowContentAsync(BlockingCollection<Info> input)
    {
      return Task.Run(() =>
        {
          foreach (var item in input.GetConsumingEnumerable())
          {
            ConsoleHelper.WriteLine(string.Format("stage 6: {0}", item), item.Color);
          }
        });
    }
  }
}
