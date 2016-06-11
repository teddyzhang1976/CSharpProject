using System.AddIn.Pipeline;

namespace Wrox.ProCSharp.MAF
{
   internal class OperationContractToViewHostAdapter : Operation
   {
      // internal IOperationContract contract;

      public IOperationContract Contract { get; private set; }

      private ContractHandle handle;

      public OperationContractToViewHostAdapter(IOperationContract contract)
      {
         this.Contract = contract;
         handle = new ContractHandle(contract);
      }

      public override string Name
      {
         get
         {
            return Contract.Name;
         }
      }

      public override int NumberOperands
      {
         get
         {
            return Contract.NumberOperands;
         }
      }
   }

   internal static class OperationHostAdapters
   {
      internal static IOperationContract ViewToContractAdapter(Operation view)
      {
         return ((OperationContractToViewHostAdapter)view).Contract;
      }

      internal static Operation ContractToViewAdapter(IOperationContract contract)
      {
         return new OperationContractToViewHostAdapter(contract);
      }
   }
}
