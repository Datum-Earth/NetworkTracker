using NetworkTracker.Database.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkTracker.Command
{
    public class CommandLayer
    {
        public void InsertNetworkEvent(NetworkTracker.Domain.Model.NetworkEvent dEvent)
        {
            var mapper = new NetworkTracker.Domain.Maps.EventMap();
            NetworkTracker.Database.Model.NetworkEvent mappedEvent = mapper.Map(dEvent);

            using (var ctx = new NetworkTrackerContext())
            {
                InsertEventTypeIfNotExists(dEvent.EventType);

                var eventType = ctx.EventTypes.Where(x => x.ID == mappedEvent.EventType.ID).FirstOrDefault();
                mappedEvent.EventType = eventType;
                
                ctx.NetworkEvents.Add(mappedEvent);
                ctx.SaveChanges();
            }
        }

        public void InsertEventTypeIfNotExists(NetworkTracker.Domain.Model.NetworkEventType dType)
        {
            var mapper = new NetworkTracker.Domain.Maps.EventMap();
            NetworkTracker.Database.Model.EventType mappedEvent = mapper.Map(dType);

            using (var ctx = new NetworkTrackerContext())
            {
                var eventType = ctx.EventTypes.Where(x => x.ID == mappedEvent.ID).FirstOrDefault();

                if (eventType == null)
                {
                    ctx.EventTypes.Add(mappedEvent);
                    ctx.SaveChanges();
                }
            }
        }
    }
}
