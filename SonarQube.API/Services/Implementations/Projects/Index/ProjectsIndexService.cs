
using PeterSoft.SonarQube.Connector.Client;
using PeterSoft.SonarQube.Connector.Models;
using System.Collections.Generic;

namespace PeterSoft.SonarQube.Connector.Services
{
    internal class ProjectsIndexService: ServiceBase<IList<Project>>, IProjectsIndexService
    {

        public ProjectsIndexService(RestClient restGetter, IRestParameters parameters): base(restGetter, parameters,"projects/index") { }

        public IProjectsIndexService SetKey(string projectKey)
        {
            SetParameter(@"key", projectKey);
            return this;
        }
    }
}
