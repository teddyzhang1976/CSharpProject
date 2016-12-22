using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SharedInterfaces
{
    public class PropertyInformationClient : ClientBase<IPropertyInformation>, IPropertyInformation
    {
        public PropertyInformationClient(string endpointName) : base(endpointName)
        {
        }

        public Guid UploadPropertyInformation(string ownerName, string address, float price)
        {
            return this.Channel.UploadPropertyInformation(ownerName, address, price);
        }

        public void UploadRoomInformation(Guid propertyId, string roomName, float width, float length)
        {
            this.Channel.UploadRoomInformation(propertyId, roomName, width, length);
        }

        public void DetailsComplete(Guid propertyId)
        {
            this.Channel.DetailsComplete(propertyId);
        }
    }
}
