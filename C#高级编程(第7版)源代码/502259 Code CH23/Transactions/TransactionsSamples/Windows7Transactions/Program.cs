using System;
using System.IO;
using System.Transactions;


namespace Wrox.ProCSharp.Transactions
{
    class Program
    {
        static void Main()
        {
            using (var scope = new TransactionScope())
            {
                FileStream stream = TransactedFile.GetTransactedFileStream("sample.txt");

                var writer = new StreamWriter(stream);

                writer.WriteLine("Write a transactional file");
                writer.Close();

                if (!Utilities.AbortTx())
                    scope.Complete();
            }

        }
    }
}
