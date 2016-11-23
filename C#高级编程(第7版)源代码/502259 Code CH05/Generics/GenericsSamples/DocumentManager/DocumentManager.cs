using System;
using System.Collections.Generic;

namespace Wrox.ProCSharp.Generics
{
    public class DocumentManager<GDoc>
        where GDoc : IDocument
    {
        private readonly Queue<GDoc> documentQueue = new Queue<GDoc>();

        public void AddDocument(GDoc doc)
        {
            lock (this)
            {
                documentQueue.Enqueue(doc);
            }
        }

        public bool IsDocumentAvailable
        {
            get { return documentQueue.Count > 0; }
        }

        public void DisplayAllDocuments()
        {
            foreach (GDoc doc in documentQueue)
            {
                Console.WriteLine(doc.Title);
            }
        }


        public GDoc GetDocument()
        {
            GDoc doc = default(GDoc);
            lock (this)
            {
                doc = documentQueue.Dequeue();
            }
            return doc;
        }

    }

}
