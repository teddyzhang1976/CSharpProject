using System.Collections.Generic;
using System.AddIn.Pipeline;

namespace Wrox.ProCSharp.MAF
{
   [HostAdapter]
   internal class CalculatorContractToViewHostAdapter : Calculator
   {
      private ICalculatorContract contract;
      private ContractHandle handle;

      public CalculatorContractToViewHostAdapter(ICalculatorContract contract)
      {
          this.contract = contract;
          handle = new ContractHandle(contract);
      }



      public override IList<Operation> GetOperations()
      {
          return CollectionAdapters.ToIList<IOperationContract, Operation>(
              contract.GetOperations(),
              OperationHostAdapters.ContractToViewAdapter,
              OperationHostAdapters.ViewToContractAdapter);

      }

      public override double Operate(Operation operation, double[] operands)
      {
          return contract.Operate(OperationHostAdapters.ViewToContractAdapter(operation),
              operands);
      }
   }
}
