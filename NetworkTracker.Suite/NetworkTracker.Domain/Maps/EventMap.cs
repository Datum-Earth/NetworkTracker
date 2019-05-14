using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkTracker.Domain.Maps
{
    public class EventMap
    {
        public Model.NetworkEvent Map(NetworkTracker.Database.Model.NetworkEvent dbEvent)
        {
            return new Model.NetworkEvent()
            {
                EventType = Map(dbEvent.EventType),
                EventTime = dbEvent.CreateTime,
                Value = dbEvent.Value
            };
        }

        public NetworkTracker.Database.Model.NetworkEvent Map(NetworkTracker.Domain.Model.NetworkEvent domainEvent)
        {
            return new NetworkTracker.Database.Model.NetworkEvent()
            {
                EventType = Map(domainEvent.EventType),
                Value = domainEvent.Value,
                CreateTime = DateTimeOffset.Now
            };
        }

        public Model.NetworkEventType Map(NetworkTracker.Database.Model.EventType dbEventType)
        {
            switch (dbEventType.ID)
            {
                case 0:
                    return Model.NetworkEventType.Jitter;
                default:
                    throw new Exception($"Invalid type found. ID: {dbEventType.ID}; Type: {dbEventType.Type}");
            }
        }

        public NetworkTracker.Database.Model.EventType Map(NetworkTracker.Domain.Model.NetworkEventType domainType)
        {
            switch (domainType)
            {
                case Model.NetworkEventType.Jitter:
                    return new Database.Model.EventType() { ID = 1, Type = "Jitter" };
                default:
                    throw new Exception($"Invalid type found. Domain type: {domainType.ToString()}");
            }
        }
    }
}
