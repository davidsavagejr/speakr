using System;
using System.Data.SqlClient;
using Data;
using Microsoft.Extensions.Options;

namespace Web.Core.Config
{
    internal class WebConnectionConfig : IConnectionConfig
    {
        public WebConnectionConfig(IOptions<ConnectionStrings> connectionStrings)
        {
            var sqlConnectionString = new SqlConnectionStringBuilder(connectionStrings.Value.SpeakRDb);

            // Some people like to reconfigure their local instance name (SQL)
            // Set this value to override what's in the config, just makes things easier for you
            var environmentOverride = Environment.GetEnvironmentVariable("_LOCAL_SQL_INSTANCE");
            if (!string.IsNullOrEmpty(environmentOverride))
                sqlConnectionString.DataSource = environmentOverride;

            ConnectionString = sqlConnectionString.ToString();
        }

        public string ConnectionString { get; }
    }
}