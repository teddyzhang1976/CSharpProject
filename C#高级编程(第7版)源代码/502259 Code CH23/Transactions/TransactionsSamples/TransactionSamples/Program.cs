using System;
using System.Threading;
using System.Transactions;

namespace Wrox.ProCSharp.Transactions
{
    class Program
    {
        static void Main()
        {
            // CommittableTransaction();
            // TransactionPromotion();
            // DependentTransaction();
            // TransactionScope();
            // NestedScopes();

            Console.ReadLine();
        }

        static void NestedScopes()
        {
            using (var scope = new TransactionScope())
            {
                Transaction.Current.TransactionCompleted +=
                      OnTransactionCompleted;

                Utilities.DisplayTransactionInformation("Ambient TX created",
                      Transaction.Current.TransactionInformation);

                using (var scope2 =
                      new TransactionScope(TransactionScopeOption.RequiresNew))
                {
                    Transaction.Current.TransactionCompleted +=
                          OnTransactionCompleted;

                    Utilities.DisplayTransactionInformation(
                           "Inner Transaction Scope",
                           Transaction.Current.TransactionInformation);

                    scope2.Complete();
                }
                scope.Complete();
            }

        }

        static void TransactionScope()
        {
            using (var scope = new TransactionScope())
            {
                Transaction.Current.TransactionCompleted +=
                      OnTransactionCompleted;

                Utilities.DisplayTransactionInformation("Ambient TX created",
                      Transaction.Current.TransactionInformation);

                var s1 = new Student
                {
                    FirstName = "Ingo",
                    LastName = "Rammer",
                    Company = "thinktecture"
                };
                var db = new StudentData();
                db.AddStudent(s1);

                if (!Utilities.AbortTx())
                    scope.Complete();
                else
                    Console.WriteLine("transaction will be aborted");

            } // scope.Dispose()

        }

        static void OnTransactionCompleted(object sender, TransactionEventArgs e)
        {
            Utilities.DisplayTransactionInformation("TX completed",
                  e.Transaction.TransactionInformation);
        }


        static void DependentTransaction()
        {
            var tx = new CommittableTransaction();
            Utilities.DisplayTransactionInformation("Root TX created",
                  tx.TransactionInformation);

            try
            {
                new Thread(TxThread).Start(tx.DependentClone(
                      DependentCloneOption.BlockCommitUntilComplete));

                if (Utilities.AbortTx())
                {
                    throw new ApplicationException("transaction abort");
                }

                tx.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                tx.Rollback();
            }

            Utilities.DisplayTransactionInformation("TX finished",
                  tx.TransactionInformation);

        }

        static void TxThread(object obj)
        {
            DependentTransaction tx = obj as DependentTransaction;
            Utilities.DisplayTransactionInformation("Dependent Transaction",
                  tx.TransactionInformation);

            Thread.Sleep(3000);

            tx.Complete();

            Utilities.DisplayTransactionInformation("Dependent TX Complete",
                  tx.TransactionInformation);
        }


        static void TransactionPromotion()
        {
            var tx = new CommittableTransaction();
            Utilities.DisplayTransactionInformation("TX created",
                  tx.TransactionInformation);

            try
            {
                var s1 = new Student
                {
                    FirstName = "Jörg",
                    LastName = "Neumann",
                    Company = "thinktecture"
                };
                var db = new StudentData();
                db.AddStudent(s1, tx);

                Student s2 = new Student
                {
                    FirstName = "Richard",
                    LastName = "Blewett",
                    Company = "thintkecture"
                };
                db.AddStudent(s2, tx);

                Utilities.DisplayTransactionInformation("2nd connection enlisted",
                      tx.TransactionInformation);

                if (Utilities.AbortTx())
                {
                    throw new ApplicationException("transaction abort");
                }

                tx.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine();
                tx.Rollback();
            }

            Utilities.DisplayTransactionInformation("TX finished",
                  tx.TransactionInformation);

        }

        static void CommittableTransaction()
        {
            var tx = new CommittableTransaction();
            Utilities.DisplayTransactionInformation("TX created",
                  tx.TransactionInformation);

            try
            {
                var s1 = new Student
                {
                    FirstName = "Neno",
                    LastName = "Loye",
                    Company = "thinktecture"
                };
                var db = new StudentData();
                db.AddStudent(s1, tx);

                if (Utilities.AbortTx())
                {
                    throw new ApplicationException("transaction abort");
                }

                tx.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine();
                tx.Rollback();
            }

            Utilities.DisplayTransactionInformation("TX completed",
                  tx.TransactionInformation);

        }
    }
}
