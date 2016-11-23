
using SonarQube.API.Logic;
using SonarQube.API.Model;
using SonarQube.API.Response;
using System.Collections.Generic;


namespace SonarQube.API.Services
{
    public class RulesSearchService  : SonarQubePagedServiceBase<Rule, RulesSearchPage>
    {

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
