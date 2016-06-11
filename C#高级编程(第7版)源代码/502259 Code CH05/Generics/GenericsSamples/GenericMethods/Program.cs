using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wrox.ProCSharp.Generics
{
    class Program
    {
        static void Main()
        {
            var accounts = new List<Account>()
            {
                new Account("Christian", 1500),
                new Account("Stephanie", 2200),
                new Account("Angela", 1800)
            };

            decimal amount = Algorithm.AccumulateSimple(accounts);

            amount = Algorithm.Accumulate(accounts);

            amount = Algorithm.Accumulate<Account, decimal>(accounts, (item, sum) => sum += item.Balance);
        }
    }
}
