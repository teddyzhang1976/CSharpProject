using System;
using System.Linq;
using System.ServiceModel.Activation;

namespace SilverlightDemos.Web
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class RegistrationService : IRegistrationService
    {
        public Event[] GetEvents(DateTime fromTime, DateTime toTime)
        {
            Event[] events = null;
            using (var data = new EventRegistrationEntities())
            {
                events = (from e in data.Events
                          where e.DateFrom >= fromTime && e.DateFrom <= toTime
                          select e).ToArray();

                foreach (var ev in events)
                {
                    data.Detach(ev);
                }
            
            }
            return events;
        }

        public bool RegisterAttendee(Attendee attendee)
        {
            using (EventRegistrationEntities data = new EventRegistrationEntities())
            {
                if ((from rc in data.RegistrationCodes
                        where rc.RegistrationCode1 == attendee.RegistrationCode
                        select rc).Count() < 1)
                {
                    return false;
                }
                else
                {
                    data.Attendees.AddObject(attendee);
                    if (data.SaveChanges() == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
    }
}
