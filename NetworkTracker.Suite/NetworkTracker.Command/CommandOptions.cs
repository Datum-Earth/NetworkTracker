using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkTracker.Command
{
    public class CommandOptions
    {
        public DatabaseProviderOptions ProviderOptions { get; set; }
    }

    public class DatabaseProviderOptions
    {
        public DatabaseProviderType Provider { get; set; }
        public string ConnectionString { get; set; }
    }

    public enum DatabaseProviderType
    {
        Sqlite
    }
}
