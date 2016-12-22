using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace Wrox.ProCSharp.MEF
{
    [Export(typeof(ICalculator))]
    public class Calculator : ICalculator
    {
        [ImportMany("Add", typeof(Func<double, double, double>))]
        public Lazy<Func<double, double, double>, ISpeedCapabilities>[] AddMethods { get; set; }
        // public Lazy<Func<double, double, double>, IDictionary<string, object>>[] AddMethods { get; set; }

        //[Import("Add", typeof(Func<double, double, double>))]
        //public Func<double, double, double> Add { get; set; }

        [Import("Subtract", typeof(Func<double, double, double>))]
        public Func<double, double, double> Subtract { get; set; }

        public IList<IOperation> GetOperations()
        {
            return new List<IOperation>()
            {
                new Operation { Name="+", NumberOperands=2},
                new Operation { Name="-", NumberOperands=2},
                new Operation { Name="/", NumberOperands=2},
                new Operation { Name="*", NumberOperands=2}
            }; 
        }

        public double Operate(IOperation operation, double[] operands)
        {
            double result = 0;
            switch (operation.Name)
            {
                case "+":
                    // result = Add(operands[0], operands[1]);
                    //foreach (var addMethod in AddMethods)
                    //{
                    //    if (addMethod.Metadata.ContainsKey("speed") && (string)addMethod.Metadata["speed"] == "fast")
                    //        result = addMethod.Value(operands[0], operands[1]);           
                    //}
                    foreach (var addMethod in AddMethods)
                    {
                        if (addMethod.Metadata.Speed == Speed.Fast)
                            result = addMethod.Value(operands[0], operands[1]);
                    }
                    // result = operands[0] + operands[1];
                    break;
                case "-":
                    result = Subtract(operands[0], operands[1]);
                    // result = operands[0] - operands[1];
                    break;
                case "/":
                    result = operands[0] / operands[1];
                    break;
                case "*":
                    result = operands[0] * operands[1];
                    break;
                default:
                    throw new InvalidOperationException(
                        String.Format("invalid operation {0}", operation.Name));
            }
            return result;
        }
    }
}
