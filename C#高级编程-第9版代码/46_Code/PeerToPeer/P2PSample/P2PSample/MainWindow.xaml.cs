using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.PeerToPeer;
using System.Net.Sockets;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace P2PSample
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private P2PService localService;
    private ServiceHost host;
    private PeerName peerName;
    private PeerNameRegistration peerNameRegistration;
    private ObservableCollection<PeerEntry> peerList = new ObservableCollection<PeerEntry>();
    private object peersLock = new object();

    public MainWindow()
    {
      InitializeComponent();
      this.DataContext = peerList;
      peerList.Add(
        new PeerEntry
        {
          DisplayString = "Refresh to look for peers.",
          ButtonsEnabled = false
        });
      BindingOperations.EnableCollectionSynchronization(peerList, peersLock);
    }

    protected override void OnClosing(CancelEventArgs e)
    {
      // Stop registration
      peerNameRegistration.Stop();
      peerNameRegistration.Dispose();

      // Stop WCF service
      if (host.State == CommunicationState.Opened)
        host.Close();

      base.OnClosing(e);
    }


    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
      // Get configuration from app.config
      string port = ConfigurationManager.AppSettings["port"];
      string username = ConfigurationManager.AppSettings["username"];
      string machineName = Environment.MachineName;
      string serviceUrl = null;

      // Set window title
      this.Title = string.Format("P2P example - {0}", username);

      // Get service url using IPv4 address and port from config file
      serviceUrl = Dns.GetHostAddresses(Dns.GetHostName())
        .Where(address => address.AddressFamily == AddressFamily.InterNetwork)
        .Select(address => string.Format("net.tcp://{0}:{1}/P2PService", address, port)).FirstOrDefault();

      // Check for null address
      if (serviceUrl == null)
      {
        // Display error and shutdown
        MessageBox.Show(this, "Unable to determine WCF endpoint.", "Networking Error", MessageBoxButton.OK, MessageBoxImage.Stop);
        Application.Current.Shutdown();
      }

      // Register and start WCF service.
      localService = new P2PService(this, username);
      host = new ServiceHost(localService, new Uri(serviceUrl));
      var binding = new NetTcpBinding();
      binding.Security.Mode = SecurityMode.None;
      host.AddServiceEndpoint(typeof(IP2PService), binding, serviceUrl);
      try
      {
        host.Open();
      }
      catch (AddressAlreadyInUseException)
      {
        // Display error and shutdown
        MessageBox.Show(this, "Cannot start listening, port in use.", "WCF Error", MessageBoxButton.OK, MessageBoxImage.Stop);
        Application.Current.Shutdown();
      }

      // Create peer name
      peerName = new PeerName("P2P Sample", PeerNameType.Unsecured);

      // Prepare peer name registration in link local clouds
      peerNameRegistration = new PeerNameRegistration(peerName, int.Parse(port));
      peerNameRegistration.Cloud = Cloud.AllLinkLocal;

      // Start registration
      peerNameRegistration.Start();

    }


    private async void RefreshButton_Click(object sender, RoutedEventArgs e)
    {
      // Create resolver and add event handlers
      var resolver = new PeerNameResolver();
      resolver.ResolveProgressChanged += new EventHandler<ResolveProgressChangedEventArgs>(resolver_ResolveProgressChanged);
      resolver.ResolveCompleted += new EventHandler<ResolveCompletedEventArgs>(resolver_ResolveCompleted);

      // Prepare for new peers
      peerList.Clear();
      RefreshButton.IsEnabled = false;

      // Resolve unsecured peers asynchronously
      resolver.ResolveAsync(new PeerName("0.P2P Sample"), 1);

      await Task.Delay(5000);  // to fire the Completed event latest after 5 seconds
      resolver.ResolveAsyncCancel(1);
    }

    void resolver_ResolveCompleted(object sender, ResolveCompletedEventArgs e)
    {
      // Add failure message if necessary
      if (peerList.Count == 0)
      {
        lock (peersLock)
        {
          peerList.Add(
            new PeerEntry
            {
              DisplayString = "No peers found.",
              ButtonsEnabled = false
            });
        }
      }
      // Reenable refresh button
      RefreshButton.IsEnabled = true;
    }

    void resolver_ResolveProgressChanged(object sender, ResolveProgressChangedEventArgs e)
    {
      // Get peer record from event args
      PeerNameRecord peer = e.PeerNameRecord;

      // Examine endpoints for peer
      peer.EndPointCollection.Where(ep => ep.Address.AddressFamily == AddressFamily.InterNetwork)
        .AsParallel().ForAll(ep =>
        {
          try
          {
            // Get service reference
            string endpointUrl = string.Format("net.tcp://{0}:{1}/P2PService", ep.Address, ep.Port);
            var binding = new NetTcpBinding();
            binding.Security.Mode = SecurityMode.None;
            IP2PService serviceProxy = ChannelFactory<IP2PService>.CreateChannel(binding, new EndpointAddress(endpointUrl));

            lock (peersLock)
            {
              peerList.Add(
                new PeerEntry
                {
                  PeerName = peer.PeerName,
                  ServiceProxy = serviceProxy,
                  DisplayString = serviceProxy.GetName(),
                  ButtonsEnabled = true
                }
              );
            }
          }
          catch (EndpointNotFoundException)
          {
            // Add client but not extra info.
            lock (peersLock)
            {
              peerList.Add(
                new PeerEntry
                {
                  PeerName = peer.PeerName,
                  DisplayString = "Unknown peer",
                  ButtonsEnabled = false
                }
              );
            }
          }
        });
    }


    private void PeerList_Click(object sender, RoutedEventArgs e)
    {
      // Ensure button is MessageButton
      if (((Button)e.OriginalSource).Name == "MessageButton")
      {
        // Get peer and service proxy, send message with one way method.
        PeerEntry peerEntry = ((Button)e.OriginalSource).DataContext as PeerEntry;
        if (peerEntry != null && peerEntry.ServiceProxy != null)
        {
          try
          {
            peerEntry.ServiceProxy.SendMessage("Hi there!", ConfigurationManager.AppSettings["username"]);
          }
          catch (CommunicationException)
          {
            // Ignore - thrown when the peer already has a dialog open.
          }
        }
      }
    }

    internal void DisplayMessage(string message, string from)
    {
      // Display received message (called from WCF service)
      MessageBox.Show(this, message, string.Format("Message from {0}", from), MessageBoxButton.OK, MessageBoxImage.Information);
    }
  }
}
