using System;
using System.Collections.Generic;
using System.Text;

namespace Diagram
{
   public class AddInAdapter : System.AddIn.Pipeline.ContractBase, ICalcContract
   {
      public AddInView AddInView
      {
         get
         {
            throw new System.NotImplementedException();
         }
         set
         {
         }
      }
      #region ICalcContract Members

      public int GetOperations(int x, int y)
      {
         throw new NotImplementedException();
      }

      public void Operate()
      {
         throw new NotImplementedException();
      }

      #endregion


   }
}
