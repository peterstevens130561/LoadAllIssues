using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PeterSoft.SonarQube.Connector.Client {
    internal class RestClient : IRestClient
    {
        private string url;
        private string path;
        private string username;
        private string password;
        internal String Result { get; set; }

        public IRestClient SetPath(string path)
        {
            this.path = path;
            return this;
        }

        public virtual void SetCredentials(string url, string username, string password)
        {
            this.url = url;
            this.username = username;
            this.password = password;
        }


        public string Get(IRestParameters parameters)
        {
            string getUrl = url + @"/api/" + path;
            var values = parameters.Values();
            Task task = GetTask(getUrl, values);
            task.Wait();
            return Result;

        }

        public void SetCredentials(ICredentials credentials)
        {
            SetCredentials(credentials.Url, credentials.Username, credentials.Password);
        }

        public void Post(IRestParameters parameters)
        {
            string posturl = url + @"/api/" + path;
            var values = parameters.Values();
            Task task = PostTask(posturl, values);
            task.Wait();
        }

        public async Task PostTask(string url, IDictionary<String, String> values)
        {

            using (var client = new HttpClient())
            {
                var content = new FormUrlEncodedContent(values);
                string header = username + @":" + password;
                var credentials = Encoding.ASCII.GetBytes(header);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(@"Basic", Convert.ToBase64String(credentials));
                var response = await client.PostAsync(url, content);
                var statusCode = response.StatusCode;
                if (statusCode != HttpStatusCode.OK)
                {
                    throw new WebException(@"Post returned " + statusCode);
                }
                var responseString = response.Content.ReadAsStringAsync();
                responseString.Wait();
                Result = responseString.Result;
            }
        }

        public async Task GetTask(string url, IDictionary<String, String> values)
        {

            using (var client = new HttpClient())
            {
                var content = new FormUrlEncodedContent(values);
                string query = content.ReadAsStringAsync().Result;
                string header = username + @":" + password;
                var credentials = Encoding.ASCII.GetBytes(header);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(@"Basic", Convert.ToBase64String(credentials));
                var response = await client.GetAsync(url + "?" + query);
                var statusCode = response.StatusCode;
                if (statusCode != HttpStatusCode.OK)
                {
                    throw new WebException(@"Get returned " + statusCode);
                }
                
                var responseString = response.Content.ReadAsStringAsync();
                responseString.Wait();
                Result = responseString.Result;
            }
        }

        public T GetPostResult<T>()
        {
            return JsonConvert.DeserializeObject<T>(Result);
        }
    }
}
