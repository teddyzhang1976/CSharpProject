using System.Runtime.Serialization;

namespace Wrox.ProCSharp.Messaging
{
    [DataContract]
    public class Customer
    {
        [DataMember]
        public string Company { get; set; }

        [DataMember]
        public string Contact { get; set; }
    }

}
