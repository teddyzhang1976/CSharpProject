using System;
using System.Collections.Generic;
using System.Text;

namespace Diagram
{
   public interface ICalcContract : System.AddIn.Contract.IContract
   {
      int GetOperations(int x, int y);

      void Operate();
   }
}
