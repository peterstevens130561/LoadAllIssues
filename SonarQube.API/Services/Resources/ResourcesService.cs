using PeterSoft.SonarQubeConnector.API.Logic;
using PeterSoft.SonarQubeConnector.Models;
using PeterSoft.SonarQubeConnector.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeterSoft.SonarQubeConnector.Services
{
    internal class ResourcesService : ServiceBase<IList<Resource>>, IResourcesService
    {
        public ResourcesService(RestClient restQuerier,IRestParameters parameters) : base(restQuerier, "resources")
        {

        }

        public IResourcesService SetScope(string scope)
        {
            SetParameter(@"scope", scope);
            return this;
        }
    }
}
