using System;
using System.Windows;
using System.Windows.Controls;

namespace Wrox.ProCSharp.MEF
{

    public enum TempConversionType
    {
        Celsius,
        Fahrenheit,
        Kelvin
    }
    /// <summary>
    /// Interaction logic for TemperatureConversion.xaml
    /// </summary>
    public partial class TemperatureConversion : UserControl
    {
        public TemperatureConversion()
        {
            InitializeComponent();
            this.DataContext = Enum.GetNames(typeof(TempConversionType));
        }

        private double ToCelsiusFrom(double t, TempConversionType conv)
        {
            switch (conv)
            {
                case TempConversionType.Celsius:
                    return t;
                case TempConversionType.Fahrenheit:
                    return (t - 32) / 1.8;
                case TempConversionType.Kelvin:
                    return (t - 273.15);
                default:
                    throw new ArgumentException("invalid enumeration value");
            }
        }
        private double FromCelsiusTo(double t, TempConversionType conv)
        {
            switch (conv)
            {
                case TempConversionType.Celsius:
                    return t;
                case TempConversionType.Fahrenheit:
                    return (t * 1.8) + 32;
                case TempConversionType.Kelvin:
                    return t + 273.15;
                default:
                    throw new ArgumentException("invalid enumeration value");
            }
        }

        private void OnCalculate(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                TempConversionType from;
                TempConversionType to;
                if (Enum.TryParse<TempConversionType>((string)comboFrom.SelectedValue, out from) &&
                    Enum.TryParse<TempConversionType>((string)comboTo.SelectedValue, out to))
                {
                    double result = FromCelsiusTo(ToCelsiusFrom(double.Parse(textInput.Text), from), to);
                    textOutput.Text = result.ToString();
                }

            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    }
}
