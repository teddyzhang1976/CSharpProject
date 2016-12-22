using System.Windows.Media.Imaging;

namespace Wrox.ProCSharp.MEF
{
  public interface ICalculatorExtensionMetadata
  {
    string Title { get; }
    string Description { get; }

    string ImageUri { get; }
  }
}
