
using PeterSoft.SonarQube.Connector.Models;
using System;

namespace PeterSoft.SonarQube.Connector.Services
{
    public interface IRulesShowService : IExecuteService<RulesShow>
    {
        IRulesShowService SetKey(string key);
        IRulesShowService SetActives(bool show);

    }
}