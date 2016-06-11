using System.ComponentModel.Composition;
using System.Windows;

namespace Wrox.ProCSharp.MEF
{
    [Export(typeof(ICalculatorExtension))]
    public class TemperatureCalculatorExtension : ICalculatorExtension
    {
        public string Title
        {
            get { return "Temperature Conversion"; }
        }

        public string Description
        {
            get { return "Convert Celsius to Fahrenheit and Fahrenheit to Celsius"; }
        }

        public FrameworkElement GetUI()
        {
            return new TemperatureConversion();
        }
    }
}
