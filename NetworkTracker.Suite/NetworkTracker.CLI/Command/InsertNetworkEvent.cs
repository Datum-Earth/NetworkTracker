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
        string EventType { get; set; }
        string EventValue { get; set; }

        public InsertNetworkEvent()
        {
            IsCommand("InsertNetworkEvent", "Inserts a network event into the database.");
            HasRequiredOption("EventType=", "Type of event. Valid options: 'Jitter'", t => this.EventType = t);
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
            cmd.InsertNetworkEvent(new NetworkTracker.Command.Model.InsertNetworkEventCommand() { EventType = this.EventType, Value = this.EventValue });
        }
    }
}
