using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PeterSoft.SonarQubeConnector.API.Logic { 
    internal class RestClient : IRestClient
    {
        private string url;
        private string path;
        private string result;
        private readonly WebClient webClient;
        public RestClient(WebClient webClient)
        {
            this.webClient = webClient;
        }

        public IRestClient SetPath(string path)
        {
            this.path = path;
            return this;
        }

        public void Connect(string url, string  username, string password)
        {
            this.url = url;
            webClient.UseDefaultCredentials = false;
            webClient.Credentials = new NetworkCredential(username, password);
        }

        public T Execute<T>(IRestParameters parameters) 
        {
                String query = url + "/api/" + path + "?format=json" + parameters.Build();
                try
                {
                    result = webClient.DownloadString(new Uri(query));
                    return JsonConvert.DeserializeObject<T>(result);
                } catch (WebException e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
       
        }

        public void Connect(ICredentials credentials)
        {
            Connect(credentials.Url, credentials.Username, credentials.Password);
        }

        public void Post(IRestParameters parameters)
        {
            string query = url + "/api/" + path  + parameters.Build();
            byte[]  resultBytes = webClient.UploadData(url, "POST", System.Text.Encoding.ASCII.GetBytes(query));
            result= System.Text.Encoding.ASCII.GetString(resultBytes);
            if(!"OK".Equals(result))
            {
                throw new ArgumentOutOfRangeException(result);
            }
        }

        public T  GetPostResult<T>()
        {
            return JsonConvert.DeserializeObject<T>(result);
        }
    }
}
