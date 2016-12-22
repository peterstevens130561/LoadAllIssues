
using PeterSoft.SonarQubeConnector.Models;
using System;

namespace PeterSoft.SonarQubeConnector.Services
{
    public interface IRulesShowService : IService<RulesShow>
    {
        IRulesShowService SetKey(string key);
        IRulesShowService SetActives(bool show);

    }
}