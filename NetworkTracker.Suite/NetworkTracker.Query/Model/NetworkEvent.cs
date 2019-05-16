using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkTracker.Query.Model
{
    public class NetworkEvent
    {
        public long ID { get; set; }
        public NetworkEventType EventType { get; set; }
        public string Value { get; set; }
        public DateTimeOffset CreateDate { get; set; }
    }
}
