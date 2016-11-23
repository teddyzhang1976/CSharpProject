using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortFolio.Model
{
    public class EventModel
    {
        public int eventID { get; set; }
        public string eventName { get; set; }
        public DateTime eventDate { get; set; }
        public int accountID { get; set; }
        public int stockCode { get; set; }
    }
}
