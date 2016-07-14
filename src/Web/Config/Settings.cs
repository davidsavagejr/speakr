using System.Configuration;

namespace Web.Config
{
    public class Settings
    {
        public static bool UserDebug => GetSetting("DebugAuth") == "true";
        public static bool MiniProfiler => GetSetting("MiniProfiler") == "true";

        private static string GetSetting(string setting)
        {
            return ConfigurationManager.AppSettings[setting];
        }
    }
}