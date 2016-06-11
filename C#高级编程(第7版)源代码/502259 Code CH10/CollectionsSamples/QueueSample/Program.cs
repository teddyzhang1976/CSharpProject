using System;
using System.Threading;

namespace Wrox.ProCSharp.Collections
{
    class Program
    {
        static void Main()
        {
            var dm = new DocumentManager();

            ProcessDocuments.Start(dm);

            // Create documents and add them to the DocumentManager
            for (int i = 0; i < 1000; i++)
            {
                Document doc = new Document("Doc " + i.ToString(), "content");
                dm.AddDocument(doc);
                Console.WriteLine("Added document {0}", doc.Title);
                Thread.Sleep(new Random().Next(20));
            }

        }
    }
}
