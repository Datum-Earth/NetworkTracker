using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetworkTracker.Database.Context;

namespace NetworkTracker.Database.Sqlite
{
    public class SqliteContextFactory
    {
        private readonly string _dbPath = @"Data Source=.\events.db";

        /// <summary>
        /// Creates a NetworkTrackerContext with a default database path of ".\events.db".
        /// </summary>
        public NetworkTrackerContext CreateSqliteContext()
        {
            var options = new DbContextOptionsBuilder<NetworkTrackerContext>();
            options.UseSqlite(_dbPath);

            return new NetworkTrackerContext(options.Options);
        }

        /// <summary>
        /// Creates a NetworkTrackerContext with a custom database path.
        /// </summary>
        /// <param name="customDbPath"></param>
        /// <returns></returns>
        public NetworkTrackerContext CreateSqliteContext(string customDbPath)
        {
            var options = new DbContextOptionsBuilder<NetworkTrackerContext>();
            options.UseSqlite(customDbPath);

            return new NetworkTrackerContext(options.Options);
        }
    }
}
