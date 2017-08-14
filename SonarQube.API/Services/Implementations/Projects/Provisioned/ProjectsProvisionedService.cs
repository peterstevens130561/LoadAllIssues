
using PeterSoft.SonarQube.Connector.Client;
using PeterSoft.SonarQube.Connector.Models;
using System.Collections.Generic;


namespace PeterSoft.SonarQube.Connector.Services
{
    internal class ProjectsProvisionedService : PagedServiceBase<VerboseProject, ProjectsProvisionedPage>, IProjectsProvisionedService

    {

        public ProjectsProvisionedService(IRestClient restGetter,IRestParameters parameters) : base(restGetter, parameters, "custom_measures/search") { }
  


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
