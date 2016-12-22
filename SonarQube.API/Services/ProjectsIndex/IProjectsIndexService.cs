using PeterSoft.SonarQubeConnector.Models;
using System.Collections.Generic;

namespace PeterSoft.SonarQubeConnector.Services
{
    public interface IProjectsIndexService : IService<IList<Project>>
    {
        IProjectsIndexService SetKey(string projectKey);
    }
}