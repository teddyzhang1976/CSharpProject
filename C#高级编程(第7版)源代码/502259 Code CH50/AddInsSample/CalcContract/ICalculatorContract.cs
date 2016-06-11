using System.AddIn.Contract;
using System.AddIn.Pipeline;

namespace Wrox.ProCSharp.MAF
{

    [AddInContract]
    public interface ICalculatorContract : IContract
    {
        IListContract<IOperationContract> GetOperations();
        double Operate(IOperationContract operation, double[] operands);
    }

    public interface IOperationContract : IContract
    {
        string Name { get; }
        int NumberOperands { get; }
    }
}
