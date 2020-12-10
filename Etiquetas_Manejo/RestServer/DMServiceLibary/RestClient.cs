using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Text;

namespace DMServiceLibrary
{
    public class RestClient
    {
        public enum HttpVerb
        {
            GET,
            POST,
            PUT,
            DELETE
        }

        private string user = null;
        private string pass = null;
        private string encoded = null;

        public string EndPoint { get; set; }
        public HttpVerb Method { get; set; }
        public string ContentType { get; set; }
        public string PostData { get; set; }

        public RestClient()
        {
            EndPoint = "";
            Method = HttpVerb.GET;
            ContentType = "application/json";
            PostData = "";
        }
        public RestClient(string endpoint)
        {
            EndPoint = endpoint;
            Method = HttpVerb.GET;
            ContentType = "application/json";
            PostData = "";
        }
        public RestClient(string endpoint, HttpVerb method)
        {
            EndPoint = endpoint;
            Method = method;
            ContentType = "application/json";
            PostData = "";
        }

        public RestClient(string endpoint, HttpVerb method, string postData)
        {
            EndPoint = endpoint;
            Method = method;
            ContentType = "application/json";
            PostData = postData;
        }

        public void setCredentials(string username, string password)
        {
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                this.user = username;
                this.pass = password;
            }
            else
                throw new Exception("No Credential given!");
        }

        public void setCredentials(string encodedCredential)
        {
            if (!string.IsNullOrEmpty(encodedCredential))
            {
                this.encoded = encodedCredential;
            }
            else
                throw new Exception("No Credential given!");
        }


        public string MakeRequest()
        {
            return MakeRequest("");
        }

        public string MakeRequest(string parameters)
        {
            HttpWebResponse response = null;
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(EndPoint + parameters);

                request.Method = Method.ToString();
                request.ContentLength = 0;
                request.ContentType = ContentType;
                if (!string.IsNullOrEmpty(this.user) && !string.IsNullOrEmpty(this.pass))
                {
                    string cred = this.user + ":" + this.pass;
                    request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(cred));
                }else if (!string.IsNullOrEmpty(this.encoded))
                {
                    request.Headers["Authorization"] = "Basic " + this.encoded;
                }


                if (!string.IsNullOrEmpty(PostData) && (Method == HttpVerb.POST || Method == HttpVerb.PUT))
                {
                    var bytes = Encoding.UTF8.GetBytes(PostData);
                    request.ContentLength = bytes.Length;

                    using (var writeStream = request.GetRequestStream())
                    {
                        writeStream.Write(bytes, 0, bytes.Length);
                    }
                }
                
                
                using ( response = (HttpWebResponse)request.GetResponse())
                {
                    var responseValue = string.Empty;

                    if ((response.StatusCode != HttpStatusCode.OK) && (response.StatusCode != HttpStatusCode.Created))
                    {
                        var message = String.Format("Request failed. Received HTTP {0}", response.StatusCode);
                        throw new ApplicationException(message);
                    }

                    // grab the response
                    using (var responseStream = response.GetResponseStream())
                    {
                        if (responseStream != null)
                            using (var reader = new System.IO.StreamReader(responseStream))
                            {
                                responseValue = reader.ReadToEnd();
                            }
                    }

                    return responseValue;
                }
            }
            catch (Exception  ex)
            {
                if (ex is WebException)
                {
                    var resp = new StreamReader(((WebException)ex).Response.GetResponseStream()).ReadToEnd();
                    throw new WebException(resp);
                } else
                {
                    throw new Exception(ex.Message);
                }
                
            }
        }

    } // class

}
