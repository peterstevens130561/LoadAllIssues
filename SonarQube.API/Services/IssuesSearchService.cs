
using SonarQube.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonarQube.API.Services
{
    public class IssuesSearchService : SonarQubePagedServiceBase<Issue, IssuesSearchPage>

    {
        private readonly SonarQubePagedServiceBase<Issue, IssuesSearchPage> restGetService;

        public IssuesSearchService(RestGetter restGetter) : base(restGetter, "issues/search") { }
  

        internal IssuesSearchService SetProjectKeys(string projectKeys)
        {
            SetParameter("projectKeys", projectKeys);
            return this;
        }

        internal IssuesSearchService SetStatuses(string statuses)
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
