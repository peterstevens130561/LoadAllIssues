using LoadAllIssues.Logic;
using LoadAllIssues.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadAllIssues.Services
{
    public class RulesSearchService  : SonarQubePagedServiceBase<Rule, RulesSearchPage>
    {
        private readonly SonarQubePagedServiceBase<Rule,RulesSearchPage> restGetService;

        public RulesSearchService(RestGetter restGetter) : base(restGetter,"rules/search")
        { 
        }

        public RulesSearchService SetRepositories(string repositories)
        {
            SetParameter("repositories", repositories);
            return this;
        }

    }

    public class RulesSearchPage : PageBase<Rule>
    {
        public override IList<Rule> Items
        {
            get
            {
                return Rules;
            }
        }

        public IList<Rule> Rules { get; set; }
    }
}
