using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortFolio.Control.interfaces;
using PortFolio.Model;

namespace PortFolio.Control
{
    public class SQLiteEventManager:IEventManager
    {
        private static SQLiteEventManager instance;
        private SQLiteEventManager()
        {
            // singleton
        }

        public static SQLiteEventManager singleInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SQLiteEventManager();
                }
                return instance;
            }
        }

        public List<EventModel> load()
        {
            List<EventModel> eventList = new List<EventModel>();
            //load from db
            return eventList;
        }
        public Boolean add(EventModel am)
        {
            return true;
        }
        public Boolean update(EventModel am)
        {
            return true;
        }
        public EventModel chose(int id)
        {
            EventModel em = new EventModel();
            //select from db
            return em;
        }
        public Boolean delete(int id)
        {
            //delete from db
            return true;
        }
    }
}
