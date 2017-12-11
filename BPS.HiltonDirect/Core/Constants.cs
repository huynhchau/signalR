using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPS.HiltonDirect.Core.Constants
{
    public static class Api
    {
        public const string DefaultContentType = "application/json";
        public const string LocalHost = "localhost";
        public const string ContentType = "ContentType";
    }

    public static class AppSettingKeys
    {
        public const string AuthAccessTokenExpireMinutes = "AuthAccessTokenExpireMinutes";
        public const string AuthServerAllowInsecureHttp = "AuthServerAllowInsecureHttp";
        public const string SSO_UserName = "SSO_UserName";
        public const string SSO_Password = "SSO_Password";
        public const string SSO_Domain = "SSO_Domain";
        public const string Login_URL = "Login_URL";

        public const string ConnectionKey = "BPSContextConnectionString";
        public const string ServerUrl = "ServerUrl";
    }

    public static class Session
    {
        public const string LoggedIn = "LoggedIn";
        public const string LoggedUser = "LoggedUser";
        public const string LoggedOut = "LoggedOut";
        public const string SessionID = "SessionID";

        public const string sesUserID = "sesUserID";
        public const string sesUserName = "sesUserName";
        public const string sesUserEmail = "sesUserEmail";
        public const string sesAdminUser = "sesAdminUser";
        public const string sesOnQUserType = "sesOnQUserType";
        public const string sesOnQUserHotels = "sesOnQUserHotels";

        public const string UserDesc = "userdesc";
        public const string UserId = "userid";
        public const string EmailAddress = "emailaddress";
    }

    public static class Misc
    {
        public const string ShortDate = "ddMMMyyyy";
    }
}
