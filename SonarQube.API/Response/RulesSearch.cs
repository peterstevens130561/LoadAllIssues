
using System.Collections.Generic;
using System;
using SonarQube.API.Model;

namespace SonarQube.API.Response
{
    public class RulesSearchPageC  : PageBase<Rule >
    {
        public override IList<Rule> Items
        {
            get
            {
                return Rules;
            }
        }

        public IList<Rule> Rules { get; set; }
    }
}