using PeterSoft.SonarQubeConnector.Models;
using System;
using System.Collections.Generic;

namespace PeterSoft.SonarQubeConnector.Services
{
    public interface IIssuesSearchService : IExecuteService<IList<Issue>>
    {
        IIssuesSearchService SetProjectKeys(string projectKeys);
        IIssuesSearchService SetStatuses(string statuses);
        IIssuesSearchService SetRules(string rules);
        IIssuesSearchService SetCreatedAfter(DateTimeOffset after);

        /// <summary>
        /// Retrieve only the comma seperated severities 
        /// INFO, MINOR,MAJOR,CRITICAL,BLOCKER
        /// </summary>
        /// <param name="severities">string</param>
        /// <returns>this</returns>
        IIssuesSearchService SetSeverities(string severities);
        IIssuesSearchService SetCreatedBefore(DateTime before);
    }
}