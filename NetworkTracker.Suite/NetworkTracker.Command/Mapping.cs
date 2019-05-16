using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkTracker.Command
{
    internal class Mapping
    {
        public Tuple<string, string> Map(Model.InsertNetworkEventCommand cmd)
        {
            string eventType = String.Empty;

            switch (cmd.EventType)
            {
                case "Jitter":
                    eventType = "Jitter";
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Invalid EventType.");
            }

            return new Tuple<string, string>(eventType, cmd.Value);
        }
    }
}
