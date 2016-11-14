using LoadAllIssues.Logic;
using LoadAllIssues.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadAllIssues.Services
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
