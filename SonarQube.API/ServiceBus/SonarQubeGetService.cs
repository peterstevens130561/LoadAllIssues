using PeterSoft.SonarQubeConnector.API.Logic;
using PeterSoft.SonarQubeConnector.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeterSoft.SonarQubeConnector.Services
{
    class QueryService <T>  : IQueryService<T> 
    {
        private readonly string path;
        private readonly RestClient restGetter;
        private IRestParameters parameters;

        public QueryService(RestClient restGetter,string path, IRestParameters parameters)
        {
            this.restGetter = restGetter;
            this.path = path;
            this.parameters = parameters;
        }

        public IRestParameters Parameters { get; }


        public T Execute()
        {
            return restGetter.SetPath(path).Execute<T>(parameters);
        }
    }
}
