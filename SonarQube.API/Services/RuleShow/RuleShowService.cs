
using PeterSoft.SonarQubeConnector.API.Logic;
using PeterSoft.SonarQubeConnector.API.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeterSoft.SonarQubeConnector.Services
{
    //SonarQubeServiceBase<RulesShow>,IRulesShowService
    internal class RulesShowService : SonarQubeServiceBase<RulesShow>, IRulesShowService
    {


        public RulesShowService(RestClient restGetter): base(restGetter, "rules/show")
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
