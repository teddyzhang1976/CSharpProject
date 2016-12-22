using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace ImmutableCollectionsSample
{
  class Program
  {
    static void Main(string[] args)
    {
      // ArraySample();
      ListSample();
    }

    private static void ListSample()
    {
      List<Account> accounts = new List<Account>() {
        new Account {
          Name = "Scrooge McDuck", 
          Amount = 667377678765m
        },
        new Account {
          Name = "Donald Duck",
          Amount = -200m
        },
       new Account {
         Name = "Ludwig von Drake",
         Amount = 20000m
        }};
      ImmutableList<Account> immutableAccounts = accounts.ToImmutableList();

      ImmutableList<Account>.Builder builder = immutableAccounts.ToBuilder();
      for (int i = 0; i < builder.Count; i++)
      {
        Account a = builder[i];
        if (a.Amount > 0)
        {
          builder.Remove(a);
        }
      }

      ImmutableList<Account> overdrawnAccounts = builder.ToImmutable();


      foreach (var item in overdrawnAccounts)
      {
        Console.WriteLine("{0} {1}", item.Name, item.Amount);
      }

    }

    private static void ArraySample()
    {
      ImmutableArray<string> a1 = ImmutableArray.Create<string>();
      ImmutableArray<string> a2 = a1.Add("Williams");
      ImmutableArray<string> a3 = a2.Add("Ferrari").Add("Mercedes").Add("Red Bull Racing");
      foreach (var item in a3)
      {
        Console.WriteLine(item);
      }

    }
  }
}
