
using PeterSoft.SonarQubeConnector.API.Logic;
using PeterSoft.SonarQubeConnector.Models;
using System.Collections.Generic;

namespace PeterSoft.SonarQubeConnector.Services
{
    internal class ProjectsIndexService: ServiceBase<IList<Project>>, IProjectsIndexService
    {

        public ProjectsIndexService(RestClient restGetter, IRestParameters parameters): base(restGetter, "projects/index") { }

        public IProjectsIndexService SetKey(string projectKey)
        {
            SetParameter("projectKey", projectKey);
            return this;
        }
    }
}
