using System;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels.Ipc;
using System.Runtime.Remoting.Channels.Tcp;

namespace Wrox.ProCSharp.Remoting
{
    class Program
    {
        static void Main()
        {
            //var channel = new TcpServerChannel(8086);
            //ChannelServices.RegisterChannel(channel, true);

            var tcpChannel = new TcpServerChannel(8086);
            tcpChannel.IsSecured = false;
           
            ShowChannelProperties(tcpChannel);
            //var httpChannel = new HttpServerChannel(8085);
            //ShowChannelProperties(httpChannel);

            var properties = new Dictionary<string, string>();
            properties["name"] = "HTTP Channel with a Binary Formatter";
            properties["priority"] = "15";
            properties["port"] = "8085";
            var sinkProvider = new BinaryServerFormatterSinkProvider();
            var httpChannel = new HttpServerChannel(properties, sinkProvider);
            ShowChannelProperties(httpChannel);



            var ipcChannel = new IpcServerChannel("myIPCPort");
            ipcChannel.IsSecured = false;
            ShowChannelProperties(ipcChannel);

            //RemotingConfiguration.RegisterWellKnownServiceType(
            //      typeof(Hello), "Hi", WellKnownObjectMode.SingleCall);
            RemotingConfiguration.ApplicationName = "HelloApp";
            RemotingConfiguration.RegisterActivatedServiceType(typeof(Hello));





            Console.WriteLine("Press return to exit");
            Console.ReadLine();
        }

        static void ShowChannelProperties(IChannelReceiver channel)
        {
            Console.WriteLine("Name:  {0}", channel.ChannelName);
            Console.WriteLine("Priority: {0}", channel.ChannelPriority);
            if (channel is TcpChannel)
            {
                TcpChannel tcpChannel = channel as TcpChannel;
                Console.WriteLine("is secured: {0}", tcpChannel.IsSecured);
            }

            if (channel is HttpServerChannel)
            {
                HttpServerChannel httpChannel = channel as HttpServerChannel;
                Console.WriteLine("Scheme: {0}", httpChannel.ChannelScheme);
            }

            ChannelDataStore data = (ChannelDataStore)channel.ChannelData;
            if (data != null)
            {
                foreach (string uri in data.ChannelUris)
                {
                    Console.WriteLine("URI: " + uri);
                }
            }
            Console.WriteLine();
        }
    }
}
