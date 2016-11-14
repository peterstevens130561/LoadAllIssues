
using SonarQube.API.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonarQube.API.Services
{
    class RulesShowService : SonarQubeServiceBase<RulesShow>
    {


        public RulesShowService(RestGetter restGetter): base(restGetter, "rules/show")
        { 
        }

        public RulesShowService SetKey(string key)
        {
            SetParameter("key", key);
            return this;
        }

        public RulesShowService SetActives(Boolean show)
        {
            SetParameter("actives", show);
            return this;
        }

    }
}
