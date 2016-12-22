using System;
using System.Net.Sockets;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Wrox.ProCSharp.WinServices
{
  /// <summary>
  /// Interaction logic for Window1.xaml
  /// </summary>
  public partial class QuoteClientWindow : Window
  {
    private QuoteInformation quoteInfo = new QuoteInformation();

    public QuoteClientWindow()
    {
      InitializeComponent();
      this.DataContext = quoteInfo;
    }

    private async void OnGetQuote(object sender, RoutedEventArgs e)
    {
      const int bufferSize = 1024;
      Cursor currentCursor = this.Cursor;
      this.Cursor = Cursors.Wait;
      quoteInfo.EnableRequest = false;

      string serverName = Properties.Settings.Default.ServerName;
      int port = Properties.Settings.Default.PortNumber;

      var client = new TcpClient();
      NetworkStream stream = null;
      try
      {
        await client.ConnectAsync(serverName, port);
        stream = client.GetStream();
        byte[] buffer = new Byte[bufferSize];
        int received = await stream.ReadAsync(buffer, 0, bufferSize);
        if (received <= 0)
        {
          return;
        }
               
        quoteInfo.Quote = Encoding.Unicode.GetString(buffer).Trim('\0');
      }
      catch (SocketException ex)
      {
        MessageBox.Show(ex.Message, "Error Quote of the day",
              MessageBoxButton.OK, MessageBoxImage.Error);
      }
      finally
      {
        if (stream != null)
        {
          stream.Close();
        }

        if (client.Connected)
        {
          client.Close();
        }
      }
      this.Cursor = currentCursor;
      quoteInfo.EnableRequest = true;
    }

  }
}
