using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketClient
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] receivedBytes = new byte[1024];
            IPHostEntry ipHost = Dns.Resolve("127.0.0.1");
            IPAddress ipAddress = ipHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 2112);
            Console.WriteLine("Starting: Creating Socket object");

            Socket sender = new Socket(AddressFamily.InterNetwork,
                                         SocketType.Stream,
                                         ProtocolType.Tcp);
            sender.Connect(ipEndPoint);
            Console.WriteLine("Successfully connected to {0}",
                   sender.RemoteEndPoint);
            string sendingMessage = "Hello World Socket Test";
            Console.WriteLine("Creating message: Hello World Socket Test");
            byte[] forwardMessage = Encoding.ASCII.GetBytes(sendingMessage
               + "[FINAL]");
            sender.Send(forwardMessage);
            int totalBytesReceived = sender.Receive(receivedBytes);
            Console.WriteLine("Message provided from server: {0}",
                              Encoding.ASCII.GetString(receivedBytes,
                              0, totalBytesReceived));
            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
            Console.ReadLine();

        }
    }
}
