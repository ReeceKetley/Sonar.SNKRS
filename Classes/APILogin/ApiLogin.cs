using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Management;
using Microsoft.Win32;
using System.Collections;
using System.Diagnostics;

namespace SonarSNKRS
{
    [Serializable]
    public class JSONLoginData
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string DeviceId { get; set; }
        public JSONLoginData(string username, string password, string deviceid)
        {
            Username = username;
            Password = password;
            DeviceId = deviceid;
        }
    }
    class ApiLogin
    {

        private static string _ky = "7E6FC60178275B1C7A0E4727F9EEC19F";
        private static string _iv = "F91CEE9F7274E0A7C1B57287106CF6E7";

        public static LoginResponseCode Login(string devId, string user, string pass)
        {
            HTTP http = new HTTP("");
            string salt = Functions.RandomString(10);
            ////Debug.WriteLine(salt);
            string postData = Functions.RandomString(50) + "{" +
                              string.Format(
                                  "\"username\": \"{0}\", \"password\": \"{1}\", \"device\": \"{2}\", \"salt\": \"{3}\"",
                                  new[] { user, pass, devId, salt }) + "}";
            try
            {
                postData = Crypto.EncryptRJ256(postData);
            }
            catch
            {
                return LoginResponseCode.UnkownFail;
            }
            http.IncludeHeaderInResponse = false;
            string postRequest = http.Post("http://nikesonar.com/Nike/api.php", "v=" + Functions.UrlEncode(postData) + "&sonar=true");
            Console.WriteLine(postRequest);
            if (postRequest == "")
            {
                return LoginResponseCode.HttpError;
            }

            try
            {
                postRequest = Crypto.DecryptRJ256(postRequest);
            }
            catch
            {
                //Console.WriteLine("'Decrypt Fail!'");
                return LoginResponseCode.DecryptFail;
            }
            int len = postRequest.IndexOf("\0");
            postRequest = postRequest.Substring(0, len);
            int start = postRequest.IndexOf("{");
            if (start < 0)
            {
                return LoginResponseCode.DecryptFail;
            }

            postRequest = postRequest.Substring(start);
            //Console.WriteLine(postRequest);
            JObject responseData;
            try
            {
                responseData = JObject.Parse(postRequest);
            }
            catch
            {
                return LoginResponseCode.JsonFail;
            }
            ////Debug.WriteLine(postRequest);
            if (responseData["salt"] == null || (string)responseData["salt"] != salt)
            {
                return LoginResponseCode.JsonFail;
            }
            if (responseData["status"] == null)
            {
                return LoginResponseCode.JsonFail;
            }
            if (responseData["accountlimit"] != null)
            {
                APIUser.MaxAccounts = Convert.ToInt32((string)responseData["accountlimit"]);
                if (APIUser.MaxAccounts <= 5)
                {
                    APIUser.UserLevel = UserLevel.Basic;
                }
                if (APIUser.MaxAccounts >= 5 && APIUser.MaxAccounts <= 15)
                {
                    APIUser.UserLevel = UserLevel.Standard;
                }
                if (APIUser.MaxAccounts >= 15 && APIUser.MaxAccounts <= 50)
                {
                    APIUser.UserLevel = UserLevel.Pro;
                }
                if (APIUser.MaxAccounts >= 50)
                {
                    APIUser.UserLevel = UserLevel.Business;
                }
            }
            else
            {
                APIUser.MaxAccounts = 0;
            }
            switch ((string)responseData["status"])
            {
                case "success":
                    APIUser.iBool = true;
                    return LoginResponseCode.Sucess;
                case "activated":
                    APIUser.iBool = true;
                    return LoginResponseCode.LinkedDevice;
                case "maxdevices":
                    return LoginResponseCode.MaxDevices;
                default:
                    return LoginResponseCode.InvalidCredentials;
            }
        }
        public enum Key { Windows };
        public static byte[] GetRegistryDigitalProductId(Key key)
        {
            byte[] digitalProductId = null;
            RegistryKey registry = null;
            switch (key)
            {
                case Key.Windows:
                    registry =
                      Registry.LocalMachine.
                        OpenSubKey(
                          @"SOFTWARE\Microsoft\Windows NT\CurrentVersion",
                            false);
                    break;
            }
            if (registry != null)
            {
                digitalProductId = registry.GetValue("DigitalProductId")
                  as byte[];
                registry.Close();
            }
            return digitalProductId;
        }

        public static string GetUDID()
        {
            byte[] results = GetRegistryDigitalProductId(Key.Windows);
            return Crypto.EncryptRJ256(results + Environment.UserName);
        }
    }
}
