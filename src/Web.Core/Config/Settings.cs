namespace Web.Core.Config
{
    public class AppSettings
    {
        public bool UserDebug { get; set; }
        public bool MiniProfiler { get; set; }
    }

    public class ConnectionStrings
    {
        public string SpeakRDb { get; set; }
    }


    public class Settings
    {
        public static bool UserDebug => GetSetting("DebugAuth") == "true";
        public static bool MiniProfiler => GetSetting("MiniProfiler") == "true";

        private static string GetSetting(string setting)
        {
            //return ConfigurationManager.AppSettings[setting];
            return null;
        }
    }
}