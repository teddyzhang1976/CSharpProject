using System;
using System.Drawing;

namespace ClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            PropertyExample();
        }

        private static void PropertyExample()
        {
            Console.WriteLine("Client ready, press [Enter] to upload information to the service...");
            Console.ReadLine();

            // Bilbo is selling up...
            Guid id = UploadProperty("Bilbo Baggins", "Bag End, Hobbiton", 295000);
            Console.WriteLine("Property = {0}", id);

            Console.WriteLine("Press [Enter] to upload room information");
            Console.ReadLine();

            // His kitchen is the largest room, No surprise there
            UploadRoom(id, "Kitchen", 30, 20);
            UploadRoom(id, "Dining Room", 20, 15.5);
            UploadRoom(id, "Sitting Room", 15, 18);

            Console.WriteLine("Press [Enter] to complete the upload");
            Console.ReadLine();

            DetailsComplete(id);
        }

        /// <summary>
        /// This kicks off the workflow and returns the property ID
        /// </summary>
        /// <param name="ownerName"></param>
        /// <param name="streetAddress"></param>
        /// <param name="askingPrice"></param>
        /// <returns></returns>
        static Guid UploadProperty(string ownerName, string streetAddress, double askingPrice)
        {
            PropertyService.PropertyClient client = new PropertyService.PropertyClient();
            Guid? id = client.UploadPropertyInformation(new PropertyService.UploadPropertyInformation { owner = ownerName, address = streetAddress, askingPrice = askingPrice });

            return id.Value;
        }

        /// <summary>
        /// Add some room information
        /// </summary>
        /// <param name="id"></param>
        /// <param name="roomName"></param>
        /// <param name="width"></param>
        /// <param name="depth"></param>
        static void UploadRoom(Guid id, string roomName, double width, double depth)
        {
            PropertyService.PropertyClient client = new PropertyService.PropertyClient();
            client.UploadRoomInformation(id, roomName, width, depth);
        }

        /// <summary>
        /// Send the end of message
        /// </summary>
        /// <param name="id"></param>
        static void DetailsComplete(Guid id)
        {
            PropertyService.PropertyClient client = new PropertyService.PropertyClient();

            client.DetailsComplete(id);
        }
    }
}
