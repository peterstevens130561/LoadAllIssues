﻿using Newtonsoft.Json;
using PeterSoft.SonarQube.Connector.Client;
using PeterSoft.SonarQube.Connector.Client;
using System;

namespace PeterSoft.SonarQube.Connector.Services
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
            restClient.SetPath(path);
            string result = restClient.Get(base.Parameters());
            result = TransFormResponse(result);
            return JsonConvert.DeserializeObject<T>(result);
        }

        virtual protected string TransFormResponse(string response)
        {
            return response;
        }

    }
}