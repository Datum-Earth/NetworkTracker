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
        public List<Model.NetworkEvent> GetEventsInRange(DateTimeOffset startTime, DateTimeOffset endTime)
        {
            var mapper = new Mapping();
            var list = new List<Model.NetworkEvent>();

            using (var ctx = new NetworkTrackerContext())
            {
                var events = ctx.NetworkEvents.Include(x => x.EventType);

                var eventList = events.ToList();

                //foreach (var e in events)
                //{
                //    list.Add(new Model.NetworkEvent()
                //    {
                //        ID = e.ID,
                //        EventType = mapper.Map(e.EventType),
                //        CreateDate = e.CreateTime,
                //        Value = e.Value
                //    });
                //}
            }

            return list;
        }
    }
}
