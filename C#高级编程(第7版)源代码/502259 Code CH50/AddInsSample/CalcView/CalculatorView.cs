using System.AddIn.Pipeline;
using System.Collections.Generic;

namespace Wrox.ProCSharp.MAF
{

   [AddInBase]
   public abstract class Calculator
   {
      public abstract IList<Operation> GetOperations();
      public abstract double Operate(Operation operation, double[] operand);

   }

   public class Operation
   {
       public string Name { get; set; }
       public int NumberOperands { get; set; }
   }
}
