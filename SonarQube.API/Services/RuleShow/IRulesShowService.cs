
using PeterSoft.SonarQubeConnector.Models;
using System;

namespace PeterSoft.SonarQubeConnector.Services
{
    public interface IRulesShowService : IExecuteService<RulesShow>
    {
        IRulesShowService SetKey(string key);
        IRulesShowService SetActives(bool show);

    }
}