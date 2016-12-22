using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Wrox.ProCSharp.WinServices
{
  public class QuoteServer
  {
    private TcpListener listener;
    private int port;
    private string filename;
    private List<string> quotes;
    private Random random;
    private Task listenerTask;

    public QuoteServer()
      : this("quotes.txt")
    {
    }
    public QuoteServer(string filename)
      : this(filename, 7890)
    {
    }
    public QuoteServer(string filename, int port)
    {
      Contract.Requires<ArgumentNullException>(filename != null);
      Contract.Requires<ArgumentException>(port >= IPEndPoint.MinPort && port <= IPEndPoint.MaxPort);

      this.filename = filename;
      this.port = port;
    }

    protected void ReadQuotes()
    {
      try
      {
        quotes = File.ReadAllLines(filename).ToList();
        if (quotes.Count == 0)
          throw new QuoteException("quotes file is empty");

        random = new Random();
      }
      catch (IOException ex)
      {
        throw new QuoteException("I/O error", ex);
      }
    }

    protected string GetRandomQuoteOfTheDay()
    {
      int index = random.Next(0, quotes.Count);
      return quotes[index];
    }

    public void Start()
    {
      ReadQuotes();

      listenerTask = Task.Factory.StartNew(Listener, TaskCreationOptions.LongRunning);
    }

    protected void Listener()
    {
      try
      {
        IPAddress ipAddress = IPAddress.Any;
        listener = new TcpListener(ipAddress, port);
        listener.Start();
        while (true)
        {
          Socket clientSocket = listener.AcceptSocket();
          string message = GetRandomQuoteOfTheDay();
          var encoder = new UnicodeEncoding();
          byte[] buffer = encoder.GetBytes(message);
          clientSocket.Send(buffer, buffer.Length, 0);
          clientSocket.Close();
        }
      }
      catch (SocketException ex)
      {
        Trace.TraceError(String.Format("QuoteServer {0}", ex.Message));
        throw new QuoteException("socket error", ex);
      }
    }

    public void Stop()
    {
      listener.Stop();
    }
    public void Suspend()
    {
      listener.Stop();
    }

    private void StopListener()
    {
      
    }

    public void Resume()
    {
      Start();
    }

    public void RefreshQuotes()
    {
      ReadQuotes();
    }
  }
}
