using System;
using LoadAllIssues.Logic;
using LoadAllIssues.Model;
using LoadAllIssues.Services;

namespace SonarQube.API.Logic
{
    public class SonarQubeServiceBase<T> : ISonarQubeService<T>
    {
        protected readonly IRestParameters restParameters = new RestParameters();
        private readonly RestGetter restQuerier;
        private string path;
        public SonarQubeServiceBase(RestGetter restQuerier, string path)
        {
            this.restQuerier = restQuerier;
            this.path = path;
        }


        internal string GetParameter(string key)
        {
            return restParameters.Get(key);
        }

        internal void SetParameter(string key, string value)
        {
            restParameters.Add(key,value);
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