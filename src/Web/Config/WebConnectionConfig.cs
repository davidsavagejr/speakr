using System;
using System.Configuration;
using System.Data.SqlClient;
using Data;

namespace Web.Config
{
    internal class WebConnectionConfig : IConnectionConfig
    {
        public string ConnectionString
        {
            get
            {
                var configValue = ConfigurationManager.ConnectionStrings["SpeakRDb"];
                var sqlConnectionString = new SqlConnectionStringBuilder(configValue.ConnectionString);

                // Some people like to reconfigure their local instance name (SQL)
                // Set this value to override what's in the config, just makes things easier for you
                var environmentOverride = Environment.GetEnvironmentVariable("_LOCAL_SQL_INSTANCE");
                if (!string.IsNullOrEmpty(environmentOverride))
                    sqlConnectionString.DataSource = environmentOverride;

                return sqlConnectionString.ToString();
            }
        }
    }
}