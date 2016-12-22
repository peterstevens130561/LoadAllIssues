using PeterSoft.SonarQubeConnector.API.Response;
using System;

namespace PeterSoft.SonarQubeConnector.Services
{
    public interface IRulesShowService
    {
        IRulesShowService SetKey(string key);
        IRulesShowService SetActives(bool show);
        RulesShow Execute();
    }
}