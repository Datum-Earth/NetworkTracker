using ManyConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkTracker.CLI.Command
{
    public class InsertNetworkEvent : ConsoleCommand
    {
        NetworkTracker.Domain.Model.NetworkEventType EventType { get; set; }
        string EventValue { get; set; }

        public InsertNetworkEvent()
        {
            IsCommand("InsertNetworkEvent", "Inserts a network event into the database.");
            HasRequiredOption("EventType=", "Type of event. Valid options: '0' == 'Jitter'", t => this.EventType = (NetworkTracker.Domain.Model.NetworkEventType)Int32.Parse(t));
            HasRequiredOption("Value=", "Value for event.", v => this.EventValue = v);
        }

        public override int Run(string[] remainingArguments)
        {
            try
            {
                InsertNetworkEventCommand();
                return 0;
            } catch (Exception e)
            {
                Console.WriteLine(e);
                return 2;
            }
            
        }

        void InsertNetworkEventCommand()
        {
            var cmd = new NetworkTracker.Command.CommandLayer();
            cmd.InsertNetworkEvent(new Domain.Model.NetworkEvent() { EventType = this.EventType, Value = this.EventValue });
        }
    }
}
