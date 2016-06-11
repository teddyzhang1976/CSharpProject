using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.PeerToPeer;
using System.Net.PeerToPeer.Collaboration;

namespace PNMSample
{
   public class PeerEntry
   {
      public PeerNearMe PeerNearMe { get; set; }
      public PeerPresenceStatus PresenceStatus { get; set; }
      public string DisplayString { get; set; }
   }
}
