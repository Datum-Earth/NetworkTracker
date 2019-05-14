using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkTracker.Database.Model
{
    public class NetworkEvent : Base
    {
        public EventType EventType { get; set; }
        public string Value { get; set; }
    }
}
