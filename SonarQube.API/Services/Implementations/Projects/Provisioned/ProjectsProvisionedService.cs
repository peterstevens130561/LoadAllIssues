
using PeterSoft.SonarQube.Connector.Client;
using PeterSoft.SonarQube.Connector.Models;
using System.Collections.Generic;
using System;

namespace PeterSoft.SonarQube.Connector.Services
{
    internal class ProjectsProvisionedService : PagedServiceBase<VerboseProject, ProjectsProvisionedPage>, IProjectsProvisionedService

    {

        public ProjectsProvisionedService(IRestClient restGetter,IRestParameters parameters) : base(restGetter, parameters, "custom_measures/search") { }

        public IProjectsProvisionedService SetFilter(string filter)
        {
            SetParameter("q", filter);
            return this;
        }
    }

    public class ProjectsProvisionedPage : Page<VerboseProject>
    {

        public IList<VerboseProject> Projects { get; set; }

        public override IList<VerboseProject> Items
        {
            get
            {
                return Projects;
            }
        }
    }
}
