using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace P2PSample
{
   // NOTE: If you change the interface name "IP2PService" here, you must also update the reference to "IP2PService" in App.config.
   [ServiceContract]
   public interface IP2PService
   {
      [OperationContract]
      string GetName();

      [OperationContract(IsOneWay=true)]
      void SendMessage(string message, string from);
   }
}
