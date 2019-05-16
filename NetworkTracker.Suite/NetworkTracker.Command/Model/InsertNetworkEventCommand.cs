using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkTracker.Command.Model
{
    public class InsertNetworkEventCommand
    {
        public string EventType { get; set; }
        public string Value { get; set; }
    }
}
