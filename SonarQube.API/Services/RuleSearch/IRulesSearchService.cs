using PeterSoft.SonarQubeConnector.Models;
using System.Collections.Generic;

namespace PeterSoft.SonarQubeConnector.Services
{
    public interface IRulesSearchService : IPagedService<Rule, RulesSearchPage>
    {
        IRulesSearchService SetRepositories(string repositories);
        IRulesSearchService SetProfileKey(string profileKey);
    }
}