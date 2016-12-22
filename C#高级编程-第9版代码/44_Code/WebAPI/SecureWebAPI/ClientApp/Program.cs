using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ClientApp
{
  class Program
  {
    private const string baseAddress = "http://localhost:11663";
    static void Main(string[] args)
    {
      Run();
      Console.ReadLine();
    }

    private static void Run()
    {
      Console.WriteLine("client - wait for service");
      Console.ReadLine();
      // NotAuthenticated();
     //  RegisterUser();
      // var token = await GetToken();
      Authenticated();
      // UserInfo();
      // Authenticate2();
    }

    //private async static void Authenticate2()
    //{
    //  string tokenUri = "/Token";
    //  HttpClient client = new HttpClient();
    //  client.BaseAddress = new Uri("http://localhost:11663");
    //  client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("password", "username=christian&password=Password123");
    //  HttpResponseMessage resp = await client.PostAsync(tokenUri,)

    //}

    private async static void UserInfo()
    {
      string userInfoUri = "/api/Account/UserInfo";
      var token = await GetToken();
      HttpClient client = new HttpClient();
      client.BaseAddress = new Uri(baseAddress);
      client.DefaultRequestHeaders.Add("Authorization", string.Format("{0} {1}", token.token_type, token.access_token));

      HttpResponseMessage resp = await client.GetAsync(userInfoUri);
      resp.EnsureSuccessStatusCode();
      UserInfo userInfo = await resp.Content.ReadAsAsync<UserInfo>();
      Console.WriteLine("user: {0}, registered: {1}, provider: {2}", userInfo.UserName, userInfo.HasRegistered, userInfo.LoginProvider);
    }

    private async static Task<dynamic> GetToken()
    {
      string tokenUri = "/Token";
      var client = new HttpClient();
      client.BaseAddress = new Uri(baseAddress);

      HttpContent content = new FormUrlEncodedContent(
                new List<KeyValuePair<string, string>> { 
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string,string>("username","christian"),
                    new KeyValuePair<string,string>("password","Password123"),
                });
      content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
      content.Headers.ContentType.CharSet = "UTF-8";

      HttpResponseMessage resp = await client.PostAsync(tokenUri, content);

      resp.EnsureSuccessStatusCode();
      dynamic token = await resp.Content.ReadAsAsync<dynamic>();
      Console.WriteLine("{0}", token.token_type);
      Console.WriteLine("{0}", token.access_token);
      Console.WriteLine();
      return token;
    }

    private async static void Authenticated()
    {
      dynamic token = await GetToken();

      string valuesUri = "/api/Values";
      var client = new HttpClient();
      client.BaseAddress = new Uri(baseAddress);

      client.DefaultRequestHeaders.Add("Authorization", string.Format("{0} {1}", token.token_type, token.access_token));

      HttpResponseMessage resp = await client.GetAsync(valuesUri);

      Console.WriteLine(resp.StatusCode);

      string content = await resp.Content.ReadAsStringAsync();
      Console.WriteLine(content);
    }

    private async static void NotAuthenticated()
    {
      string valuesUri = "/api/Values";
      var client = new HttpClient();
      client.BaseAddress = new Uri(baseAddress);
      HttpResponseMessage resp = await client.GetAsync(valuesUri);

      Console.WriteLine(resp.StatusCode);
      string result = await resp.Content.ReadAsStringAsync();

    }

    private async static void RegisterUser()
    {
      string registerUri = "/api/Account/Register";
      HttpClient client = new HttpClient();
      client.BaseAddress = new Uri(baseAddress);

      var user = new
        {
          UserName = "christian",
          Password = "Password123",
          ConfirmPassword = "Password123"
        };

      HttpResponseMessage resp = await client.PostAsJsonAsync(registerUri, user);

      resp.EnsureSuccessStatusCode();
      Console.WriteLine("registered successfully");

    }
  }
}
