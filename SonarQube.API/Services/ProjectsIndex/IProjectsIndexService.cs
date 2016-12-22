using PeterSoft.SonarQubeConnector.Models;
using System.Collections.Generic;

namespace PeterSoft.SonarQubeConnector.Services
{
    public interface IProjectsIndexService
    {
        IProjectsIndexService SetKey(string projectKey);

        IList<Project> Execute();
    }
}