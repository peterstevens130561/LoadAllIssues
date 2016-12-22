
using PeterSoft.SonarQubeConnector.API.Logic;
using PeterSoft.SonarQubeConnector.Models;
using System.Collections.Generic;


namespace PeterSoft.SonarQubeConnector.Services
{
    internal class IssuesSearchService : PagedServiceBase<Issue, IssuesSearchPage>, IIssuesSearchService

    {

        public IssuesSearchService(RestClient restGetter,IRestParameters parameters) : base(restGetter, "issues/search") { }
  

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
