namespace Wrox.ProCSharp.OOProg
{
   using System;
   

   public abstract class GenericCustomer
   {
      private string name;

      public GenericCustomer()
      {
         name = "<no name>";
      }
      
      public GenericCustomer(string name)
      {
          this.name = name;
      }


      public string Name 
      { 
         get {return name;}
         set {name = value;}
      }

   }

   public class Nevermore60Customer : GenericCustomer
   {
      private string referrerName;
      private uint highCostMinutesUsed;
      
      public Nevermore60Customer(string name) : this(name, "<None>")
      {
      }

      public Nevermore60Customer(string name, string referrerName) : base(name)
      {
         this.referrerName = referrerName;
      }

      public string ReferrerName
      {
         get {return referrerName;}
         set {referrerName = value;}
      }

   }


   public class MainEntryPoint
   {
      public static void Main()
      {
         GenericCustomer arabel = new Nevermore60Customer("Arabel Jones");
      }
   }
}
