using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace ExposeWFService
{
    [ServiceContract]
    public interface IWorkflow1
    {
        [OperationContract]
        string Hello(string message);
    }
}
