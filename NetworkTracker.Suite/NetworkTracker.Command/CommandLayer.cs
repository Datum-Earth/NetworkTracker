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
        public void InsertNetworkEvent(Model.InsertNetworkEventCommand cmd)
        {
            var mapper = new Mapping();
            var cmdValues = mapper.Map(cmd);

            using (var ctx = new NetworkTrackerContext())
            {
                InsertEventTypeIfNotExists(cmdValues.Item1);

                var eventType = ctx.EventTypes.Where(x => x.Type == cmdValues.Item1).FirstOrDefault();

                ctx.NetworkEvents.Add(new Database.Model.NetworkEvent() { EventType = eventType, Value = cmdValues.Item2, CreateTime = DateTimeOffset.UtcNow });
                ctx.SaveChanges();
            }
        }

        public void InsertEventTypeIfNotExists(string value)
        {
            using (var ctx = new NetworkTrackerContext())
            {
                var eventType = ctx.EventTypes.Where(x => x.Type == value).FirstOrDefault();

                if (eventType == null)
                {
                    ctx.EventTypes.Add(new Database.Model.EventType() { Type = value });
                    ctx.SaveChanges();
                }
            }
        }
    }
}
