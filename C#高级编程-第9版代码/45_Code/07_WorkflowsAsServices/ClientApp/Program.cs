using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedInterfaces;

namespace ClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Client app running, press [Enter] to call the server");

            Console.ReadLine();

PropertyInformationClient client = new PropertyInformationClient("state");
            //PropertyInformationClient client = new PropertyInformationClient("server");

            Guid propertyId = client.UploadPropertyInformation("Bilbo Baggins", "Bag End, Hobbiton", 295000);

            Console.WriteLine("Property id = {0}", propertyId);

            Console.WriteLine("Created workflow, [Enter] to continue");
            Console.ReadLine();

            // Now upload some room dimensions
            client.UploadRoomInformation(propertyId, "Kitchen", 20, 30);
            client.UploadRoomInformation(propertyId, "Parlour", 10, 12);
            client.UploadRoomInformation(propertyId, "Pantry", 5, 15);

            Console.WriteLine("Uploaded some room dimensions, [Enter] to complete");
            Console.ReadLine();

            client.DetailsComplete(propertyId);
        }
    }
}
