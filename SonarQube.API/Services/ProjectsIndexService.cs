
using SonarQube.API.Logic;
using SonarQube.API.Model;
using SonarQube.API.Response;
using System.Collections.Generic;

namespace SonarQube.API.Services
{
    public class ProjectsIndexService: SonarQubeServiceBase<IList<Project>>,IProjectsIndexService
    {

        public ProjectsIndexService(RestGetter restGetter): base(restGetter, "projects/index") { }
       
        public IProjectsIndexService SetKey(string projectKey)
        {
            SetParameter("key", projectKey);
            return this;
        }

    }
}
