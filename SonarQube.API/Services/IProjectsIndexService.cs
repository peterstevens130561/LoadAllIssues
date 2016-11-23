using SonarQube.API.Model;
using System.Collections.Generic;

namespace SonarQube.API.Services
{
    public interface IProjectsIndexService
    {
        IProjectsIndexService SetKey(string projectKey);

        IList<Project> Execute();
    }
}