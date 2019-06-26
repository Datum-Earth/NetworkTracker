using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetworkTracker.Database.Context;

namespace NetworkTracker.Database.Test
{
    [TestClass]
    public class DatabaseContextTests
    {
        [TestMethod]
        public void ContextConstructs()
        {
            using (var ctx = InitializeWithProvider())
            {
                var canConnect = ctx.Database.CanConnect();

                if (!canConnect)
                    Assert.Fail();
            }
        }

        [TestMethod]
        public async Task DatabaseConstructs()
        {
            using (var ctx = InitializeWithProvider())
            {
                // add event type

                var testType = new NetworkTracker.Database.Model.EventType()
                {
                    Type = "UnitTestType"
                };

                await ctx.EventTypes.AddAsync(testType);

                // add event

                var testEvent = new NetworkTracker.Database.Model.NetworkEvent()
                {
                    EventType = testType,
                    CreateTime = DateTimeOffset.UtcNow,
                    Value = "UnitTestValue"
                };

                await ctx.NetworkEvents.AddAsync(testEvent);

                // attempt to read back out

                var resultType = await ctx.EventTypes.FindAsync(testType.EventTypeId);
                var resultEvent = await ctx.NetworkEvents.FindAsync(testEvent.NetworkEventId);

                Trace.WriteLine($"Test Type: {{ Id: {testType.EventTypeId} , Type: {testType.Type}}}");
                Trace.WriteLine($"Test Event: {{ Id: {testEvent.NetworkEventId} , EventType: {testEvent.EventType.Type} , CreateTime: {testEvent.CreateTime} , Value: {testEvent.Value}}}");

                Trace.WriteLine($"Result Type: {{ Id: {resultType.EventTypeId} , Type: {resultType.Type}}}");
                Trace.WriteLine($"Result Event: {{ Id: {resultEvent.NetworkEventId} , EventType: {resultEvent.EventType.Type} , CreateTime: {resultEvent.CreateTime} , Value: {resultEvent.Value}}}");

                Assert.AreEqual(testType, resultType);
                Assert.AreEqual(testEvent, resultEvent);
            }
        }

        NetworkTrackerContext InitializeWithProvider()
        {
            var path = @"Data Source=.\tests.db";

            var options = new DbContextOptionsBuilder<NetworkTrackerContext>();
            options.UseSqlite(path);

            using (var ctx = new NetworkTrackerContext(options.Options))
            {
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();
            }

            return new NetworkTrackerContext(options.Options);
        }
    }
}
