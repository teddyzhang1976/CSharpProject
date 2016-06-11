using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Wrox.ProCSharp.MEF
{
    /// <summary>
    /// Interaction logic for FuelEconomyUC.xaml
    /// </summary>
    public partial class FuelEconomyUC : UserControl
    {
        private List<FuelEconomyType> fuelEcoTypes;

        public FuelEconomyUC()
        {
            InitializeComponent();
            InitializeFuelEcoTypes();
        }

        private void InitializeFuelEcoTypes()
        {
            var t1 = new FuelEconomyType 
            { 
                Id = "lpk", 
                Text = "L/100 km",
                DistanceText = "Distance (kilometers)",
                FuelText = "Fuel used (liters)"
            };
            var t2 = new FuelEconomyType 
            { 
                Id = "mpg", 
                Text = "Miles per gallon",
                DistanceText = "Distance (miles)",
                FuelText = "Fuel used (gallons)"
            };
            fuelEcoTypes = new List<FuelEconomyType>() { t1, t2 };
            this.DataContext = fuelEcoTypes;

            
        }

        private void OnCalculate(object sender, RoutedEventArgs e)
        {
            double fuel = double.Parse(textFuel.Text);
            double distance = double.Parse(textDistance.Text);
            FuelEconomyType ecoType = comboFuelEco.SelectedItem as FuelEconomyType;
            double result = 0;
            switch (ecoType.Id)
            {
                case "lpk":
                    result = fuel / (distance / 100);
                    break;
                case "mpg":
                    result = distance / fuel;
                    break;
                default:
                    break;
            }
            this.textResult.Text = result.ToString();
        }
    }
}
