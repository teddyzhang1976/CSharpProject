using System.Windows;
namespace Wrox.ProCSharp.Delegates
{
  class Program
  {
    static void Main()
    {
      var dealer = new CarDealer();

      var michael = new Consumer("Michael");
      WeakEventManager<CarDealer, CarInfoEventArgs>.AddHandler(dealer, "NewCarInfo", michael.NewCarIsHere);
      dealer.NewCarInfo += michael.NewCarIsHere;

      dealer.NewCar("Ferrari");

      var sebastian = new Consumer("Sebastian");
      WeakEventManager<CarDealer, CarInfoEventArgs>.AddHandler(dealer, "NewCarInfo", sebastian.NewCarIsHere);
      dealer.NewCarInfo += sebastian.NewCarIsHere;

      dealer.NewCar("Mercedes");

      dealer.NewCarInfo -= michael.NewCarIsHere;

      dealer.NewCar("Red Bull");
    }
  }
}
