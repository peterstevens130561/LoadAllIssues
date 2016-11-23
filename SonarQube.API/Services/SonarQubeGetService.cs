using SonarQube.API.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonarQube.API.Services
{
    class SonarQubeGetService <T,V>  : ISonarQubeGetService<T,V> where V: IRestParameters
    {
        private readonly string path;
        private readonly RestGetter restGetter;
        private V parameters;

        public SonarQubeGetService(RestGetter restGetter,string path, V parameters)
        {
            this.restGetter = restGetter;
            this.path = path;
            this.parameters = parameters;
        }

        public V Parameters { get; }


        public T Execute()
        {
            return restGetter.SetPath(path).Execute<T>(parameters);
        }
    }
}
