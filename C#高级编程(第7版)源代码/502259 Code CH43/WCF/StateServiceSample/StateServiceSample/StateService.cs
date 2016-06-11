using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Globalization;

namespace Wrox.ProCSharp.WCF
{
   [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
   public class StateService : IStateService
   {
      int i = 0;

      public void Init(int i)
      {
         this.i = i;
      }

      public void SetState(int i)
      {
         if (i == -1)
         {
            FaultReasonText[] text = new FaultReasonText[2];
            text[0] = new FaultReasonText("Sample Error", new CultureInfo("en"));
            text[1] = new FaultReasonText("Beispiel Fehler", new CultureInfo("de"));
            FaultReason reason = new FaultReason(text);

            throw new FaultException<StateFault>(
               new StateFault() { BadState = i }, reason);
         }
         else
         {
            this.i = i;
         }
      }

      public int GetState()
      {
         return i;
      }

      public void Close()
      {
      }
   }

}
