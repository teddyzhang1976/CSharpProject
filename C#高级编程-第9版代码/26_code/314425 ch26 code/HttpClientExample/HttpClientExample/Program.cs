using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace HttpClientExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("In main before call to GetData!");
            GetData();
            Console.WriteLine("Back in main after call to GetData!");
            Console.ReadKey();
        }

        private static async void GetData()
        {
            HttpClient httpClient = new HttpClient();
            //httpClient.DefaultRequestHeaders.Add("Accept", "application/json;odata=verbose");
            HttpResponseMessage response = null;
            response = await httpClient.GetAsync("http://services.odata.org/Northwind/Northwind.svc/Regions");
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Response Status Code and Reason Phrase: " + response.StatusCode + " " + response.ReasonPhrase);
                string responseBodyAsText = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine("Received payload of " + responseBodyAsText.Length + " characters");
                Console.WriteLine(responseBodyAsText);
            }
        }
    }
}
