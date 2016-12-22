using PeterSoft.SonarQubeConnector.Models;
using System.Collections.Generic;

namespace PeterSoft.SonarQubeConnector.Services
{
    public interface IIssuesSearchService : IService<IList<Issue>>
    {
        IIssuesSearchService SetProjectKeys(string projectKeys);
        IIssuesSearchService SetStatuses(string statuses);
    }
}