using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using SonarSNKRS;

public class HTTP
{
    // Fields
    public string LastRedirectUrl = string.Empty;
    public string LastResponse = string.Empty;
    public bool ProxyAlive = false;

    // Methods
    public HTTP(string useragent, string proxy = "")
    {
        ServicePointManager.Expect100Continue = false;
        ServicePointManager.DefaultConnectionLimit = 0x3e8;
        ServicePointManager.CheckCertificateRevocationList = false;
        ServicePointManager.Expect100Continue = false;
        Cookies = new CookieContainer();
        Headers = new WebHeaderCollection();
        UserAgent = useragent;
        Accept = "*/*";
        AutoRedirect = true;
        IncludeHeaderInResponse = true;
        ResponseExceptionString = string.Empty;
        if (!string.IsNullOrEmpty(proxy))
        {
            try
            {
                string[] strArray = proxy.Split(new[] { ':' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    strArray[i] = Regex.Replace(strArray[i], @"\s", "");
                }
                if (strArray.Length >= 2)
                {
                    Proxy = new WebProxy("http://" + strArray[0] + ":" + strArray[1]);
                }
                if (strArray.Length >= 4)
                {
                    Proxy.Credentials = new NetworkCredential(strArray[2], strArray[3]);
                }
            }
            catch (Exception exception)
            {
                //Console.WriteLine("Proxy adding exception" + exception.Message);
            }
        }
    }

    // Properties
    public string Accept { get; set; }

    public bool AutoRedirect { get; set; }

    public CookieContainer Cookies { get; set; }

    public WebHeaderCollection Headers { get; set; }

    public bool IncludeHeaderInResponse { get; set; }

    public HttpStatusCode LastStatusCode { get; set; }

    public WebProxy Proxy { get; set; }

    public string Referer { get; set; }

    public WebException ResponseException { get; set; }

    public string ResponseExceptionString { get; set; }

    public WebHeaderCollection ResponseHeaders { get; set; }

    public string UserAgent { get; set; }

    public string Get(string url, int timeout = 0)
    {
        try
        {
            HttpWebRequest request = NewRequest(url, "GET", "");
            if (timeout != 0)
            {
                request.Timeout = timeout;
            }
            return GetResponse(request);
        }
        catch (WebException exception)
        {
            //Console.WriteLine(exception.Status);
            if (exception.Response != null)
            {
                ResponseExceptionString = new StreamReader(exception.Response.GetResponseStream()).ReadToEnd();
            }
            ResponseException = exception;
        }
        catch (Exception exception2)
        {
            //Console.WriteLine("Exception: " + exception2);
        }
        return string.Empty;
    }

    public bool GetTrueFalse(string url, out string response, int timeout = 0)
    {
        try
        {
            HttpWebRequest request = NewRequest(url, "GET", "");
            if (timeout != 0)
            {
                request.Timeout = timeout;
            }
            response = GetResponse(request);
            return true;
        }
        catch (WebException exception)
        {
            //Console.WriteLine(exception.Status);
            if (exception.Response != null)
            {
                ResponseExceptionString = new StreamReader(exception.Response.GetResponseStream()).ReadToEnd();
                response = ResponseExceptionString;
            }
            else
            {
                response = "Http Error";
            }
            ResponseException = exception;
        }
        catch (Exception exception2)
        {
            ////Console.WriteLine("Exception: " + exception2);
            response = exception2.Message;
        }
        return false;
    }

    public string GetRedirectUrl(string url)
    {
        try
        {
            int num = 0;
            AutoRedirect = false;
            string str = url;
            do
            {
                Get(str);
                if (ResponseHeaders["Location"] != null)
                {
                    str = ResponseHeaders["Location"];
                }
                else
                {
                    break;
                }
                num++;
            } while ((((LastStatusCode == HttpStatusCode.Found) || (LastStatusCode == HttpStatusCode.MovedPermanently)) ||
                      (LastStatusCode == HttpStatusCode.MovedPermanently)) || (num > 5));
            AutoRedirect = true;
            if (num > 5)
            {
                return string.Empty;
            }
            return str;
        }
        catch
        {
            return string.Empty;
        }
    }

    public string GetResponse(HttpWebRequest request)
    {
        byte[] buffer2;
        string str2;
        string str = string.Empty;
        try
        {
            if (ProxyAlive)
            {
                request.Headers.GetType()
                    .GetMethod("AddWithoutValidate", BindingFlags.NonPublic | BindingFlags.Instance)
                    .Invoke(request.Headers, new[] { "Proxy-Connection", "keep-alive" });
            }
            var response = (HttpWebResponse)request.GetResponse();
            if (response.Headers["Location"] != null)
            {
                LastRedirectUrl = response.Headers["Location"];
            }
            ResponseHeaders = response.Headers;
            if (IncludeHeaderInResponse)
            {
                str = ResponseHeaders.ToString();
            }
            LastStatusCode = response.StatusCode;
            if ((response.StatusCode == HttpStatusCode.OK) || (response.StatusCode == HttpStatusCode.BadRequest))
            {
                if (response.Headers.Get("Content-Encoding") == "gzip")
                {
                    buffer2 = Functions.DecompressGZIP(Functions.ReadFully(response.GetResponseStream()));
                    str2 = Encoding.UTF8.GetString(buffer2);
                    str = str + str2;
                }
                else
                {
                    var reader = new StreamReader(response.GetResponseStream());
                    str = str + reader.ReadToEnd();
                }
            }
        }
        catch (WebException exception)
        {
            //Console.WriteLine(exception.Status);
            if (exception.Response != null)
            {
                var response2 = (HttpWebResponse)exception.Response;
                LastStatusCode = response2.StatusCode;
                if (exception.Response.Headers.Get("Content-Encoding") == "gzip")
                {
                    buffer2 = Functions.DecompressGZIP(Functions.ReadFully(exception.Response.GetResponseStream()));
                    str2 = Encoding.UTF8.GetString(buffer2);
                    ResponseExceptionString = string.Empty;
                    ResponseExceptionString = ResponseExceptionString + str2;
                }
                else
                {
                    ResponseExceptionString = new StreamReader(exception.Response.GetResponseStream()).ReadToEnd();
                }
            }
            ResponseException = exception;
        }
        catch (Exception exception2)
        {
            //Console.WriteLine("Exception: " + exception2);
        }
        LastResponse = str;
        return str;
    }

    private HttpWebRequest NewRequest(string url, string method = "GET", string contentType = "")
    {
        var requestUri = new Uri(url);
        var request = (HttpWebRequest)WebRequest.Create(requestUri);
        if (Proxy != null)
        {
            request.Proxy = Proxy;
        }
        request.Method = method;
        request.AllowAutoRedirect = AutoRedirect;
        request.CookieContainer = Cookies;
        request.Headers = Headers;
        request.UserAgent = UserAgent;
        request.Accept = Accept;
        request.Referer = Referer;
        request.ReadWriteTimeout = 0x186a0;
        request.Timeout = 0x186a0;
        if (!string.IsNullOrEmpty(contentType))
        {
            request.ContentType = contentType;
        }
        return request;
    }

    public string Post(string url, string data, string contentType = "application/x-www-form-urlencoded",
        bool keepalive = true, int timeout = 0)
    {
        string str = string.Empty;
        try
        {
            HttpWebRequest request = NewRequest(url, "POST", contentType);
            if (timeout != 0)
            {
                request.Timeout = timeout;
            }
            if (!keepalive)
            {
                request.KeepAlive = false;
            }
            else
            {
                /*ServicePoint servicePoint = request.ServicePoint;
                servicePoint.GetType()
                    .GetProperty("HttpBehaviour", BindingFlags.NonPublic | BindingFlags.Instance)
                    .SetValue(servicePoint, (byte)0, null);
                 * */
            }
            byte[] bytes = new ASCIIEncoding().GetBytes(data);
            request.ContentLength = bytes.Length;
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();
            return GetResponse(request);
        }
        catch (WebException exception)
        {
            Console.WriteLine(exception.Status);
            if (exception.Response != null)
            {
                ResponseExceptionString = new StreamReader(exception.Response.GetResponseStream()).ReadToEnd();
            }
            ResponseException = exception;
        }
        catch (Exception exception2)
        {
            Console.WriteLine("Exception: " + exception2);
        }
        return str;
    }

    public string Put(string url, string data, string contentType = "application/x-www-form-urlencoded",
       bool keepalive = true, int timeout = 0)
    {
        string str = string.Empty;
        try
        {
            HttpWebRequest request = NewRequest(url, "PUT", contentType);
            if (timeout != 0)
            {
                request.Timeout = timeout;
            }
            if (!keepalive)
            {
                request.KeepAlive = false;
            }
            else
            {
                /*ServicePoint servicePoint = request.ServicePoint;
                servicePoint.GetType()
                    .GetProperty("HttpBehaviour", BindingFlags.NonPublic | BindingFlags.Instance)
                    .SetValue(servicePoint, (byte)0, null);
                 * */
            }
            byte[] bytes = new ASCIIEncoding().GetBytes(data);
            request.ContentLength = bytes.Length;
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();
            return GetResponse(request);
        }
        catch (WebException exception)
        {
            Console.WriteLine(exception.Status);
            if (exception.Response != null)
            {
                ResponseExceptionString = new StreamReader(exception.Response.GetResponseStream()).ReadToEnd();
            }
            ResponseException = exception;
        }
        catch (Exception exception2)
        {
            Console.WriteLine("Exception: " + exception2);
        }
        return str;
    }

    
        // Nested Types
        public class TrustAllCertificatePolicy : ICertificatePolicy
        {
            // Methods
            public bool CheckValidationResult(ServicePoint sp, X509Certificate cert, WebRequest req, int problem)
            {
                return true;
            }
        }
    
}