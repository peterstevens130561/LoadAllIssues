using PeterSoft.SonarQube.Connector.Models;
using System.Collections.Generic;

namespace PeterSoft.SonarQube.Connector.Services
{
    public interface IProjectsIndexService : IExecuteService<IList<Project>>
    {
        IProjectsIndexService SetKey(string projectKey);
    }
}