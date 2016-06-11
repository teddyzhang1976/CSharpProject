using System.ComponentModel.Composition;
using System.Windows;

namespace Wrox.ProCSharp.MEF
{
    [Export(typeof(ICalculatorExtension))]
    public class FuelCalculatorExtension : ICalculatorExtension
    {
        public string Title
        {
            get { return "Fuel Economy"; }
        }

        public string Description
        {
            get { return "Calculate fuel economy"; }
        }

        public FrameworkElement GetUI()
        {
            return new FuelEconomyUC();
        }
    }
}
