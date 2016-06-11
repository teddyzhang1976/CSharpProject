using System;
using System.DirectoryServices.Protocols;
using System.Net;

namespace DsmlSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri uri = new Uri("http://dsmlserver/dsml");
            var identifier = new DsmlDirectoryIdentifier(uri);

            var credentials = new NetworkCredential();
            credentials.UserName = "cnagel";
            credentials.Password = "password";
            credentials.Domain = "explorer";

            var dsmlConnection = new DsmlSoapHttpConnection(identifier, credentials);

            string distinguishedName = null;
            string ldapFilter = "(objectClass=user)";
            string[] attributesToReturn = null;// return all attributes

            var searchRequest = new SearchRequest(distinguishedName,
                  ldapFilter, SearchScope.Subtree, attributesToReturn);

            SearchResponse searchResponse = (SearchResponse)dsmlConnection.SendRequest(searchRequest);

            Console.WriteLine("\r\nSearch matched {0} entries:", searchResponse.Entries.Count);
            foreach (SearchResultEntry entry in searchResponse.Entries)
            {
                Console.WriteLine(entry.DistinguishedName);

                // retrieve a specific attribute
                DirectoryAttribute attribute = entry.Attributes["ou"];
                Console.WriteLine("{0} = {1}", attribute.Name, attribute[0]);

                // retrieve all attributes
                foreach (DirectoryAttribute attr in entry.Attributes.Values)
                {
                    Console.Write("{0}=", attr.Name);

                    // retrieve all values for the attribute
                    // the type of the value can be one of string, byte[] or Uri
                    foreach (object value in attr)
                    {
                        Console.Write("{0} ", value);
                    }
                    Console.WriteLine();
                }
            }

        }
    }
}
