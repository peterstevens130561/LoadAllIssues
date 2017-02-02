
using PeterSoft.SonarQubeConnector.API.Logic;
using PeterSoft.SonarQubeConnector.Models;
using System.Collections.Generic;
using System;

namespace PeterSoft.SonarQubeConnector.Services
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
            string value = after.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            SetParameter(@"createdAfter", value);
            return this;
        }

        public IIssuesSearchService SetSeverities(string severities)
        {
            SetParameter(@"severities", severities);
            return this;
        }

        public IIssuesSearchService SetCreatedBefore(DateTime before)
        {
            string value = before.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            SetParameter(@"createdBefore", value);
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
