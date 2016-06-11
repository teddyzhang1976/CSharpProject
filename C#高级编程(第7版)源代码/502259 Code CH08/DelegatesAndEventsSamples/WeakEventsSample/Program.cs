
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

            var nick = new Consumer("Nick");
            WeakCarInfoEventManager.AddListener(dealer, nick);

            dealer.NewCar("Ferrari");

            WeakCarInfoEventManager.RemoveListener(dealer, michael);

            dealer.NewCar("Toyota");
        }
    }
}
