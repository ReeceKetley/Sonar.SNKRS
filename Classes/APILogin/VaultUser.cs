using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SonarSNKRS
{
    class VaultUser
    {
        public string Email;
        public string Password;
        public List<string> AccessTags;
        public bool LoggedIn = false;
        public VaultUser(string email, string password, List<string> accesstags = null)
        {
            if (accesstags == null)
            {
                accesstags = new List<string>();
            }
            Email = email;
            Password = password;
            AccessTags = accesstags;
        }

        public string LoginString()
        {
            if (String.IsNullOrEmpty(Email) && String.IsNullOrEmpty(Password))
            {
                return "No login data";
            }
            return Functions.SHA256_ComputeHash(Functions.RandomString(16) + "[" + Email + "," + Password + "]");
        }
    }
}
