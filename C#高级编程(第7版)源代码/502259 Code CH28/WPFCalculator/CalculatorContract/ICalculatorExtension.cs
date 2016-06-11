using System.Windows;

namespace Wrox.ProCSharp.MEF
{
    public interface ICalculatorExtension
    {
        string Title { get; }
        string Description { get; }

        FrameworkElement GetUI();
    }
}
