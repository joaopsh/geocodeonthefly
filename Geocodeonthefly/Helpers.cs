using System.Configuration;
using System.IO;

namespace Geocodeonthefly
{
    public static class Helpers
    {
        public static readonly string appPath;
        private static readonly string _configFile;
        private static readonly ExeConfigurationFileMap _configFileMap;

        static Helpers()
        {
            appPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            _configFile = Path.Combine(appPath, "Geocodeonthefly.exe.config");
            _configFileMap = new ExeConfigurationFileMap();
            _configFileMap.ExeConfigFilename = _configFile;
        }

        public static string GetAppSetting(string key)
        {
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(_configFileMap, ConfigurationUserLevel.None);

            return config.AppSettings.Settings[key].Value.ToString();
        }

        public static void SetAppSetting(string key, string value)
        {
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(_configFileMap, ConfigurationUserLevel.None);
            config.AppSettings.Settings[key].Value = value;
            config.Save();
        }
    }
}
