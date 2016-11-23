using SonarQube.API.Model;
using System.Collections.Generic;


namespace SonarQube.API.Response
{
    public class ProjectsIndex
    {
        public IList<Project> Projects { get; set; }
    }
}
