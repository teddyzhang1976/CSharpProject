using System.AddIn.Pipeline;

namespace Wrox.ProCSharp.MAF
{
   internal class OperationViewToContractAddInAdapter : ContractBase, IOperationContract
   {
      private Operation view;

      public OperationViewToContractAddInAdapter(Operation view)
      {
         this.view = view;

      }

      #region IOperationContract Members

      public string Name
      {
         get { return view.Name; }
      }

      public int NumberOperands
      {
         get { return view.NumberOperands; }
      }

      #endregion

      public static IOperationContract ViewToContractAdapter(Operation view)
      {
         return new OperationViewToContractAddInAdapter(view);
      }

      public static Operation ContractToViewAdapter(IOperationContract contract)
      {
         return (contract as OperationViewToContractAddInAdapter).view;
      }
   }
}
