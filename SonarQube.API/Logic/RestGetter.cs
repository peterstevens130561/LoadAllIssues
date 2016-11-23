using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SonarQube.API.Logic { 
    public class RestGetter : IRestGetter
    {
        private string url;
        private string path;
        private readonly WebClient webClient;
        public RestGetter(WebClient webClient)
        {
            this.webClient = webClient;
        }

        public IRestGetter SetPath(string path)
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
                    String result = webClient.DownloadString(new Uri(query));
                    return JsonConvert.DeserializeObject<T>(result);
                } catch (WebException e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
       
        }
    }
}
