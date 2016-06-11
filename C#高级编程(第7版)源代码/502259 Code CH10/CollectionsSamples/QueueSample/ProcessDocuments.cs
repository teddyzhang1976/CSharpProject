using System;
using System.Threading;

namespace Wrox.ProCSharp.Collections
{
    public class ProcessDocuments
    {
        public static void Start(DocumentManager dm)
        {
            new Thread(new ProcessDocuments(dm).Run).Start();
        }

        protected ProcessDocuments(DocumentManager dm)
        {
            documentManager = dm;
        }

        private DocumentManager documentManager;

        protected void Run()
        {
            while (true)
            {
                if (documentManager.IsDocumentAvailable)
                {
                    Document doc = documentManager.GetDocument();
                    Console.WriteLine("Processing document {0}", doc.Title);
                }
                Thread.Sleep(new Random().Next(20));
            }
        }
    }

}
