using PeterSoft.SonarQube.Connector.Models;
using System;
using System.Collections.Generic;

namespace PeterSoft.SonarQube.Connector.Services
{
    public interface IIssuesSearchService : IExecuteService<IList<Issue>>
    {
        IIssuesSearchService SetProjectKeys(string projectKeys);
        IIssuesSearchService SetStatuses(string statuses);
        IIssuesSearchService SetRules(string rules);
        /// <summary>
        /// To retrieve issues created after the given date (inclusive). If this parameter is set, createdSince must not be set
        /// </summary>
        /// <param name="after">date</param>
        /// <returns></returns>
        IIssuesSearchService SetCreatedAfter(DateTimeOffset after);

        /// <summary>
        /// Retrieve only the comma seperated severities 
        /// INFO, MINOR,MAJOR,CRITICAL,BLOCKER
        /// </summary>
        /// <param name="severities">string</param>
        /// <returns>this</returns>
        IIssuesSearchService SetSeverities(string severities);
        /// <summary>
        /// To retrieve issues created before the given date (exclusive).
        /// </summary>
        /// <param name="before">date</param>
        /// <returns></returns>
        IIssuesSearchService SetCreatedBefore(DateTime before);
        /// <summary>
        /// To retrieve issues created in a specific analysis,
        /// </summary>
        /// <param name="at">date</param>
        /// <returns></returns>
        IIssuesSearchService SetCreatedAt(DateTime at);
    }
}