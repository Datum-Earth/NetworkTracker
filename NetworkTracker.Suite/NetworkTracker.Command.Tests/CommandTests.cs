using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetworkTracker.Database.Context;

namespace NetworkTracker.Command.Tests
{
    [TestClass]
    public class CommandTests
    {
        [TestMethod]
        public async Task Layer_Can_Insert_EventType_Correctly()
        {
            using (var ctx = InitializeWithProvider())
            {
                var testEventTypeValue = "UnitTestEventType";

                var cmdLayer = new NetworkTracker.Command.CommandLayer();
                await cmdLayer.InsertNetworkEventType(new Model.InsertNetworkEventTypeCommand() { Value = testEventTypeValue });

                var result = ctx.EventTypes.Where(x => x.Type == testEventTypeValue).FirstOrDefault();

                Assert.AreEqual(result.Type, testEventTypeValue);
            }
        }

        NetworkTrackerContext InitializeWithProvider()
        {
            var dbPath = GetRandomFileName();

            var options = new DbContextOptionsBuilder<NetworkTrackerContext>();
            options.UseSqlite(dbPath);

            using (var ctx = new NetworkTrackerContext(options.Options))
            {
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();
            }

            return new NetworkTrackerContext(options.Options);
        }

        string GetRandomFileName()
        {
            var guid = Guid.NewGuid();
            var path = $@"Data Source=.\{guid.ToString()}.db";

            return path;
        }
    }
}
