using System.Runtime.Serialization;
using System.ServiceModel;

namespace Wrox.ProCSharp.WCF
{
   [ServiceContract(SessionMode = SessionMode.Required)]
   public interface IStateService
   {
      [OperationContract(IsInitiating = true)]
      void Init(int i);

      [FaultContract(typeof(StateFault))]
      [OperationContract]
      void SetState(int i);

      [OperationContract]
      int GetState();

      [OperationContract(IsTerminating = true)]
      void Close();
   }

   [DataContract]
   public class StateFault
   {
      [DataMember]
      public int BadState { get; set; }
   }


}
