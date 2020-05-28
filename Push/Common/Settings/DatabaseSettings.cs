using System;
using System.Collections.Generic;
using System.Text;

namespace Push.Common.Settings
{
    public interface IDatabaseSettings
    {
        string ConnectionString { get; set; }
        int CommandTimeout { get; set; }
    }

    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public int CommandTimeout { get; set; }
    }
}
