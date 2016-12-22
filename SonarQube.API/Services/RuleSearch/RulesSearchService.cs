
using PeterSoft.SonarQubeConnector.API.Logic;
using PeterSoft.SonarQubeConnector.Models;
using PeterSoft.SonarQubeConnector.API.Response;
using System.Collections.Generic;


namespace PeterSoft.SonarQubeConnector.Services
{
    internal class RulesSearchService  : SonarQubePagedServiceBase<Rule, RulesSearchPage>, IRulesSearchService
    {

        public RulesSearchService(RestClient restGetter) : base(restGetter,"rules/search")
        { 
        }

        public IRulesSearchService SetRepositories(string repositories)
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
