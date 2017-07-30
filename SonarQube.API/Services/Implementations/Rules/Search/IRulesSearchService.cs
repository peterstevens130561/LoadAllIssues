using PeterSoft.SonarQube.Connector.Models;
using System.Collections.Generic;

namespace PeterSoft.SonarQube.Connector.Services
{
    public interface IRulesSearchService : IPagedService<Rule, RulesSearchPage>
    {
        IRulesSearchService SetRepositories(string repositories);
        IRulesSearchService SetProfileKey(string profileKey);
    }
}