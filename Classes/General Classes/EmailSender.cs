using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Windows.Forms;
using EO.WebBrowser;

namespace SonarSNKRS.Classes.General_Classes
{
    public static class EmailSender
    {
        public static string host;
        public static string port;
        public static string pass;
        public static string message;
        public static string sms;
        public static string subject;
        public static string from;
        public static bool useSSL;
        public static bool useCustom;
        public static string smtpuser;
        public static void SendMailViaPost(string to, string product, string size, string alert, string subject1, string email = "1")
        {
            Debug.WriteLine("Send Email via post");
            HTTP http = new HTTP("");
            try
            {
                if (email == "0")
                {
                    var number = to.Split('@')[0];
                    if (number[0].ToString() != "1") ;
                    {
                        number = "1" + number;
                    }

                    SendSMS(number, product, size, alert);
                    return;
                }
            }
            catch
            {
                
            }
            string postData = "{" + "\"to\": \"" + to + "\", \"product\": \"" + product + "\", \"size\": \"" + size + "\", \"alert\": \"" + alert + "\", \"subject\": \"" + subject1 + "\", \"salt\": \"" + Functions.RandomString(50) + "\"" + "}";
            postData = Encrypt(postData);
            //Debug.WriteLine(postData);
            var result = http.Post("http://mg.nikesonar.com/notify.php", "packet=" + HttpUtility.UrlEncode(postData) + "&email=" + HttpUtility.UrlEncode(email) + "&u=" + HttpUtility.UrlEncode(APIUser.UserName) + "&p=" + HttpUtility.UrlEncode(APIUser.Password));
            Debug.WriteLine(result);
        }

        public static void SendSMS(string to, string product, string size, string alert)
        {
            var msg = "Sonar Alert: " + product + " - " + size + " " + alert;
            HTTP http = new HTTP("");
            var result = http.Post("http://mg.nikesonar.com/sms.php", "to=" + HttpUtility.UrlEncode(to) + "&msg=" + msg + "&u=" + HttpUtility.UrlEncode(APIUser.UserName) + "&p=" + HttpUtility.UrlEncode(APIUser.Password));
            Debug.WriteLine(result);
        }

        public static void SendMail(string email, string product, string alert, string size, bool sms1 = false)
        {
            if(string.IsNullOrEmpty(port))
            {
                return;            
            }
            bool html = false;
            if (email == "")
            {
                return;
            }
            if (string.IsNullOrEmpty(email))
            {
                return;
            }
            string errorMessage;
            string body = "";
            if (sms1)
            {
                //Debug.WriteLine("to:" + email);
                body = sms.Replace("{PRODUCT}", product);
                //body = body.Replace("{NIKEEMAIL}", nikeEmail);
                //body = body.Replace("{NIKEPASS}", nikePass);
                body = body.Replace("{ALERT}", alert);
                body = body.Replace("{SIZE}", size);
                subject = "";
            }
            else
            {
                body = message.Replace("{PRODUCT}", product);
                //body = body.Replace("{NIKEEMAIL}", nikeEmail);
                //body = body.Replace("{NIKEPASS}", nikePass);
                body = body.Replace("{ALERT}", alert);
                body = body.Replace("{SIZE}", size);
                html = true;
            }
            subject = subject.Replace("{PRODUCT}", product);
            subject = subject.Replace("{ALERT}", alert);
            //subject = subject.Replace("{NIKEEMAIL}", nikeEmail);
            //subject = subject.Replace("{NIKEPASS}", nikePass);
            subject = subject.Replace("{SIZE}", size);
            SendM(host, Convert.ToInt32(port), useSSL, smtpuser, pass, from,
                from.Substring(from.IndexOf('@') + 1), email.Trim(), email.Trim(), subject,
                body, out errorMessage, html);
        }


        public static bool SendM(string host, int port, bool bSSL, string username, string password, string from_email, string from_name, string to_email, string to_name, string subject1, string body, out string errorMessage, bool bIsBodyHTML = false)
        {
            errorMessage = "";
            try
            {
                MailAddress from = new MailAddress(from_email, from_name);
                MailAddress to = new MailAddress(to_email, to_name);
                SmtpClient client = new SmtpClient
                {
                    Host = host,
                    Port = port,
                    EnableSsl = bSSL,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(username, password)
                };
                MailMessage message2 = new MailMessage(@from, to)
                {
                    Subject = subject1,
                    Body = body,
                    IsBodyHtml = bIsBodyHTML
                };
                using (MailMessage message = message2)
                {
                    client.Send(message);
                }
                return true;
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
                errorMessage = e.Message;
            }
            return false;
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Encrypt(string prm_text_to_encrypt)
        {
            string _ky = Base64Encode("7E6FC60178275B1C7A0E4727F9EEC19F");
            string _iv = Base64Encode("F91CEE9F7274E0A7C1B57287106CF6E7");
            var sToEncrypt = prm_text_to_encrypt;

            var rj = new RijndaelManaged()
            {
                Padding = PaddingMode.PKCS7,
                Mode = CipherMode.CBC,
                KeySize = 256,
                BlockSize = 256,
            };

            var key = Convert.FromBase64String(_ky);
            var IV = Convert.FromBase64String(_iv);

            var encryptor = rj.CreateEncryptor(key, IV);

            var msEncrypt = new MemoryStream();
            var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);

            var toEncrypt = Encoding.ASCII.GetBytes(sToEncrypt);

            csEncrypt.Write(toEncrypt, 0, toEncrypt.Length);
            csEncrypt.FlushFinalBlock();

            var encrypted = msEncrypt.ToArray();

            return (Convert.ToBase64String(encrypted));
        }
    }
}
