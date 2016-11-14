
using SonarQube.API.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonarQube.API.Services
{
    class ProjectsIndexService: SonarQubeServiceBase<ProjectsIndex>
    {

        public ProjectsIndexService(RestGetter restGetter): base(restGetter, "projects/index") { }
       
        public ProjectsIndexService SetKey(string projectKey)
        {
            SetParameter("key", projectKey);
            return this;
        }

    }
}
