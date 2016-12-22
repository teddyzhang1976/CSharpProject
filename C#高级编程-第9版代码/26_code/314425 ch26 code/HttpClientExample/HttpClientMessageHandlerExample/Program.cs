using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace HttpClientMessageHandlerExample
{
    class Program
    {

        static void Main(string[] args)
        {
            GetData();
            Console.ReadKey();
        }

private static void GetData()
{
    HttpClient httpClient = new HttpClient(new MessageHandler("error"));
    HttpResponseMessage response = null;
    Console.WriteLine();
    response = httpClient.GetAsync("http://services.odata.org/Northwind/Northwind.svc/Regions").Result;
    Console.WriteLine(response.StatusCode);
}
    }

public class MessageHandler : HttpClientHandler
{
    string displayMessage = "";
    public MessageHandler (string message)
    {
        displayMessage = message;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
    {
        Console.WriteLine("In DisplayMessageHandler " + displayMessage);
        if(displayMessage == "error")
        {
            var response = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }
        return base.SendAsync(request, cancellationToken);
    }
}
}
