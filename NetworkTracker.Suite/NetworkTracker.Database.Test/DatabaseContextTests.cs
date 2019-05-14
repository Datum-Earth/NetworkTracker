using System;
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
            var path = @"Data Source=.\events.db";
            var options = new DbContextOptionsBuilder<NetworkTrackerContext>();
            options.UseSqlite(path);

            using (var ctx = new NetworkTrackerContext(options.Options))
            {
                var canConnect = ctx.Database.CanConnect();

                if (!canConnect)
                    Assert.Fail();
            }
        }
    }
}
