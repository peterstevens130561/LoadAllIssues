using SonarQube.API.Model;
using System.Collections.Generic;

namespace SonarQube.API.Services
{
    public interface IIssuesSearchService
    {
        IIssuesSearchService SetProjectKeys(string projectKeys);
        IIssuesSearchService SetStatuses(string statuses);
        IList<Issue> Execute();
    }
}