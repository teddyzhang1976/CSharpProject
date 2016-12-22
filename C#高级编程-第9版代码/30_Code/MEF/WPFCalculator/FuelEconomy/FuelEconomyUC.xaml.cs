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
    private FuelEconomyViewModel viewModel = new FuelEconomyViewModel();

    public FuelEconomyUC()
    {
      InitializeComponent();
      this.DataContext = viewModel;
    }


    private void OnCalculate(object sender, RoutedEventArgs e)
    {
      double fuel = double.Parse(viewModel.Fuel);
      double distance = double.Parse(viewModel.Distance);
      FuelEconomyType ecoType = viewModel.SelectedFuelEcoType;
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
      viewModel.Result = result.ToString();
    }
  }
}
