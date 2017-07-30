
using PeterSoft.SonarQube.Connector.Client;
using PeterSoft.SonarQube.Connector.Models;

namespace PeterSoft.SonarQube.Connector.Services
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
