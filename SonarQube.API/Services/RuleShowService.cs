
using SonarQube.API.Logic;
using SonarQube.API.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonarQube.API.Services
{
    public class RulesShowService : SonarQubeServiceBase<RulesShow>,IRulesShowService
    {


        public RulesShowService(RestGetter restGetter): base(restGetter, "rules/show")
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
