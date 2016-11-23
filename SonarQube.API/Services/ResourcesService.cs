using SonarQube.API.Logic;
using SonarQube.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonarQube.API.Services
{
    internal class ResourcesService : SonarQubeGetService<IList<Resource>,IResourcesParameters>, IResourcesService
    {
        public ResourcesService(RestGetter restQuerier) : base(restQuerier, "resources",new ResourcesParameters())
        {
        }
    }
}
