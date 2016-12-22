using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace HttpClientHeadersExample
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
    HttpClient httpClient = new HttpClient();
    HttpResponseMessage response = null;
    httpClient.DefaultRequestHeaders.Add("Accept", "application/json;odata=verbose");
    Console.WriteLine("Request Headers:");
    EnumerateHeaders(httpClient.DefaultRequestHeaders);
    Console.WriteLine();
    response = httpClient.GetAsync("http://services.odata.org/Northwind/Northwind.svc/Regions").Result;
    if (response.IsSuccessStatusCode)
    {
        Console.WriteLine("Response Headers:");
        EnumerateHeaders(response.Headers);
    }
}

private static void EnumerateHeaders(HttpHeaders headers)
{
    foreach (var header in headers)
    {
        var value = "";
        foreach (var val in header.Value)
        {
            value = val + " ";
        }
        Console.WriteLine("Header: " + header.Key + " Value: " + value);
    }
}
    }
}
