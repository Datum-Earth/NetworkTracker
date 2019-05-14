using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkTracker.Domain.Model
{
    public class NetworkEvent
    {
        public NetworkEventType EventType { get; set; }
        public string Value { get; set; }
        public DateTimeOffset EventTime { get; set; }
    }
}
