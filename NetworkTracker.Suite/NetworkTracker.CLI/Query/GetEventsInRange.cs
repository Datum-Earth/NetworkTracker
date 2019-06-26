using ManyConsole;
using NetworkTracker.CLI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkTracker.CLI.Query
{
    public class GetEventsInRange : ConsoleCommand
    {
        DateTimeOffset StartTime { get; set; }
        DateTimeOffset EndTime { get; set; }

        public GetEventsInRange()
        {
            IsCommand("GetEventsInRange", "Gets all events in a given span of time.");
            HasRequiredOption("StartTime=", "Start time in range. Format: 'DD/MM/YYYY HH:MM:SS'", time => this.StartTime = DateTimeOffset.Parse(time));
            HasRequiredOption("EndTime=", "End time in range. Format: 'DD/MM/YYYY HH:MM:SS'", time => this.EndTime = DateTimeOffset.Parse(time));
        }

        public override int Run(string[] remainingArguments)
        {
            try
            {
                GetEventsInRangeQuery();
                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 2;
            }
        }

        void GetEventsInRangeQuery()
        {
            var query = new NetworkTracker.Query.QueryLayer();
            var events = query.GetEventsInRange(this.StartTime, this.EndTime);
            ConsoleHelper.WriteCollectionToConsole(events);
        }
    }
}
