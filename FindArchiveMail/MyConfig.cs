using System.Configuration;

namespace FindArchiveMail
{
    public static class MyConfig
    {
        public static string GetMailFolder()
        {
            return ConfigurationManager.AppSettings["MailFolder"];
        }
        public static string GetVersion()
        {
            return ConfigurationManager.AppSettings["Version"];
        }
        public static int GetMaxThread()
        {
            string s = ConfigurationManager.AppSettings["MaxThread"];
            return System.Convert.ToInt32(s);
        }
        public static int GetChunkSize()
        {
            string s = ConfigurationManager.AppSettings["ChunkSize"];
            return System.Convert.ToInt32(s);
        }
        public static void SaveSetting(string key, string value)
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;
            if (settings[key] == null)
            {
                settings.Add(key, value);
            }
            else
            {
                settings[key].Value = value;
            }
            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
        }
    }
}
