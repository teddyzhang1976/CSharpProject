using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SharedInterfaces
{
    [ServiceContract(Namespace="http://www.morganskinner.com")]
    public interface IPropertyInformation
    {
        [OperationContract()]
        Guid UploadPropertyInformation(string ownerName, string address, float price);
        
        [OperationContract(IsOneWay=true)]
        void UploadRoomInformation(Guid propertyId, string roomName, float width, float length);

        [OperationContract(IsOneWay = true)]
        void DetailsComplete(Guid propertyId);
    }
}
