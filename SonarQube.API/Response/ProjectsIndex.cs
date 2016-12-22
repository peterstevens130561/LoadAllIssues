using PeterSoft.SonarQubeConnector.Models;
using System.Collections.Generic;


namespace PeterSoft.SonarQubeConnector.API.Response
{
    public class ProjectsIndex
    {
        public IList<Project> Projects { get; set; }
    }
}
