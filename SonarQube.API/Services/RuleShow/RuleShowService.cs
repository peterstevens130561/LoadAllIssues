
using PeterSoft.SonarQubeConnector.API.Logic;
using PeterSoft.SonarQubeConnector.Models;

namespace PeterSoft.SonarQubeConnector.Services
{
    //SonarQubeServiceBase<RulesShow>,IRulesShowService
    internal class RulesShowService : ServiceBase<RulesShow>, IRulesShowService
    {


        public RulesShowService(RestClient restGetter,RestParameters restParameters): base(restGetter, restParameters, "rules/show")
        { 
        }

        public IRulesShowService SetKey(string key)
        {
            SetParameter("key", key);
            return this;
        }

        public IRulesShowService SetActives(bool show)
        {
            SetParameter("actives", show);
            return this;
        }

    }
}
