using PeterSoft.SonarQubeConnector.Models;
using System.Collections.Generic;

namespace PeterSoft.SonarQubeConnector.Services
{
    public interface IIssuesSearchService
    {
        IIssuesSearchService SetProjectKeys(string projectKeys);
        IIssuesSearchService SetStatuses(string statuses);
        IList<Issue> Execute();
    }
}