using PeterSoft.SonarQube.Connector.Client;
using PeterSoft.SonarQube.Connector.Models;
using PeterSoft.SonarQube.Connector.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeterSoft.SonarQube.Connector.Services
{
    internal class ResourcesService : ServiceBase<IList<Resource>>, IResourcesService
    {
        public ResourcesService(RestClient restQuerier,IRestParameters parameters) : base(restQuerier, parameters, "resources")
        {

        }

        public IResourcesService SetScope(string scope)
        {
            SetParameter(@"scope", scope);
            return this;
        }
    }
}
