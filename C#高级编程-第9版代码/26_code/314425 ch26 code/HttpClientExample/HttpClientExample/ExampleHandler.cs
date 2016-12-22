using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientExample
{
    class ExampleHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            Console.WriteLine("This is from ExampleHandler");
            if(InnerHandler == null)
            {
                return null;
            }
            return base.SendAsync(request,cancellationToken)
                .ContinueWith(task => 
                    {
                        return task.Result;
                    });
        }
    }
}
