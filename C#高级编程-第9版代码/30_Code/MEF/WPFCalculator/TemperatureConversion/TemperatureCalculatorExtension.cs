using System;
using System.ComponentModel.Composition;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Wrox.ProCSharp.MEF
{
  [CalculatorExtensionExport(typeof(ICalculatorExtension), 
    Title = "Temperature Conversion", 
    Description="Convert Celsius to Fahrenheit and Fahrenheit to Celsius",
    ImageUri = "Temperature.png")]
  public class TemperatureCalculatorExtension : ICalculatorExtension
  {

    private TemperatureConversion control;
    public FrameworkElement UI
    {
      get
      {
        return control ?? (control = new TemperatureConversion());
      }
    }


    private BitmapImage image;
    public BitmapImage Image
    {
      get
      {
        if (image == null)
        {
          image = new BitmapImage();
          image.BeginInit();
          var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Wrox.ProCSharp.MEF.Images.Temperature.png");
          image.StreamSource = stream;
          image.EndInit();
        }
        return image;
      }
    }
  }
}
