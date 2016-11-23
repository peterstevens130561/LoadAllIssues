
using SonarQube.API.Logic;
using SonarQube.API.Model;
using SonarQube.API.Response;
using System.Collections.Generic;


namespace SonarQube.API.Services
{
    public class IssuesSearchService : SonarQubePagedServiceBase<Issue, IssuesSearchPage>, IIssuesSearchService

    {

        public IssuesSearchService(RestGetter restGetter) : base(restGetter, "issues/search") { }
  

        public IIssuesSearchService SetProjectKeys(string projectKeys)
        {
            SetParameter("projectKeys", projectKeys);
            return this;
        }

        public IIssuesSearchService SetStatuses(string statuses)
        {
            SetParameter("statuses", statuses);
            return this;
        }

    }

    public class IssuesSearchPage : PageBase<Issue>
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
