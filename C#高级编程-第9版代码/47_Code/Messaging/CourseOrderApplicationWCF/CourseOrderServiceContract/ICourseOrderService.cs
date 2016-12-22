using System.ServiceModel;

namespace Wrox.ProCSharp.Messaging
{
  [ServiceContract]
  [DeliveryRequirements(QueuedDeliveryRequirements=QueuedDeliveryRequirementsMode.Required)]
  public interface ICourseOrderService
  {
    [OperationContract(IsOneWay=true)]
    void AddCourseOrder(CourseOrder courseOrder);
  } 
}
