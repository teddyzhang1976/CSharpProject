using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CSharp
{
   static class Linq
   {
      public static void Sample(List<Person> persons)
      {
         var query = from p in persons
                     where p.LastName == "Test"
                     orderby p.FirstName descending
                     select p;
         //var query = from r in racers
         //            where r.Country == "Brazil"
         //            orderby r.Wins descending
         //            select r;

         foreach (var r in query)
         {
            
         }
      }

   }
}
