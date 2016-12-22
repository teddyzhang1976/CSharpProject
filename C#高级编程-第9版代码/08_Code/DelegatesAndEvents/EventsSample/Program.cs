namespace Wrox.ProCSharp.Delegates
{
    class Program
    {
        static void Main()
        {
            var dealer = new CarDealer();

            var michael = new Consumer("Michael");
            dealer.NewCarInfo += michael.NewCarIsHere;

            dealer.NewCar("Ferrari");

            var nick = new Consumer("Sebastian");
            dealer.NewCarInfo += nick.NewCarIsHere;

            dealer.NewCar("Mercedes");

            dealer.NewCarInfo -= michael.NewCarIsHere;

            dealer.NewCar("Red Bull Racing");
        }
    }
}
