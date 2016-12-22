using System.Collections.Generic;

namespace Wrox.ProCSharp.MEF
{
  public class FuelEconomyViewModel : BindableBase
  {
    public FuelEconomyViewModel()
    {
      InitializeFuelEcoTypes();
    }

    private List<FuelEconomyType> fuelEcoTypes;
    public List<FuelEconomyType> FuelEcoTypes
    {
      get
      {
        return fuelEcoTypes;
      }
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
    }

    private FuelEconomyType selectedFuelEcoType;

    public FuelEconomyType SelectedFuelEcoType
    {
      get { return selectedFuelEcoType; }
      set { SetProperty(ref selectedFuelEcoType, value); }
    }

    private string fuel;
    public string Fuel
    {
      get { return fuel; }
      set { SetProperty(ref fuel, value); }
    }

    private string distance;
    public string Distance
    {
      get { return distance; }
      set { SetProperty(ref distance, value); }
    }

    private string result;
    public string Result
    {
      get { return result; }
      set { SetProperty(ref result, value); }
    }
    
  } 
}
