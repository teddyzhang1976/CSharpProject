using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Activation;

namespace SilverlightDemos.Web
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRegistrationService" in both code and config file together.
    [ServiceContract]
    public interface IRegistrationService
    {
        [OperationContract]
        Event[] GetEvents(DateTime fromTime, DateTime toTime);

        [OperationContract]
        bool RegisterAttendee(Attendee attendee);
    }

    //[DataContract]
    //public class Attendee
    //{
    //    public int Id { get; set; }
    //    public int EventId { get; set; }
    //    public string Name { get; set; }
    //    public string Email { get; set; }
    //    public string Company { get; set; }
    //    public string RegistrationCode { get; set; }
    //}

    //[DataContract]
    //public class Event
    //{
    //    [DataMember]
    //    public int Id { get; set; }

    //    [DataMember]
    //    public string Name { get; set; }

    //    [DataMember]
    //    public DateTime FromTime { get; set; }

    //    [DataMember]
    //    public DateTime ToTime { get; set; }

    //    [DataMember]
    //    public string Description { get; set; }
    //}
}
