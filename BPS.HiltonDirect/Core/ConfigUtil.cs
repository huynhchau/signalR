using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPS.HiltonDirect.Core
{
    public class ConfigUtil
    {
        public static string GetConfigValue(string key)
        {
            if (ConfigurationManager.AppSettings.AllKeys.Contains(key))
                return ConfigurationManager.AppSettings[key];
            else
                return string.Empty;
        }

        public static int GetConfigIntValue(string key)
        {
            var configValue = GetConfigValue(key);
            if (!string.IsNullOrEmpty(configValue))
            {
                int result;
                if (int.TryParse(configValue, out result))
                    return result;
            }
            throw new Exception(string.Format("Failed to get Int32 configuration value by key '{0}'", key));
        }

        public static bool GetConfigBoolValue(string key)
        {
            var configValue = GetConfigValue(key);
            return configValue.ToLower() == true.ToString().ToLower();
        }
    }
}
