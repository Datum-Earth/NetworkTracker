using NetworkTracker.Query.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkTracker.Query
{
    internal class Mapping
    {
        public NetworkEventType Map(Database.Model.EventType eventType)
        {
            switch (eventType.Type)
            {
                case "Jitter":
                    return NetworkEventType.Jitter;
                default:
                    throw new ArgumentOutOfRangeException($"Unrecognized EventType found. Type: {eventType}");
            }
        }
    }
}
