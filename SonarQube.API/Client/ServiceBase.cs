using PeterSoft.SonarQubeConnector.API.Logic;
using System;

namespace PeterSoft.SonarQubeConnector.Services
{
    internal class ServiceBase<T> : IService<T>
    {
        protected readonly IRestParameters restParameters = new RestParameters();
        private readonly RestClient restQuerier;
        private string path;
        public ServiceBase(RestClient restQuerier, string path)
        {
            this.restQuerier = restQuerier;
            this.path = path;
        }


        internal string GetParameter(string key)
        {
            return restParameters.GetParameter(key);
        }

        internal void SetParameter(string key, string value)
        {
            restParameters.SetParameter(key,value);
        }

        internal void SetParameter(string key, int value)
        {
            SetParameter(key, value.ToString());
        }

        internal void SetParameter(string key, bool value)
        {
            SetParameter(key, value.ToString());
        }

        public T Execute()
        {
            return restQuerier.SetPath(path).Execute<T>(restParameters);
        }

    }
}