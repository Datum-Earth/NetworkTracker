using NetworkTracker.Database.Context;
using NetworkTracker.Database.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkTracker.Command
{
    public class CommandLayer
    {
        private CommandOptions _options { get; set; }

        public CommandLayer()
        {

        }

        public CommandLayer(CommandOptions options)
        {
            _options = options;
        }

        public async Task InsertNetworkEventType(Model.InsertNetworkEventTypeCommand command)
        {
            using (var ctx = IOC.CreateNetworkTrackerContext())
            {
                var eventType = ctx.EventTypes.Where(x => x.Type == command.Value).FirstOrDefault();

                if (eventType == null)
                {
                    var newType = new NetworkTracker.Database.Model.EventType()
                    {
                        Type = command.Value
                    };

                    await ctx.EventTypes.AddAsync(newType);
                    await ctx.SaveChangesAsync();
                }
            }
        }

        public async Task InsertNetworkEvent(Model.InsertNetworkEventCommand command)
        {
            using (var ctx = IOC.CreateNetworkTrackerContext())
            {
                var eventType = (from et in ctx.EventTypes
                                 where et.Type == command.EventType
                                 select et).FirstOrDefaultAsync();

                if (await eventType == null)
                    throw new ArgumentOutOfRangeException("EventType does not exist.");

                var newEvent = new Database.Model.NetworkEvent()
                {
                    EventType = await eventType,
                    Value = command.Value,
                    CreateTime = DateTimeOffset.UtcNow
                };

                await ctx.NetworkEvents.AddAsync(newEvent);
                await ctx.SaveChangesAsync();
            }
        }

        NetworkTrackerContext CreateNetworkTrackerContext()
        {
            if (_options != null)
            {
                if (_options.ProviderOptions != null)
                {
                    if (_options.ProviderOptions.Provider == DatabaseProviderType.Sqlite)
                    {
                        var factory = new SqliteContextFactory();
                        return String.IsNullOrWhiteSpace(_options.ProviderOptions.ConnectionString) 
                            ? factory.CreateSqliteContext() 
                            : factory.CreateSqliteContext(_options.ProviderOptions.ConnectionString);
                    }
                }
            } else
            {
                var factory = new SqliteContextFactory();
                return factory.CreateSqliteContext();
            }
        }
    }
}
