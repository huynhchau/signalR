using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPS.HiltonDirect.Core
{
    public class ConfigManager
    {
        public static class ConnectionString
        {
            public static string DbContext
            {
                get
                {
                    return ConfigUtil.GetConfigValue(Core.Constants.AppSettingKeys.ConnectionKey);
                }
            }
        }
    }
}
