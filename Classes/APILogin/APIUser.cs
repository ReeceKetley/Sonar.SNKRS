using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace SonarSNKRS
{
    public enum UserLevel
    {
        Basic,
        Standard,
        Pro,
        Business
    }

    class APIUser
    {
        public static int MaxAccounts;
        public static bool LoggedIn;
        public static string UserName;
        public static UserLevel UserLevel;
        public static bool iBool;
        public static string Password;
        public static JObject ConvertToJObject()
        {
            var accountObject = new JObject();
            accountObject["username"] = UserName;
            accountObject["userlevel"] = UserLevel.ToString();
            accountObject["maxtasks"] = MaxAccounts.ToString();
            return accountObject;
        }
    }
}
