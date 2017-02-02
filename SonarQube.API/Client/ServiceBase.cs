using Newtonsoft.Json;
using PeterSoft.SonarQubeConnector.API.Logic;
using PeterSoft.SonarQubeConnector.Client;
using System;

namespace PeterSoft.SonarQubeConnector.Services
{
    internal class ServiceBase<T> : ParametersBase, IExecuteService<T>
    {
        private readonly IRestClient restClient;
        private readonly string path;
        public ServiceBase(IRestClient restClient, IRestParameters restParameters, string path): base(restParameters)
        {
            this.restClient = restClient;
            this.path = path;
        }

        public virtual T Execute()
        {
            string result= restClient.SetPath(path).Get(base.Parameters());
            return JsonConvert.DeserializeObject<T>(result);
        }

    }
}