using System.Collections.Generic;
namespace Wrox.ProCSharp.MAF
{

   public abstract class Calculator
   {
       public abstract IList<Operation> GetOperations();
       public abstract double Operate(Operation operation, params double[] operand);

   }

   public abstract class Operation
   {
       public abstract string Name { get; }
       public abstract int NumberOperands { get; }
   }
}
