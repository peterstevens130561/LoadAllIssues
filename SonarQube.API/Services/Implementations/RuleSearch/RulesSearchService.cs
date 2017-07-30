
using PeterSoft.SonarQube.Connector.Client;
using PeterSoft.SonarQube.Connector.Models;
using System.Collections.Generic;
using System;

namespace PeterSoft.SonarQube.Connector.Services
{
    internal class RulesSearchService  : PagedServiceBase<Rule, RulesSearchPage>, IRulesSearchService
    {

        public RulesSearchService(RestClient restGetter,RestParameters restParameters) : base(restGetter,restParameters,"rules/search")
        { 
        }

        public IRulesSearchService SetProfileKey(string profileKey)
        {
            SetParameter("qprofile", profileKey);
            return this;
        }

        public IRulesSearchService SetRepositories(string repositories)
        {
            SetParameter("repositories", repositories);
            return this;
        }

    }

    public class RulesSearchPage : Page<Rule>
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
