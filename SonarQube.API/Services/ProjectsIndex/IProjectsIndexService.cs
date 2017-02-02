using PeterSoft.SonarQubeConnector.Models;
using System.Collections.Generic;

namespace PeterSoft.SonarQubeConnector.Services
{
    public interface IProjectsIndexService : IExecuteService<IList<Project>>
    {
        IProjectsIndexService SetKey(string projectKey);
    }
}