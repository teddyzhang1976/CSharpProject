using System;
using System.AddIn;
using System.Collections.Generic;

namespace Wrox.ProCSharp.MAF
{
   [AddIn("Advanced Calc", Publisher = "Wrox Press", Version = "1.1.0.0", Description = "Sample AddIn")]
   public class AdvancedCalculatorV1 : Calculator
   {
      private List<Operation> operations;

      public AdvancedCalculatorV1()
      {
         operations = new List<Operation>();
         operations.Add(new Operation() { Name = "+", NumberOperands = 2 });
         operations.Add(new Operation() { Name = "-", NumberOperands = 2 });
         operations.Add(new Operation() { Name = "/", NumberOperands = 2 });
         operations.Add(new Operation() { Name = "*", NumberOperands = 2 });
         operations.Add(new Operation() { Name = "++", NumberOperands = 1 });
         operations.Add(new Operation() { Name = "--", NumberOperands = 1 });
         operations.Add(new Operation() { Name = "%", NumberOperands = 2 });
      }

      public override IList<Operation> GetOperations()
      {
         return operations;
      }

      public override double Operate(Operation operation, double[] operand)
      {

         switch (operation.Name)
         {
            case "+":
               return operand[0] + operand[1];
            case "-":
               return operand[0] - operand[1];
            case "/":
               return operand[0] / operand[1];
            case "*":
               return operand[0] * operand[1];
            case "++":
               return ++operand[0];
            case "--":
               return --operand[0];
            case "%":
               return operand[0] % operand[1];
            default:
               throw new InvalidOperationException(String.Format("invalid operation {0}", operation.Name));
         }
      }
   }
}

