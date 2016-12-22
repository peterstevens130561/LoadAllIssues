using PeterSoft.SonarQubeConnector.Models;
using System.Collections.Generic;

namespace PeterSoft.SonarQubeConnector.Services
{
    public interface IRulesSearchService : ISonarQubePagedServiceBase<Rule, RulesSearchPage>
    {
        IRulesSearchService SetRepositories(string repositories);

    }
}