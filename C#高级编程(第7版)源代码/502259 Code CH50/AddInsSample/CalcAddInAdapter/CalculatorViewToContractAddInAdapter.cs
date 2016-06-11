using System.AddIn.Contract;
using System.AddIn.Pipeline;

namespace Wrox.ProCSharp.MAF
{
   [AddInAdapter]
   internal class CalculatorViewToContractAddInAdapter : ContractBase, ICalculatorContract
   {
      private Calculator view;

      public CalculatorViewToContractAddInAdapter(Calculator view)
      {
         this.view = view;
      }


      #region ICalculatorContract Members

      public IListContract<IOperationContract> GetOperations()
      {
         return CollectionAdapters.ToIListContract<Operation, IOperationContract>(view.GetOperations(),
             OperationViewToContractAddInAdapter.ViewToContractAdapter,
             OperationViewToContractAddInAdapter.ContractToViewAdapter);
      }

      public double Operate(IOperationContract operation, double[] operands)
      {
         return view.Operate(OperationViewToContractAddInAdapter.ContractToViewAdapter(operation),
             operands);
      }

      #endregion
   }
}
