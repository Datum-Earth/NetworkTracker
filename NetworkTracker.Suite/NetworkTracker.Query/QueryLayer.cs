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
        public async Task<List<Model.NetworkEvent>> GetEventsInRangeAsync(DateTimeOffset startTime, DateTimeOffset endTime)
        {
            var mapper = new Mapping();
            var list = new List<Model.NetworkEvent>();

            using (var ctx = new NetworkTrackerContext())
            {
                var events = from e in ctx.NetworkEvents
                             where e.CreateTime >= startTime && e.CreateTime <= endTime
                             orderby e.CreateTime
                             select e;

                foreach (var e in await events.ToListAsync())
                {
                    list.Add(new Model.NetworkEvent()
                    {
                        ID = e.ID,
                        EventType = mapper.Map(e.EventType),
                        CreateDate = e.CreateTime,
                        Value = e.Value
                    });
                }
            }

            return list;
        }
    }
}
