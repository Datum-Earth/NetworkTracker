using NetworkTracker.Database.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkTracker.Query
{
    public class QueryLayer
    {
        public async Task<List<NetworkTracker.Domain.Model.NetworkEvent>> GetEventsInRangeAsync(DateTimeOffset startTime, DateTimeOffset endTime)
        {
            var mapper = new NetworkTracker.Domain.Maps.EventMap();
            var eventList = new List<NetworkTracker.Domain.Model.NetworkEvent>();

            using (var ctx = new NetworkTrackerContext())
            {
                var events = from e in ctx.NetworkEvents
                             where e.CreateTime >= startTime && e.CreateTime <= endTime
                             orderby e.CreateTime
                             select e;

                foreach (var e in await events.ToListAsync())
                {
                    eventList.Add(mapper.Map(e));
                }
            }

            return eventList;
        }
    }
}
