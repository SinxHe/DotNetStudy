namespace N32Common
{
    public static class ConfigurationHelper
    {
        public static string AppSettings(string key)
        {
            return System.Configuration.ConfigurationManager.AppSettings[key];
        }
    }
}
