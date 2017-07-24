
using PeterSoft.SonarQube.Connector.API.Logic;
using PeterSoft.SonarQube.Connector.Models;
using System.Collections.Generic;
using System;

namespace PeterSoft.SonarQube.Connector.Services
{
    internal class IssuesSearchService : PagedServiceBase<Issue, IssuesSearchPage>, IIssuesSearchService

    {

        public IssuesSearchService(IRestClient restGetter,IRestParameters parameters) : base(restGetter, parameters, "issues/search") { }
  

        public IIssuesSearchService SetProjectKeys(string projectKeys)
        {
            SetParameter(@"projectKeys", projectKeys);
            return this;
        }

        public IIssuesSearchService SetStatuses(string statuses)
        {
            SetParameter(@"statuses", statuses);
            return this;
        }

        public IIssuesSearchService SetRules(string rules)
        {
            SetParameter(@"rules", rules);
            return this;
        }

        public IIssuesSearchService SetCreatedAfter(DateTimeOffset after)
        {
            SetIsoDateParameter(@"createdAfter", after);
            return this;
        }

        public IIssuesSearchService SetSeverities(string severities)
        {
            SetParameter(@"severities", severities);
            return this;
        }

        public IIssuesSearchService SetCreatedBefore(DateTime before)
        {
            SetIsoDateParameter(@"createdBefore", before);
            return this;
        }

        public IIssuesSearchService SetCreatedAt(DateTime before)
        {
            SetIsoDateParameter(@"createdAt", before);
            return this;
        }

    }

    public class IssuesSearchPage : Page<Issue>
    {

        public IList<Issue> Issues { get; set; }

        public override IList<Issue> Items
        {
            get
            {
                return Issues;
            }
        }
    }
}
