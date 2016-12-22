
namespace Wrox.ProCSharp.Delegates
{
  class Program
  {
    static void Main()
    {
      var dealer = new CarDealer();

      var michael = new Consumer("Michael");
      WeakCarInfoEventManager.AddListener(dealer, michael);

      dealer.NewCar("Mercedes");

      var sebastian = new Consumer("Sebastian");
      WeakCarInfoEventManager.AddListener(dealer, sebastian);

      dealer.NewCar("Ferrari");

      WeakCarInfoEventManager.RemoveListener(dealer, michael);

      dealer.NewCar("Red Bull Racing");
    }
  }
}
