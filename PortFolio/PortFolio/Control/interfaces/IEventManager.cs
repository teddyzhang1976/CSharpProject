using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortFolio.Model;
namespace PortFolio.Control.interfaces
{
    public interface IEventManager
    {
        List<EventModel> load();
        Boolean add(EventModel am);
        Boolean update(EventModel am);
        EventModel chose(int id);
        Boolean delete(int id);
    }
}
