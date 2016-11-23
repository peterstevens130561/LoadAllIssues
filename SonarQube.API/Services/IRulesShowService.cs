using SonarQube.API.Response;
using System;

namespace SonarQube.API.Services
{
    public interface IRulesShowService
    {
        IRulesShowService SetKey(string key);
        IRulesShowService SetActives(bool show);
        RulesShow Execute();
    }
}