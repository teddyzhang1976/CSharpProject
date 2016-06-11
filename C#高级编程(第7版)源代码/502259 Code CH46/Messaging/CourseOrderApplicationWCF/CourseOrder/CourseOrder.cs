using System;
using System.Runtime.Serialization;

namespace Wrox.ProCSharp.Messaging
{
    [DataContract]
    public class CourseOrder
    {
        [DataMember]
        public Customer Customer { get; set; }
        [DataMember]
        public Course Course { get; set; }

        public override string ToString()
        {
            return String.Format("Course Order {{{0}}}", Customer.Company);
        }

    }

}
